import { Data } from "@angular/router/src/config";

export class ProductModel{

    id:number;

    productType:string;
        
    productCategory:string;

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
