import React from "react";
import PropTypes from "prop-types";

const TextInputAlone = ({
  name,
  onChange,
  placeholder,
  value,
  error,
  className,
  inputType
}) => {
  return (
    <div className={className}>
      <input
        type={inputType}
        name={name}
        className="form-control"
        placeholder={placeholder}
        value={value}
        onChange={onChange}
      />
      {error && <div className="alert alert-danger">{error}</div>}
    </div>
  );
};

TextInputAlone.propTypes = {
  name: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
  placeholder: PropTypes.string,
  value: PropTypes.oneOfType([
    PropTypes.string,
    PropTypes.number,
    PropTypes.null
  ]),
  error: PropTypes.string,
  className: PropTypes.string,
  inputType: PropTypes.string
};

export default TextInputAlone;
