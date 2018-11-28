import React, { Component } from "react";


class TicketDetail extends Component {
  render() {
    if (!this.props.ticket) {
      return <div>No ticket to display</div>;
    }

    return (
      <div>
      <table className="table-bordered table-striped table-responsive">
      <tbody>
        <tr>
          <td colSpan="2"><strong>Ticket ID</strong>: {this.props.ticket.ticketId}</td>
        </tr>
        <tr>
            <td className="st-label">
                Description
            </td>
            <td>
                {this.props.ticket.description}
            </td>
        </tr>
        <tr>
            <td className="st-label">
                Problem
            </td>
            <td>
                {this.props.ticket.problem}
            </td>
        </tr>
        <tr>
            <td className="st-label">
                Active
            </td>
            <td>
                {this.props.ticket.active.toString()}
            </td>
        </tr>
        <tr>
            <td className="st-label">
                TicketId
            </td>
            <td>
                {this.props.ticket.ticketId}
            </td>
        </tr>
        <tr>
            <td className="st-label">
                Severity
            </td>
            <td>
                {typeof(this.props.ticket.severity) === 'undefined'? '' : this.props.ticket.severity.displayName}
            </td>
        </tr>
      </tbody>
    </table>
    <hr/>
    </div>
    );
  }
}


export default TicketDetail;
