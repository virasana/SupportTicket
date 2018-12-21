import React, {Component} from 'react';
import { Field, reduxForm } from "redux-form";
import { compose } from 'redux';
import { connect } from 'react-redux';
import * as actions from '../../actions/auth-actions';
import StTextBox from '../form-components/st-text-box';
import StPassword from '../form-components/st-password';
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faExclamation } from '@fortawesome/free-solid-svg-icons'
import StValidationSummary from '../form-components/st-validation-summary';

library.add(faExclamation);

export class Signup extends Component {
    onSubmit = formProps => {
        this.props.signup(formProps, () => {
            this.props.history.push('/signin');
        });
      };
    
    render(){
        const { handleSubmit, invalid } = this.props;
        return (
            <div>
                <div><h2>Sign Up</h2></div>
                <form onSubmit={handleSubmit(this.onSubmit)}>
                    <fieldset>
                        <Field
                            label="First Name"
                            name="firstname"
                            component={StTextBox}
                        />
                    </fieldset>
                    <fieldset>
                        <Field
                            label="Last Name"
                            name="lastname"
                            component={StTextBox}
                        />
                    </fieldset>

                    <fieldset>
                        <Field
                            label="User Name"
                            name="username"
                            component={StTextBox}
                        />
                    </fieldset>
                    <fieldset>
                        <Field
                            label="Password"
                            name="password"
                            component={StPassword}
                        />
                    </fieldset>
                    <fieldset>
                        <Field
                            label="Confirm Password"
                            name="confirmpassword"
                            component={StPassword}
                        />
                    </fieldset>
                    <fieldset>
                        <Field
                            name="validationsummary"
                            component={StValidationSummary}
                        />
                    </fieldset>
                    <div className="st-texthelp">{(this.props.errorMessage && <FontAwesomeIcon icon="exclamation" className="st-exclamation" />)}{this.props.errorMessage}</div>
                    <button type="submit" className="btn btn-basic st-formbutton" disabled={invalid}>Submit</button>
                </form>
            </div>
        )
    }
}

function validate(values) {
    const errors = {};
  
    // Validate the inputs from 'values'
    if (!values.firstname) {
      errors.firstname = "Enter First Name";
    }
    
    if (!values.lastname) {
      errors.lastname = "Enter Last Name";
    }

    if (!values.username) {
        errors.username = "Enter User Name";
      }
  
    if (!values.password) {
      errors.password = "Enter Password";
    }
  
    if (!values.confirmpassword) {
      errors.confirmpassword = "Confirm Password";
    }

    if (values.confirmpassword && values.password 
        && values.confirmpassword !== values.password) {
            errors.validationsummary = "Passwords do not match";
    }

    if (values.confirmpassword && values.confirmpassword.length < 9)
    {
        errors.confirmpassword = "Password must be at least 9 characters long";
    }

    if (values.password && values.password.length < 9)
    {
        errors.password = "Password must be at least 9 characters long";
    }
  
    return errors;
  }

function mapStateToProps(state) {
    return { errorMessage: state.auth.errorMessage };
}

export default compose(
    connect(mapStateToProps, actions),
    reduxForm({ form: 'signup',validate })
  )(Signup);