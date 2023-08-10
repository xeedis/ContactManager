import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Contact } from '../_models/Contact';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {
  contacts: Contact[];
  baseUrl = "https://localhost:7036/api/";
  constructor(private http: HttpClient) {
   }

   getContacts()
   {
      return this.http.get(this.baseUrl+'contacts');
   }

   getContactByName(name: string){
      return this.http.get<Contact>(this.baseUrl+ 'contacts/'+ name);
   }
}
