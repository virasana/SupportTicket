import React from "react";
import { Component } from "react";
import TicketList from "./containers/ticket-list";
import TicketsNew from "./containers/tickets-new";
import TicketsEdit from "./containers/tickets-edit";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import Signin from './containers/auth/Signin';
import Signout from './containers/auth/Signout';
import Header from './containers/header';

export class App extends Component {
  render() {
    const SUPPORT_TICKET_BUILD_REACT_IMAGE="virasana/0.0.0.0"; //default  
    return (
      <BrowserRouter>
        <div id="outer-container" className="st-navbar">
            <Header />
            <div id="page-wrap">
                <Switch>
                    <Route path="/signout" component={Signout} />
                    <Route path="/signin" component={Signin} />
                    <Route path="/tickets/edit/:id" component={TicketsEdit} />
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
