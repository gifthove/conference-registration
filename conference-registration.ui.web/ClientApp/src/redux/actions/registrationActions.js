import * as types from "./actionTypes";
import * as registrationApi from "../../api/registrationApi";
import { beginApiCall, apiCallError } from "./apiStatusActions";

export function loadRegistrationSuccess(registrations) {
  return {
    type: types.LOAD_REGISTRATION_SUCCESS,
    registrations
  };
}

export function createRegistrationSuccess(registration) {
  return {
    type: types.CREATE_REGISTRATION_SUCCESS,
    registration
  };
}

export function updateRegistrationSuccess(registration) {
  return {
    type: types.UPDATE_REGISTRATION_SUCCESS,
    registration
  };
}

// Every thunk is a function that returns a function which takes/accepts dispatch as an arg
export function loadRegistrations() {
  return function(dispatch) {
    dispatch(beginApiCall());
    return registrationApi
      .getRegistrations()
      .then(registrations => {
        dispatch(loadRegistrationSuccess(registrations));
      })
      .catch(error => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}

// Every thunk is a function that returns a function which takes/accepts dispatch as an arg
export function saveRegistration(registration) {
  //eslint-disable-next-line no-unused-vars
  return function(dispatch, getState) {
    dispatch(beginApiCall());
    return registrationApi
      .saveRegistration(registration)
      .then(registration => {
        registration.id
          ? dispatch(updateRegistrationSuccess(registration))
          : dispatch(createRegistrationSuccess(registration));
      })
      .catch(error => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}
