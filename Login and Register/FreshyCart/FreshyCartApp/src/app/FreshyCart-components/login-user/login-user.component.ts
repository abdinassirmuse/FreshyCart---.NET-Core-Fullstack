import { Component, OnInit } from '@angular/core';
import { FreshyCartServiceService } from '../../FreshyCart-services/freshy-cart-service.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.css']
})
export class LoginUserComponent implements OnInit {
    status: string;
    errorMsg: string;
    msg: string;
    name: string;

    constructor(private _freshyCartService: FreshyCartServiceService, private router: Router) { 
    }

  ngOnInit() {

  }

    loginUser(form: NgForm) {
        this._freshyCartService.loginUser(form.value.email, form.value.password).subscribe(
            responseData => {
                this.status = responseData;
                if (this.status != "Invalid credentials") {
                    //sessionStorage.setItem('name', this.name);
                    sessionStorage.setItem('email', form.value.email);
                    sessionStorage.setItem('password', form.value.password);
                    this.router.navigate(['/home']);
                }
                else {
                    this.msg = this.status + ". Please try again";
                    alert(this.msg);
                }
            },
            responseErrorData => {
                this.errorMsg = responseErrorData;
                this.msg = "Some error occurred";
                alert(this.msg);
                console.log(this.errorMsg);

            },
            () => console.log("loginUser method executed successfully")
        );
    }

}
