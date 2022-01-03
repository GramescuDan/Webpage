import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './Components/menu/menu.component';
import { SvgButtonComponent } from './Components/svg-button/svg-button.component';
import { TextButtonComponent } from './Components/text-button/text-button.component';
import { MainPageComponent } from './Components/main-page/main-page.component';
import { LineComponent } from './Components/line/line.component';
import { PreorderbuttonComponent } from './Components/preorderbutton/preorderbutton.component';
import { BackgroundImageComponent } from './Components/background-image/background-image.component';
import { TextLineComponent } from './Components/text-line/text-line.component';
import { BannerComponent } from './Components/banner/banner.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    SvgButtonComponent,
    TextButtonComponent,
    MainPageComponent,
    LineComponent,
    PreorderbuttonComponent,
    BackgroundImageComponent,
    TextLineComponent,
    BannerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
