import React, { Fragment } from "react";
import { connect } from "react-redux";
import * as registrationActions from "../../redux/actions/registrationActions";
import { bindActionCreators } from "redux";
import PropTypes from "prop-types";
import RegistrationList from "./RegistrationList";
import { Redirect } from "react-router-dom";
import Spinner from "../common/Spinner";

class RegistrationsPage extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      redirectToAddRegistrationPage: false
    };
  }
  componentDidMount() {
    const { registrations, actions } = this.props;
    debugger;
    if (registrations.length === 0) {
      actions.loadRegistrations().catch(error => {
        alert("Loading registrations failed" + error);
      });
    }
  }

  render() {
    return (
      <Fragment>
        {this.state.redirectToAddRegistrationPage && (
          <Redirect to="/Registration" />
        )}
        <h2>Registrations</h2>
        {this.props.loading ? (
          <Spinner />
        ) : (
          <Fragment>
            <button
              style={{ margin: 20 }}
              className="btn btn-primary add-attendee"
              onClick={() =>
                this.setState({ redirectToAddRegistrationPage: true })
              }
            >
              Add Registration
            </button>
            <RegistrationList registrations={this.props.registrations} />
          </Fragment>
        )}
      </Fragment>
    );
  }
}

RegistrationsPage.propTypes = {
  registrations: PropTypes.array.isRequired,
  actions: PropTypes.object.isRequired,
  loading: PropTypes.bool.isRequired
};

// This functions determines what part of the state we expose to our component on props
function mapStateToProps(state) {
  return {
    registrations: state.registrations,
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
      )
    }
  };
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(RegistrationsPage);
