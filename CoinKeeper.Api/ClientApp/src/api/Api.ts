import {isDev} from "../utils/Utils";
import {Constants} from "../utils/Constants";
import {LoginModel} from "../models/User/LoginModel";
import {LoginResult} from "../models/User/LoginResult";
import {plainToClass} from "class-transformer";
import {UserStateViewModel} from "../models/User/UserStateViewModel";
import {RegisterModel} from "../models/User/RegisterModel";
import {RegistrationResult} from "../models/User/RegistrationResult";

export class Api {
    
    private static readonly baseURL: string = isDev() ? Constants.DEVELOPMENT_BACKEND_BASE_URL : Constants.PRODUCTION_BASE_URL;
    
    public static async Login(model: LoginModel): Promise<LoginResult> {
        let response = await fetch(`${this.baseURL}/api/account/login`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            credentials: "include",
            body: JSON.stringify(model)
        });

        return plainToClass(LoginResult, response.json());
    }
    
    public static async IsAuthenticated(): Promise<UserStateViewModel> {
        let response = await fetch(`${this.baseURL}/api/account/authenticated`, {
            method: "GET",
            credentials: "include"
        });
        
        return plainToClass(UserStateViewModel, response.json());
    }
    
    public static async Logout(): Promise<void> {
        await fetch(`${this.baseURL}/api/account/signout`, {
            method: "POST",
            credentials: "include"
        });
    }
    
    public static async Register(model: RegisterModel): Promise<RegistrationResult> {
        const response = await fetch(`${this.baseURL}/api/account/register`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            credentials: "include",
            body: JSON.stringify(model)
        });
        
        return plainToClass(RegistrationResult, response.json());
    }
}