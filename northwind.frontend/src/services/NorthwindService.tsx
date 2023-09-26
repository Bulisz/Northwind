import axios from 'axios';
import { ProductDetailsModel } from '../models/ProductDetailsModel';
import { SupplierModel } from '../models/SupplierModel';
import { SupplierOrdersModel } from '../models/SupplierOrdersModel';

const BASE_URL = process.env.REACT_APP_DEV_BASE_URL

export async function getAllProducts(): Promise<Array<ProductDetailsModel>> {
    const response = await axios.get<Array<ProductDetailsModel>>(`${BASE_URL}/GetAllProducts`);
    return response.data;
  }

  export async function getAllSupplier(): Promise<Array<SupplierModel>> {
    const response = await axios.get<Array<SupplierModel>>(`${BASE_URL}/GetAllSuppliers`);
    return response.data;
  }

export async function getOrdersOfSupplier(supplierId: number): Promise<Array<SupplierOrdersModel>> {
    const response = await axios.get<Array<SupplierOrdersModel>>(`${BASE_URL}/GetOrdersOfSupplier/${supplierId}`);
    return response.data;
  }