import * as types from "../actions/actionTypes";
import intialState from "./initialState";

export default function(state = intialState.registrations, action) {
  switch (action.type) {
    case types.CREATE_REGISTRATION_SUCCESS:
      return [...state, { ...action.registration }];
    case types.LOAD_REGISTRATION_SUCCESS:
      return action.registrations;
    case types.UPDATE_REGISTRATION_SUCCESS:
      return state.map(registration =>
        registration.id === action.registration.id
          ? action.registration
          : registration
      );
    default:
      return state;
  }
}
