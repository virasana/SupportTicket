import React from "react";
import { Component } from "react";
import TicketList from "./containers/ticket-list";
import TicketsNew from "./containers/tickets-new";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import { Link } from "react-router-dom";
import Menu from 'react-burger-menu/lib/menus/stack'

export class App extends Component {
  constructor (props) {
    super(props)
    this.state = { menuOpen: false }
    this.handleStateChange = this.handleStateChange.bind(this);
    this.closeMenu = this.closeMenu.bind(this);
    this.toggleMenu = this.toggleMenu.bind(this);
  }

  handleStateChange (state) {
    this.setState({menuOpen: state.isOpen})  
  }

  closeMenu () {
    this.setState({menuOpen: false})
  }

  toggleMenu () {
    this.setState({menuOpen: !this.state.menuOpen})
  }

  render() {
    const SUPPORT_TICKET_BUILD_REACT_IMAGE="virasana/0.0.0.0"; //default  
    
    return (

      <BrowserRouter>
        <div id="outer-container" className="st-navbar">
            <div className="navbar navbar-inverse navbar-fixed-top">
                <div className="container">
                    <div className="st-navbar-brand">Ticket Track</div>
                    <div className="navbar-collapse collapse st-pconly">
                        <ul className="nav navbar-nav">
                            <li className="st-navitem"><Link to="/" className="menu-item">View Tickets</Link></li>
                            <li className="st-navitem"><Link to="/tickets/new" className="menu-item">New Ticket</Link></li>
                        </ul>
                    </div>
                    <div className="st-mobileonly">
                    <Menu 
                    isOpen={this.state.menuOpen}
                    onStateChange={(state) => this.handleStateChange(state)}
                    right 
                    pageWrapId={"page-wrap"} outerContainerId={"outer-container"}>
                        <Link className="st-navitem" onClick={() => this.closeMenu()} to="/tickets/new" >New Ticket</Link>
                        <Link className="st-navitem" onClick={() => this.closeMenu()} to="/" >View Tickets</Link>
                    </Menu>
                </div>
                </div>
            </div>
            <div id="page-wrap">
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
