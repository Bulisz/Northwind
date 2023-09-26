import "./NavBar.css";
import { Link } from "react-router-dom";

function NavBar() {
  return (
    <div className="navbar">
      <Link className="link" to="">Home</Link>
      <Link className="link" to="products">Products</Link>
      <Link className="link" to="suppliers">Suppliers</Link>
    </div>
  );
}

export default NavBar;