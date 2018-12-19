import React from "react";
import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from  'redux';
import reducers from './reducers';
import reduxPromise from 'redux-promise'; 
import reduxThunk from 'redux-thunk'; 

export default (
    {
        children, 
        initialState = { 
            auth: { authenticated: localStorage.getItem('token') }
        }
    }) => {
    const store=createStore(
        reducers, 
        initialState, 
        applyMiddleware(reduxPromise, reduxThunk))
    return (
        <Provider store={store}>
            {children}
        </Provider>
    )
    };


