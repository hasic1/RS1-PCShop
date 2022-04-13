import {Component, Input, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../moj-config";



declare function porukaSuccess(x:string):any;


@Component({
  selector: 'app-registracija',
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})
export class RegistracijaComponent implements OnInit {
  @Input() kreirajKorisnik:any;
  drzavePodatci:any=null;


  constructor(private httpKlijent:HttpClient) { }

  ngOnInit() {
    this.testirajWebApi();
  }

  getDrzave(){
    if (this.drzavePodatci == null)
      return [];
    return this.drzavePodatci;
  }

  snimi() {

    this.httpKlijent.post(mojConfig.adresa_servera+"/Korisnik/Add/",this.kreirajKorisnik).subscribe((x:any)=>{
      porukaSuccess("Uspjesna reg");
      this.kreirajKorisnik.prikazi=false;
    });
  }

  testirajWebApi() :void
  {
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Drzava/GetAll_ForCmb",mojConfig.http_opcije()).subscribe(x=>{
      this.drzavePodatci = x;
    });
  }
}



