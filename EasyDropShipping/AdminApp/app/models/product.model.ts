import { Data } from "@angular/router/src/config";
import { AttributeModel } from "app/models/attribute.model";

export class ProductModel{

    id:number;

    productType:string;
        
    attributes:Array<AttributeModel> = new Array();

    productUrl:string;
    
    title:string;

    visibilityStr:string;
       
    strockStatusStr: string ;

    regularPrice:number;      

    salePrice:number;
    
    salePercent:number;
       
    price:number;
       
    weight:number;  

    length: number;   

    width: number;

    height :number;

    salePriceDateFrom:Data;

    salePriceDateTo:Data;

    shortDescription:string;
   
    description:string;  

    imageURL:string;  
}
