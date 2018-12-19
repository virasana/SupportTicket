import React from 'react';

class StTextBox extends React.Component {
  render() {
    const { input, label, className, meta: { touched, error }} = this.props;
    return (
    <div className={className}>
        <label>{label}</label>
        <input {...input} className="form-control" type="text" />
        <div className="text-help">
            {touched ? error : ""}
        </div>
    </div>
    );
  }
}

export default StTextBox;