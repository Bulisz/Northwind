import { ProductDetailsModel } from "../models/ProductDetailsModel";
import { getAllProducts } from "../services/NorthwindService";
import { useState, useEffect } from "react";
import "./Products.css";

function Products({}) {
  const [products, setProducts] = useState(Array<ProductDetailsModel>);
  const [filteredProducts, setfilteredProducts] = useState(Array<ProductDetailsModel>);

  useEffect(() => {
    getAllProducts().then(res => {
      setProducts(res);
      setfilteredProducts(res);
    });
  }, []);

  function filterProductHandler(filteredName: string){
    const newFilteredList = products.filter(product => product.productName.toLowerCase().startsWith(filteredName.toLowerCase()));
    setfilteredProducts(newFilteredList);
  }

  return (
    <div>
      <label>Filter product name:</label>
      <input type="text" onChange={event => filterProductHandler(event.target.value)}></input>
      <table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Supplier</th>
            <th>Category</th>
            <th>Quantity Per Unit</th>
            <th>Unit Price</th>
          </tr>
        </thead>
        <tbody>
          {filteredProducts.map((product) => (
            <tr key={product.productId}>
              <td>{product.productId}</td>
              <td>{product.productName}</td>
              <td>{product.supplierName}</td>
              <td>{product.categoryName}</td>
              <td>{product.quantityPerUnit}</td>
              <td>{product.unitPrice}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Products;