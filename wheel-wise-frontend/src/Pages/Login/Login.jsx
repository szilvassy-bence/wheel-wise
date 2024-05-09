import { useContext, useState } from "react";
import { AuthContext } from "../Layout/Layout";
import {Link} from "react-router-dom";
import "./Login.css";

import React from 'react'

const Login = () => {
	
		const [loginForm, setLoginForm] = useState({
			email: "",
			password: ""
		});
		const {user, login} = useContext(AuthContext);
		
		const submitLogin = async(e) => {
			e.preventDefault();
      await login(loginForm);
		}


	return (
		<div className="form-wrapper" id="login-wrapper"> { user === null ? (
			<>
					<h3>Login</h3>
					<form className="registration-login-form on-white" id="login-form" onSubmit={submitLogin}>
					<label>
						<span>Email</span>
						<input 
							type="email" 
							name="email" 
							placeholder="Email" 
							onChange={(e) => {
								setLoginForm({...loginForm, email: e.target.value});
							}} />
					</label>
					<label>
						<span>Password</span>
						<input 
							type="password" 
							name="password" 
							placeholder="Password" 
							onChange={(e) => {
								setLoginForm({...loginForm, password: e.target.value});
							}} />
					</label>
					<button id="submit-btn" type="submit">Login</button>
				</form>
			</>
			

		) : (
			<>
				<h2>You are currently logged in as {user.userName}</h2>
				<h4>Click <Link to={`/users/${user.userName}`}>here</Link> to check your account</h4>
			</>
		)}</div>
	)
}

export default Login