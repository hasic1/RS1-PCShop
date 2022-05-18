import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import  {FormsModule} from "@angular/forms";
import { HttpClientModule,} from "@angular/common/http";
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
import {AutorizacijaAdminProvjera} from "./_guards/autorizacija-admin-provjera.service";
import {AutorizacijaLoginProvjera} from "./_guards/autorizacija-login-provjera.service";
import {AutorizacijaKorisnikProvjera} from "./_guards/autorizacija-korisnik-provjera.service";
import { PostoviComponent } from './postovi/postovi.component';
import { ReactiveFormsModule } from '@angular/forms';
import {ProizvodDetaljnoComponent} from "./proizvodi-korisnik/proizvod-detaljno/proizvod-detaljno.component";
import { KorisnikComponent } from './korisnik/korisnik.component';
import { ProizvodiKorisnikComponent } from './proizvodi-korisnik/proizvodi-korisnik.component';
import { NarudzbeKorisnikComponent } from './narudzbe-korisnik/narudzbe-korisnik.component';
import { OglasiAdminComponent } from './oglasi-admin/oglasi-admin.component';
import { PostoviAdminComponent } from './postovi-admin/postovi-admin.component';
import { PostEditComponent } from './postovi-admin/post-edit/post-edit.component';
import { OglasEditComponent } from './oglasi-admin/oglas-edit/oglas-edit.component';
import {DatePipe} from "@angular/common";
import { FooterComponent } from './footer/footer.component';
import {PaginationComponent} from "./pagination/pagination.component";
import { ObavjestiComponent } from './obavjesti/obavjesti.component';


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
    PostoviComponent,
    ProizvodDetaljnoComponent,
    KorisnikComponent,
    ProizvodiKorisnikComponent,
    NarudzbeKorisnikComponent,
    OglasiAdminComponent,
    PostoviAdminComponent,
    PostEditComponent,
    OglasEditComponent,
    FooterComponent,
    PaginationComponent,
    ObavjestiComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path:"", redirectTo:"/pocetna",pathMatch:"full"},
      {path:'narudzbe',component:NarudzbeComponent},
      {path:'login',component:LoginComponent},
      {path:'oglasi',component:OglasiComponent},
      {path:'proizvodi',component:ProizvodiComponent},
      {path:'registracija',component:RegistracijaComponent},
      {path:'pocetna',component:PocetnaComponent},
      {path:'administrator',component:AdministratorComponent,canActivate:[AutorizacijaAdminProvjera]},
      {path:'korpa',component:KorpaComponent,canActivate:[AutorizacijaKorisnikProvjera]},
      {path:'administrator-proizvodjac',component:AdministratorProizvodjacComponent,canActivate:[AutorizacijaAdminProvjera]},
      {path:'administrator-kategorija',component:AdministratorKategorijaComponent,canActivate:[AutorizacijaAdminProvjera]},
      {path:'administrator-postovi',component:AdministratorPostoviComponent,canActivate:[AutorizacijaAdminProvjera]},
      {path:'administrator-postovi-edit',component:AdministratorPostoviEditComponent,canActivate:[AutorizacijaAdminProvjera]},
      {path:'postovi',component:PostoviComponent},
      {path:'proizvod-detaljno/:id',component:ProizvodDetaljnoComponent},
      {path: 'proizvodi-korisnik/:id',component:ProizvodiKorisnikComponent},
      {path:'korisnik',component:KorisnikComponent},
      {path:'postovi-admin',component:PostoviAdminComponent},
      {path:'naruzdbe-korisnik',component:NarudzbeKorisnikComponent,canActivate:[AutorizacijaKorisnikProvjera]},
      {path:'oglasi-admin',component:OglasiAdminComponent},

    ]),
    FormsModule,
    HttpClientModule,



  ],
  providers: [
    AutorizacijaAdminProvjera,
    AutorizacijaLoginProvjera,
    AutorizacijaKorisnikProvjera,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
