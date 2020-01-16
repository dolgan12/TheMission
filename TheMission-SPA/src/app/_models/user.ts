import { Skill } from './skill';

export interface User {
    userid: number;
    username: string;
    skills?: Skill[];
}
