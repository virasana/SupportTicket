import axios from "axios";

export const FETCH_TICKETS = "FETCH_TICKETS";

const ROOT_URL = "http://webservice:32768/api";

export function fetchTickets() {
  const request = axios.get(`${ROOT_URL}/tickets`);
  console.log('Fetching tickets...', request);
  return {
    type: FETCH_TICKETS,
    payload: request
  };
}




  