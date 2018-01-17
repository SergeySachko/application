import { Component, OnInit } from '@angular/core';
import { ProductModel } from 'app/models/product.model';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  product:ProductModel = new ProductModel();
  elementId:string;
  tabcontainer:number;

  constructor() {
    this.elementId = "elementIdtiny";
    this.tabcontainer = 1;
   }

  ngOnInit() {
  }

  getProduct(product:ProductModel){
    this.product = product;
  }

  showTab(i:number)
  {
    this.tabcontainer  = i;
  }
}
