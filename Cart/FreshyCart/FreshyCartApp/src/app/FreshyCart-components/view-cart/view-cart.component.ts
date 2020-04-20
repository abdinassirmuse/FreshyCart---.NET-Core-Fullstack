import { Component, OnInit } from '@angular/core';
import { ICartProducts } from '../../FreshyCart-interfaces/ICartProducts';
import { FreshyCartServiceService } from '../../FreshyCart-services/freshy-cart-service.service';
import { Router } from '@angular/router';
import { IProducts } from '../../FreshyCart-interfaces/IProducts';

@Component({
  selector: 'app-view-cart',
  templateUrl: './view-cart.component.html',
  styleUrls: ['./view-cart.component.css']
})
export class ViewCartComponent implements OnInit {

    errorMsg: string;
    emailId: string;
    cartProducts: ICartProducts[];
    showError: boolean = false;
    showMsgDiv: boolean = false;
    status: boolean = false;

    constructor(private _freshyCartService: FreshyCartServiceService, private router: Router) { }

    ngOnInit() {

        this.emailId = sessionStorage.getItem('email');

        this.getCartProducts();
    }

    getCartProducts() {
        this._freshyCartService.getCartProducts(this.emailId)
            .subscribe(
                resCartProductData => {
                    this.cartProducts = resCartProductData;
                    this.showMsgDiv = false;
                    if (this.cartProducts.length == 0) {
                        this.showError = true;
                        this.errorMsg = "Your cart is empty.";
                    }
                },
                resCartProductError => {
                    this.cartProducts = null;
                    this.errorMsg = resCartProductError;
                    console.log(this.errorMsg);
                    if (this.cartProducts.length == 0) {
                        this.showError = true;
                        this.errorMsg = "No records found.";
                    }
                },
                () => console.log("GetCartProducts method executed successfully")
          );
    }

    // updateCart(prod: ICartProducts)
    // {
    //     this.router.navigate(['updateCart/', prod.productName, prod.productImage, prod.price, prod.quantity]);
    // }

    updateCart(prod: ICartProducts) {
        this.router.navigate(['/updateCart', prod.productId, prod.productName, prod.productImage, prod.quantity, prod.price]);
      }

    deleteFromCart(prod: IProducts) {
        this._freshyCartService.deleteFromCart(prod.productId, this.emailId)
        .subscribe(
            responseDeleteData => {
                this.status = responseDeleteData;
                if(this.status)
                {
                    alert(prod.productName + ' deleted from cart');
                    this.ngOnInit();
                }
                else
                {
                    alert('Could not delete ' + prod.productName + 'from cart');
                }
            },
            responseDeleteDataError => {
                this.errorMsg = responseDeleteDataError;
                alert('Some error occurred!!!')
                console.log(this.errorMsg);
            },
            () => console.log('DeleteFromCart method executed successfully')
        );
    }



}
