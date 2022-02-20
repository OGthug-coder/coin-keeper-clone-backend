import {LoginStatus} from "./LoginStatus";
import {UserViewModel} from "./UserViewModel";

export class LoginResult {
    public Status: LoginStatus | null = null;
    public Message: string | null = null;
    public Errors: string[] | null = null;
    public Data: UserViewModel | null = null;
}