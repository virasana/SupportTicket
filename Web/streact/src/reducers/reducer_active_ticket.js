// State argument is not application state, only the state
// this reducer is responsible for
export default function(state = null, action) {
    switch (action.type) {
      case "TICKET_SELECTED":
        var ticket = action.payload;
        ticket.active = true;
        return ticket;
    default: 
        return state;
    }
  }
  