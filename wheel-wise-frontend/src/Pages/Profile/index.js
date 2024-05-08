import { json } from "react-router-dom";
import Profile from "./Profile";
export default Profile;

export async function loader(name){

    
    try {
        const userJson = window.localStorage.getItem("user")
        let token;
        if (userJson != null) {
            const user = JSON.parse(userJson)
            if (user &&  user.hasOwnProperty("token")) {
                token = user.token;
            }
        }
        const requestOptions = {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}` 
            }
        };
        const res = await fetch(`/api/user/${name}`, requestOptions);
        const data = await res.json();
        console.log(data)
        return data;
    } catch (e) {
        console.log(e);
    }
}