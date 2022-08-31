import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IShoe } from 'src/app/Interfaces/IShoe';
import { IUser } from 'src/app/Interfaces/IUser';
import { DataService } from 'src/app/services/Account/data.service';
import { CartService } from 'src/app/services/Cart/cart.service';
import { ProductsService } from 'src/app/services/Product/products.service';

@Component({
  selector: 'app-shoes',
  templateUrl: './shoes.component.html',
  styleUrls: ['./shoes.component.scss']
})
export class ShoesComponent implements OnInit{

  public pageTitle: string = 'Our Products:';
  public showImage: boolean = true;
  public imageWidth: number = 50;
  public imageMargin: number = 2;
  private _listFilter: string = '';
  public currentUser: string | null = '';
  public filterForm: FormGroup =  new FormGroup({
    filter: new FormControl(''),
  });

  public subscription!: Subscription;

  constructor(
    private router: Router,
    public dataService: DataService,
    private productsService: ProductsService,
    private cartService: CartService
  ) { }

  get listFilter(): string {
    return this._listFilter;
  }

  set listFilter(value: string) {
    this._listFilter = value;
    this.filteredProducts = this.performFilter(value);
  }

  public products: IShoe[] = [];  
  public filteredProducts: any[] = [];

  public toggleImage() : void {
      console.log(this.products);
      this.showImage = !this.showImage;
  }

  public performFilter(filterBy: string): any[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.products.filter((product) => product.name.toLocaleLowerCase().includes(filterBy))
  }

  onRatingClicked(message: string): void {
    this.pageTitle = 'Our Products: ' + message;
  }

  ngOnInit(): void {
    this.productsService.getProducts().subscribe({
      next: products => {
        products.forEach(product => product.image = "../../../../assets/pics/" + product.image);
        console.log(products);
        this.products = products; 
        this.filteredProducts = this.products;}
    });

    this.dataService.currentUser.subscribe({next: (user: IUser) => { 
        if(user.email === ''){
          this.currentUser = localStorage.getItem('currentEmail');
        }
        else{
          localStorage.setItem('currentEmail', user.email); 
          this.currentUser = user.email}}});
  }

  public logout(): void {
    localStorage.setItem("Role", "null");
    this.router.navigate(["auth/login"]);
  }

  public placeOrder(): void {
    if(this.cartService.cart.size == 0)
      alert("Your cart is empty!");
    else
      this.router.navigate(["/order"]);
  }
}
