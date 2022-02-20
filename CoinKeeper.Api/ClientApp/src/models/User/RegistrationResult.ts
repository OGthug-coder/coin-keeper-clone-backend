import {RegistrationStatus} from "./RegistrationStatus";
import {string} from "prop-types";
import {UserViewModel} from "./UserViewModel";

export class RegistrationResult {
    public Status: RegistrationStatus = RegistrationStatus.Error;
    public Message: string = "";
    public Errors: string[] = [];
    public Data: UserViewModel | null = null;
}