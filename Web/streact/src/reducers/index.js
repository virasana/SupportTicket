import { combineReducers } from "redux";
import TicketsReducer from "./reducer_tickets";

const rootReducer = combineReducers({
  tickets: TicketsReducer,
});

export default rootReducer;
