import React from "react";
import PropTypes from "prop-types";

const LabelForInput = ({ name, label, className }) => (
  <div className={className}>
    <label htmlFor={name}>{label}</label>
  </div>
);

LabelForInput.propTypes = {
  name: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  className: PropTypes.string.isRequired
};

export default LabelForInput;
