import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonComponent } from './Person/Person.component';
import { CounterComponent } from './counter/counter.component';


//rutas del navbar
const routes: Routes = [
  { path: 'Person', component: PersonComponent },
  { path: 'count', component: CounterComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
