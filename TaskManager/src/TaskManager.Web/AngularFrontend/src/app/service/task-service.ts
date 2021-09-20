import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../environments/environment';
import { Task } from '../domain/entities/task';
import { ITask } from '../domain/interfaces/itask';

@Injectable()
export class TaskService {

  private TaskUrl: string = "api/task";

  constructor(private http: HttpClient) { }

  CreateTask(task:Task): Observable<any>{
    return this.http.post<ITask>(`${environment.url}${this.TaskUrl}`,task);
  }

  UpdateTask(task:Task): Observable<any>{
    return this.http.put<ITask>(`${environment.url}${this.TaskUrl}`,task);
  }

  DeleteTask(taskName:String): Observable<any>{
    return this.http.delete<ITask>(`${environment.url}${this.TaskUrl}/${taskName}`);
  }

  GetTask(taskName:String): Observable<any>{
    return this.http.get<ITask>(`${environment.url}${this.TaskUrl}/${taskName}`);
  }

  GetTasks(): Observable<any>{
    return this.http.get<ITask>(`${environment.url}${this.TaskUrl}`);
  }

}
