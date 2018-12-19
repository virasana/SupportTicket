import React, {Component} from 'react';
import { Field, reduxForm } from "redux-form";
import { compose } from 'redux';
import { connect } from 'react-redux';
import * as actions from '../../actions/auth-actions';
import StTextBox from '../form-components/st-text-box';
import StPassword from '../form-components/st-password';

export class Signin extends Component {
    onSubmit = formProps => {
        this.props.signin(formProps, () => {
          this.props.history.push('/tickets');
        });
      };

    render(){
        const { handleSubmit, invalid } = this.props;
        return (
            <div>
                <div><h2>Sign In</h2></div>
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
    reduxForm({ form: 'signin' })
  )(Signin);