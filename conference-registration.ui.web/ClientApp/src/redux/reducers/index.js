import { combineReducers } from "redux";
import attendees from "./attendeeReducer";
import registrations from "./registrationReducer";
import apiCallsInProgress from "./apiStatusReducer";
import conference from "./conferenceReducer";
import registrationsData from "./registrationSearchReducer";

const rootReducer = combineReducers({
  attendees,
  registrations,
  apiCallsInProgress,
  conference,
  registrationsData
});

export default rootReducer;
