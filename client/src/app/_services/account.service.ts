import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject} from 'rxjs';
import {map} from 'rxjs/operators';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = "https://localhost:7036/api/";
  private currentUserSource = new BehaviorSubject<User | null>(null);;
  currentUser$=this.currentUserSource.asObservable();
  constructor(private http: HttpClient) { }

  login(model:any)
  {
    return this.http.post(this.baseUrl+'account/login',model).pipe(
      map((response)=>{
        const user = response as User;
        if(user)
        {
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user;
      })
    )
  }

  register(model:any){
    return this.http.post<User>(this.baseUrl+'account/register',model).pipe(
      map(user=>{
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }

  setCurrentUser(user:User){
      this.currentUserSource.next(user);
  }
  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
