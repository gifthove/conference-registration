import React from "react";
import { Pagination, PaginationItem, PaginationLink } from "reactstrap";
import PropTypes from "prop-types";

const TablePagination = ({
  pagesCount,
  currentPage,
  handlePageClick,
  handlePreviousClick,
  handleNextClick
}) => (
  <Pagination>
    <PaginationItem disabled={currentPage <= 0}>
      <PaginationLink onClick={handlePreviousClick} previous href="#" />
    </PaginationItem>

    {[...Array(pagesCount)].map((page, i) => (
      <PaginationItem active={i === currentPage} key={i}>
        <PaginationLink onClick={e => handlePageClick(e, i)} href="#">
          {i + 1}
        </PaginationLink>
      </PaginationItem>
    ))}

    <PaginationItem disabled={currentPage >= pagesCount - 1}>
      <PaginationLink onClick={handleNextClick} next href="#" />
    </PaginationItem>
  </Pagination>
);
TablePagination.propTypes = {
  pagesCount: PropTypes.number.isRequired,
  currentPage: PropTypes.number.isRequired,
  handlePageClick: PropTypes.func.isRequired,
  handlePreviousClick: PropTypes.func.isRequired,
  handleNextClick: PropTypes.func.isRequired
};
export default TablePagination;
