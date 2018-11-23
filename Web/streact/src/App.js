import React from "react";
import { Component } from "react";

import TicketList from "../containers/ticket-list";
import TicketDetail from "../containers/ticket-detail";

export class App extends Component {
  render() {
    return (
      <div className="App">
        <TicketList />
        <TicketDetail />
      </div>
      <div>
        <footer className="App-header">
          <p>Ticket-Track : &copy; Karunasoft Ltd 2018. All rights reserved : Docker: ${SUPPORT_TICKET_REACT_IMAGE}</p>
        </footer>
      </div>
    );
  }
}

export default App;
