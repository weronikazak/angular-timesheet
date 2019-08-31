import { Worker } from './worker';

export interface Group {
    groupId: number;
    headOfProject: Worker;
    memebers: Worker[];
    timeStart: Date;
    timeEnd: Date;
    spentHours: number;
}
