import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../moj-config";

@Component({
  selector: 'app-narudzbe',
  templateUrl: './narudzbe.component.html',
  styleUrls: ['./narudzbe.component.css']
})
export class NarudzbeComponent implements OnInit {
  narudzbePodatci :any;
  ime:any='';
  odabranaNarudzba: any=null;

  constructor(private httpKlijent: HttpClient) {
  }

  testirajWebApi() {
    this.httpKlijent.get( mojConfig.adresa_servera+"/Narudzba/GetAll").subscribe(x=>{
      this.narudzbePodatci = x;
    });
  }
  getNarudzbaPodaci() {
    if (this.narudzbePodatci == null)
      return [];
    return this.narudzbePodatci;
  }

  ngOnInit(): void {
  }

  detalji(s:any) {
   this.odabranaNarudzba=s;
  }

  snimi() {
    //this.odabranaNarudzba
    this.httpKlijent.post(mojConfig.adresa_servera+"/Narudzba/Update/"+this.odabranaNarudzba.ID ,this.odabranaNarudzba).subscribe((povratnaVrijednost:any)=>{
      alert("Uredu");
    });
  }
}



