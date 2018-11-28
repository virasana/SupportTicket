import _ from "lodash";
import { FETCH_TICKETS } from "../actions";

export default function(state = [{ticketId: 1, active: 'false'}, {ticketId: 2, active: 'true'}], action) {
  switch (action.type) {
    case FETCH_TICKETS:
    console.log('data', action.payload)
      console.log('payload', action.payload.data);
      
      let result = [];

      try
      {
        result = _.mapKeys(action.payload.data, "ticketId");
      }
      catch
      {
        console.log('there was an error');
      }

      return result;
    default:
      return state;
  }
}
