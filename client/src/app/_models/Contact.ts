import { CategoryType } from "./CategoryType";
import { SubcategoryType } from "./SubcategoryType";

export interface Contact{
    id: number;
    firstname: string;
    lastname: string;
    email: string;
    password: string;
    categoryId: number;
    category: CategoryType;
    phone: string;
    dateofbirth: Date;
}