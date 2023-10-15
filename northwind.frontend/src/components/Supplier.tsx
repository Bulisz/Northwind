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
    const [supplierOrders, setSupplierOrders] = useState(Array<SupplierOrdersModel>);
    const [isLoading, setIsloading] = useState(Boolean)
  
    useEffect(() => {
      getAllSupplier().then(res => setSuppliers(res));
    }, []);
  
    function supplierChangeHandler(supplierId: string) {
      setIsloading(true);
      if(!isNaN(+supplierId)){
        getOrdersOfSupplier(+supplierId).then(res => {
          setSupplierOrders(res)
          setIsloading(false);
        });
      }
    }
  
    return (
      <Fragment>
        <label>Choose a supplier:</label>
        <select defaultValue={'DEFAULT'} onChange={(event) => supplierChangeHandler(event.target.value)}>
            <option value="DEFAULT" disabled>-- Choose a supplier --</option>
            {suppliers.map((supplier) => (
                <option key={supplier.supplierId} value={supplier.supplierId}>
                    {supplier.companyName}
                </option>
          ))}
        </select>
        {isLoading ? <h3>. . . loading . . .</h3> :
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
        </table>}
      </Fragment>
    );
  }
  
  export default Suppliers;