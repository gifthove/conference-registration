import React from "react";
import PropTypes from "prop-types";
import TextInput from "../common/TextInput";

const RegistrationForm = ({
  registration,
  onSave,
  onChange,
  saving = false,
  errors = {}
}) => {
  return (
    <form onSubmit={onSave}>
      <h2>{registration.id ? "Edit" : "Add"} Registration</h2>
      {errors.onSave && (
        <div className="alert alert-danger" role="alert">
          {errors.onSave}
        </div>
      )}
      <TextInput
        name="title"
        label="Title"
        value={registration.attendee.title}
        onChange={onChange}
        error={errors.title}
      />

      <TextInput
        name="firstName"
        label="FirstName"
        value={registration.attendee.firstName}
        onChange={onChange}
        error={errors.firstName}
      />

      <TextInput
        name="lastName"
        label="LastName"
        value={registration.attendee.lastName}
        onChange={onChange}
        error={errors.lastName}
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
        label="Address"
        value={registration.attendee.addressLine2}
        onChange={onChange}
        error={errors.addressLine2}
      />

      <TextInput
        name="company"
        label="Company"
        value={registration.attendee.company}
        onChange={onChange}
        error={errors.company}
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
        label="email"
        value={registration.attendee.email}
        onChange={onChange}
        error={errors.email}
      />

      <button type="submit" disabled={saving} className="btn btn-primary">
        {saving ? "Saving..." : "Save"}
      </button>
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
