import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { CandidateService, CandidateDto } from '@proxy/entities'; //CandidateService is generated.
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';



@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.scss'],
  providers: [ListService],
})
export class CandidateComponent implements OnInit {

  candidate = { items: [], totalCount: 0 } as PagedResultDto<CandidateDto>;
  isModalOpen = false;
  form: FormGroup;

  selectedCandidate = {} as CandidateDto;

  sorted = [];
  listFinal = [];


  constructor(public readonly list: ListService, private candidateService:CandidateService, private formbuilder: FormBuilder,private confirmation: ConfirmationService) { }

  ngOnInit() {
    const candidateStreamCreator = (query) => this.candidateService.getList(query);
    this.list.hookToQuery(candidateStreamCreator).subscribe((response) => {this.candidate = response;});
  }

  sortByLastName(){
    for (let i = 0; i < this.list.maxResultCount; i++)
      this.sorted.push(this.list[i]);
    for (let j = 0; j < this.list.maxResultCount; j++)
      this.listFinal[j] = this.sorted.sort((a, b) => (b.lastName < a.lastName ? 1 : b.lastName > a.lastName ? -1 : 0))[j]
      console.log(this.listFinal);
  }

  deleteCandidate(id:string){
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {if (status === Confirmation.Status.confirm) {this.candidateService.delete(id).subscribe(()=>this.list.get())}});
  }

  createCandidate() {
    this.selectedCandidate = {} as CandidateDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editCandidate(id: string){
    this.candidateService.get(id).subscribe((candidate)=>{
      this.selectedCandidate=candidate;
      this.buildForm();
      this.isModalOpen = true;
    })
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

    const request = this.selectedCandidate.id?this.candidateService.update(this.selectedCandidate.id, this.form.value):this.candidateService.create(this.form.value);

    request.subscribe(()=>{this.isModalOpen=false; this.form.reset(); this.list.get();});
    
  }

}
