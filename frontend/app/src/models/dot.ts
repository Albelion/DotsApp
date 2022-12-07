import Comment from "./comment";
export default interface Dot {
    dotId: number;
    xpos: number;
    ypos: number;
    radius: number;
    color: string;
    comments: Comment[];
}