import "./Layout.css"
import {Outlet, useNavigate} from "react-router-dom"
import MainNav from "../../Components/MainNav"
import {createContext, useMemo, useEffect, useState, useContext} from "react";
import {useLocalStorage} from "../../Hooks/useLocalStorage.jsx";


export const AuthContext = createContext(null);
export const FavoriteContext = createContext(null);

export default function Layout() {
    
    const [favorites, setFavorites] = useState([]);
    const [userAds, setUserAds] = useState([]);
    const [user, setUser] = useLocalStorage("user", null);
    const navigate = useNavigate();

    const login = async (data) => {
        try {
            let res = await fetch("/api/Auth/Login", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(data),
            });
            if (res.status === 400) {
                console.error("Bad request. Please check your input.");
                return false;
            }
            let user = await res.json();
            console.log(user);
            setUser(user);
            navigate("/");
            return true;
        } catch (e) {
            console.log(e)
        }
    }

    const logout = () => {
        setUser(null);
        navigate("/", {replace: true});
    }


    function getRequestOptions(){
        const requestOptions = {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${user.token}` 
            }
        };
        return requestOptions;
    }


    useEffect(() =>{
        async function fetchFavorites(){
            try {
                const res = await fetch(`/api/user/${user.userName}/favorites`, getRequestOptions());
                const data = await res.json();
                setFavorites(data);
                console.log("favorites: " + data );
            } catch(err) {
                console.error(err);
            }
        }
        if (user != null)
        {fetchFavorites()}
    }, [user])

    useEffect(() =>{
        async function fetchUserAds(){
            try {
                const res = await fetch(`/api/user/${user.userName}/ads`, getRequestOptions());
                const data = await res.json();
                setUserAds(data);
                console.log(data)
            } catch(e) {
                console.log(e);
            }
        }
        if (user != null)
            fetchUserAds();
    }, [user])
    
    

    const value = useMemo(
        () => ({
            user, login, logout
        }), [user]
    )

    return (
        <AuthContext.Provider value={value}>
            <FavoriteContext.Provider value={[favorites, setFavorites, userAds, setUserAds]} >
                <MainNav/>
                <div id="main-content">
                    <Outlet/>
                </div>
            </FavoriteContext.Provider>
        </AuthContext.Provider>
    )
}

export const useAuth = () => {
    return useContext(AuthContext);
  };