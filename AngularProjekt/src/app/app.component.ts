import {Component } from '@angular/core';
import {AutentifikacijaHelper} from "./_helpers/autentifikacija-helper";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {mojConfig} from "./moj-config";
import {LoginInformacije} from "./_helpers/login-informacije";



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
  prikaziObavjest:any;
  brojNovihObavjesti:number=0;
  private korisnikId: number;
  obavjestiPodatci:any;

  constructor(private httpKlijent: HttpClient, private router: Router) {
  }
  ngOnInit(): void {
    this.testirajWebApi();
    this.ucitajObavjesti();

  }
  logoutButton() {
    AutentifikacijaHelper.setLoginInfo(null);

    this.httpKlijent.post(mojConfig.adresa_servera + "/Autentifikacija/Logout", null, mojConfig.http_opcije())
      .subscribe((x: any) => {
        this.router.navigateByUrl("/pocetna");
        this.obavjestiPodatci=null;
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
    this.prikaziObavjest={
      prikazi:true,
    };
    console.log(this.prikaziObavjest);
    this.setObavjestAsRead();
  }

  ucitajObavjesti(): void {
    this.korisnikId = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalog.id;
    let korinsnik={
      id:this.korisnikId
    }
    this.httpKlijent.get(mojConfig.adresa_servera + "/Obavjest/GeUnReadUserNotifications",
      {params:korinsnik}).subscribe((x:any) => {
      this.obavjestiPodatci = x['data'];
      this.brojNovihObavjesti= this.obavjestiPodatci.length;
      console.log("Broj obavjesti " +this.brojNovihObavjesti);

    });

  }
  setObavjestAsRead(){
    this.korisnikId = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalog.id;
    this.httpKlijent.put(mojConfig.adresa_servera+ "/Obavjest/SetObavjestAsRead/"+this.korisnikId,this.korisnikId)
      .subscribe(data=>
        console.log(data));
   this.brojNovihObavjesti=0;

  }

}
