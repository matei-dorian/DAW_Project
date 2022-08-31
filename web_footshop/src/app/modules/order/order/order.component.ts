import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { CartService } from 'src/app/services/Cart/cart.service';
import { OrderService } from 'src/app/services/Order/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  public cartMessage: string = "";

  public orderForm: FormGroup =  new FormGroup({
    address: new FormControl(''),
    city: new FormControl(''),
  });

  constructor(
    private router : Router,
    public http: HttpClient,
    private orderService: OrderService,
    private cartService: CartService) { }

  get address(): AbstractControl | null{
    return this.orderForm.get('address');
  }

  get city(): AbstractControl | null{
    return this.orderForm.get('city');
  }

  ngOnInit(): void {
    this.cartMessage = this.cartService.printCart();
    console.log(this.cartMessage);
  }

  public placeOrder(): void{
    this.orderService.postOrder(this.orderForm.value).subscribe({
      next: (_) => {
        alert("Order placed!");
        this.cartService.cart.clear();
        this.router.navigate(['/shoes']);
      } 
    });
  }
}
