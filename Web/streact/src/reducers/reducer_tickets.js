import _ from "lodash";
import { FETCH_TICKETS } from "../actions";


export default function(state = [{ticketId: 1, active: 'false'}], action) {
  switch (action.type) {
    case FETCH_TICKETS:
      let result = [];
      try
      {
        result = _.mapKeys(action.payload.data, "ticketId");
      }
      catch
      {
        console.log('there was an error fetching tickets. Could not map payload data.');
      }

      return result;
    default:
      return state;
  }
}
