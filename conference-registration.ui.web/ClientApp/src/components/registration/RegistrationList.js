import React from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

const RegistrationList = ({ registrations }) => (
  <table className="table">
    <thead>
      <tr>
        <th />
        <th>Title</th>
        <th>Firstname</th>
        <th>Lastname</th>
      </tr>
    </thead>
    <tbody>
      {registrations.map(registration => {
        return (
          <tr key={registration.id}>
            <td>
              <a className="btn btn-light">View</a>
            </td>
            <td>
              <Link to={"/registration/" + registration.id}>
                {registration.attendee.title}
              </Link>
            </td>
            <td>{registration.attendee.firstName}</td>
            <td>{registration.attendee.lastName}</td>
          </tr>
        );
      })}
    </tbody>
  </table>
);

RegistrationList.propTypes = {
  registrations: PropTypes.array.isRequired
};

export default RegistrationList;
