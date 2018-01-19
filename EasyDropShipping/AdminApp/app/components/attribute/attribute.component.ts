import { Component, OnInit, Input } from '@angular/core';
import { AttributeModel } from 'app/models/attribute.model';

@Component({
  selector: 'app-attribute',
  templateUrl: './attribute.component.html',
  styleUrls: ['./attribute.component.css']
})
export class AttributeComponent implements OnInit {

  @Input() productUrl:AttributeModel;  

  constructor() { }

  ngOnInit() {
    
  }

}
