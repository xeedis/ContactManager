import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CategoryType } from '../_models/CategoryType';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }
  baseUrl = "https://localhost:7036/api/";

  getCategories(){
    return this.http.get(this.baseUrl+ 'categories');
  }
  addCategory(model:CategoryType){
    this.http.post(this.baseUrl+ 'categories',model);
  }
}
