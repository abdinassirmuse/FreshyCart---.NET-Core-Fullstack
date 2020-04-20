import { Component, OnInit } from '@angular/core';
import { FreshyCartServiceService } from 'src/app/FreshyCart-services/freshy-cart-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  email: string;

  constructor(private _freshyCartService: FreshyCartServiceService, private router: Router) { 
    this.email = sessionStorage.getItem('email');
  }

  ngOnInit() {
    this.email = sessionStorage.getItem('email');
    if(this.email == null)
    {
      this.router.navigate(['/loginUser']);
    }
  }

  logoutCustomer() {
    //sessionStorage.setItem('name', null);
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('password');
    this.router.navigate(['/loginUser']);
  }

}
