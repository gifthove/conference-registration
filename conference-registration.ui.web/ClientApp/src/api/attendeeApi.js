import { handleResponse, handleError } from "./apiUtils";
// const baseUrl = process.env.API_URL + "/attendees/";
const baseUrl = "/api/attendees/";
export function getAttendees() {
  return fetch(baseUrl)
    .then(handleResponse)
    .catch(handleError);
}

export function saveAttendee(attendee) {
  var url = baseUrl + (attendee.id || "");
  return fetch(url, {
    method: attendee.id ? "PUT" : "POST", // POST for create, PUT to update when id already exists.
    headers: { "content-type": "application/json" },
    body: JSON.stringify(attendee)
  })
    .then(handleResponse)
    .catch(handleError);
}

export function deleteAttendee(attendeeId) {
  return fetch(baseUrl + attendeeId, { method: "DELETE" })
    .then(handleResponse)
    .catch(handleError);
}
