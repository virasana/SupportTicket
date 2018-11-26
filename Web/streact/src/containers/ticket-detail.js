import React, { Component } from "react";
import { connect } from "react-redux";

class TicketDetail extends Component {
  render() {
    if (!this.props.ticket) {
      return <div>Select a ticket to get started.</div>;
    }

    return (
      <div>
        <h3>Details for:</h3>
        <div>Id: {this.props.ticket.ticketId}</div>
        <div>Description: {this.props.ticket.description}</div>
        <div>Problem:<div class="ticketDetail">{this.props.ticket.problem}</div></div>
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    ticket: state.activeTicket
  };
}

export default connect(mapStateToProps)(TicketDetail);
