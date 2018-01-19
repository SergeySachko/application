import { Injectable } from '@angular/core';
import { DialogService } from "ng2-bootstrap-modal";
import { AttributeModalComponent } from 'app/components/common/attribute-modal/attribute-modal.component';
import { AttributeModel } from 'app/models/attribute.model';


@Injectable()
export class DisplayModalService {    
    constructor(private dialogService: DialogService) { }

    showAttributeModal(title:string,attribute:AttributeModel): any {        
        return this.dialogService.addDialog(AttributeModalComponent,{title :title, attribute : attribute});       
    };      
}