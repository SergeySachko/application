import { Component, OnInit } from '@angular/core';
import { ProductModel } from 'app/models/product.model';
import { DisplayModalService } from 'app/services/display-modal.service';
import { AttributeModel } from 'app/models/attribute.model';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  product:ProductModel = new ProductModel();
  elementId:string;
  tabcontainer:number;

  constructor(private  modalService:DisplayModalService) {
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

  addAttribute(){
    this.modalService.showAttributeModal("Добавить новый аттрибут", new AttributeModel()).subscribe( (result:any) => {
       this.product.attributes.push(result);
    })
  }
}
