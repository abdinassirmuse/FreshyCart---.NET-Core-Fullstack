import { Component, OnInit } from '@angular/core';
import { FreshyCartServiceService } from 'src/app/FreshyCart-services/freshy-cart-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  constructor(private _freshyCartService: FreshyCartServiceService, private router: Router) { 
  }

  ngOnInit() {
  }

  logoutCustomer() {
    sessionStorage.removeItem('name');
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('password');
    this.router.navigate(['/loginUser']);
  }

}
