import axios from "axios";

export const FETCH_TICKETS = "FETCH_TICKETS";
export const FETCH_TICKET = "FETCH_TICKET";
export const CREATE_TICKET = "CREATE_TICKET";
export const UPDATE_TICKET = "UPDATE_TICKET";
export const TICKET_SELECTED = "TICKET_SELECTED";
export const FETCH_STATIC_DATA = "FETCH_STATIC_DATA";
export const SET_TICKET = "SET_TICKET";

const ROOT_URL = process.env.REACT_APP_API_URL;

export function fetchTickets() {
  const request = axios.get(`${ROOT_URL}/tickets`);
  return {
    type: FETCH_TICKETS,
    payload: request
  };
}

export function fetchStaticData() {
  const request = axios.get(`${ROOT_URL}/staticdata`);
  return {
    type: FETCH_STATIC_DATA,
    payload: request
  };
}

// the callback will be provided by the handler on the form. 
// See ticketsNew where it navigates using history.push
export function createTicket(values, callback) {
  const request = axios
    .post(`${ROOT_URL}/tickets/add`, values)
    .then(() => callback());

  return {
    type: CREATE_TICKET,
    payload: request
  };
}

export function updateTicket(values, callback) {
  const request = axios
    .put(`${ROOT_URL}/tickets`, values)
    .then(() => callback());

  return {
    type: CREATE_TICKET,
    payload: request
  };
}

export function fetchTicket(ticketId) {
  const request = axios.get(`${ROOT_URL}/tickets/${ticketId}`);
  console.log("Fetch ticket from API");
  return {
    type: "FETCH_TICKET",
    payload: request
  };
}


export function setTicket(ticket) {
  console.log("Fetch ticket from cache");
  return {
    type: "SET_TICKET",
    payload: ticket
  };
}


  