import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ParserService } from '../../services/parser.service';
import { ParserRequestModel } from 'app/models/parserRequestModel';

@Component({
  selector: 'app-parse',
  templateUrl: './parse.component.html',
  styleUrls: ['./parse.component.css']
})
export class ParseComponent implements OnInit {

  @Input() productUrl:string;   
  @Output() onGetProduct: EventEmitter<any> = new EventEmitter<any>();
 
  parserRequst:ParserRequestModel = new ParserRequestModel(); 

  constructor(private parserService:ParserService) {        
  }

  ngOnInit() {
  }
 
  getProduct(){
    this.parserRequst.productUrl = this.productUrl;
    this.parserService.parseByUrl(this.parserRequst).subscribe(response =>{             
      this.onGetProductInfo(response);       
    });
  }
  onGetProductInfo(response:any){
    this.onGetProduct.emit(response);  
  }
}
