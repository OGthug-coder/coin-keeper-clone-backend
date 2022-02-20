export class RegisterModel {
    public Name: string = "";
    public Email: string = "";
    public Password: string = "";
    public ConfirmPassword: string = "";
    
    constructor(name: string, email: string, password: string, confirmPassword: string) {
        this.Name = name;
        this.Email = email;
        this.Password = password;
        this.ConfirmPassword = confirmPassword;
    }
}