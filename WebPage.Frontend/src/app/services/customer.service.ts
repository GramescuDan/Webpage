import {HttpClient} from '@angular/common/http'
import {Injectable} from "@angular/core";
import {environment} from "../../environments/environment";
import {Observable, tap} from "rxjs";
import {ICustomer} from "../models/customer";

@Injectable({
  providedIn: 'root'
})

export class CustomerService {
  private readonly _apiUrl = environment.apiUrl + 'Customer';

  constructor(
    private readonly _http: HttpClient
  ) {
  }
  curentCustomer:ICustomer = {
    id: " ",
    age: 0,
    name: " ",
    surname: " ",
    email: "user@example.com",
    phoneNr: "0700000000",
    address: " ",
    country: " ",
    postalcode: " "
  };

  post(): Observable<ICustomer> {

    return this._http.post<ICustomer>(this._apiUrl, this.curentCustomer).pipe(tap(customer => this.curentCustomer = customer));
  }
  patch(customer:ICustomer,oldCustomerId): Observable<ICustomer> {

    return this._http.patch<ICustomer>(this._apiUrl+"?oldCustemer="+oldCustomerId, customer);
  }
}
