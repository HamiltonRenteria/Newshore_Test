import { Flight } from "./Flight";

export class Journey {
  origin!: string;
  destination!:string;
  price!: number;
  flights!: Flight[];
}
