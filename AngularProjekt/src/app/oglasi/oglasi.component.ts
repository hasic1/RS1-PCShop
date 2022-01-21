import {Component, Injectable, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../moj-config";

declare function porukaSuccess(a: string):any;
declare function porukaError(a:string):any;

@Component({
  selector: 'app-oglasi',
  templateUrl: './oglasi.component.html',
  styleUrls: ['./oglasi.component.css']
})

export class OglasiComponent implements OnInit {

  oglasiPodatci:any;
  odabraniOglas: any=null;

  constructor(private httpKlijent: HttpClient) {
  }



  testirajWebApi() {
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Oglasi/GetAll").subscribe(x=>{
      this.oglasiPodatci = x;
    });
  }



  getOglasiPodaci() {
    if (this.oglasiPodatci == null)
      return [];
    return this.oglasiPodatci;
  }
  ngOnInit(): void {
    this.testirajWebApi();
  }

  detalji(o:any) {
    this.odabraniOglas=o;
    this.odabraniOglas.prikazi=true;
  }
  snimi() {
    //this.odabranaNarudzba
    this.httpKlijent.post(mojConfig.adresa_servera+ "/Oglasi/Update/" + this.odabraniOglas.id,this.odabraniOglas)
      .subscribe((x:any)=>{
        alert("Uredu"+x.potvrdjena)
      })
  }
  btnNovi() {
    this.odabraniOglas={
      prikazi:true,
      naslov:"",
      sadrzaj:"",
      brojPozicija:0,
      lokacija:"",
      datumObjave:0,
      datumIsteka:0,
      trajanjeOglasa:0,
      aktivan:0
    }

  }

  obrisi(o:any) {
    this.httpKlijent.post(mojConfig.adresa_servera+"/Oglasi/Delete/"+o.id,null)
      .subscribe((x:any)=>{
        const index=this.oglasiPodatci.indexOf(o);
        if(index>-1){
          this.oglasiPodatci.splice(index,1);
        }
        porukaSuccess("Oglas uspjesno obrisan");
      })
  }


}
