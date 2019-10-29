import { Company } from './company';
import { User } from './user';

export interface Project {
    id: number;
    projectName: string;
    companyId: number;
    company: Company;
    projectStart?: Date;
    deadline?: Date;
    isFinished: boolean;
    userId: number;
    user: User;
    spentHours: number;
    worker: Worker[];
}
