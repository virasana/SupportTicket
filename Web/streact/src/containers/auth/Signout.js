import React, { Component } from 'react';
import { connect } from 'react-redux';
import * as actions from '../../actions/auth-actions';
import requireAuth from './requireAuth';

class Signout extends Component {
  componentDidMount() {
    this.props.signout();
  }

  render() {
    return <div>Sorry to see you go (you should be redirected to Sign In)</div>;
  }
}

export default requireAuth(connect(null, actions)(Signout));
