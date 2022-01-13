import {HttpClient} from '@angular/common/http'
import {Injectable} from "@angular/core";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {ICart} from "../models/cart";
import {ISubscriber} from "../models/ISubscriber";

@Injectable({
  providedIn: 'root'
})

export class CartService {
  private readonly _apiUrl = environment.apiUrl + 'ShoppingCart';

  constructor(
    private readonly _http: HttpClient
  ) {
  }

  get(id:string): Observable<ICart> {
    return this._http.get<ICart>(this._apiUrl + "?customerId=" + id);
  }
  post(customerid:string, itemid:string): Observable<ICart> {

    return this._http.post<ICart>(this._apiUrl +"/"+ customerid + ","+ itemid,null);
  }
}
