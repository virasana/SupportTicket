import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

class StPassword extends React.Component {
  render() {
    const { input, label, className, meta: { touched, error }} = this.props;
    return (
    <div className={className}>
        <label>{label}</label>
        <input {...input} className="form-control" type="password" />
        <div className="text-help">
            {touched && (error && <span className="st-texthelp"><FontAwesomeIcon className="st-exclamation" icon="exclamation"/>{error}</span>)}
        </div>
    </div>
    );
  }
}

export default StPassword;