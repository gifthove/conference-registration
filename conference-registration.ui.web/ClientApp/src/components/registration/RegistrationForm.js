import React from "react";
import PropTypes from "prop-types";
import TextInput from "../common/TextInput";
import SelectInput from "../common/SelectInput";
import { Titles } from "../../dataModels/models";
import LabelForInput from "../common/LabelForInput";
import TextInputAlone from "../common/TextInputAlone";
import { Countries } from "../../tools/Countries";

const RegistrationForm = ({
  registration,
  onSave,
  onChange,
  saving = false,
  errors = {}
}) => {
  return (
    <form onSubmit={onSave}>
      <br />
      <p className="offset-md-1">
        Please {registration.id ? "edit" : "book for"} your conference by ing
        the form below, specify the expected number joining the conference.
      </p>
      <br />
      {errors.onSave && (
        <div className="alert alert-danger" role="alert">
          {errors.onSave}
        </div>
      )}
      <SelectInput
        name="title"
        label="Title"
        onChange={onChange}
        defaultOption={"Select a Title"}
        value={registration.attendee.title}
        error={errors.title}
        options={Titles}
      />
      <div className="form-group col-md-12 offset-md-1 row">
        <LabelForInput
          name="firstName"
          label="Full Name"
          className="col-md-3"
        />
        <TextInputAlone
          name="firstName"
          value={registration.attendee.firstName}
          onChange={onChange}
          error={errors.firstName}
          placeholder="First Name"
          className="field col-md-3"
          inputType={"input"}
        />
        <TextInputAlone
          name="lastName"
          value={registration.attendee.lastName}
          onChange={onChange}
          error={errors.lastName}
          placeholder="Family Name"
          className="field col-md-3"
          inputType={"input"}
        />
      </div>

      <div className="form-group col-md-12 offset-md-1 row">
        <LabelForInput
          name="postion"
          label="Position & Department"
          className="col-md-3"
        />
        <TextInputAlone
          name="position"
          value={registration.attendee.position}
          onChange={onChange}
          error={errors.position}
          placeholder="Position"
          className="field col-md-3"
          inputType={"input"}
        />
        <TextInputAlone
          name="department"
          value={registration.attendee.department}
          onChange={onChange}
          error={errors.department}
          placeholder="Department"
          className="field col-md-3"
          inputType={"input"}
        />
      </div>
      <TextInput
        name="company"
        label="Company"
        value={registration.attendee.company}
        onChange={onChange}
        error={errors.company}
      />

      <TextInput
        name="addressLine1"
        label="Address"
        value={registration.attendee.addressLine1}
        onChange={onChange}
        error={errors.addressLine1}
      />

      <TextInput
        name="addressLine2"
        label=""
        value={registration.attendee.addressLine2}
        onChange={onChange}
        error={errors.addressLine2}
      />
      <div className="form-group col-md-12 offset-md-1 row">
        <LabelForInput
          name="postalcode"
          label="Postal code & City"
          className="col-md-3"
        />
        <TextInputAlone
          name="postalcode"
          value={registration.attendee.postalcode}
          onChange={onChange}
          error={errors.postalcode}
          placeholder="Postal code"
          className="field col-md-3"
          inputType={"input"}
        />
        <TextInputAlone
          name="city"
          value={registration.attendee.city}
          onChange={onChange}
          error={errors.city}
          placeholder="City"
          className="field col-md-3"
          inputType={"input"}
        />
      </div>

      <SelectInput
        name="country"
        label="Country"
        onChange={onChange}
        defaultOption={"Select a Country"}
        value={registration.attendee.country}
        error={errors.country}
        options={Countries}
      />
      <TextInput
        name="workphone"
        label="Work Phone"
        value={registration.attendee.workphone}
        onChange={onChange}
        error={errors.workphone}
      />

      <TextInput
        name="mobilePhone"
        label="Mobile Phone"
        value={registration.attendee.mobilePhone}
        onChange={onChange}
        error={errors.mobilePhone}
      />

      <TextInput
        name="email"
        label="Email"
        value={registration.attendee.email}
        onChange={onChange}
        error={errors.email}
      />
      <TextInput
        name="fax"
        label="Fax"
        value={registration.attendee.fax}
        onChange={onChange}
        error={errors.fax}
      />

      <TextInputAlone
        name="conferenceId"
        label="conferenceId"
        value={registration.conferenceId}
        onChange={onChange}
        error={errors.conferenceId}
        placeholder="conferenceId"
        className="field col-md-3"
        inputType={"hidden"}
      />

      <div className="offset-md-5">
        <button type="submit" disabled={saving} className="btn btn-primary">
          {saving ? "Submitting..." : "Submit"}
        </button>
      </div>
    </form>
  );
};

RegistrationForm.propTypes = {
  registration: PropTypes.object.isRequired,
  errors: PropTypes.object,
  onSave: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
  saving: PropTypes.bool
};

export default RegistrationForm;
