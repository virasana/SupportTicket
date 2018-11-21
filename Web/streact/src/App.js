import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
		  <p>Ticket Track</p>
          <p>
            &copy; Karunasoft Ltd 2018. All rights reserved.
          </p>
		  <p>Docker: ${SUPPORT_TICKET_REACT_IMAGE}</p>
          <a
            className="App-link"
            href="https://reactjs.org"
            target="_blank"
            rel="noopener noreferrer"
          >
		  
            Learn React
          </a>
        </header>
      </div>
    );
  }
}

export default App;
