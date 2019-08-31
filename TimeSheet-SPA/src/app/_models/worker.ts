import { User } from './user';

export interface Worker {
    workerId: number;
    user: User;
    role: string;
    timeAdded: Date;
    timeSpent: number;
}
