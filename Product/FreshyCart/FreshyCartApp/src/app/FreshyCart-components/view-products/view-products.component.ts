import { Component, OnInit } from '@angular/core';
import { FreshyCartServiceService } from 'src/app/FreshyCart-services/freshy-cart-service.service';
import { IProducts } from 'src/app/FreshyCart-interfaces/IProducts';
import { Router } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import { IFeaturedProd } from '../../FreshyCart-interfaces/IFeaturedProd';


@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent implements OnInit {

  productList: IProducts[];
  featuredProdList: IFeaturedProd[];
  errMsg: string;
  showMsgDiv: boolean = false;
  message: string;

    constructor(private _freshyCartService: FreshyCartServiceService, private router: Router, private sanitizer: DomSanitizer) {

   }

    ngOnInit() {
        this.getAllProducts();
        this.GetFeaturedProducts();
        
        if (this.productList == null) {
            this.showMsgDiv = true;
            this.message = "No products available";
        }

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





}
