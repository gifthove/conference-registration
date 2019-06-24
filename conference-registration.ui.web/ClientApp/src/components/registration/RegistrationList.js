import React, { useState } from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";
import TablePagination from "../common/TablePagination";

const RegistrationList = ({ registrations }) => {
  const [currentPage, setCurrentPage] = useState(0);

  const dataSet = registrations.length === 0 ? [] : registrations;

  const pageSize = 10;
  const pagesCount = Math.ceil(dataSet.length / pageSize);

  const handlePageClick = (e, index) => {
    e.preventDefault();
    setCurrentPage(index);
  };

  const handlePreviousClick = e => {
    e.preventDefault();
    const index = currentPage - 1;
    setCurrentPage(index);
  };

  const handleNextClick = e => {
    e.preventDefault();
    const index = currentPage + 1;
    setCurrentPage(index);
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
        pagesCount={pagesCount}
        currentPage={currentPage}
        handlePageClick={handlePageClick}
        handlePreviousClick={handlePreviousClick}
        handleNextClick={handleNextClick}
      />
    </React.Fragment>
  );
};

RegistrationList.propTypes = {
  registrations: PropTypes.array.isRequired
};

export default RegistrationList;
