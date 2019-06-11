import React, { useState } from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";
import TablePagination from "../common/TablePagination";

const RegistrationList = ({ registrations }) => {
  const [currentPage, setCurrentPage] = useState(0);

  const dataSet = registrations.length === 0 ? [] : registrations;

  let pageSize = 10;
  let pagesCount = Math.ceil(dataSet.length / pageSize);

  const handleClick = (e, index) => {
    e.preventDefault();
    setCurrentPage(index);
  };

  const handleBackClick = e => {
    let index = currentPage - 1;
    handleClick(e, index);
  };

  const handleForwardClick = e => {
    let index = currentPage + 1;
    handleClick(e, index);
  };

  return (
    <React.Fragment>
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
          {registrations
            .slice(currentPage * pageSize, (currentPage + 1) * pageSize)
            .map(registration => {
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
      <TablePagination
        pageSize={pageSize}
        pagesCount={pagesCount}
        currentPage={currentPage}
        handleClick={handleClick}
        handleBackClick={handleBackClick}
        handleForwardClick={handleForwardClick}
      />
    </React.Fragment>
  );
};

RegistrationList.propTypes = {
  registrations: PropTypes.array.isRequired
};

export default RegistrationList;
