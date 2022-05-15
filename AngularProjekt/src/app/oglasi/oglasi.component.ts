import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../moj-config";
import {Oglas} from "../_helpers/Oglas";



declare function porukaSuccess(a: string):any;


@Component({
  selector: 'app-oglasi',
  templateUrl: './oglasi.component.html',
  styleUrls: ['./oglasi.component.css']
})

export class OglasiComponent implements OnInit {


  oglasiPodatci:any;
  odabraniOglas: any=null;
  total:number = 101;
  page:number = 1;
  limit:number = 10;
  loading:boolean = false;


  constructor(private httpKlijent:HttpClient ) {
  }


  testirajWebApi() {

   let parametri={
     page_number: this.page,
     items_per_page:this.limit
   }
   JSON.stringify(parametri)
      this.httpKlijent.get(mojConfig.adresa_servera+ "/Oglasi/GetAllPaged",
      {params:parametri},).subscribe((x:any)=>{
        this.oglasiPodatci=x['dataItems'];
        this.total=x['totalCount'];
        this.loading=false;
  console.log(this.page)

    });
  }

  getOglasiPodaci() {
    if (this.oglasiPodatci == null)
      return [];
    return this.oglasiPodatci;
  }

  ngOnInit(): void {
    this.testirajWebApi();
  }

  goToPrevious(): void {
    // console.log('Previous Button Clicked!');
    this.page--;
    this.testirajWebApi();
  }

  goToNext(): void {
    // console.log('Next Button Clicked!');
    this.page++;
    this.testirajWebApi();
  }

  goToPage(n: number): void {
    this.page = n;
    console.log(this.page)
    this.testirajWebApi();
  }

}
