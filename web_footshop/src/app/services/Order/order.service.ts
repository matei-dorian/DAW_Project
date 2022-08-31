import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IOrder } from '../../Interfaces/IOrder';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private url = "https://localhost:44337/api/Order/create-order";
  constructor(private http: HttpClient) { }

  public postOrder(order: IOrder) {
    order.distributor = "Cargus";
    return this.http.post<String>(this.url, order);
  
  }
}
