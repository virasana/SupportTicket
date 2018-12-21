import axios from 'axios';
import { AUTH_USER, AUTH_ERROR } from './action-types';

const ROOT_URL = process.env.REACT_APP_API_URL;

export const signup = (formProps, callback) => async dispatch => {
    await axios.post(
      `${ROOT_URL}/signup`,
      formProps
    )
    .then((response) => {
      dispatch({ type: AUTH_USER, payload: response.data.token });
      localStorage.setItem('token', response.data.token);
      callback();
    })
    .catch((error) => {
      if(error.response){
        console.log('errordata',error.response.data);
        console.log('errorstatus', error.response.status);
        console.log('errorheaders', error.response.headers);
      }
      dispatch({ type: AUTH_ERROR, payload: error.response.data });
    });
};

export const signin = (formProps, callback) => async dispatch => {
  try {
    const response = await axios.post(
      `${ROOT_URL}/authenticate`,
      formProps
    );
    
    dispatch({ type: AUTH_USER, payload: response.data.token });
    localStorage.setItem('token', response.data.token);
    callback();
  } catch (e) {
    dispatch({ type: AUTH_ERROR, payload: 'Invalid login credentials' });
  }
};

export const signout = () => {
  localStorage.removeItem('token');

  return {
    type: AUTH_USER,
    payload: ''
  };
};