import { combineReducers } from "redux";
import TicketsReducer from "./reducer_tickets";
import ActiveTicket from "./reducer_active_ticket";

const rootReducer = combineReducers({
  tickets: TicketsReducer,
  activeTicket: ActiveTicket
});

export default rootReducer;
