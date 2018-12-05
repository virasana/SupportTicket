import _ from "lodash";
import { FETCH_TICKETS, FETCH_STATIC_DATA } from "../actions";


export default function(state = {}, action) {
  let result;
  switch (action.type) {
    case FETCH_TICKETS:
      result = _.mapKeys(action.payload.data, "ticketId");
      return result;
    case FETCH_STATIC_DATA:
      result = {...state, staticData: action.payload.data};
      return result;
    default:
      return state;
  }
}
