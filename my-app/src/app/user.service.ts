import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
// user.interface.ts
export interface User {
  id: number;
  name: string;
  email: string;
  password: string;
  user_type: string;
}

@Injectable({
  providedIn: 'root'
})


export class UserService {


  constructor(private http: HttpClient) { }

  loginuser(eamil : string): Observable<any> {
    return this.http.get<any>(`http://localhost:5205/api/Users/email/${eamil}`);
  }

  // Add other API calls here as needed
}
