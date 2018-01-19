import { Component, AfterViewInit} from '@angular/core';
import { DialogComponent, DialogService } from "ng2-bootstrap-modal";
import { AttributeModel } from 'app/models/attribute.model';
import { AttributeTermModel } from 'app/models/attribute-term.model';

export interface DialogModel{  
  title:string;  
  attribute:AttributeModel
}

@Component({
  selector: 'app-attribute-modal',
  templateUrl: './attribute-modal.component.html',
  styleUrls: ['./attribute-modal.component.css']
})
export class AttributeModalComponent extends DialogComponent<DialogModel, AttributeModel> implements DialogModel,AfterViewInit {

  title:string;  
  attribute:AttributeModel;    

  constructor(dialogService: DialogService){ 
      super(dialogService);      
  }
  confirm() {         
      this.result = this.attribute;                    
      this.close();
  }   
  
  ngAfterViewInit(){      
  }

  AddNewTerms(){

    let term = new AttributeTermModel();   
    this.attribute.terms.push(term);
    
  }

}
