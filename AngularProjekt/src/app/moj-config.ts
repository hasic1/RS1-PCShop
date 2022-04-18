import {HttpHeaders} from "@angular/common/http";
import {AutentifikacijaToken} from "./_helpers/login-informacije";
import {AutentifikacijaHelper} from "./_helpers/autentifikacija-helper";
export  class mojConfig{
  static adresa_servera="https://localhost:5001";
  //static adresa_servera="http://localhost:51433";
  static http_opcije=function (){
    let autentifikacijaToken:AutentifikacijaToken = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken;
    let mojToken = "";

    if (autentifikacijaToken!=null)
      mojToken = autentifikacijaToken.vrijednost;
    return{
      headers:{
        'autentifikacija-token': mojToken,
      }
    };
  }
}
