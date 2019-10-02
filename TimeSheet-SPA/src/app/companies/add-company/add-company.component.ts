import { Component, OnInit, Output, Input } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-add-company',
  templateUrl: './add-company.component.html',
  styleUrls: ['./add-company.component.css']
})
export class AddCompanyComponent implements OnInit {
  companyForm: FormGroup;
  @Input() addProject: boolean;

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.createCompanyForm();
  }

  createCompanyForm() {
    this.companyForm = this.fb.group({
      companyName: ['', Validators.required],
      przedstawicielImie: ['', Validators.required],
      przedstawicielNazwisko: ['', Validators.required],
      ulica: [''],
      miasto: ['', Validators.required],
      kodPocztowy: [''],
      phoneNumber: ['',
        [Validators.required, Validators.minLength(9), Validators.maxLength(12)]]
    });
  }

}
