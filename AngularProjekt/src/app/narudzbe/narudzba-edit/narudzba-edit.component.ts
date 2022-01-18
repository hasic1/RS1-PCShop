import {Component, Input, OnInit} from '@angular/core';
import {mojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-narudzba-edit',
  templateUrl: './narudzba-edit.component.html',
  styleUrls: ['./narudzba-edit.component.css']
})

export class NarudzbaEditComponent implements OnInit {
 @Input()
 urediNarudzbu:any;
  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
  }
  snimi() {
    if(this.urediNarudzbu.id==null){
      this.urediNarudzbu.aktivna=false;//definirano kao false jer ukoliko ne promjenimo vrijednost checkboxa salje se 0 umjseto true ili false
      this.urediNarudzbu.potvrdjena=false;//definirano kao false jer ukoliko ne promjenimo vrijednost checkboxa salje se 0 umjseto true ili false
      this.httpKlijent.post(mojConfig.adresa_servera+"/Narudzba/Add",this.urediNarudzbu).subscribe((x:any)=>{
        porukaSuccess("Narudzba uspjesno kreirana" +x.Aktivna);
        this.urediNarudzbu.prikazi=false;
        }
      )
    }
    else{
    this.httpKlijent.post(mojConfig.adresa_servera+ "/Narudzba/Update/" + this.urediNarudzbu.id, this.urediNarudzbu).subscribe((x:any) => {
      porukaSuccess("uredu..." + x.aktivna);
      this.urediNarudzbu.prikazi = false;

    });
    }
  }
}
