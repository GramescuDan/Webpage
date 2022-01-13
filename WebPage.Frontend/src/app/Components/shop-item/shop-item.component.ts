import { Component, OnInit } from '@angular/core';
import {ShopitemService} from "../../services/shopitem.service";
import {IShopItem} from "../../models/shopitem";
import {CustomerService} from "../../services/customer.service";
import {CartService} from "../../services/cart.service";

@Component({
  selector: 'app-shop-item',
  templateUrl: './shop-item.component.html',
  styleUrls: ['./shop-item.component.scss']
})
export class ShopItemComponent implements OnInit {
  items:IShopItem[];
  constructor( private readonly _shopItem : ShopitemService,private readonly _customerService : CustomerService,private readonly _cartService: CartService) { }

  ngOnInit(): void {
    this._shopItem.get().subscribe(items => this.items = items)

  }
  addToCart(id:string):void{
    this._cartService.post(this._customerService.curentCustomer.id,id).subscribe();
}

}
