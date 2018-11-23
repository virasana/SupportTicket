export function selectTicket(ticket) {
    // selectBook is an ActionCreator, it needs to return an action,
    // an object with a type property.
    return {
      type: "TICKET_SELECTED",
      payload: ticket
    };
  }
  