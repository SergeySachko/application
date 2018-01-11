import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavmenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ProductComponent } from './components/product/product.component' ;

@NgModule({
  declarations: [
    AppComponent,
    NavmenuComponent,
    HomeComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([                       
      { path: 'Account/Admin', redirectTo: 'home' },
      { path: 'home', component: HomeComponent },
      { path: '**', redirectTo: 'home' }
  ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
