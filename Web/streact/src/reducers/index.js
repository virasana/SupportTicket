import { combineReducers } from "redux";
import TicketsReducer from "./reducer-tickets";
import { reducer as formReducer } from "redux-form";
import AuthReducer from './reducer-auth';

const rootReducer = combineReducers({
  tickets: TicketsReducer,
  form: formReducer,
  auth: AuthReducer
});

export default rootReducer;
