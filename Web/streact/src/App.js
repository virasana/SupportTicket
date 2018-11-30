import React from "react";
import { Component } from "react";

import TicketList from "./containers/ticket-list";

export class App extends Component {
  render() {
    const SUPPORT_TICKET_BUILD_REACT_IMAGE="virasana/0.0.0.0"; //default
    let nav = (
      <div>
        <nav className="navbar navbar-inverse navbar-fixed-top">
          <div className="container">
              <div className="navbar-header">
                  <button type="button" className="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                  <span className="sr-only">Toggle Navigation</span>
                  <span className="icon-bar"></span>
                  <span className="icon-bar"></span>
                  <span className="icon-bar"></span>
              </button>
                  <span className="navbar-brand">Ticket Track</span>
              </div>
              <div className="navbar-collapse collapse">
                  <ul className="nav navbar-nav">
                      <li><span>View Tickets</span></li>
                      <li><span>Add Ticket</span></li>
                      <li><span href="Contact">Contact</span></li>
                      <li><span href="Login">Login</span></li>
                  </ul>
              </div>
          </div>
        </nav>
      </div>
    );

    let main = (
      <TicketList/>
    );

    let footer = (
    <div >
        <footer>
            <p className="st-footer">Ticket-Track : &copy; Karunasoft Ltd 2018. All rights reserved : Docker: ${SUPPORT_TICKET_BUILD_REACT_IMAGE}</p>
        </footer>
    </div>
    );

    return (
      <div>
        {nav}
        {main} 
        {footer}       
      </div>
    );
  }
}

export default App;
