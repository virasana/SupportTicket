import React, { Component } from "react";
import { connect } from "react-redux";
import { selectTicket } from "../actions/index";
import { bindActionCreators } from "redux";

class TicketList extends Component {
  renderList() {
    return this.props.tickets.map(ticket => {
      return (
        <li
          key={ticket.ticketId}
          onClick={() => this.props.selectTicket(ticket)}
          className="list-group-item"
        >
          {ticket.description}
        </li>
      );
    });
  }

  render() {
    return (
      <ul className="list-group col-sm-4">
        {this.renderList()}
      </ul>
    );
  }
}

function mapStateToProps(state) {
  // Whatever is returned will show up as props
  // inside of TicketList
  return {
    tickets: state.tickets
  };
}

// Anything returned from this function will end up as props
// on the TicketList container
function mapDispatchToProps(dispatch) {
  // Whenever selectTicket is called, the result should be passed
  // to all of our reducers
  return bindActionCreators({ selectTicket: selectTicket }, dispatch);
}

// Promote TicketList from a component to a container - it needs to know
// about this new dispatch method, selectTicket. Make it available
// as a prop.
export default connect(mapStateToProps, mapDispatchToProps)(TicketList);
