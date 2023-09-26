import { Outlet } from "react-router-dom";
import NavBar from "./NavBar";
import { Fragment } from "react";

function RootLayout() {
  return (
    <Fragment>
      <NavBar />
      <Outlet />
    </Fragment>
  );
}

export default RootLayout;