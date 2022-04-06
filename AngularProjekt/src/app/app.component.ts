import {Component, OnInit} from '@angular/core';
import {AutentifikacijaHelper} from "./_helpers/autentifikacija-helper";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {mojConfig} from "./moj-config";
import {LoginInformacije} from "./_helpers/login-informacije";

declare function porukaSuccess(x:string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  logoutButton() {
    AutentifikacijaHelper.setLoginInfo(null);

    this.httpKlijent.post(mojConfig.adresa_servera+"/Autentifikacija/Logout", null, mojConfig.http_opcije())
      .subscribe((x: any) => {
        this.router.navigateByUrl("/pocetna");
        porukaSuccess("Logout uspješan");
      });
  }

  loginInfo():LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }
}
