import { Component, OnInit } from '@angular/core';
import {mojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";

@Component({
  selector: 'app-pocetna',
  templateUrl: './pocetna.component.html',
  styleUrls: ['./pocetna.component.css']
})
export class PocetnaComponent implements OnInit {
proizvodi:any;
odabraniProizvod:any=null;
  total:number = 1;
  page:number = 1;
  limit:number = 8;
  loading:boolean = false;

  constructor(private httpKlijent: HttpClient,private router:Router) {
  }

  ngOnInit(): void {
    this.testirajWebApi();
  }
  testirajWebApi() :void
  {
    let parametri={
      page_number: this.page,
      items_per_page:this.limit
    }
    JSON.stringify(parametri)
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Proizvod/GetAllPaged",
      {params:parametri}).subscribe((x:any)=>{
      this.proizvodi = x['dataItems'];
      this.total=x['totalCount'];
      this.loading=false;
      console.log(this.page)
    });
  }
  getProizvodPodatci() {
    if (this.proizvodi == null)
      return [];
    return this.proizvodi;
  }

  dodajUKorpu() {

  }

  Prikazi(p: any) {
    this.odabraniProizvod=p;
    this.odabraniProizvod.prikazi=true;
  }
  loginInfo(): LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }

  goToPrevious(): void {

    this.page--;
    this.testirajWebApi();
  }

  goToNext(): void {

    this.page++;
    this.testirajWebApi();
  }

  goToPage(n: number): void {
    this.page = n;
    console.log(this.page)
    this.testirajWebApi();
  }
}
