import { Component, OnInit, Input } from '@angular/core';
import { ParserService } from '../../services/parser.service';
import { ParserRequestModel } from 'app/models/parserRequestModel';

@Component({
  selector: 'app-parse',
  templateUrl: './parse.component.html',
  styleUrls: ['./parse.component.css']
})
export class ParseComponent implements OnInit {

  @Input() productUrl:string;  
  title:string;
  data:string;
  elementId:string;
  parserRequst:ParserRequestModel = new ParserRequestModel();

  constructor(private parserService:ParserService) {     
    this.elementId = "elementIdtiny";
  }

  ngOnInit() {
  }
 
  getProduct(){
    this.parserRequst.productUrl = this.productUrl;
    this.parserService.parseByUrl(this.parserRequst).subscribe(response =>{             
        this.title =  response.title;
        this.data  = response.description;
    });
  }
}
