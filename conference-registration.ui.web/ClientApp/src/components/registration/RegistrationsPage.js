import React, { Fragment } from "react";
import { connect } from "react-redux";
import * as registrationActions from "../../redux/actions/registrationActions";
import { bindActionCreators } from "redux";
import PropTypes from "prop-types";
import RegistrationList from "./RegistrationList";
import { Redirect } from "react-router-dom";
import Spinner from "../common/Spinner";
import { newSearchModel } from "../../dataModels/models";

class RegistrationsPage extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      redirectToAddRegistrationPage: false
    };

    this.handlePageClick = this.handlePageClick.bind(this);
    this.handlePreviousClick = this.handlePreviousClick.bind(this);
    this.handleNextClick = this.handleNextClick.bind(this);
  }

  componentDidMount() {
    const { registrations, registrationsData, actions } = this.props;

    if (registrations.length === 0) {
      actions.loadRegistrations().catch(error => {
        alert("Loading registrations failed" + error);
      });
    }

    if (registrationsData.results.length === 0) {
      actions.searchRegistrations(newSearchModel).catch(error => {
        alert("Searching registrations failed" + error);
      });
    }
  }

  handlePageClick(e, index) {
    e.preventDefault();
    this.props.actions
      .searchRegistrations({ ...newSearchModel, page: index + 1 })
      .catch(error => {
        alert("Searching registrations failed" + error);
      });
  }

  handlePreviousClick(e) {
    e.preventDefault();
    const index = this.props.registrationsData.currentPage - 1;
    this.props.actions
      .searchRegistrations({ ...newSearchModel, page: index })
      .catch(error => {
        alert("Searching registrations failed" + error);
      });
  }

  handleNextClick(e) {
    e.preventDefault();
    const index = this.props.registrationsData.currentPage + 1;
    this.props.actions
      .searchRegistrations({ ...newSearchModel, page: index })
      .catch(error => {
        alert("Searching registrations failed" + error);
      });
  }

  render() {
    return (
      <Fragment>
        <h2>Registrations</h2>
        <button
          style={{ margin: 20 }}
          className="btn btn-primary add-attendee"
          onClick={() => this.setState({ redirectToAddRegistrationPage: true })}
        >
          Add Registration
        </button>
        {this.state.redirectToAddRegistrationPage && (
          <Redirect to="/Registration" />
        )}
        {this.props.loading ? (
          <Spinner />
        ) : (
          <Fragment>
            <RegistrationList
              registrations={this.props.registrationsData.results}
              pageSize={this.props.registrationsData.pageSize}
              pagesCount={this.props.registrationsData.pagesCount}
              currentPage={this.props.registrationsData.currentPage - 1}
              handlePageClick={this.handlePageClick}
              handlePreviousClick={this.handlePreviousClick}
              handleNextClick={this.handleNextClick}
            />
          </Fragment>
        )}
      </Fragment>
    );
  }
}

RegistrationsPage.propTypes = {
  registrations: PropTypes.array.isRequired,
  registrationsData: PropTypes.object.isRequired,
  actions: PropTypes.object.isRequired,
  loading: PropTypes.bool.isRequired
};

// This functions determines what part of the state we expose to our component on props
function mapStateToProps(state) {
  return {
    registrations: state.registrations,
    registrationsData: state.registrationsData,
    loading: state.apiCallsInProgress > 0
  };
}

// This functions lets us declare what actions to pass our component on props
function mapDispatchToProps(dispatch) {
  return {
    actions: {
      loadRegistrations: bindActionCreators(
        registrationActions.loadRegistrations,
        dispatch
      ),
      searchRegistrations: bindActionCreators(
        registrationActions.searchRegistrations,
        dispatch
      )
    }
  };
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(RegistrationsPage);
