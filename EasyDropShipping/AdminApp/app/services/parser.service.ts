import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { RequestHandlerHelper } from './request-handler-helper';
import { ParserRequestModel } from 'app/models/parserRequestModel';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ParserService extends  RequestHandlerHelper{

  constructor(private htppc : HttpClient) { 
    super();
  }

  parseByUrl(productUrl:ParserRequestModel) : Observable<any>{
    return this.htppc.post('/api/Parser/ByUrl', productUrl,{
      headers: new HttpHeaders().set('Content-Type', 'application/json'),
    })
  }

}
