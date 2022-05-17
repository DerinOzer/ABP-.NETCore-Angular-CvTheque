import { Component, OnInit } from '@angular/core';
import{ CandidateSkillService,  CandidateSkillDto} from '@proxy/candidates';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { ListService, PagedResultDto } from '@abp/ng.core';

@Component({
  selector: 'app-candidate-skill',
  templateUrl: './candidate-skill.component.html',
  styleUrls: ['./candidate-skill.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }]
})
export class CandidateSkillComponent implements OnInit {
  candidateSkill = { items: [], totalCount: 0 } as PagedResultDto<CandidateSkillDto>;
  isModalOpen = false;
  form: FormGroup;
  selectedCandidateSkill = {} as CandidateSkillDto;

  constructor(
    public readonly list : ListService,
    private candidateSkillService : CandidateSkillService,
    private formBuilder : FormBuilder,
    private confirmation: ConfirmationService
  ) { }

  ngOnInit(): void {
    const candidateSkillStreamCreator = (query) => this.candidateSkillService.getList(query);
    this.list.hookToQuery(candidateSkillStreamCreator).subscribe((response)=>{
      this.candidateSkill = response;
    });
  }

  createCandidateSkill(){
    this.selectedCandidateSkill = {} as CandidateSkillDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  updateCandidateSkill(id : string){
    this.candidateSkillService.get(id).subscribe((skill) => {
      this.selectedCandidateSkill = skill;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  deleteCandidateSkill(id:string){
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure')
    .subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.candidateSkillService.delete(id).subscribe(() => this.list.get());
      }});
  }

  buildForm(){
    this.form = this.formBuilder.group({
      skillName : [this.selectedCandidateSkill.skillName || '', Validators.required]
    });
  }

  save(){
    if (this.form.invalid) {
      return;
    }

    if(this.selectedCandidateSkill.id){
      this.candidateSkillService.update(this.selectedCandidateSkill.id, this.form.value).subscribe(()=>{
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();});
    }
    else{
      this.candidateSkillService.create(this.form.value).subscribe(()=>{
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();});
    }
  }





}
