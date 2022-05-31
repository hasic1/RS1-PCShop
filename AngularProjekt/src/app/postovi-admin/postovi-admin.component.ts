import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../moj-config";

declare function porukaSuccess(x:string):any;

@Component({
  selector: 'app-postovi-admin',
  templateUrl: './postovi-admin.component.html',
  styleUrls: ['./postovi-admin.component.css']
})
export class PostoviAdminComponent implements OnInit {
  odabraniPost: any=null;
  postPodaci:any;
  postoviPodatci:any;
  total:number = 1;
  page:number = 1;
  limit:number = 4;
  loading:boolean = false;
  constructor(private httpKlijent:HttpClient) { }

  getPostPodaci() {
    if (this.postPodaci==null)
      return[];
    return this.postPodaci;
  }



  ngOnInit(): void {
    this.testirajWebApi();
  }
  testirajWebApi() {

    let parametri={
      page_number: this.page,
      items_per_page:this.limit
    }
    JSON.stringify(parametri)
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Post/GetAllPaged",
      {params:parametri},).subscribe((x:any)=>{
      this.postoviPodatci=x['dataItems'];
      this.total=x['totalCount'];
      this.loading=false;
      console.log(this.page)

    });
  }
  getPostoviPodaci() {
    if (this.postoviPodatci == null)
      return [];
    return this.postoviPodatci;
  }

  goToPrevious(): void {

    this.page--;
    this.testirajWebApi();
  }

  goToNext(): void {

    this.page++;
    this.testirajWebApi();
  }

  goToPage(n: number): void {
    this.page = n;
    console.log(this.page)
    this.testirajWebApi();
  }
  detalji(p:any) {
    this.odabraniPost=p;
    this.odabraniPost.prikazi=true;
  }
  snimi() {
    this.httpKlijent.post(mojConfig.adresa_servera+ "/Post/Update/" + this.odabraniPost.id,this.odabraniPost)
      .subscribe((x:any)=>{
        alert("Uredu"+x.potvrdjena)
      })
  }
  btnNovi() {
    this.odabraniPost=
      {
        prikazi:true,
        naslov:"",
        sadrzaj:"",
        autorPostaID:1,
        lokacijaSlike:"negdje",
        datumObjave:new Date(),
      };
  }
  obrisi(p:any) {
    this.httpKlijent.post(mojConfig.adresa_servera+"/Post/Delete/"+p.id,null)
      .subscribe((x:any)=>{
        const index=this.postPodaci.indexOf(p);
        if(index>-1){
          this.postPodaci.splice(index,1);
        }
        porukaSuccess("Post uspjesno obrisan");
      })
  }
}
