import { Project } from './project';

export interface Company {
    companyId: number;
    companyName: string;
    przedstawicielImie: string;
    przedstawicielNazwisko: string;
    ulica: string;
    miasto: string;
    kodPocztowy: string;
    phoneNumber: number;
    projects: Project[];
}
