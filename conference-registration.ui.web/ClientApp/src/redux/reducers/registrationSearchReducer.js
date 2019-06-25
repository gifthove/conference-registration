import * as types from "../actions/actionTypes";
import intialState from "./initialState";

export default function(state = intialState.registrationsData, action) {
  switch (action.type) {
    case types.SEARCH_REGISTRATIONS_SUCCESS:
      debugger;
      return action.registrationsData;
    default:
      return state;
  }
}
