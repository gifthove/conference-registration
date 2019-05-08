import React from "react";
import PropTypes from "prop-types";
import TextInput from "../common/TextInput";

const AttendeeForm = ({
  attendee,
  onSave,
  onChange,
  saving = false,
  errors = {}
}) => {
  return (
    <form onSubmit={onSave}>
      <h2>{attendee.id ? "Edit" : "Add"} Attendee</h2>
      {errors.onSave && (
        <div className="alert alert-danger" role="alert">
          {errors.onSave}
        </div>
      )}
      <TextInput
        name="title"
        label="Title"
        value={attendee.title}
        onChange={onChange}
        error={errors.title}
      />

      <TextInput
        name="firstName"
        label="FirstName"
        value={attendee.firstName}
        onChange={onChange}
        error={errors.firstName}
      />

      <TextInput
        name="lastName"
        label="LastName"
        value={attendee.lastName}
        onChange={onChange}
        error={errors.lastName}
      />

      <TextInput
        name="category"
        label="Category"
        value={attendee.category}
        onChange={onChange}
        error={errors.category}
      />

      <button type="submit" disabled={saving} className="btn btn-primary">
        {saving ? "Saving..." : "Save"}
      </button>
    </form>
  );
};

AttendeeForm.propTypes = {
  attendee: PropTypes.object.isRequired,
  errors: PropTypes.object,
  onSave: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
  saving: PropTypes.bool
};

export default AttendeeForm;
