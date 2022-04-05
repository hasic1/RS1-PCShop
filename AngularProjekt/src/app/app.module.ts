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
import { OglasiEditComponent } from './oglasi/oglasi-edit/oglasi-edit.component';
import { RegistracijaComponent } from './registracija/registracija.component';
import { PocetnaComponent } from './pocetna/pocetna.component';
import { ProizvodEditComponent } from './proizvodi/proizvod-edit/proizvod-edit.component';
import { AdministratorComponent } from './administrator/administrator.component';
import { KorpaComponent } from './korpa/korpa.component';
import { AdministratorProizvodjacComponent } from './administrator/administrator-proizvodjac/administrator-proizvodjac.component';
import { AdministratorKategorijaComponent } from './administrator/administrator-kategorija/administrator-kategorija.component';
import {AdministratorPostoviComponent} from "./administrator/administrator-postovi/administrator-postovi.component";
import { AdministratorPostoviEditComponent } from './administrator/administrator-postovi/administrator-postovi-edit/administrator-postovi-edit.component';



@NgModule({
  declarations: [
    AppComponent,
    ProizvodiComponent,
    LoginComponent,
    NarudzbeComponent,
    OglasiComponent,
    NarudzbaEditComponent,
    OglasiEditComponent,
    RegistracijaComponent,
    PocetnaComponent,
    ProizvodEditComponent,
    AdministratorComponent,
    KorpaComponent,
    AdministratorProizvodjacComponent,
    AdministratorKategorijaComponent,
    AdministratorPostoviComponent,
    AdministratorPostoviEditComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path:"", redirectTo:"/pocetna",pathMatch:"full"},
      {path:'narudzbe',component:NarudzbeComponent},
      {path:'login',component:LoginComponent},
      {path:'oglasi',component:OglasiComponent},
      {path:'proizvodi',component:ProizvodiComponent},
      {path:'registracija',component:RegistracijaComponent},
      {path:'pocetna',component:PocetnaComponent},
      {path:'administrator',component:AdministratorComponent},
      {path:'korpa',component:KorpaComponent},
      {path:'administrator-proizvodjac',component:AdministratorProizvodjacComponent},
      {path:'administrator-kategorija',component:AdministratorKategorijaComponent},
      {path:'administrator-postovi',component:AdministratorPostoviComponent},
      {path:'administrator-postovi-edit',component:AdministratorPostoviEditComponent}
    ]),
    FormsModule,
    HttpClientModule


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
