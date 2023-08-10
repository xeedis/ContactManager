import { Contact } from "./Contact";
import { SubcategoryType } from "./SubcategoryType";

export interface CategoryType{
    id:number;
    name:string;
    alignedContacts: Contact[];
    subcategoryId: number;
    subcategory: SubcategoryType;
}