import { Component, OnInit } from '@angular/core';
import { Task } from 'src/app/domain/entities/task';
import { TaskService } from 'src/app/service/task-service';
import * as $ from 'jquery';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  public task:Task = new Task();

  constructor(private _taskService:TaskService, private toastr: ToastrService,private _router:Router,private _routeActivated: ActivatedRoute) {

  }

  ngOnInit(): void {
    this._routeActivated.params
    .subscribe(params => {
        this._taskService.GetTask(params.name).subscribe(data =>{
           this.task = data;
        });
    });
  }

  UpdateTask(btnSave:any){

      btnSave.disabled = true;
      $(btnSave).html("Editing please wait...");
      this._taskService.UpdateTask(this.task).subscribe(data =>{
        this.toastr.success(data.message, `Sucesso`);
        this._router.navigate(['list']);
      }, error =>{
        btnSave.disabled = false;
        $(btnSave).html("Salvar");
      });
  }

}
