import { ProductDetailsModel } from "../models/ProductDetailsModel";
import { getAllProducts } from "../services/NorthwindService";
import { useState, useEffect, Fragment } from "react";
import "./Products.css";

function Products({}) {
  const [products, setProducts] = useState(Array<ProductDetailsModel>);
  const [filteredProducts, setFilteredProducts] = useState(Array<ProductDetailsModel>);
  const [isLoading, setIsloading] = useState(Boolean)

  useEffect(() => {
    setIsloading(true)
    getAllProducts().then(res => {
      setProducts(res);
      setFilteredProducts(res);
      setIsloading(false)
    });
  }, []);

  function filterProductHandler(filteredName: string){
    const newFilteredList = products.filter(product => product.productName.toLowerCase().startsWith(filteredName.toLowerCase()));
    setFilteredProducts(newFilteredList);
  }

  return (
    <Fragment>
      <label>Filter product name:</label>
      <input type="text" onChange={event => filterProductHandler(event.target.value)}></input>
      {isLoading ? <h3>. . . loading . . .</h3> :
      <table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Category</th>
            <th>Supplier</th>
            <th>Quantity Per Unit</th>
            <th>Unit Price</th>
          </tr>
        </thead>
        <tbody>
          {filteredProducts.map((product) => (
            <tr key={product.productId}>
              <td>{product.productId}</td>
              <td>{product.productName}</td>
              <td>{product.categoryName}</td>
              <td>{product.supplierName}</td>
              <td>{product.quantityPerUnit}</td>
              <td>$ {product.unitPrice}</td>
            </tr>
          ))}
        </tbody>
      </table>}
    </Fragment>
  );
}

export default Products;