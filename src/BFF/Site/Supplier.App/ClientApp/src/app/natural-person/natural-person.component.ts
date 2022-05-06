import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-natural-person',
  templateUrl: './natural-person.component.html',
  styleUrls: ['./natural-person.component.css']
})
export class NaturalPersonComponent implements OnInit {
  public data: INaturalPerson;
  id: string;

  constructor(private http: HttpClient, private route: ActivatedRoute) {
    
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.http.get<INaturalPerson>('https://localhost:5002/persons/natural-persons/' + this.id).subscribe(result => {
      this.data = result;
    }, error => console.error(error));
  }

}

interface INaturalPerson {
  Type: number;
  IsNational: boolean;
  LastUpdateDate: Date;
  Status: number;
  Document: string;
  Name: string;
  MaritalStatus: number;
  Profession: string;
  CompanyType: number;
  BirthDate: Date;
  Gender: number;
  Nationality: string;
}
