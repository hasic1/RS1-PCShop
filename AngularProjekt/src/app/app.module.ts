import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule} from "@angular/forms";
import { HttpClientModule} from "@angular/common/http";
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ProizvodiComponent } from './proizvodi/proizvodi.component';
import { LoginComponent } from './login/login.component';
import { NarudzbeComponent } from './narudzbe/narudzbe.component';
import { OglasiComponent } from './oglasi/oglasi.component';
import { NarudzbaEditComponent } from './narudzbe/narudzba-edit/narudzba-edit.component';



@NgModule({
  declarations: [
    AppComponent,
    ProizvodiComponent,
    LoginComponent,
    NarudzbeComponent,
    OglasiComponent,
    NarudzbaEditComponent,

  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      {path:'narudzbe',component:NarudzbeComponent},
      {path:'login',component:LoginComponent},
      {path:'oglasi',component:OglasiComponent},
      {path:'proizvodi',component:ProizvodiComponent}
]),
    FormsModule,
    HttpClientModule


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
