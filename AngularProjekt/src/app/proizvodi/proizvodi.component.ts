import { Component, OnInit } from '@angular/core';
import {mojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";

declare function porukaSuccess(a: string):any;
declare function porukaError(a:string):any;

@Component({
  selector: 'app-proizvodi',
  templateUrl: './proizvodi.component.html',
  styleUrls: ['./proizvodi.component.css']
})
export class ProizvodiComponent implements OnInit {

  proizvodiPodatci:any;
  odabraniProizvod:any=null;

  constructor(private httpKlijent: HttpClient) {
  }


  testirajWebApi() {
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Proizvod/GetAll").subscribe(x=>{
      this.proizvodiPodatci = x;
    });
  }

  getProizvodiPodaci() {
    if (this.proizvodiPodatci==null)
      return[];
    return this.proizvodiPodatci;
  }
  ngOnInit(): void {
  }
  detalji(p:any) {
    this.odabraniProizvod=p;
    this.odabraniProizvod.prikazi=true;
  }
  snimi() {
    //this.odabranaNarudzba
    this.httpKlijent.post(mojConfig.adresa_servera+ "/Proizvod/Update/" + this.odabraniProizvod.id,this.odabraniProizvod)
      .subscribe((x:any)=>{
        alert("Uredu"+x.potvrdjena)
      })
  }
  btnNovi() {
    this.odabraniProizvod=
      {
        prikazi:true,
        nazivProizvoda:"",
        cijena:0,
        kolicina:0,
        opis:"",
        kategorijaID:0,
        lokacijaSlike:"",
        snizen:0,
        proizvodjacID:0
      }
  }
  obrisi(p:any) {
    this.httpKlijent.post(mojConfig.adresa_servera+"/Proizvod/Delete/"+p.proizvodID,null)
      .subscribe((x:any)=>{
        const index=this.proizvodiPodatci.indexOf(p);
        if(index>-1){
          this.proizvodiPodatci.splice(index,1);
        }
        porukaSuccess("Oglas uspjesno obrisan");
      })
  }


}
