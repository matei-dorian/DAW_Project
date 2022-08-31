import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  public cart = new Map<string, number>();

  constructor() { }

  public addToCart(item: string){
    if(this.cart.has(item))
      this.cart.set(item, this.cart.get(item)! + 1)
    else
      this.cart.set(item, 1)
  }

  public printCart() : string {
    var output = "";
    this.cart.forEach((value, key) => {
      output = output + key + ": " + value + "\n"; 
    });
    return output;
  }
}
