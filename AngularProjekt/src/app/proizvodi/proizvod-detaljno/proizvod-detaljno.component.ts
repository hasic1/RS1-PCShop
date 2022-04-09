import { Component, OnInit } from '@angular/core';
import {LoginInformacije} from "../../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacija-helper";

@Component({
  selector: 'app-proizvod-detaljno',
  templateUrl: './proizvod-detaljno.component.html',
  styleUrls: ['./proizvod-detaljno.component.css']
})
export class ProizvodDetaljnoComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  loginInfo(): LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }
}
