import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

class StValidationSummary extends React.Component {
  render() {
    const { className, meta: { error }} = this.props;
    return (
    <div className={className}>

        <div className="text-help">
          {((error && <span className="st-texthelp"><FontAwesomeIcon icon="exclamation"/>{' '}{error}</span>))}
        </div>
    </div>
    );
  }
}

export default StValidationSummary;