import axios from "axios";


export const FETCH_TICKETS = "FETCH_TICKETS";

const ROOT_URL = process.env.REACT_APP_API_URL;

export function fetchTickets() {
  const request = axios.get(`${ROOT_URL}/tickets`);
  console.log('Fetching tickets...', request);
  return {
    type: FETCH_TICKETS,
    payload: request
  };
}




  