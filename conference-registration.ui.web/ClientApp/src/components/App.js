import React from "react";
import { Route, Switch } from "react-router-dom";
import HomePage from "./home/HomePage";
import AboutPage from "./about/AboutPage";
import PageNotFound from "./common/PageNotFound";
import AttendeesPage from "./attendees/AttendeesPage";
import ManageAttendeePage from "./attendees/ManageAttendeePage";
import ManageRegistrationPage from "./registration/ManageRegistrationPage";
import Layout from "./common/Layout";
import RegistrationsPage from "./registration/RegistrationsPage";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function App() {
  return (
    <Layout>
      <Switch>
        <Route exact path="/" component={HomePage} />
        <Route exact path="/about" component={AboutPage} />
        <Route exact path="/Attendees" component={AttendeesPage} />
        <Route exact path="/Attendee/:id" component={ManageAttendeePage} />
        <Route exact path="/Attendee" component={ManageAttendeePage} />
        <Route exact path="/Registrations" component={RegistrationsPage} />
        <Route
          exact
          path="/Registration/:id"
          component={ManageRegistrationPage}
        />
        <Route exact path="/Registration" component={ManageRegistrationPage} />
        <Route component={PageNotFound} />
      </Switch>
      <ToastContainer autoClose={3000} hideProgressBar />
    </Layout>
  );
}

export default App;
