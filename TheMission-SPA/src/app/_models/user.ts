import { Skill } from './skill';

export interface User {
    userId: number;
    username: string;
    skills?: Skill[];
}
