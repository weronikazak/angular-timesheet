import { Company } from './company';
import { Group } from './group';

export interface Project {
    projectId: number;
    projectName: string;
    company: Company;
    companyId: number;
    projectStart?: Date;
    deadLine?: Date;
    isFinished: boolean;
    groupId: number;
    group: Group;
    spentHours: number;
}
