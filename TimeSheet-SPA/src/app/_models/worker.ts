import { User } from './user';
import { Role } from './role';

export interface Worker {
    id: number;
    userId: number;
    user: User;
    roleId: number;
    role: Role;
    timeAdded: Date;
    timeSpent: number;
}
