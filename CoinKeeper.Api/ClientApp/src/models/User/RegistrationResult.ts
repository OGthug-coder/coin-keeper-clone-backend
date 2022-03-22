import {RegistrationStatus} from "./RegistrationStatus";
import {UserViewModel} from "./UserViewModel";

export class RegistrationResult {
    public Status: RegistrationStatus = RegistrationStatus.Error;
    public Message: string = "";
    public Errors: string[] = [];
    public Data: UserViewModel | null = null;
}