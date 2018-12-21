import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

class StTextArea extends React.Component {
  
  render() {
    const { input, label, className,
      meta: { error, touched  }} = this.props;
    return (
    <div className={className}>
        <label>{label}</label>
        <textarea {...input} className="form-control" />
        <div className="text-help">
            {touched && ((error && <span className="st-texthelp"><FontAwesomeIcon className="st-exclamation" icon="exclamation"/>{error}</span>))}
        </div>
    </div>
    );
  }
}

export default StTextArea;