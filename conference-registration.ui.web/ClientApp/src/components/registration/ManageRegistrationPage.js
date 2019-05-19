import React, { useEffect, useState } from "react"; // This has been modified to pull in useEffect hook
import { connect } from "react-redux";
import * as registrationActions from "../../redux/actions/registrationActions";
import PropTypes from "prop-types";
import RegistrationForm from "./RegistrationForm";
import { newRegistration } from "../../dataModels/models";
import Spinner from "../common/Spinner";
import { toast } from "react-toastify";

function ManageRegistrationPage({
  registrations,
  loadRegistrations,
  saveRegistration,
  history,
  ...props
}) {
  // This is adding the state via useState hook... read more on hooks
  const [registration, setRegistration] = useState({
    ...props.registration,
    attendee: { ...props.registration.attendee }
  });
  const [errors, setErrors] = useState({});
  const [saving, setSaving] = useState(false);

  // useEffect hook lets us replace componentDidMount
  // Hooks allow us to handle state and side effects in func components
  // Hooks only work with function components
  // useEffect accepts a function that it will call
  // useEffect will rerun everytime the component is rerun
  // The second parameter to the UseEffect is an array of watchable items
  useEffect(() => {
    if (registrations.length === 0) {
      loadRegistrations().catch(error => {
        alert("Loading registrations failed" + error);
      });
    }
  }, []);

  function handleChange(event) {
    debugger;
    const { name, value } = event.target;

    setRegistration(prevRegistration => ({
      ...prevRegistration,
      attendee: {
        ...prevRegistration.attendee,
        [name]: value
      }
    }));
  }

  function formIsValid() {
    debugger;
    const {
      attendee: { title, firstName, lastName, addressLine1, mobilePhone, email }
    } = registration;

    const errors = {};

    if (!title) errors.title = "Title is required.";
    if (!firstName) errors.firstName = "FirstName is required.";
    if (!lastName) errors.lastName = "LastName is required.";
    if (!addressLine1) errors.addressLine1 = "AddressLine1 is required.";
    if (!mobilePhone) errors.mobilePhone = "MobilePhone is required.";
    if (!email) errors.email = "Email is required.";

    setErrors(errors);

    //Form is valid if the errors object stil has no properties
    return Object.keys(errors).length === 0;
  }

  function handleSave(event) {
    event.preventDefault();
    debugger;
    // if the form is not valid there is nothing more to do
    if (!formIsValid()) return;

    setSaving(true); //This is setting local state
    saveRegistration(registration)
      .then(() => {
        toast.success("You have successfully registered.");
        history.push("/registrations");
      })
      .catch(error => {
        setSaving(false);
        setErrors({ onSave: error.message });
      });
  }
  return registrations.length === 0 ? (
    <Spinner />
  ) : (
    <RegistrationForm
      registration={registration}
      errors={errors}
      onChange={handleChange}
      onSave={handleSave}
      saving={saving}
    />
  );
}

ManageRegistrationPage.propTypes = {
  registration: PropTypes.object,
  registrations: PropTypes.array.isRequired,
  loadRegistrations: PropTypes.func.isRequired,
  saveRegistration: PropTypes.func.isRequired,
  history: PropTypes.object.isRequired
};

export function getRegistrationById(registrations, id) {
  return registrations.find(registration => registration.id == id) || null;
}

// This functions determines what part of the state we expose to our component on props
function mapStateToProps(state, ownProps) {
  const id = ownProps.match.params.id;
  const registration =
    id && state.registrations.length > 0
      ? getRegistrationById(state.registrations, id)
      : newRegistration;
  return {
    registration,
    registrations: state.registrations
  };
}

// This functions lets us declare what actions to pass our component on props
const mapDispatchToProps = {
  saveRegistration: registrationActions.saveRegistration,
  loadRegistrations: registrationActions.loadRegistrations
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(ManageRegistrationPage);
