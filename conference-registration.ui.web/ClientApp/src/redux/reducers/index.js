import { combineReducers } from "redux";
import attendees from "./attendeeReducer";
import registrations from "./registrationReducer";
import apiCallsInProgress from "./apiStatusReducer";

const rootReducer = combineReducers({
  attendees,
  registrations,
  apiCallsInProgress
});

export default rootReducer;
