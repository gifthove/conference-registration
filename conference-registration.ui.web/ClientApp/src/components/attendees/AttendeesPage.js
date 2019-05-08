import React, { Fragment } from "react";
import { connect } from "react-redux";
import * as attendeeActions from "../../redux/actions/attendeeActions";
import { bindActionCreators } from "redux";
import PropTypes from "prop-types";
import AttendeeList from "./AttendeeList";
import { Redirect } from "react-router-dom";

class AttendeesPage extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      redirectToAddAttendeePage: false
    };
  }
  componentDidMount() {
    const { attendees, actions } = this.props;

    if (attendees.length === 0) {
      actions.loadAttendees().catch(error => {
        alert("Loading attendees failed" + error);
      });
    }
  }

  render() {
    return (
      <Fragment>
        {this.state.redirectToAddAttendeePage && <Redirect to="/Attendee" />}
        <h2>Attendees</h2>
        <button
          style={{ margin: 20 }}
          className="btn btn-primary add-attendee"
          onClick={() => this.setState({ redirectToAddAttendeePage: true })}
        >
          Add Attendee
        </button>
        <AttendeeList attendees={this.props.attendees} />
      </Fragment>
    );
  }
}

AttendeesPage.propTypes = {
  attendees: PropTypes.array.isRequired,
  actions: PropTypes.object.isRequired
};

// This functions determines what part of the state we expose to our component on props
function mapStateToProps(state) {
  return {
    attendees: state.attendees
  };
}

// This functions lets us declare what actions to pass our component on props
function mapDispatchToProps(dispatch) {
  return {
    actions: {
      loadAttendees: bindActionCreators(attendeeActions.loadAttendees, dispatch)
    }
  };
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(AttendeesPage);
