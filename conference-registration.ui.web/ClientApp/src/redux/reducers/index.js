import { combineReducers } from "redux";
import attendees from "./attendeeReducer";
import registrations from "./registrationReducer";
import apiCallsInProgress from "./apiStatusReducer";
import conference from "./conferenceReducer";

const rootReducer = combineReducers({
  attendees,
  registrations,
  apiCallsInProgress,
  conference
});

export default rootReducer;
