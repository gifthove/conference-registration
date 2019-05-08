import * as types from "./actionTypes";
import * as attendeeApi from "../../api/attendeeApi";
import { beginApiCall, apiCallError } from "./apiStatusActions";

export function loadAttendeesSuccess(attendees) {
  return {
    type: types.LOAD_ATTENDEES_SUCCESS,
    attendees
  };
}

export function createAttendeeSuccess(attendee) {
  return {
    type: types.CREATE_ATTENDEE_SUCCESS,
    attendee
  };
}

export function updateAttendeeSuccess(attendee) {
  return {
    type: types.UPDATE_ATTENDEE_SUCCESS,
    attendee
  };
}

// Every thunk is a function that returns a function which takes/accepts dispatch as an arg
export function loadAttendees() {
  return function(dispatch) {
    dispatch(beginApiCall());
    return attendeeApi
      .getAttendees()
      .then(attendees => {
        dispatch(loadAttendeesSuccess(attendees));
      })
      .catch(error => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}

// Every thunk is a function that returns a function which takes/accepts dispatch as an arg
export function saveAttendee(attendee) {
  //eslint-disable-next-line no-unused-vars
  return function(dispatch, getState) {
    dispatch(beginApiCall());
    return attendeeApi
      .saveAttendee(attendee)
      .then(attendee => {
        attendee.id
          ? dispatch(updateAttendeeSuccess(attendee))
          : dispatch(createAttendeeSuccess(attendee));
      })
      .catch(error => {
        throw error;
      });
  };
}
