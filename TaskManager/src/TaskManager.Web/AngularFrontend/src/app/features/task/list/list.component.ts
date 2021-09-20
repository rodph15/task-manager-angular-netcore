import { Component, OnInit } from '@angular/core';
import { Task } from 'src/app/domain/entities/task';
import { TaskService } from 'src/app/service/task-service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  public taskList:Array<Task> = new Array();

  constructor(private _taskService:TaskService, private toastr: ToastrService,private _router:Router,private _routeActivated: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.fetchList();
  }

  fetchList(){
    this._taskService.GetTasks().subscribe(data =>{
      this.taskList = data;
    })
  }

  DeleteTask(taskName:String){
    this._taskService.DeleteTask(taskName).subscribe(data =>{
      this.toastr.success(data, `Sucesso`);
      this.fetchList();
    });
  }

}
