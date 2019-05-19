import React from "react";
import PropTypes from "prop-types";
import LabelForInput from "./LabelForInput";
import TextInputAlone from "./TextInputAlone";

const TextInput = ({ name, label, onChange, placeholder, value, error }) => {
  let wrapperClass = "form-group col-md-12 offset-md-1 row";
  if (error && error.length > 0) {
    wrapperClass += " " + "has-error";
  }

  return (
    <div className={wrapperClass}>
      <LabelForInput name={name} label={label} className={"col-md-3"} />
      <TextInputAlone
        name={name}
        placeholder={placeholder}
        value={value}
        onChange={onChange}
        className={"field col-md-6"}
        error={error}
        inputType={"input"}
      />
    </div>
  );
};

TextInput.propTypes = {
  name: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
  placeholder: PropTypes.string,
  value: PropTypes.oneOfType([
    PropTypes.string,
    PropTypes.number,
    PropTypes.null
  ]),
  error: PropTypes.string
};

export default TextInput;
