import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { User } from '../FreshyCart-interfaces/User';
import { IProducts } from '../FreshyCart-interfaces/IProducts';
import { IFeaturedProd } from '../FreshyCart-interfaces/IFeaturedProd';

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

    //Get Featured Products Images
    GetFeaturedProducts(): Observable<IFeaturedProd[]> {
        let tempVar = this.http.get<[IFeaturedProd]>('http://localhost:50931/api/FreshyCart/GetFeaturedProducts').pipe(catchError(this.errorHandler));;
        return tempVar;
    }





    errorHandler(error: HttpErrorResponse) {
        console.error(error);
        return throwError(error.message || "Server Error");
    }
}
