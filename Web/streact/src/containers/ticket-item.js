import React, { Component } from "react";
import { Link } from "react-router-dom";
import { setTicket, deleteTicket, fetchTickets } from '../actions/index'
import { connect } from "react-redux";

class TicketItem extends Component {
  render() {
    if (!this.props.ticket) {
      return <div>No ticket to display</div>;
    }

    return (
            <tr className="st-ticketRow">
                <td className="st-ticketId-column">{this.props.ticket.ticketId}</td>
                <td>{this.props.ticket.description}</td>
                <td><button className="btn btn-basic"><Link onClick={ticket => this.props.setTicket}  to={{ 
                  pathname: `/tickets/edit/${this.props.ticket.ticketId}`,
                  state: this.props.ticket
                } }>Edit</Link></button></td>
                <td><button className="btn btn-danger" onClick={()=> this.props.deleteTicket(this.props.ticket.ticketId, this.props.fetchTickets)}>Delete</button></td>
            </tr>
    );
  }
}

export default connect(null, { setTicket, deleteTicket, fetchTickets })(TicketItem);
