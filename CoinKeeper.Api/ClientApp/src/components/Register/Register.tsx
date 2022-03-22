import React, {SyntheticEvent, useState} from "react";
import {RegisterModel} from "../../models/User/RegisterModel";
import {Api} from "../../api/Api";
import {RegistrationStatus} from "../../models/User/RegistrationStatus";
import {useNavigate} from "react-router-dom";

export default function Register() {
    
    const [userName, setUserName] = useState<string>("");
    const [email, setEmail] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const [confirmPassword, setConfirmPassword] = useState<string>("");
    const [registrationCompleted, setRegistrationCompleted] = useState<boolean>(false);
    const navigate = useNavigate();
    
    if (registrationCompleted){
        navigate("/");
    }
    
    const handleSubmit = async (e: SyntheticEvent) => {
        e.preventDefault();

        const model = new RegisterModel(userName, email, password, confirmPassword);
        const registrationResult = await Api.Register(model);
        
        switch (registrationResult.Status){
            case RegistrationStatus.Success:
                setRegistrationCompleted(true)
                break
            case RegistrationStatus.Error:
                console.log(registrationResult);
                break;
            default:
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
                    <p>Email</p>
                    <input type="email" onChange={e => setEmail(e.target.value)} />
                </label>
                <label>
                    <p>Password</p>
                    <input type="password" onChange={e => setPassword(e.target.value)} />
                </label>
                <label>
                    <p>Confirm password</p>
                    <input type="password" onChange={e => setConfirmPassword(e.target.value)} />
                </label>
                <div>
                    <button type="submit">Submit</button>
                </div>
            </form>
        </div>
    );
}