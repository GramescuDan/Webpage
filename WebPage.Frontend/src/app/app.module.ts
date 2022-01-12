import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './Components/menu/menu.component';
import { SvgButtonComponent } from './Components/svg-button/svg-button.component';
import { TextButtonComponent } from './Components/text-button/text-button.component';
import { MainPageComponent } from './Components/main-page/main-page.component';
import { LineComponent } from './Components/line/line.component';
import { PreOrderButtonComponent } from './Components/pre-order-button/pre-order-button.component';
import { BackgroundImageComponent } from './Components/background-image/background-image.component';
import { TextLineComponent } from './Components/text-line/text-line.component';
import { BannerComponent } from './Components/banner/banner.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatExpansionModule} from '@angular/material/expansion';
import { NewsSectionComponent } from './Components/news-section/news-section.component';
import { HttpClientModule } from '@angular/common/http';
import { EmailFormComponent } from './Components/email-form/email-form.component';
import {MatInputModule} from '@angular/material/input';
import {ReactiveFormsModule} from "@angular/forms";
import { ShopItemComponent } from './Components/shop-item/shop-item.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    SvgButtonComponent,
    TextButtonComponent,
    MainPageComponent,
    LineComponent,
    PreOrderButtonComponent,
    BackgroundImageComponent,
    TextLineComponent,
    BannerComponent,
    NewsSectionComponent,
    EmailFormComponent,
    ShopItemComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatExpansionModule,
    HttpClientModule,
    MatInputModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
