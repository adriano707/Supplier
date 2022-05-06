import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-juridical-person',
  templateUrl: './juridical-person.component.html',
  styleUrls: ['./juridical-person.component.css']
})
export class JuridicalPersonComponent implements OnInit {
  public data: IJuridicalPerson;
  id: string;

  constructor(private http: HttpClient, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.http.get<IJuridicalPerson>('https://localhost:5002/persons/juridical-persons/' + this.id).subscribe(result => {
      this.data = result;
    }, error => console.error(error));
  }

}

interface IJuridicalPerson {
  type: number;
  isNational: boolean;
  lastUpdateDate: Date;
  status: number;
  document: string;
  tradeName: string;
  fantasyName: string;
  size: number;
  webSite: string;
  shareQuantity: number;
  valueShare: number;
  socialCapital: number;
}
