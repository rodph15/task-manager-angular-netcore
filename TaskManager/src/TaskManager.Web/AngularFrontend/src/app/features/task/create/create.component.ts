import { Component, OnInit } from '@angular/core';
import { Task } from 'src/app/domain/entities/task';
import { TaskService } from 'src/app/service/task-service';
import * as $ from 'jquery';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  public task:Task = new Task();

  constructor(private _taskService:TaskService, private toastr: ToastrService,private _router:Router,private _routeActivated: ActivatedRoute) {

  }

  ngOnInit(): void {

  }

  createTask(btnSave:any){

      btnSave.disabled = true;
      $(btnSave).html("Saving please wait...");
      this._taskService.CreateTask(this.task).subscribe(data =>{
        console.log(data);
        this.toastr.success(data.message, `Sucesso`);
        this._router.navigate(['list']);
      }, error =>{
        btnSave.disabled = false;
        $(btnSave).html("Salvar");
      });


  }

}
