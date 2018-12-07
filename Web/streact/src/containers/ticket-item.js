import React, { Component } from "react";
import { Link } from "react-router-dom";
import { setTicket } from '../actions/index'
import { connect } from "react-redux";

class TicketItem extends Component {
  render() {
    if (!this.props.ticket) {
      return <div>No ticket to display</div>;
    }

    return (
            <tr>
                <td>{this.props.ticket.ticketId}</td>
                <td>{this.props.ticket.description}</td>
                <td><Link onClick={ticket => this.props.setTicket}  to={{ 
                  pathname: `/tickets/edit/${this.props.ticket.ticketId}`,
                  state: this.props.ticket
                } }>Edit</Link></td>
                <td><Link to={`/tickets/delete/${this.props.ticket.ticketId}` }>Delete</Link></td>
            </tr>
    );
  }
}


export default connect(null, { setTicket })(TicketItem);
