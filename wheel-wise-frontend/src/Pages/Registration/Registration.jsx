import { useState, useRef } from "react";
import { useNavigate} from "react-router-dom";
import "./Registration.css";

export default function Register(){

    const [registrationForm, setRegistrationForm] = useState({
        username: "",
        email: "",
        password: ""
    });

    const [regModal, setRegModal] = useState(false);
    const navigate = useNavigate();
    const popUpRef = useRef();

    const submitRegistration = async (e) => {
        e.preventDefault();
        try {
            let res = await fetch("/api/Auth/Register", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(registrationForm),
            });
            if (res.ok){
                let data = await res.json();
                //console.log(data);
                popUpRef.current.classList.add("show");
                setTimeout(() => navigate("/login"), 2000);
            }
        } catch (error) {
            console.log(`Error during registering: ${error.message}`);
        }
    }

    return (
        <div className="form-wrapper" id="registration-wrapper">
            <h1>Register</h1>
            <form className="registration-login-form on-white" id="registration-form" onSubmit={submitRegistration}>
                <label>
                    <span>User name</span>
                    <input 
                        type="text" 
                        name="username" 
                        placeholder="User name" 
                        value={registrationForm.username} 
                        onChange={(e) => setRegistrationForm({...registrationForm, username: e.target.value})}/>
                </label>
                <label>
                    <span>Email</span>
                    <input 
                        type="email" 
                        name="email" 
                        placeholder="Email"
                        value={registrationForm.email} 
                        onChange={(e) => setRegistrationForm({...registrationForm, email: e.target.value})}/>
                </label>
                <label>
                    <span>Password</span>
                    <input 
                        type="password"
                        name="password" 
                        placeholder="Password"
                        value={registrationForm.password} 
                        onChange={(e) => setRegistrationForm({...registrationForm, password: e.target.value})}/>
                </label>
                <button type="submit">Register</button>
            </form>
            
            <div id="successful-registration" ref={popUpRef}>
                <h2>You registered successfully</h2>
                <h4>Redirecting to login page...</h4>
            </div>
            
        </div>
    )
}