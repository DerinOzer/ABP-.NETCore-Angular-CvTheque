import { Component, OnInit } from '@angular/core';
import{ SkillService,  SkillDto, CandidateService} from '@proxy/candidates';
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
  candidateSkill = { items: [], totalCount: 0 } as PagedResultDto<SkillDto>;
  isModalOpen = false;
  form: FormGroup;
  selectedCandidateSkill = {} as SkillDto;

  constructor(
    public readonly list : ListService,
    private skillService : SkillService,
    private candidateService: CandidateService,
    private formBuilder : FormBuilder,
    private confirmation: ConfirmationService
  ) { }

  ngOnInit(): void {
    const candidateSkillStreamCreator = (query) => this.skillService.getList(query);
    this.list.hookToQuery(candidateSkillStreamCreator).subscribe((response)=>{
      this.candidateSkill = response;
    });
  }

  createCandidateSkill(){
    this.selectedCandidateSkill = {} as SkillDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  updateCandidateSkill(id : string){
    this.skillService.get(id).subscribe((skill) => {
      this.selectedCandidateSkill = skill;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  deleteCandidateSkill(id:string){
    this.candidateService.getIsInSkillBySkillId(id).subscribe(response =>{
      var message='';
      console.log(response);
      console.log(id);
      if(response == true){
        message='This skill is already being used by candidates. Are you sure you want to delete it?'
      }
      else{
        message='::AreYouSureToDelete'
      }
      this.confirmation.warn(message, '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.skillService.delete(id).subscribe(() => this.list.get());
      }});
    });
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
      this.skillService.update(this.selectedCandidateSkill.id, this.form.value).subscribe(()=>{
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();});
    }
    else{
      this.skillService.create(this.form.value).subscribe(()=>{
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();});
    }
  }





}
