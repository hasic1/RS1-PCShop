import {HttpHeaders} from "@angular/common/http";
export  class mojConfig{
  static adresa_servera="https://localhost:44356";

  static http_opcije=function (){

    let mojToken=localStorage.getItem("autentifikacija-token" )


    return{
      headers:{
        'autentifikacija-token':'HZkLV3doD8'//mojToken,
      }
    };
  }
}
