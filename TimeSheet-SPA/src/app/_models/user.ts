import { Project } from './project';

export interface User {
    id: number;
    email: string;
    name: string;
    surname: string;
    userPhoto: string;
    gender: string;
    dateOfBirth: Date;
    lastActive: Date;
    projects: Project[];
}
