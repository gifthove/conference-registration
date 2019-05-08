import React, { useEffect, useState } from "react"; // This has been modified to pull in useEffect hook
import { connect } from "react-redux";
import * as attendeeActions from "../../redux/actions/attendeeActions";
import PropTypes from "prop-types";
import AttendeeForm from "./AttendeeForm";
import { newAttendee } from "../../tools/mockData";

function ManageAttendeePage({
  attendees,
  loadAttendees,
  saveAttendee,
  history,
  ...props
}) {
  debugger;
  const [attendee, setAttendee] = useState({ ...props.attendee });
  const [errors, setErrors] = useState({});

  // useEffect hook lets us replace componentDidMount
  // Hooks allow us to handle state and side effects in func components
  // Hooks only work with function components
  // useEffect accepts a function that it will call
  // useEffect will rerun everytime the component is rerun
  // The second parameter to the UseEffect is an array of watchable items
  useEffect(() => {
    if (attendees.length === 0) {
      loadAttendees().catch(error => {
        alert("Loading attendees failed" + error);
      });
    }
  }, []);

  function handleChange(event) {
    debugger;
    const { name, value } = event.target;
    setAttendee(prevAttendee => ({
      ...prevAttendee,
      [name]: value
    }));
  }

  function handleSave(event) {
    event.preventDefault();
    saveAttendee(attendee).then(() => {
      history.push("/attendees");
    });
  }
  return (
    <AttendeeForm
      attendee={attendee}
      errors={errors}
      onChange={handleChange}
      onSave={handleSave}
    />
  );
}

ManageAttendeePage.propTypes = {
  attendee: PropTypes.object,
  attendees: PropTypes.array.isRequired,
  loadAttendees: PropTypes.func.isRequired,
  saveAttendee: PropTypes.func.isRequired,
  history: PropTypes.object.isRequired
};

export function getAttendeeById(attendees, id) {
  return attendees.find(attendee => attendee.id == id) || null;
}

// This functions determines what part of the state we expose to our component on props
function mapStateToProps(state, ownProps) {
  const id = ownProps.match.params.id;
  const attendee =
    id && state.attendees.length > 0
      ? getAttendeeById(state.attendees, id)
      : newAttendee;
  return {
    attendee,
    attendees: state.attendees
  };
}

// This functions lets us declare what actions to pass our component on props
const mapDispatchToProps = {
  saveAttendee: attendeeActions.saveAttendee,
  loadAttendees: attendeeActions.loadAttendees
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(ManageAttendeePage);
