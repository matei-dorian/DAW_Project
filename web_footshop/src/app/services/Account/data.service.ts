import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { IUser } from '../../Interfaces/IUser';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  public loginUrl: string = "https://localhost:44337/api/Auth/Login";
  public registerUrl: string = "https://localhost:44337/api/Auth/Register";

  private userSource = new BehaviorSubject({
    email: '',
    password: '',
    role: 'Customer'
  });

  public currentUser = this.userSource.asObservable();

  constructor(private http: HttpClient) { }

  public changeUserData(user: IUser ): void{
    this.userSource.next(user)
  }

  public loginUser(user: IUser){
    return this.http.post<string>(`${this.loginUrl}`, user);
  }

  public registerUser(user: IUser){
    return this.http.post<string>(`${this.registerUrl}`, user);
  }
}
