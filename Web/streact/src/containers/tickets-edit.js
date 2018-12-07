import React, { Component } from "react";
import { Field, reduxForm } from "redux-form";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import { updateTicket, fetchStaticData, fetchTicket } from "../actions/index";
import DropDownSelect from "./select-list";
import { bindActionCreators } from "redux";



class TicketsEdit extends Component {
  constructor (props) {
    super(props)
    this.render = this.render.bind(this);
  }

  componentDidMount() {
    this.props.fetchStaticData();
    this.props.fetchTicket(this.props.match.params.id);
  }  

  // handleInitialize() {
  //   const initData = {
  //     "problem": "p", //this.props.initialValues.problem,
  //     "description": "d", //this.props.initialValues.description,
  //     "active": true, //this.props.initialValues.active,
  //     "productId": (this.props.initialValues ? this.props.initialValues.severityId : 2),
  //     "severityId": (this.props.initialValues ? this.props.initialValues.productId : 2)
  //   };

  //   this.props.initialize(initData);
  // }

  renderField(field) {
    const { meta: { touched, error } } = field;
    const className = `form-group ${touched && error ? "has-danger" : ""}`;

    return (
        <div className={className}>
          <label>{field.label}</label>
          <input className="form-control" type="text" {...field.input} />
          <div className="text-help">
            {touched ? error : ""}
          </div>
        </div>
    );
  }

  renderTextArea(field) {
    const { meta: { touched, error } } = field;
    const className = `form-group ${touched && error ? "has-danger" : ""}`;

    return (
        <div className={className}>
          <label>{field.label}</label>
          <textarea className="form-control" type="text" {...field.input} />
          <div className="text-help">
            {touched ? error : ""}
          </div>
        </div>
    );
  }

  renderCheckBox(field) {
    const { meta: { touched, error } } = field;
    const className = `form-group ${touched && error ? "has-danger" : ""}`;

    return (
        <div className={className}>
          <label>{field.label}</label>
          <input className="form-control st-checkbox" type="checkbox" {...field.input} />
          <div className="text-help">
            {touched ? error : ""}
          </div>
        </div>
    );
  }

  // See the callback - it will be called by the action creator (see the action creator)
  onSubmit(values) {
    this.props.updateTicket(values, () => { 
      this.props.history.push("/");
    });
  }

  render() {
    const { handleSubmit, invalid } = this.props

    return (
      <div className="st-tickets-panel">
        <div><h2>Edit Ticket</h2></div>
        <form onSubmit={handleSubmit(this.onSubmit.bind(this))}>
          <Field
            label="Description For Ticket"
            name="description"
            component={this.renderField}
          />
          <Field
            label="Problem"
            name="problem"
            component={this.renderTextArea}
            type="textarea"
          />
          <Field
            label="Active"
            name="active"
            component={this.renderCheckBox}
            type="checkbox"
          />
          <Field
            name="productId"
            label="Product"
            component={DropDownSelect}
            items={this.props.products == null ? [] : this.props.products}
            className="form-control"
          />
          <Field
            name="severityId"
            label="Severity"
            component={DropDownSelect}
            items={this.props.severities == null ? [] : this.props.severities}
            className="form-control"
          />
          <button type="submit" className="btn btn-basic st-formbutton" disabled={invalid}>Submit</button>
          <Link to="/" className="btn btn-danger st-formbutton">Cancel</Link>
        </form>
      </div>
    );
  }
}



function validate(values) {
  const errors = {};

  // Validate the inputs from 'values'
  if (!values.description) {
    errors.description = "Enter a description";
  }
  if (!values.problem) {
    errors.problem = "Provide problem details";
  }

  if (!values.severity) {
    errors.severity = "Select severity";
  }

  if (!values.product) {
    errors.product = "Select product";
  }

  return errors;
}

function mapStateToProps(state) {
  // Whatever is returned will show up as props
  // inside of TicketList
  
  if(state.tickets == null) {
    return {};
  }
  
  try {
      let result =  { 
        initialValues: state.tickets.ticket, 
        initData: state.tickets.ticket, 
        severities: state.tickets.staticData.severities,
        products: state.tickets.staticData.products,
             };
      return result;
  }
  catch{
    return {};
  }
}

function mapDispatchToProps(dispatch) {
  // Whenever fetchStaticData is called, the result should be passed
  // to all of our reducers
  return bindActionCreators({ updateTicket, fetchStaticData, fetchTicket }, dispatch);
}

TicketsEdit = reduxForm({
  validate,
  form: "TicketsEditForm",
  enableReinitialize: true,
})(TicketsEdit); 

export default connect(mapStateToProps, mapDispatchToProps)(TicketsEdit);
// Could also use destructuring as follows:
// TicketsEdit = connect(mapStateToProps, { updateTicket, fetchStaticData })(TicketsEdit);

