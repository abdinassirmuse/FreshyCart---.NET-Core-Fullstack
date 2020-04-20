import { Component, OnInit } from '@angular/core';
import { FreshyCartServiceService } from '../../FreshyCart-services/freshy-cart-service.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ICart } from '../../FreshyCart-interfaces/ICart';

@Component({
  selector: 'app-update-cart',
  templateUrl: './update-cart.component.html',
  styleUrls: ['./update-cart.component.css']
})
export class UpdateCartComponent implements OnInit {

  emailId: string;
  productId: number;
  productName: string;
  productImage: string;
  price: number;
  quantity: number;
  cartProd: ICart;
  status: boolean = false;
  errorMsg: string;

  constructor(private _freshyCartService: FreshyCartServiceService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.emailId = sessionStorage.getItem("email");
    this.productId = parseInt(this.route.snapshot.params['productId']);
    this.productName = this.route.snapshot.params['productName'];
    this.productImage = this.route.snapshot.params['productImage'];
    this.price = this.route.snapshot.params['price'];
    this.quantity = parseInt(this.route.snapshot.params['quantity']);
  }

  updateCart(qty: number) {
    this._freshyCartService.updateCartProducts(this.productId, this.emailId, this.productName, this.productImage, qty).subscribe(
      responseUpdateCartStatus => {
        this.status = responseUpdateCartStatus;
        if (this.status) {
          alert(this.productName + " quantity updated successfully.");
          this.router.navigate(['/viewCart']);
        }
        else {
          alert("Some error occured, please try after some time.");
        }
      },
      responseUpdateCartError => {
        this.errorMsg = responseUpdateCartError;
        console.log(this.errorMsg);
        alert("Some error occured, please try after some time.");
      },
      () => console.log("UpdateCart method executed successfully.")
    );
  }

}
