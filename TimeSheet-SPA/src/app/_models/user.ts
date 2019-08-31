import { Project } from './project';

export interface User {
    userId: number;
    email: string;
    name: string;
    surname: string;
    gender: string;
    dateOfBirth: Date;
    lastActive: Date;
    projects: Project[];
}
