import { handleResponse, handleError } from "./apiUtils";
// const baseUrl = process.env.API_URL + "/conferences/";
const baseUrl = "/api/conferences/";
export function getConferenceById(conferenceId) {
  debugger;
  return fetch(baseUrl + conferenceId)
    .then(handleResponse)
    .catch(handleError);
}

export function saveAttendee(conference) {
  var url = baseUrl + (conference.id || "");
  return fetch(url, {
    method: conference.id ? "PUT" : "POST", // POST for create, PUT to update when id already exists.
    headers: { "content-type": "application/json" },
    body: JSON.stringify(conference)
  })
    .then(handleResponse)
    .catch(handleError);
}

export function deleteConference(conferenceId) {
  return fetch(baseUrl + conferenceId, { method: "DELETE" })
    .then(handleResponse)
    .catch(handleError);
}
