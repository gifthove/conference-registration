import React from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";
import TablePagination from "../common/TablePagination";

const RegistrationList = ({
  registrations,
  currentPage,
  pagesCount,
  handlePageClick,
  handlePreviousClick,
  handleNextClick
}) => {
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
  registrations: PropTypes.array.isRequired,
  pagesCount: PropTypes.number.isRequired,
  currentPage: PropTypes.number.isRequired,
  pageSize: PropTypes.number.isRequired,
  handlePageClick: PropTypes.func.isRequired,
  handlePreviousClick: PropTypes.func.isRequired,
  handleNextClick: PropTypes.func.isRequired
};

export default RegistrationList;
