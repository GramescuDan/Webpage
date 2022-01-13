import {HttpClient} from '@angular/common/http'
import {Injectable} from "@angular/core";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {IShopItem} from "../models/shopitem";

@Injectable({
  providedIn: 'root'
})

export class ShopitemService {
  private readonly _apiUrl = environment.apiUrl + 'ShopItem';

  constructor(
    private readonly _http: HttpClient
  ) {
  }

  get(): Observable<IShopItem[]> {
    return this._http.get<IShopItem[]>(this._apiUrl);
  }
}
