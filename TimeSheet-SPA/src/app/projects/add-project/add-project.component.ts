import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CompanyService } from 'src/app/_services/company.service';
import { Company } from 'src/app/_models/company';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css']
})
export class AddProjectComponent implements OnInit {
  baseUrl = environment.apiUrl;
  companyList: string[];
  selected: string;
  addProject = false;

  constructor(private companyService: CompanyService) { }

  ngOnInit() {
    this.loadCompanies();
  }

  loadCompanies() {
    this.companyService.getCompanies().subscribe((companies: Company[]) => {
      this.companyList = companies.map(c => c.companyName);
    });
  }

}
