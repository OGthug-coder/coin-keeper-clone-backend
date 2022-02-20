import React, {SyntheticEvent, useState} from "react";
import "./Login.css"
import {LoginModel} from "../../models/User/LoginModel";
import {Api} from "../../api/Api";
import {LoginStatus} from "../../models/User/LoginStatus";
import {Link} from "react-router-dom";

export default function Login({ setIsAuthenticated } : any) {
    
    const [userName, setUserName] = useState<string>("")
    const [password, setPassword] = useState<string>("")
    
    const handleSubmit = async (e: SyntheticEvent) => {
        e.preventDefault();
        const loginResult = await Api.Login(new LoginModel(userName, password));
        switch (loginResult.Status){
            case LoginStatus.Success:
                setIsAuthenticated(true);
                break;
            case LoginStatus.Error:
                setIsAuthenticated(false);
                break;
        }
    }
    
    return (
        <div className="login-wrapper">
            <form onSubmit={handleSubmit}>
                <label>
                    <p>Username</p>
                    <input type="text" onChange={e => setUserName(e.target.value)} />
                </label>
                <label>
                    <p>Password</p>
                    <input type="password" onChange={e => setPassword(e.target.value)} />
                </label>
                <div>
                    <button type="submit">Submit</button>
                </div>
            </form>
            <Link to="/register">Register</Link>
        </div>
    );
}
