import { AttributeTermModel } from "app/models/attribute-term.model";

export class AttributeModel {

    id:number ;

    name: string ;

    slug:string;

    type:number;

    terms:Array<AttributeTermModel> = new Array();
}