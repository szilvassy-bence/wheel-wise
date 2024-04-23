import {Form} from "react-router-dom";
import "./Register.css";

export default function Register(){
    return (
        <div id="register">
            <h1>Register</h1>
            <Form method="post">
                <label>
                    <span>User name</span>
                    <input type="text" name="username" placeholder="User name"/>
                </label>
                <label>
                    <span>Email</span>
                    <input type="text" name="email" placeholder="Email"/>
                </label>
                <label>
                    <span>Password</span>
                    <input type="password" name="password" placeholder="Password"/>
                </label>
                <button type="submit">Register</button>
            </Form>
        </div>
    )
}