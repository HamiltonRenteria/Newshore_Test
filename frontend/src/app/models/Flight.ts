import { Transport } from "./Transport";

export class Flight {
  origin!: string;
  destination!:string;
  price!: number;
  transport!: Transport;
}
