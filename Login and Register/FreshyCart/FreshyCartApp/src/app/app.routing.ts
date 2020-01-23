import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginUserComponent } from './FreshyCart-components/login-user/login-user.component';
import { RegisterUserComponent } from './FreshyCart-components/register-user/register-user.component';
import { HomeComponent } from './FreshyCart-components/home/home.component';


const routes: Routes = [
    { path: '', component: RegisterUserComponent },
    { path: 'home', component: HomeComponent },
    { path: 'registerUser', component: RegisterUserComponent },
    { path: 'loginUser', component: LoginUserComponent },
    { path: '**', component: RegisterUserComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
