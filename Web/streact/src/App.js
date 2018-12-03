import React from "react";
import { Component } from "react";
import TicketList from "./containers/ticket-list";
import TicketsNew from "./containers/tickets-new";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import { Link } from "react-router-dom";

export class App extends Component {
  render() {
    const SUPPORT_TICKET_BUILD_REACT_IMAGE="virasana/0.0.0.0"; //default
    
    return (

      <BrowserRouter>
      <div>
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
                    <li><Link to="/tickets">View Tickets</Link></li>
                    <li><Link to="/tickets/new">New Ticket</Link></li>
                    <li><span href="Contact">Contact</span></li>
                    <li><span href="Login">Login</span></li>
                    </ul>
                </div>
            </div>
          </nav>
        </div>
        <div className="st-main-area">
          <Switch>
            <Route path="/tickets/new" component={TicketsNew} />
            <Route path="/tickets" component={TicketList} />
            <Route path="/" component={TicketList} />
          </Switch>
        </div>
        <div >
          <footer>
              <p className="st-footer">Ticket-Track : &copy; Karunasoft Ltd 2018. All rights reserved : Docker: ${SUPPORT_TICKET_BUILD_REACT_IMAGE}</p>
          </footer>
        </div>
      </div>

      
    </BrowserRouter>
    );
  }
}

export default App;
