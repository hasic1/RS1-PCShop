import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../moj-config";

@Component({
  selector: 'app-postovi',
  templateUrl: './postovi.component.html',
  styleUrls: ['./postovi.component.css']
})
export class PostoviComponent implements OnInit {

  postoviPodatci:any;
  odabraniPost: any=null;

  constructor(private httpKlijent: HttpClient) {
  }


  ngOnInit(): void {
    this.testirajWebApi();
  }
  testirajWebApi() {
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Post/GetAll").subscribe(x=>{
      this.postoviPodatci = x;
    });
  }
  getPostoviPodaci() {
    if (this.postoviPodatci == null)
      return [];
    return this.postoviPodatci;
  }
}
