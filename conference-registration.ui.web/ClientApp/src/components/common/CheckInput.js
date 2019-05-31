import React from "react";
import PropTypes from "prop-types";

const CheckInput = ({ name, label, onClick, value, error }) => {
  return (
    <div className="form-group col-md-12 offset-md-1 row">
      <div className="col-md-3">
        {/* <label htmlFor={name}>{label}</label> */}
      </div>
      <div className="field col-md-6">
        {/* Note, value is set here rather than on the option - docs: https://facebook.github.io/react/docs/forms.html */}
        <input
          name={name}
          value={value}
          onClick={onClick}
          className="form-check-input"
          type="checkbox"
        />
        <label className="form-check-label" htmlFor={name}>
          {label}
        </label>
        {error && <div className="alert alert-danger">{error}</div>}
      </div>
    </div>
  );
};

CheckInput.propTypes = {
  name: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  onClick: PropTypes.func.isRequired,
  defaultOption: PropTypes.string,
  value: PropTypes.oneOfType([PropTypes.string, PropTypes.number]),
  error: PropTypes.string,
  options: PropTypes.arrayOf(PropTypes.object)
};

export default CheckInput;
