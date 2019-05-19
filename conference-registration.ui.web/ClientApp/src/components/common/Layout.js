/* eslint-disable react/prop-types */
import React from "react";
import { Container } from "reactstrap";
import NavMenu from "./NavMenu";

// eslint-disable-next-line react/display-name
export default props => (
  <div>
    <NavMenu />
    <Container>{props.children}</Container>
  </div>
);
