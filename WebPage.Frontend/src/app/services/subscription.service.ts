import {HttpClient} from '@angular/common/http'
import {Injectable} from "@angular/core";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {ISubscriber} from "../models/ISubscriber";

@Injectable({
  providedIn: 'root'
})

export class SubscriptionService {
  private readonly _apiUrl = environment.apiUrl + 'Subscriber';

  constructor(
    private readonly _http: HttpClient
  ) {
  }

  post(subscriber:ISubscriber): Observable<ISubscriber> {

    return this._http.post<ISubscriber>(this._apiUrl, subscriber);
  }
}
