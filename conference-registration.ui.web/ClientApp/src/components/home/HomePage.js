import React from "react";
import { Link } from "react-router-dom";

const HomePage = () => (
  <div className="jumbotron">
    <h1>Conference Registration.</h1>
    <p>This is where you can register for the conference</p>
    <Link to="about" className="btn btn-primary btn-lg">
      Read More
    </Link>
  </div>
);

export default HomePage;
