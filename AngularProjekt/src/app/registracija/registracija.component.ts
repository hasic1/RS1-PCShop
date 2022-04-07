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
  @Input() urediKorisnik:any;

  constructor(private httpKlijent:HttpClient) { }

  ngOnInit() {  }


  snimi() {

    this.httpKlijent.post(mojConfig.adresa_servera+"/Korisnik/Add/",this.urediKorisnik).subscribe((x:any)=>{
      porukaSuccess("Uspjesna reg");
      this.urediKorisnik.prikazi=false;
    });
  }
}


