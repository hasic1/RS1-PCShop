import {LoginInformacije} from "./login-informacije";
import {HttpClient} from "@angular/common/http";
import {Korisnik} from "./registracija-informacije";
import {mojConfig} from "../moj-config";

export class AutentifikacijaHelper {

  constructor(private _http: HttpClient) { }

  static setLoginInfo(x: LoginInformacije): void {
    if (x == null)
      x = new LoginInformacije();
    localStorage.setItem("autentifikacija-token", JSON.stringify(x));
  }

  static getLoginInfo(): LoginInformacije {
    let x = localStorage.getItem("autentifikacija-token");
    if (x === "")
      return new LoginInformacije();

    try {
      let loginInformacije: LoginInformacije = JSON.parse(x);
      if (loginInformacije == null)
        return new LoginInformacije();
      return loginInformacije;
    } catch (e) {
      return new LoginInformacije();
    }
  }
  public registerUser = (route: string, body: Korisnik) => {
    return this._http.post<Korisnik> (mojConfig.adresa_servera+"/Korisnik/Add", body);
  }
}
