import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { Company } from '../_models/company';


@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

  getCompanies(): Observable<Company[]> {
    return this.http.get<Company[]>(this.baseUrl + 'company');
  }

  // getCompany(id: number): Observable<Company> {
  //   return this.http.get<Company>(this.baseUrl + 'user/' + id);
  // }

  updateCompany(id: number, company: Company) {
    return this.http.put(this.baseUrl + 'company/' + id, company);
  }
}
