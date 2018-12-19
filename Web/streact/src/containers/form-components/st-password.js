import React from 'react';

class StPassword extends React.Component {
  render() {
    const { input, label, className, meta: { touched, error }} = this.props;
    return (
    <div className={className}>
        <label>{label}</label>
        <input {...input} className="form-control" type="password" />
        <div className="text-help">
            {touched ? error : ""}
        </div>
    </div>
    );
  }
}

export default StPassword;