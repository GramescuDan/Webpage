import { Component } from '@angular/core';
import {CustomerService} from "./services/customer.service";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'WebPage.Frontend';

  constructor(private readonly _customerService : CustomerService) {
  }
  ngOnInit(): void {
    this._customerService.post().subscribe();
  }
}
