import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import {RouterModule} from "@angular/router";
import {LocationStrategy, HashLocationStrategy} from '@angular/common';

import {AppRoutingModule} from "./app.routes";
import { AppComponent } from './app.component';

//App Modules

import { CoreModule } from './core/core.module'

// App views
import {MainViewModule} from "./views/main-view/main-view.module";
import {MinorViewModule} from "./views/minor-view/minor-view.module";
import {LoginModule} from "./views/login/login.module";
import {RegisterModule} from "./views/register/register.module";

// App modules/components
import {LayoutsModule} from "./components/common/layouts/layouts.module";

// PlayFactory Imports

import { PlayFactoryPagesModule } from "../playfactory/angular/pages/playfactory-pages.module"

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    // Angular modules
    BrowserModule,
    HttpModule,

    // Views
    MainViewModule,
    MinorViewModule,
    LoginModule,
    RegisterModule,

    // Modules
    LayoutsModule,
    AppRoutingModule,
    CoreModule,

    //PlayFactory
    PlayFactoryPagesModule
  ],
  //providers: [{provide: LocationStrategy, useClass: HashLocationStrategy}], 
  bootstrap: [AppComponent]
})
export class AppModule { }
