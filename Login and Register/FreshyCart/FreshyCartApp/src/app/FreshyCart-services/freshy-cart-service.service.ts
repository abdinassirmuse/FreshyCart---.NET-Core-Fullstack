import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { User } from '../FreshyCart-interfaces/User';

@Injectable({
  providedIn: 'root'
})
export class FreshyCartServiceService {

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

    errorHandler(error: HttpErrorResponse) {
        console.error(error);
        return throwError(error.message || "Server Error");
    }
}
