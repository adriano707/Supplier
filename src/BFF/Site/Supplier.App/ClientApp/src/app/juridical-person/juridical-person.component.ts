import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-juridical-person',
  templateUrl: './juridical-person.component.html',
  styleUrls: ['./juridical-person.component.css']
})
export class JuridicalPersonComponent implements OnInit {
  public data: IJuridicalPerson;
  id: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.http.get<IJuridicalPerson>(this.baseUrl + 'juridical-persons/' + this.id).subscribe(result => {
      this.data = result;
    }, error => console.error(error));
  }

}

interface IJuridicalPerson {
  Type: number;
  IsNational: boolean;
  LastUpdateDate: Date;
  Status: number;
  Document: string;
  TradeName: string;
  FantasyName: string;
  Size: number;
  WebSite: string;
  ShareQuantity: number;
  ValueShare: number;
  SocialCapital: number;
}
