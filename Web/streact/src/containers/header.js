import React, { Fragment, Component } from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import Menu from 'react-burger-menu/lib/menus/stack'

class Header extends Component {

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

  renderLinks() {
    if (this.props.authenticated) {
      console.log('authenticated',this.props.authenticated);
      return (
        <Fragment>
            <li className="st-navitem"><Link to="/signout" className="menu-item">Sign Out</Link></li>
        </Fragment>
      );
    } else {
      return (
        <Fragment>
          <li className="st-navitem"><Link to="/signin" className="menu-item">Sign In</Link></li>
        </Fragment>
      );
    }
  }

  render() {
    return (
      <div className="header">
            <div className="navbar navbar-inverse navbar-fixed-top">
                <div className="container">
                    
                    <div className="st-navbar-brand">Ticket Track</div>
                    <div className="navbar-collapse collapse st-pconly">
                        <ul className="nav navbar-nav">
                            <li className="st-navitem"><Link to="/" className="menu-item">View Tickets</Link></li>
                            <li className="st-navitem"><Link to="/tickets/new" className="menu-item">New Ticket</Link></li>
                            {this.renderLinks()}
                        </ul> 
                    </div>
                    <div className="st-mobileonly" onClick={() => this.closeMenu()}>
                    <Menu
                    isOpen={this.state.menuOpen}
                    onStateChange={(state) => this.handleStateChange(state)}
                    right 
                    pageWrapId={"page-wrap"} outerContainerId={"outer-container"}>
                        <Link className="st-navitem" onClick={() => this.closeMenu()} to="/tickets/new" >New Ticket</Link>
                        <Link className="st-navitem" onClick={() => this.closeMenu()} to="/" >View Tickets</Link>
                        <Link className="st-navitem" onClick={() => this.closeMenu()} to="/signin" >Sign In</Link>
                        <Link className="st-navitem" onClick={() => this.closeMenu()} to="/signout" >Sign Out</Link>
                    </Menu>
                </div>
                </div>
            </div>
      </div>
    );
  }
}

function mapStateToProps(state) {
  return { authenticated: state.auth.authenticated };
}

export default connect(mapStateToProps)(Header);
