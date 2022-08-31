import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { IShoe } from '../../Interfaces/IShoe';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private url = "https://localhost:44337/api/Shoe";
  constructor(private http: HttpClient) { }

  public getProducts(): Observable<IShoe[]> {
    return this.http.get<IShoe[]>(this.url);
  
  }

  getShoe(id: number): Observable<IShoe | undefined> {
    return this.getProducts()
      .pipe(
        map((products: IShoe[]) => products.find(p => p.id === id))
      );
  }
}
