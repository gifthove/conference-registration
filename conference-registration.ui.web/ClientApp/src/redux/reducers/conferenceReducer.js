import * as types from "../actions/actionTypes";
import intialState from "./initialState";

export default function(state = intialState.conference, action) {
  switch (action.type) {
    case types.GET_CONFERENCE_SUCCESS:
      return action.conference;
    default:
      return state;
  }
}
