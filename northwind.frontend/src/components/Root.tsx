import { Outlet } from "react-router-dom";
import NavBar from "./NavBar";

function RootLayout() {
  return (
    <div>
      <NavBar />
      <Outlet />
    </div>
  );
}

export default RootLayout;