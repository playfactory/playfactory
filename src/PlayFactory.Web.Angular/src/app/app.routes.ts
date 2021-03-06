import { NgModule } from '@angular/core';
import { Routes, RouterModule } from "@angular/router";
import { mainViewComponent    } from "./views/main-view/main-view.component";
import { minorViewComponent   } from "./views/minor-view/minor-view.component";
import { loginComponent       } from "./views/login/login.component";
import { registerComponent    } from "./views/register/register.component";
import { blankComponent       } from "./components/common/layouts/blank.component";
import { basicComponent       } from "./components/common/layouts/basic.component";
import { PageNotFoundComponent } from "../playfactory/angular/pages/page-notfound.component"


const routes: Routes = [
  // Main redirect
  {path: '', redirectTo: 'mainView', pathMatch: 'full'},

  // App views
  {
    path: '', component: basicComponent,
    children: [
      {path: 'mainView', component: mainViewComponent, pathMatch: 'full'},
      {path: 'minorView', component: minorViewComponent}
    ]
  },
  {
    path: '', component: blankComponent,
    children: [
      { path: 'login', component: loginComponent },
      { path: 'register', component: registerComponent }
    ]
  },

  // Handle all other routes
  {path: '**',    component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

