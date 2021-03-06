import {HttpClient} from '@angular/common/http'
import {Injectable} from "@angular/core";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {IArticle} from "../models/article";

@Injectable({
  providedIn: 'root'
})

export class FaqsService {
  private readonly _apiUrl = environment.apiUrl + 'Article/Faqs';

  constructor(
    private readonly _http: HttpClient
  ) {
  }

  get(): Observable<IArticle[]> {
    return this._http.get<IArticle[]>(this._apiUrl);
  }
}
