import React, {SyntheticEvent, useEffect, useState} from 'react';
import './App.css';
import {Link, Outlet} from "react-router-dom";
import Login from "./components/Login/Login";
import {Api} from "./api/Api";

function App() {
    const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    
    useEffect( () => {
        Api.IsAuthenticated()
            .then(x => {
                setIsAuthenticated(x.IsAuthenticated)
                setIsLoading(false);
            });
    }, [])
    
    if (!isAuthenticated){
        if (isLoading){
            return (<h1>Loading</h1>);
        } 
        return (<Login setIsAuthenticated={setIsAuthenticated}/>);
    }

    const handleLogout = async (e: SyntheticEvent) => {
        e.preventDefault();
        await Api.Logout();
        setIsAuthenticated(false);
    }
    
    return (
        <div className="wrapper">
            <h1>Application</h1>
            <nav
                style={{
                    borderBottom: "solid 1px", 
                    paddingBottom: "1rem"
                }}
            >
                <Link to="/dashboard">Dashboard</Link> | {" "}
                <Link to="/preferences">Preferences</Link> | {" "}
                <a href={"/"} onClick={handleLogout}>Logout</a>
            </nav>
            <Outlet />
        </div>
    );
}

export default App;
