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

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    SvgButtonComponent,
    TextButtonComponent,
    MainPageComponent,
    LineComponent,
    PreorderbuttonComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
