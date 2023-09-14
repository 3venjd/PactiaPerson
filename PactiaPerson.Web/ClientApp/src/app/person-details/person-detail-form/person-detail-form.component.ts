import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { PersonDetail } from 'src/app/shared/person-detail.model';
import { PersonDetailService } from 'src/app/shared/person-detail.service';

@Component({
  selector: 'app-person-detail-form',
  templateUrl: './person-detail-form.component.html',
  styleUrls: ['./person-detail-form.component.css']
})
export class PersonDetailFormComponent implements OnInit {

  //se llama a la entidad y al servicio de toastr para usar los pop up
  constructor(public service: PersonDetailService, private toastr: ToastrService) { }

  ngOnInit() {
  }

  //ejecucion del boton submit para crear o editar un usuario
  onSubmit(form:NgForm){
    this.service.formSubmitted = true;
    if(form.valid){
      if(this.service.formData.id == 0){
        this.insertRecord(form)
      }
      else{
        this.UpdatetRecord(form)
      }
    } 
  }
  //metodo para insertar un usuario nuevo
  insertRecord(form: NgForm){
    this.service.postPersonDetail()
      .subscribe({
          next: res =>{
            this.service.ListPersons = res as PersonDetail[]  
            this.service.resetForm(form)
            this.toastr.success('Agregado exitosamente', 'Resgitro Persona');
          },
          error: err => this.toastr.error('Usuario no valido', 'Persona no valida')
      })
  }
  //metodo para actualizar un usuario seleccionado
  UpdatetRecord(form: NgForm){
    this.service.putPersonDetail()
      .subscribe({
          next: res =>{
            this.service.ListPersons = res as PersonDetail[]  
            this.service.resetForm(form)
            this.toastr.info('Actualizado exitosamente', 'Resgitro Persona');
          },
          error: err => {console.log(err)}
      })
  }
}
