import {
    getAllSupplier,
    getOrdersOfSupplier,
  } from "../services/NorthwindService";
  import { useState, useEffect, Fragment } from "react";
  import { SupplierOrdersModel } from "../models/SupplierOrdersModel";
  import { SupplierModel } from "../models/SupplierModel";
  import "./Supplier.css";
  
  function Suppliers() {
    const [suppliers, setSuppliers] = useState(Array<SupplierModel>);
    const [supplierOrders, setSupplierOrders] = useState(
      Array<SupplierOrdersModel>
    );
  
    useEffect(() => {
      getAllSupplier().then(res => setSuppliers(res));
    }, []);
  
    function supplierChangeHandler(supplierId: string) {
      if(!isNaN(+supplierId)){
        getOrdersOfSupplier(+supplierId).then(res => setSupplierOrders(res));
      }
    }
  
    return (
      <Fragment>
        <label>Choose a supplier:</label>
        <select onChange={(event) => supplierChangeHandler(event.target.value)}>
            <option>-- Supplier list--</option>
            {suppliers.map((supplier) => (
                <option key={supplier.supplierId} value={supplier.supplierId}>
                    {supplier.companyName}
                </option>
          ))}
        </select>
        <table>
          <thead>
            <tr>
              <th>Product Name</th>
              <th>Ordered Amount</th>
            </tr>
          </thead>
          <tbody>
            {supplierOrders.map((orders) => (
              <tr key={orders.productName}>
                <td>{orders.productName}</td>
                <td>$ {orders.amount}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </Fragment>
    );
  }
  
  export default Suppliers;