export class AttributeTermModel{
    
    id:number;

    name:string;

    slug:string;

    description:string;

    parent:AttributeTermModel = new AttributeTermModel();
}