import { Company } from './company';
import { Group } from './group';
import { User } from './user';

export interface Project {
    projectId: number;
    projectName: string;
    company: Company;
    companyId: number;
    projectStart?: Date;
    deadline?: Date;
    isFinished: boolean;
    userId: number;
    user: User;
    spentHours: number;
}
