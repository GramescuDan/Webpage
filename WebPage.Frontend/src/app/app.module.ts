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
import { ArticlesComponent } from './Components/articles/articles.component';
import {HttpClientModule} from "@angular/common/http";

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
    ArticlesComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatExpansionModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
