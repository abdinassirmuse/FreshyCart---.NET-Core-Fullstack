import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ISlideShow } from '../../FreshyCart-interfaces/ISlideShow';
import { IFeaturedProd } from '../../FreshyCart-interfaces/IFeaturedProd';
import { IProducts } from '../../FreshyCart-interfaces/IProducts';
import { FreshyCartServiceService } from '../../FreshyCart-services/freshy-cart-service.service';


@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent implements OnInit {

  productList: IProducts[];
  //slideShowList: ISlideShow[];
  featuredProdList: IFeaturedProd[];
  errMsg: string;
  status: boolean = false;
  showMsgDiv: boolean = false;
  message: string;
  email: string;
  password: string;
  addToCartStatus: number;


    constructor(private _freshyCartService: FreshyCartServiceService, private router: Router) {
        this.email = sessionStorage.getItem('email');
        this.password = sessionStorage.getItem('password');
    }

    ngOnInit() {

        
        this.getAllProducts();
        //this.GetSlideShow();
        this.GetFeaturedProducts();
        
        if (this.productList == null) {
            this.showMsgDiv = true;
            this.message = "No products available";
        }
        
        console.log(this.email);
        console.log(this.password);

    }

  getAllProducts() {
    this._freshyCartService.getAllProducts().subscribe(
      responseProductData => {
        this.productList = responseProductData;
        this.showMsgDiv = false;
      },
      responseProductError => {
        this.productList = null;
        this.errMsg = responseProductError;
        console.log(this.errMsg);
      },
      () => console.log("getAllProducts method executed successfully")
    )
  }


  // GetSlideShow() {
  //   this._freshyCartService.GetSlideShow().subscribe(
  //     responseProductData => {
  //       this.slideShowList = responseProductData;
  //       this.showMsgDiv = false;
  //     },
  //     responseProductError => {
  //       this.slideShowList = null;
  //       this.errMsg = responseProductError;
  //       console.log(this.errMsg);
  //     },
  //     () => console.log("GetSlideShow method executed successfully")
  //   )
  // }

  GetFeaturedProducts() {
    this._freshyCartService.GetFeaturedProducts().subscribe(
      responseProductData => {
        this.featuredProdList = responseProductData;
        this.showMsgDiv = false;
      },
      responseProductError => {
        this.featuredProdList = null;
        this.errMsg = responseProductError;
        console.log(this.errMsg);
      },
      () => console.log("GetFeaturedProducts method executed successfully")
    )
  }



    addToCart(prod: IProducts) {
        this._freshyCartService.addProductToCart(prod.productId, this.email, prod.productName, prod.productImage)
        .subscribe(
          responseAddToCartData => {
            this.addToCartStatus = responseAddToCartData;
            //this.status = responseAddToCartData
            if (this.addToCartStatus == 1) {
              alert(prod.productName + " added to cart sucessfully.")
            }
            else if (this.addToCartStatus == 0)
            (
              alert("Information is missing")
            )
            else
            {
              
              alert("Product was not added.")
            }
          },
          responseAddToCartError => {
            this.errMsg = responseAddToCartError,
              console.log(this.errMsg),
              alert("Sorry, something went wrong. Please try again after sometime.")
          },
          () => console.log("AddToCart method executed successfully")
        );
      
    }

}
