import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IShoe } from 'src/app/Interfaces/IShoe';
import { CartService } from 'src/app/services/Cart/cart.service';

import { ProductsService } from 'src/app/services/Product/products.service';

@Component({
  selector: 'app-shoe-detail',
  templateUrl: './shoe-detail.component.html',
  styleUrls: ['./shoe-detail.component.scss']
})
export class ShoeDetailComponent implements OnInit {

  pageTitle = 'Product Detail';
  product: IShoe | undefined;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private productsService: ProductsService,
              private cartService: CartService) {
  }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (id) {
      this.getProduct(id);
    }
  }

  getProduct(id: number): void {
    this.productsService.getShoe(id).subscribe({
      next: (product: IShoe | undefined) => {
        if(typeof(product) != "undefined") 
          product.image = "../../../../assets/pics/" + product.image; 
        this.product = product; 
        console.log(this.product)}
    })
  }

  onBack(): void {
    this.router.navigate(['/shoes']);
  }

  public addToCart(): void{
    this.cartService.addToCart(this.product!.name);
  }
}
