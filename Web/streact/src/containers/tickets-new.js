import React, { Component } from "react";
import { Field, reduxForm, propTypes } from "redux-form";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import { createTicket } from "../actions";


class TicketsNew extends Component {
  constructor (props) {
    super(props)
    this.render = this.render.bind(this);
  }

  

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
    this.props.createTicket(values, () => { 
      this.props.history.push("/");
    });
  }

  render() {
    const { handleSubmit, invalid } = this.props

    return (
      <div className="st-tickets-panel">
        <div><h2>New Ticket</h2></div>
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
          
          <button type="submit" className="btn btn-primary" disabled={invalid}>Submit</button>
          <Link to="/" className="btn btn-danger">Cancel</Link>
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

  // If errors is empty, the form is fine to submit
  // If errors has *any* properties, redux form assumes form is invalid
  return errors;
}

export default reduxForm({
  validate,
  form: "TicketsNewForm"
})(connect(null, { createTicket })(TicketsNew)); 