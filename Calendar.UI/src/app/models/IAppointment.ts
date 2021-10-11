import { IAttendee } from "./IAttendee";
import { IUser } from "./IUser";

export interface IAppointment {
  id: number;
  description: string;
  date: Date;
  organizer:string;
  attendee: IAttendee[];
}
