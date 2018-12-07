import _ from "lodash";
import { FETCH_TICKETS, FETCH_STATIC_DATA, UPDATE_TICKET, TICKET_SELECTED } from "../actions";

export default function(state = null, action) {
  let result;
  switch (action.type) {
    case FETCH_TICKETS:
      result = _.mapKeys(action.payload.data, "ticketId");
      return result;
      case UPDATE_TICKET:
      result = action.payload.data; // Status code
      return result;
    case TICKET_SELECTED:
      result = action.payload; 
      return result;
    case FETCH_STATIC_DATA:
      result = {...state,staticData: action.payload.data};
      return result;
    default:
      return state;
  }
}
