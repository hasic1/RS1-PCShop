import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from "@angular/common/http";
import { RouterModule } from '@angular/router';
import {FormsModule} from "@angular/forms";
import { AppComponent } from './app.component';
import { ProizvodiComponent } from './proizvodi/proizvodi.component';
import { LoginComponent } from './login/login.component';
import { NarudzbeComponent } from './narudzbe/narudzbe.component';
import { OglasiComponent } from './oglasi/oglasi.component';

@NgModule({
  declarations: [
    AppComponent,
    ProizvodiComponent,
    LoginComponent,
    NarudzbeComponent,
    OglasiComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
