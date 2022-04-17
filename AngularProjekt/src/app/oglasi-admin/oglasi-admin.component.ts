import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../moj-config";

declare function porukaSuccess(x:string):any;

@Component({
  selector: 'app-oglasi-admin',
  templateUrl: './oglasi-admin.component.html',
  styleUrls: ['./oglasi-admin.component.css']
})
export class OglasiAdminComponent implements OnInit {
  odabraniOglas: any=null;
  oglasiPodaci:any;

  constructor(private httpKlijent:HttpClient) { }

  testirajWebApi() {
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Oglasi/GetAll").subscribe(x=>{
      this.oglasiPodaci = x;
    });
  }

  getProizvodiPodaci() {
    if (this.oglasiPodaci==null)
      return[];
    return this.oglasiPodaci;
  }
  ngOnInit(): void {
    this.testirajWebApi();
  }
  detalji(p:any) {
    this.odabraniOglas=p;
    this.odabraniOglas.prikazi=true;
  }
  snimi() {
    this.httpKlijent.post(mojConfig.adresa_servera+ "/Oglasi/Update/" + this.odabraniOglas.id,this.odabraniOglas)
      .subscribe((x:any)=>{
        alert("Uredu"+x.potvrdjena)
      })
  }
  btnNovi() {
    this.odabraniOglas=
      {
        prikazi:true,
        naslov:"",
        sadrzaj:"",
        brojPozicja:0,
        lokacija:"",
        datumObjave:new Date().getDate(),
        trajanjeOglasa:0,
        datumIsteka:new Date().getDate(),
        autorOglasaID:2,
        aktivan:false,
      }
  }
  obrisi(p:any) {
    this.httpKlijent.post(mojConfig.adresa_servera+"/Oglasi/Delete/"+p.proizvodID,null)
      .subscribe((x:any)=>{
        const index=this.oglasiPodaci.indexOf(p);
        if(index>-1){
          this.oglasiPodaci.splice(index,1);
        }
        porukaSuccess("Proizvod uspjesno obrisan");
      })
  }

}
