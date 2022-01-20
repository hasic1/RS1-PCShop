import {Component, Input, OnInit} from '@angular/core';
import {mojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-proizvod-edit',
  templateUrl: './proizvod-edit.component.html',
  styleUrls: ['./proizvod-edit.component.css']
})
export class ProizvodEditComponent implements OnInit {
  @Input()
  urediProizvod: any;


  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
  }

  snimi() {
    if(this.urediProizvod.proizvodID==null){
      this.urediProizvod.snizen=false;//definirano kao false jer ukoliko ne promjenimo vrijednost checkboxa salje se 0 umjseto true ili false
      this.httpKlijent.post(mojConfig.adresa_servera+"/Proizvod/Add",this.urediProizvod).subscribe((x:any)=>{
          porukaSuccess("Proizvod " +x.nazivProizvoda +" uspjesno dodat");
          this.urediProizvod.prikazi=false;
        }
      )
    }
    else{
      this.httpKlijent.post(mojConfig.adresa_servera+ "/Proizvod/Update/" + this.urediProizvod.proizvodID, this.urediProizvod).subscribe((x:any) => {
        porukaSuccess("Proizvod sa naziviom '" + x.nazivProizvoda+"' uspjesno editovan");
        this.urediProizvod.prikazi = false;

      });
  }
}
}
