import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {AutentifikacijaHelper} from "./_helpers/autentifikacija-helper";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {mojConfig} from "./moj-config";
import {LoginInformacije} from "./_helpers/login-informacije";
import {HttpParams} from "@angular/common/http";

declare function porukaSuccess(x:string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  noviProizvodjac:any;
  novaKategorija:any;
  noviPost:any=null;
  kategorijePodatci:any;
  prikaziObavjest:boolean;

  @Output() goPrči = new EventEmitter<boolean>();

  constructor(private httpKlijent: HttpClient, private router: Router) {
  }
  ngOnInit(): void {
    this.testirajWebApi();
    this.nePrikazi();
  }
  logoutButton() {
    AutentifikacijaHelper.setLoginInfo(null);

    this.httpKlijent.post(mojConfig.adresa_servera + "/Autentifikacija/Logout", null, mojConfig.http_opcije())
      .subscribe((x: any) => {
        this.router.navigateByUrl("/pocetna");
      });
  }

  loginInfo(): LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }

  btnDodajProizvodjaca() {
    this.noviProizvodjac = {
      prikazi: true,
      id: 0,
      nazivProizvodjaca:"",
      sjedisteID:1,
    }
  }

  btnDodajKategoriju() {
    this.novaKategorija={
      id:0,
      prikazi:true,
      nazivKategorije:"",
    };

  }
  testirajWebApi() {
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Kategorija/GetAll").subscribe(x=>{
      this.kategorijePodatci = x;
    });
  }
  getKategorijePodaci() {
    if (this.kategorijePodatci == null)
      return [];
    return this.kategorijePodatci;
  }

  Otvori(k: any) {
    this.router.navigate(['/proizvodi-korisnik',k.kategorijaID])
      .then(() => {
        window.location.reload();
      });
  }
  prikaziObavjestiModal(){
    this.prikaziObavjest=true;
    console.log(this.prikaziObavjest)


  }
  nePrikazi(){
    this.prikaziObavjest=false;
  }
}
