import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CreateuserComponent } from './createuser/createuser.component';
import { HomeComponent } from './home/home.component';
import { Product } from './product/Product';
import { ProductComponent } from './product/product.component';

const routes: Routes = [{path:"Login",component:LoginComponent},{path:"CreateCustomer",component:CreateuserComponent},{path:"Home",component:HomeComponent},{path:"Product",component:ProductComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
