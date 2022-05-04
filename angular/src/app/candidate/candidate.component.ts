import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { CandidateService, CandidateDto } from '@proxy/entities'; //CandidateService is generated.
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class CandidateComponent implements OnInit {

  candidate = { items: [], totalCount: 0 } as PagedResultDto<CandidateDto>;
  isModalOpen = false;
  form: FormGroup;

  constructor(public readonly list: ListService, private candidateService:CandidateService, private formbuilder: FormBuilder) { }

  ngOnInit() {
    const candidateStreamCreator = (query) => this.candidateService.getList(query);
    this.list.hookToQuery(candidateStreamCreator).subscribe((response) => {this.candidate = response;});
  }

  createCandidate() {
    this.buildForm();
    this.isModalOpen = true;
  }

  buildForm(){
    this.form = this.formbuilder.group({
      name:['', Validators.required],
      lastName:['', Validators.required],
      email:['', Validators.required],
      availability: [null],
      noticeDuration:[0],
      lastContact:[null],
      currentSalary:[0],
      requestedSalary:[0],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    this.candidateService.create(this.form.value).subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }

}
