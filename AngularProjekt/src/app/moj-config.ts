import {HttpHeaders} from "@angular/common/http";
export  class mojConfig{
<<<<<<< Updated upstream
  static adresa_servera="https://localhost:5001";
=======
  static adresa_servera="https://localhost:44326";
>>>>>>> Stashed changes

  static http_opcije=function (){

    let mojToken=localStorage.getItem("autentifikacija-token" )


    return{
      headers:{
        'autentifikacija-token':'HZkLV3doD8'//mojToken,
      }
    };
  }
}
