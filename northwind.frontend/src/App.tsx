import Products from "./components/Products";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import "./App.css";
import HomePage from "./components/Home";
import RootLayout from "./components/Root";
import Suppliers from "./components/Supplier";

const router = createBrowserRouter([
  {
    path: "",
    element: <RootLayout />,
    children: [
      { path: "", element: <HomePage /> },
      { path: "products", element: <Products /> },
      { path: "suppliers", element: <Suppliers /> }
    ],
  },
]);

function App() {
  return <RouterProvider router={router} />;
}

export default App;
