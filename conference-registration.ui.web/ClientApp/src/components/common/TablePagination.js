import React from "react";
import { Pagination, PaginationItem, PaginationLink } from "reactstrap";
import PropTypes from "prop-types";

class TablePagination extends React.Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
      <Pagination aria-label="Page navigation example">
        <PaginationItem disabled={this.props.currentPage <= 0}>
          <PaginationLink
            onClick={this.props.handleBackClick}
            previous
            href="#"
          />
        </PaginationItem>

        {[...Array(this.props.pagesCount)].map((page, i) => (
          <PaginationItem active={i === this.props.currentPage} key={i}>
            <PaginationLink
              onClick={e => this.props.handleClick(e, i)}
              href="#"
            >
              {i + 1}
            </PaginationLink>
          </PaginationItem>
        ))}

        <PaginationItem
          disabled={this.props.currentPage >= this.props.pagesCount - 1}
        >
          <PaginationLink
            onClick={this.props.handleForwardClick}
            next
            href="#"
          />
        </PaginationItem>
      </Pagination>
    );
  }
}
TablePagination.propTypes = {
  pageSize: PropTypes.number.isRequired,
  pagesCount: PropTypes.number.isRequired,
  currentPage: PropTypes.number.isRequired,
  handleClick: PropTypes.func.isRequired,
  handleBackClick: PropTypes.func.isRequired,
  handleForwardClick: PropTypes.func.isRequired
};
export default TablePagination;
