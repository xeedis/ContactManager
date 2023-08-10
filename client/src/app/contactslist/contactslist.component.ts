import { Component, OnInit } from '@angular/core';
import { Contact } from '../_models/Contact';
import { ContactsService } from '../_services/contacts.service';
import { map } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { CategoryService } from '../_services/category.service';
import { CategoryType } from '../_models/CategoryType';

@Component({
  selector: 'app-contactslist',
  templateUrl: './contactslist.component.html',
  styleUrls: ['./contactslist.component.css']
})
export class ContactslistComponent implements OnInit{
  contacts: any;
  selectedContact:any;
  categories: CategoryType[] = [];
  selectedCategory: CategoryType | null = null;
  
  editModes: { [key: number]: boolean } = {};
  constructor(private contactsService:ContactsService, public accountService: AccountService, private categoryService:CategoryService){}

  ngOnInit(){
    this.loadContacts();
    this.loadCategories();
    console.log(this.contacts);
    console.log(this.categories);
  }


  loadContacts(){
    this.contactsService.getContacts().subscribe({
      next: response=> this.contacts = response,
      error: error=>console.log(error)
    });
    }

    loadCategories() {
      this.categoryService.getCategories().subscribe({
        next: response=> this.categories = response as CategoryType[],
        error: error =>console.log(error)
      });
    }

    showDetails(name: string){
      this.contactsService.getContactByName(name).subscribe({
        next: response => this.selectedContact = response,
        error: error=>console.log(error)
      });
    }
    goBackToList() {
      this.selectedContact = null;
    }

    isEditMode(contact: Contact): boolean {
      return this.editModes[contact.id] === true;
    }

    enterEditMode(contact: Contact) {
      this.editModes[contact.id] = true;
    }

    cancelEditMode(contact: Contact) {
      this.editModes[contact.id] = false;

    }
    onCategoryChange() {
      if (this.selectedContact.categoryId) {
        this.selectedCategory = this.categories.find(category => category.id === this.selectedContact.categoryId);
      } else {
        this.selectedCategory = null;
      }
    }

    updateContact(){

    }
  }
