import _ from "lodash";
import React, { Component } from "react";
import { connect } from "react-redux";
import { fetchTickets } from "../actions/index";
//import { bindActionCreators } from "redux";
import TicketDetail from "./ticket-detail";

class TicketList extends Component {

  componentWillMount() {
    this.props.fetchTickets();
  }

  renderList() {
    return _.map(this.props.tickets, ticket => {
      return (
        <TicketDetail key={ticket.ticketId} ticket={ticket}/>
      );
    });
  }

  render() {
    return (
      <div className="st-tickets-panel">
        <div><h2>View Tickets</h2></div>
        <div>
          <p><strong>Note: </strong>Inactive tickets will not be displayed</p>
          <div>
              <p>
                  Download the code from Github <a href="https://github.com/virasana/SupportTicket">here</a>
              </p>
          </div>
        </div>
        <div className="row st-tickets-panel">
            <div className="col-md-12 container st-scrollable-area">
                {this.renderList()}
          </div>
        </div>
      </div>
      )
  }
}



// function mapDispatchToProps(dispatch) {
//   // Whenever selectTicket is called, the result should be passed
//   // to all of our reducers
//   return bindActionCreators({ fetchTickets: fetchTickets }, dispatch);
// }

// Promote TicketList from a component to a container - it needs to know
// about this new dispatch method, selectTicket. Make it available
// as a prop.

// Anything returned from this function will end up as props
// on the TicketList container
function mapStateToProps(state) {
  // Whatever is returned will show up as props
  // inside of TicketList
  return { tickets: state.tickets };
}


export default connect(mapStateToProps, { fetchTickets })(TicketList);
