import { Component, OnInit } from '@angular/core';
import {mojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  txtkorisnickoIme: any;
  txtLozinka: any;


  constructor(private httpKlijent: HttpClient ,private router:Router) {
  }

  ngOnInit(): void {
  }

  btnLogin() {
    let saljemo = {
      korisnickoIme:this.txtkorisnickoIme,
      lozinka: this.txtLozinka
    };
    this.httpKlijent.post(mojConfig.adresa_servera+ "/Autentifikacija/Login/", saljemo)
      .subscribe((x:any) =>{
        if (x!=null) {
          porukaSuccess("uspjesan login");
          localStorage.setItem("autentifikacija-token", x.vrijednost);

         this.router.navigateByUrl("/narudzbe");

        }
        else
        {
          localStorage.setItem("autentifikacija-token", "");
          alert("Neispravan login ");
          porukaError("neispravan login");
        }
      });
  }
}

