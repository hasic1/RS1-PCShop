import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-obavjesti',
  templateUrl: './obavjesti.component.html',
  styleUrls: ['./obavjesti.component.css']
})
export class ObavjestiComponent implements OnInit {

  obavjesti :any;

  constructor() { }

  ngOnInit(): void {
  }

}
