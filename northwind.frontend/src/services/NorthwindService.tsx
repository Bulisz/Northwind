import axios from 'axios';
import { ProductDetailsModel } from '../models/ProductDetailsModel';

const BASE_URL = 'https://localhost:5001/Northwind'

export async function getAllProducts(): Promise<Array<ProductDetailsModel>> {
    const response = await axios.get<Array<ProductDetailsModel>>(`${BASE_URL}/GetAllProducts`);
    return response.data;
  }