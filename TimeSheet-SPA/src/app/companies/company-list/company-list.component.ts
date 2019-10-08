import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'src/app/_services/company.service';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Company } from 'src/app/_models/company';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css']
})
export class CompanyListComponent implements OnInit {
  companies: Company[];
  selected: Company;
  client_names: string[];

  constructor(private companyService: CompanyService, private http: HttpClient,
    private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadCompanies();
  }

  loadCompanies() {
    this.companyService.getCompanies().subscribe((companies: Company[]) => {
      this.companies = companies;
      this.client_names = companies.map(c => c.companyName);
    }, error => {
      this.alertify.error(error);
    });
  }

}
