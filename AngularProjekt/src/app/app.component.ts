import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "./moj-config";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AngularProjekt';
  bankaPodatci :any;
  ime:any='';


  constructor(private httpKlijent: HttpClient) {
  }
  testirajWebApi() {
    this.httpKlijent.get( mojConfig.adresa_servera+"/Korisnik/GetAll").subscribe(x=>{
      this.bankaPodatci = x;
    });
  }

  getBankaPodaci() {
    if (this.bankaPodatci == null)
      return [];
    return this.bankaPodatci.filter((x:any)=>(x.ime+" "+ x.prezime).toLowerCase().startsWith(this.ime.toLowerCase())||x.ime.length==0 ||(x.prezime+" "+ x.ime).toLowerCase().startsWith(this.ime.toLowerCase()))
  }

}
