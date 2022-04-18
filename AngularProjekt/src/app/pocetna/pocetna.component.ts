import { Component, OnInit } from '@angular/core';
import {mojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-pocetna',
  templateUrl: './pocetna.component.html',
  styleUrls: ['./pocetna.component.css']
})
export class PocetnaComponent implements OnInit {
proizvodi:any;
odabraniProizvod:any=null;


  constructor(private httpKlijent: HttpClient,private router:Router) {
  }

  ngOnInit(): void {
    this.testirajWebApi();
  }
  testirajWebApi() :void
  {
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Proizvod/GetAll",mojConfig.http_opcije()).subscribe(x=>{
      this.proizvodi = x;
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
}
