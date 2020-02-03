import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginUserComponent } from './FreshyCart-components/login-user/login-user.component';
import { RegisterUserComponent } from './FreshyCart-components/register-user/register-user.component';
import { HomeComponent } from './FreshyCart-components/home/home.component';
import { ViewProductsComponent } from './FreshyCart-components/view-products/view-products.component';


const routes: Routes = [
    { path: '', component: RegisterUserComponent },
    //{ path: '/', component: RegisterUserComponent },
    { path: 'home', component: HomeComponent },
    { path: 'registerUser', component: RegisterUserComponent },
    { path: 'loginUser', component: LoginUserComponent },
    { path: 'viewProducts', component: ViewProductsComponent },
    { path: '**', component: RegisterUserComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
