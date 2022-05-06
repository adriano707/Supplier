import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Inject } from '@angular/core';

@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css']
})
export class SuppliersComponent implements OnInit {
  public suppliers: ISupplier[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ISupplier[]>('https://localhost:5002/persons').subscribe(result => {
      this.suppliers = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}

interface ISupplier {
  type: number;
  isNational: boolean;
  document: string;
  name: string;
}
