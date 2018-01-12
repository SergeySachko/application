import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './components/app/app.component';
import { NavmenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ProductComponent } from './components/product/product.component';
import { ParseComponent } from './components/parse/parse.component' ;


import { ParserService } from './services/parser.service';
import { RequestHandlerHelper } from './services/request-handler-helper';


@NgModule({
  declarations: [
    AppComponent,
    NavmenuComponent,
    HomeComponent,
    ProductComponent,
    ParseComponent
  ],
  imports: [
    BrowserModule,
    FormsModule, 
    HttpClientModule,
    RouterModule.forRoot([                       
      { path: 'Account/Admin', redirectTo: 'home' },
      { path: 'home', component: HomeComponent },
      { path: 'product', component: ProductComponent },
      { path: '**', redirectTo: 'home' }
  ]),
  ],
  providers: [ParserService,RequestHandlerHelper],
  bootstrap: [AppComponent]
})
export class AppModule { }
