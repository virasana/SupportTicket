import React, {Component} from 'react';
import { Field, reduxForm } from "redux-form";
import { compose } from 'redux';
import { connect } from 'react-redux';
import * as actions from '../../actions/auth-actions';
import StTextBox from '../form-components/st-text-box';
import StPassword from '../form-components/st-password';

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

                    <div>{this.props.errorMessage}</div>
                    <button type="submit" className="btn btn-basic st-formbutton" disabled={invalid}>Submit</button>
                </form>
            </div>
        )
    }
}

function mapStateToProps(state) {
    return { errorMessage: state.auth.errorMessage };
}

export default compose(
    connect(mapStateToProps, actions),
    reduxForm({ form: 'signup' })
  )(Signup);