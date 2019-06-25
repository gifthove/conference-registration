import { handleResponse, handleError } from "./apiUtils";
// const baseUrl = process.env.API_URL + "/registration/";
const baseUrl = "/api/registrations/";
export function getRegistrations() {
  return fetch(baseUrl)
    .then(handleResponse)
    .catch(handleError);
}

export function saveRegistration(registration) {
  var url = baseUrl + (registration.id || "");
  return fetch(url, {
    method: registration.id ? "PUT" : "POST", // POST for create, PUT to update when id already exists.
    headers: { "content-type": "application/json" },
    body: JSON.stringify(registration)
  })
    .then(handleResponse)
    .catch(handleError);
}

export function searchRegistrations(searchModel) {
  var url = baseUrl + "searchregistrations";
  return fetch(url, {
    method: "POST",
    headers: { "content-type": "application/json" },
    body: JSON.stringify(searchModel)
  })
    .then(handleResponse)
    .catch(handleError);
}

export function deleteRegistration(registrationId) {
  return fetch(baseUrl + registrationId, { method: "DELETE" })
    .then(handleResponse)
    .catch(handleError);
}
