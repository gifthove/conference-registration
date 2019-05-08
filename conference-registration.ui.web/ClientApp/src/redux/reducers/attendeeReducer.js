import * as types from "../actions/actionTypes";
import intialState from "./initialState";

export default function(state = intialState.attendees, action) {
  switch (action.type) {
    case types.CREATE_ATTENDEE_SUCCESS:
      return [...state, { ...action.attendee }];
    case types.LOAD_ATTENDEES_SUCCESS:
      return action.attendees;
    case types.UPDATE_ATTENDEE_SUCCESS:
      return state.map(attendee =>
        attendee.id === action.attendee.id ? action.attendee : attendee
      );
    default:
      return state;
  }
}
