import { Component, OnInit } from '@angular/core';
import { FreshyCartServiceService } from '../../FreshyCart-services/freshy-cart-service.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {

    status: boolean;
    errorMsg: string;
    msg: string;

    constructor(private _freshyCartService: FreshyCartServiceService, private router: Router) { }

  ngOnInit() {
  }

    registerUser(form: NgForm) {
        this._freshyCartService.registerUser(form.value.name, form.value.email, form.value.password).subscribe(
            responseData => {
                this.status = responseData;
                if (this.status) {
                    sessionStorage.setItem('name', form.value.name);
                    sessionStorage.setItem('email', form.value.email);
                    sessionStorage.setItem('password', form.value.password);
                    this.router.navigate(['/home']);
                }
                else {
                    this.msg = "Registration Failed. Please try again.";
                    alert(this.msg);
                }
            },
            responseErrorData => {
                this.errorMsg = responseErrorData;
                console.log(this.errorMsg);
                this.msg = "Some error occurred";
                alert(this.msg);
            },
            () => console.log("registerUser method executed successfully")
        );
    }

}
