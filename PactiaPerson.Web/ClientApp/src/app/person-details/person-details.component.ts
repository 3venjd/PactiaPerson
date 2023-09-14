import { Component, OnInit } from '@angular/core';
import { PersonDetailService } from '../shared/person-detail.service';
import { PersonDetail } from '../shared/person-detail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-person-details',
  templateUrl: './person-details.component.html',
  styleUrls: ['./person-details.component.css']
})
export class PersonDetailsComponent {

  constructor(public service: PersonDetailService, private toastr: ToastrService) {
  }

  ngOnInit():void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: PersonDetail){
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id : number){
    if(confirm('Are you sure to delete this record?')){
      this.service.DeletePersonDetail(id)
      .subscribe({
        next: res => {
          this.service.ListPersons = res as PersonDetail[];
          this.toastr.error('Deleted Successfully', 'Person Detail')
        }
      })
    }
    
  }
}
