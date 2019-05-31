import * as types from "./actionTypes";
import * as conferenceApi from "../../api/conferenceApi";
import { beginApiCall, apiCallError } from "./apiStatusActions";

export function getConferenceSuccess(conference) {
  return {
    type: types.GET_CONFERENCE_SUCCESS,
    conference
  };
}

// Every thunk is a function that returns a function which takes/accepts dispatch as an arg
export function getConferenceById(conferenceId) {
  return function(dispatch) {
    dispatch(beginApiCall());
    return conferenceApi
      .getConferenceById(conferenceId)
      .then(conference => {
        dispatch(getConferenceSuccess(conference));
      })
      .catch(error => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}
