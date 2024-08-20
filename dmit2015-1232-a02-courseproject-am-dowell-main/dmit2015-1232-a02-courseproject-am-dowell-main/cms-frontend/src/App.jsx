import './App.css';
import React, { useState } from 'react';
import { BrowserRouter as BrowserRouter, Routes, Route } from 'react-router-dom';
import HeaderComponent from './components/HeaderComponent';
import FooterComponent from './components/FooterComponent';
import Buttons from './components/Buttons';
import LoginForm from './components/LoginForm';
import WelcomeComponent from './components/WelcomeComponent';
import { request, setAuthHeader } from './services/CityService';

function App() {
  const [componentToShow, setComponentToShow] = useState("welcome");

  const login = () => {
    setComponentToShow("login");
  };

  const logout = () => {
    setComponentToShow("welcome");
    setAuthHeader(null);
  };

  const onLogin = (e, username, password) => {
    e.preventDefault();
    request(
      "POST",
      "/login",
      {
        login: username,
        password: password
      }
    ).then(
      (response) => {
        setAuthHeader(response.data.token);
        setComponentToShow("messages");
      }
    ).catch(
      (error) => {
        setAuthHeader(null);
        setComponentToShow("welcome");
      }
    );
  };

  const onRegister = (event, firstName, lastName, username, password) => {
    event.preventDefault();
    request(
      "POST",
      "/register",
      {
        firstName: firstName,
        lastName: lastName,
        login: username,
        password: password
      }
    ).then(
      (response) => {
        setAuthHeader(response.data.token);
        setComponentToShow("messages");
      }
    ).catch(
      (error) => {
        setAuthHeader(null);
        setComponentToShow("welcome");
      }
    );
  };

  return (
    <>
    <BrowserRouter>
      <HeaderComponent/>
      <Buttons
          login={this.login}
          logout={this.logout}
        />
         {/* TODO: Check this, play with rendering. */}
        {this.state.componentToShow === "welcome" && <WelcomeComponent /> }
        {this.state.componentToShow === "login" && <LoginForm onLogin={this.onLogin} onRegister={this.onRegister} />}
        {this.state.componentToShow === "messages" && 
          <Routes>
            {/* //http://localhost3000 */}
            <Route path='/' element = {<WelcomeComponent/>}> </Route>
            {/* //http://localhost3000 */}
            <Route path='/' element = {<ListCityComponent/>}> </Route>
            {/* //http://localhost3000/cities */}
            <Route path='/cities' element = {<ListCityComponent/>}> </Route>
            {/* //http://localhost3000/add-city */}
            <Route path='/add-city' element = {<CityComponent/>}> </Route>
              {/* //http://localhost3000/edit-city/1 */}
              <Route path='/edit-city/:id' element = {<CityComponent/>}> </Route>
          </Routes>
          }
      <FooterComponent/>
    </BrowserRouter>
    </>
  )
};

export default App