export class LoginModel {
    
    public UserName: string;
    public Password: string;
    
    public constructor(userName: string, password: string) {;
        this.UserName = userName;
        this.Password = password;
    }
}