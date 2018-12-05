import { combineReducers } from "redux";
import TicketsReducer from "./reducer_tickets";
import { reducer as formReducer } from "redux-form";

const rootReducer = combineReducers({
  tickets: TicketsReducer,
  form: formReducer
});

export default rootReducer;
