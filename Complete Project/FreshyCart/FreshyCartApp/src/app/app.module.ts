import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpHeaders, HttpClientModule} from '@angular/common/http'


import { AppComponent } from './app.component';
import { LoginUserComponent } from './FreshyCart-components/login-user/login-user.component';
import { RegisterUserComponent } from './FreshyCart-components/register-user/register-user.component';
import { routing } from './app.routing';
import { HomeComponent } from './FreshyCart-components/home/home.component';
import { ViewProductsComponent } from './FreshyCart-components/view-products/view-products.component';
import { ViewCartComponent } from './FreshyCart-components/view-cart/view-cart.component';
import { UpdateCartComponent } from './FreshyCart-components/update-cart/update-cart.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginUserComponent,
    RegisterUserComponent,
    HomeComponent,
    ViewProductsComponent,
    ViewCartComponent,
    UpdateCartComponent
  ],
  imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      routing
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
