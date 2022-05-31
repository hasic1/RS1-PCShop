import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {mojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {LoginInformacije} from "../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";



@Component({
  selector: 'app-obavjesti',
  templateUrl: './obavjesti.component.html',
  styleUrls: ['./obavjesti.component.css']
})
export class ObavjestiComponent implements OnInit {

@Input()
  prikazObavjesti:any;
  obavjestiPodatci:any;
  private korisnikId: any;
  brojObavjesti:number;
   id:any;


  constructor(private httpKlijent:HttpClient) {
  }

  ngOnInit(): void {
      this.ucitajObavjesti()


  }


  ucitajObavjesti(): void {
    if(AutentifikacijaHelper.getLoginInfo().isPermisijaKorisnik && AutentifikacijaHelper.getLoginInfo().isLogiran) {
      this.korisnikId = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalog.id;
      let korinsnik = {
        id: this.korisnikId
      }
      this.httpKlijent.get(mojConfig.adresa_servera + "/Obavjest/GetUserNotifications",
        {params: korinsnik}).subscribe((x: any) => {
        this.obavjestiPodatci = x['data'];
        console.log(this.obavjestiPodatci)
        this.brojObavjesti = this.obavjestiPodatci.length;
        console.log("Broj obavjesti " + this.brojObavjesti);
      });
    }
  }

  getObavjesti(){
    if(this.obavjestiPodatci==null)
      return [];
    return this.obavjestiPodatci;
    console.log(this.obavjestiPodatci);
  }

  dismissModal() {
      this.prikazObavjesti=false;
      console.log(this.prikazObavjesti);

  }

  setDeleted(o: any) {
    if(AutentifikacijaHelper.getLoginInfo().isPermisijaKorisnik && AutentifikacijaHelper.getLoginInfo().isLogiran) {
      this.id = o.id;
      console.log("id" + this.id);
      this.httpKlijent.put(mojConfig.adresa_servera + "/Obavjest/SetObavjestiAsDeleted/" + this.id, this.id)
        .subscribe(data =>

          console.log(data));

      this.ucitajObavjesti();
    }
  }
  loginInfo(): LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }
}
