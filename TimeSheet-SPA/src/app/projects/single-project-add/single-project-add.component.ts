import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-single-project-add',
  templateUrl: './single-project-add.component.html',
  styleUrls: ['./single-project-add.component.css']
})
export class SingleProjectAddComponent implements OnInit {
  projectForm: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.createCompanyForm();
  }

  createCompanyForm() {
    this.projectForm = this.fb.group({
      projectName: ['', Validators.required],
      deadline: ['', Validators.required]
    });
  }
}
