import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { TinymceModule } from 'angular2-tinymce';


import { AppComponent } from './components/app/app.component';
import { NavmenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ProductComponent } from './components/product/product.component';
import { ParseComponent } from './components/parse/parse.component' ;


import { ParserService } from './services/parser.service';
import { RequestHandlerHelper } from './services/request-handler-helper';
import { TinymceEditorComponent } from './components/common/tinymce-editor.component/tinymce-editor.component.component';
import { AttributeComponent } from 'app/components/attribute/attribute.component';
import { AttributeModalComponent } from 'app/components/common/attribute-modal/attribute-modal.component';
import { DisplayModalService } from 'app/services/display-modal.service';
import { BootstrapModalModule } from 'ng2-bootstrap-modal';



@NgModule({
  declarations: [
    AppComponent,    
    NavmenuComponent,
    HomeComponent,
    ProductComponent,
    ParseComponent,
    TinymceEditorComponent,
    AttributeComponent,    
    AttributeModalComponent
  ],
  imports: [
    BrowserModule,
    FormsModule, 
    HttpClientModule,
    BootstrapModalModule.forRoot({ container: document.body }),
    TinymceModule.withConfig({}),
    RouterModule.forRoot([                       
      { path: 'Account/Admin', redirectTo: 'home' },
      { path: 'home', component: HomeComponent },
      { path: 'product', component: ProductComponent },
      { path: '**', redirectTo: 'home' }
  ]),
  ],
  providers: [ParserService,RequestHandlerHelper, DisplayModalService],
  bootstrap: [AppComponent],
  entryComponents : [AttributeModalComponent]
})
export class AppModule { }
