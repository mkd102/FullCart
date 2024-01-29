import { Component, OnInit } from '@angular/core';
import { Product } from './Product';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  
})
export class ProductComponent implements OnInit {

  currentproduct: Product=new Product();
  products: Array<Product>=new Array<Product>();
 
  constructor() { }
  ProductObj: Product =new Product();
  ngOnInit(): void {
  }

  Select(selected: Product)
  {
    this.currentproduct=Object.assign({},selected);
    
  }
  Add()
  {
    this.products.push(this.currentproduct);
    console.log(this.products);
    this.products=this.products.slice();
    this.currentproduct=new Product();
  }
  Cancel(){
    this.currentproduct=new Product();

  }
  Delete(){
    
  }
  Update(){
    for (let prod of this.products)
    {
      if(prod.name==this.currentproduct.name)
      {
        prod.brand= this.currentproduct.brand;
        prod.category=this.currentproduct.category;
        prod.description=this.currentproduct.description;
        prod.image=this.currentproduct.image;
        prod.price=this.currentproduct.price;
        prod.quantity=this.currentproduct.quantity;
      }
      this.currentproduct=new Product();
    }
  }
}
