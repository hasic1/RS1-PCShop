import {Component, Input, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../moj-config";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {FormBuilder, Validators,FormControl,NgForm,FormGroup} from "@angular/forms";
import {Korisnik} from "../_helpers/registracija-informacije";
import {Router} from "@angular/router";

declare function porukaSuccess(x:string):any;


@Component({
  selector: 'app-registracija',
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})
export class RegistracijaComponent implements OnInit {
  @Input()
  kreirajKorisnik:any;
  drzavePodatci:any=null;
  KorisnickaForma:any;
  message:string;
  data=false;

  constructor(private httpKlijent:HttpClient, private formbulider: FormBuilder,private autentifikacijaRegistracija:AutentifikacijaHelper,private router: Router,) { }

  ngOnInit() {
    this.KorisnickaForma=this.formbulider.group({
      ime: ['', [Validators.required]],
      prezime: ['', [Validators.required]],
      drzavaID: ['', [Validators.required]],
      spol: ['', [Validators.required]],
      korisnickoIme: ['', [Validators.required]],
      lozinka: ['', [Validators.required, Validators.minLength(6)]],
    })
    this.testirajWebApi();
  }

  getDrzave(){
    if (this.drzavePodatci == null)
      return [];
    return this.drzavePodatci;
  }

  onFormSubmit()
  {
    const korisnik = this.KorisnickaForma.value;
    this.KreirajKorisnika(korisnik);



  }
  KreirajKorisnika(register:Korisnik)
  {
    this.autentifikacijaRegistracija.registerUser(register).subscribe(
      ()=>
      {
        this.data = true;
        this.message = 'Data saved Successfully';
        this.KorisnickaForma.reset();
      });
  }


  testirajWebApi() :void
  {
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Drzava/GetAll_ForCmb",mojConfig.http_opcije()).subscribe(x=>{
      this.drzavePodatci = x;
    });
  }
}



