import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {mojConfig} from "../moj-config";

declare function porukaSuccess(x:string):any;

@Component({
  selector: 'app-registracija',
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})
export class RegistracijaComponent implements OnInit {
  noviKorisnik:any=null;

  constructor(private httpKlijent: HttpClient ,private router:Router) {
  }
  ngOnInit(): void {
  }

  btnDodajKorisnika() {
    this.noviKorisnik={
      id:0,
      korisnickoIme: "",
      ime: "",
      prezime: "",
      spol: "",
      datumRodjenja: "2003-10-01",
      drzavaID: 1,
      lozinka: "a"
    }
    this.httpKlijent.post(mojConfig.adresa_servera+"/Korisnik/Add/",this.noviKorisnik).subscribe((x:any)=>{
      porukaSuccess("Uspjesno registrovan");
    });
  }
}
