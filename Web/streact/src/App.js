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
        <div id="outer-container" >
            <div className="st-pconly">
                <div className="st-navitem"><Link to="/" className="menu-item">View Tickets</Link></div>
                <div className="st-navitem"><Link className="st-navitem" to="/tickets/new" className="menu-item">New Ticket</Link></div>
            </div>
            <div className="st-mobileonly">
                <Menu 
                  isOpen={this.state.menuOpen}
                  onStateChange={(state) => this.handleStateChange(state)}
                  right 
                  pageWrapId={"page-wrap"} outerContainerId={"outer-container"}>
                    <Link onClick={() => this.closeMenu()} to="/tickets/new" className="menu-item">New Ticket</Link>
                    <Link onClick={() => this.closeMenu()} to="/" className="menu-item">View Tickets</Link>
                </Menu>
            </div>
            <div id="page-wrap" className="st-main-area">
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
