import React from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

const AttendeeList = ({ attendees }) => (
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
      {attendees.map(attendee => {
        return (
          <tr key={attendee.id}>
            <td>
              <a className="btn btn-light">View</a>
            </td>
            <td>
              <Link to={"/attendee/" + attendee.id}>{attendee.title}</Link>
            </td>
            <td>{attendee.firstName}</td>
            <td>{attendee.lastName}</td>
          </tr>
        );
      })}
    </tbody>
  </table>
);

AttendeeList.propTypes = {
  attendees: PropTypes.array.isRequired
};

export default AttendeeList;
