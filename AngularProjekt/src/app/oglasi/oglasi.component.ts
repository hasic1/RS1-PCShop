import { Component, OnInit } from '@angular/core';
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
  odabraniOglas: any=null;
oglasiPodatci:any;
  constructor(private httpKlijent: HttpClient) {
  }

  ngOnInit(): void {
  }

  testirajWebApi() {
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Oglasi/GetAll").subscribe(x=>{
      this.oglasiPodatci = x;
    });
  }

  btnNovi() {
    this.odabraniOglas={
      prikazi:true,
      naslov:"",
      sadrzaj:"",
      brojPozicija:0,
      lokacija:"",
      datumObjave:"",
      datumIsteka:"",
      trajanjeOglasa:0,
      aktivan:0
  }
  }

  getOglasiPodaci() {
    if (this.oglasiPodatci == null)
      return [];
    return this.oglasiPodatci;
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

  detalji(o: any) {
    this.oglasiPodatci=o;
    this.odabraniOglas.prikazi=true;
  }
}
