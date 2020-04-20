import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { User } from '../FreshyCart-interfaces/User';
import { IProducts } from '../FreshyCart-interfaces/IProducts';
import { ISlideShow } from '../FreshyCart-interfaces/ISlideShow';
import { IFeaturedProd } from '../FreshyCart-interfaces/IFeaturedProd';
import { ICart } from '../FreshyCart-interfaces/ICart';
import { ICartProducts } from '../FreshyCart-interfaces/ICartProducts';

@Injectable({
  providedIn: 'root'
})
export class FreshyCartServiceService {

    productList: IProducts[];

    constructor(private http: HttpClient) { }

    //Consuming the Login API
    loginUser(email: string, password: string): Observable<string> {
        return this.http.get<string>('http://localhost:50931/api/FreshyCart/UserLogin?EmailID=' + email + '&Password=' + password).pipe(catchError(this.errorHandler));
    }

    //Consuming the Register API
    registerUser(name: string, email: string, password: string): Observable<boolean> {
        var userObj: User;
        userObj = { FullName: name, EmailID: email, Password: password };
        return this.http.post<boolean>('http://localhost:50931/api/FreshyCart/RegisterUser', userObj).pipe(catchError(this.errorHandler))
    }

    //Get All Products
    getAllProducts(): Observable<IProducts[]> {
        let tempVar = this.http.get<[IProducts]>('http://localhost:50931/api/FreshyCart/GetAllProducts').pipe(catchError(this.errorHandler));;
        return tempVar;
    }

    //Get SlideShow Images
    GetSlideShow(): Observable<ISlideShow[]> {
        let tempVar = this.http.get<[ISlideShow]>('http://localhost:50931/api/FreshyCart/GetSlideShow').pipe(catchError(this.errorHandler));;
        return tempVar;
    }

    //Get Featured Products Images
    GetFeaturedProducts(): Observable<IFeaturedProd[]> {
        let tempVar = this.http.get<[IFeaturedProd]>('http://localhost:50931/api/FreshyCart/GetFeaturedProducts').pipe(catchError(this.errorHandler));;
        return tempVar;
    }


    //Add/Update/Delete/Get Cart
    addProductToCart(productId: number, emailId: string, productName: string, productImage: string): Observable<number> {
        var cartObj: ICart;
        cartObj = { productId: productId, emailId: emailId, productName: productName, productImage: productImage, quantity: 1 };
        return this.http.post<number>('http://localhost:50931/api/FreshyCart/AddProductToCart', cartObj).pipe(catchError(this.errorHandler))
    }

    //Update Cart
    updateCartProducts(productId: number, emailId: string, productName: string, productImage: string, quantity: number): Observable<boolean>{
        var cartObj: ICart;
        cartObj = {productId: productId, emailId: emailId, productName: productName, productImage: productImage, quantity: quantity};
        return this.http.put<boolean>('http://localhost:50931/api/FreshyCart/UpdateCartProducts', cartObj).pipe(catchError(this.errorHandler));
    }

    //Delete From Cart
    deleteFromCart(productId: number, emailId: string): Observable<boolean> {
        var cartObj: ICart;
        cartObj = {productId: productId, emailId: emailId, productName: undefined, productImage: undefined, quantity: undefined};
        let httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }), body: cartObj };
        return this.http.delete<boolean>('http://localhost:50931/api/FreshyCart/DeleteFromCart', httpOptions).pipe(catchError(this.errorHandler));
    }

    //Get Products From Cart
    getCartProducts(emailId: string): Observable<[ICartProducts]> {
        let tempVar = this.http.get<[ICartProducts]>('http://localhost:50931/api/FreshyCart/GetCartProducts?EmailId=' + emailId).pipe(catchError(this.errorHandler));
        return tempVar;
    }

    errorHandler(error: HttpErrorResponse) {
        console.error(error);
        return throwError(error.message || "Server Error");
    }
}
