import "./MainNav.css";
import {useRef, useState, useContext, useEffect} from "react";
import {AuthContext} from "../../Pages/Layout/Layout.jsx";
import {Link, useNavigate} from "react-router-dom";

export default function MainNav() {

    const [isLoginOpen, setIsLoginOpen] = useState(false);
    const [isSearchActive, setIsSearchActive] = useState(false);
    const [headerEmail, setHeaderEmail] = useState(null);
    const [headerPassword, setHeaderPassword] = useState(null);
    const [headerIsLoginSuccessful, setHeaderIsLoginSuccessful] = useState(null);
    const dropdownRef = useRef(null);
    const menuSearchDiv = useRef(null);
    const menuSearchInput = useRef(null);
    const {user, login, logout} = useContext(AuthContext);
    const navigate = useNavigate();

    function toggleLogin() {
        console.log("Login toggled.")
        setIsLoginOpen(prevState => !prevState);
    }

    function toggleSearch() {
        setIsSearchActive(prevState => !prevState);
    }

    useEffect(() => {
        if (isSearchActive){
            menuSearchInput.current.focus();
        }
    }, [isSearchActive]);

    function handleLogout() {
        logout();
        setIsLoginOpen(prevState => !prevState);
    }

    function handleAccountClick() {
        setIsLoginOpen(false);
        navigate(`/users/${user.userName}`)
    }

    async function onHeaderLogin(e){
        e.preventDefault();
        const userToLogin = {
            email: headerEmail,
            password: headerPassword
        };
        if (await login(userToLogin)){
            setIsLoginOpen(prevState => !prevState);
            setHeaderIsLoginSuccessful(true);
        } else{
            setHeaderIsLoginSuccessful(false);
        }
    }

    return (
        <header>
            <div id="navigation">
                <div className="logo">
                    <Link to="/" id="nav-logo">Logo</Link>
                </div>
                <ul className="menu">
                    <li>
                        <Link to="/ads" id="nav-ads">Ads</Link>
                    </li>
                </ul>
                <div className="user-menu">
                    <div id="search">
                        <div onClick={toggleSearch} className="user-menu-items">
                            <svg aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24"
                                 fill="none"
                                 viewBox="0 0 24 24">
                                <path stroke="currentColor" strokeLinecap="round" strokeWidth="2"
                                      d="m21 21-3.5-3.5M17 10a7 7 0 1 1-14 0 7 7 0 0 1 14 0Z"/>
                            </svg>
                            <span className="user-menu-span">Search</span>
                        </div>
                        { isSearchActive && (
                            <div className={"user-menu-search"} ref={menuSearchDiv}>
                                <input type="text" ref={menuSearchInput}/>
                            </div>
                        )}
                    </div>
                    <div id="account">
                        <div onClick={toggleLogin} className="user-menu-items">
                            <svg aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24"
                                 fill="none"
                                 viewBox="0 0 24 24">
                                <path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round"
                                      strokeWidth="2"
                                      d="M12 21a9 9 0 1 0 0-18 9 9 0 0 0 0 18Zm0 0a8.949 8.949 0 0 0 4.951-1.488A3.987 3.987 0 0 0 13 16h-2a3.987 3.987 0 0 0-3.951 3.512A8.948 8.948 0 0 0 12 21Zm3-11a3 3 0 1 1-6 0 3 3 0 0 1 6 0Z"/>
                            </svg>
                            <span className="user-menu-span">{user != null ? user.userName : "Account"}</span>
                        </div>

                        {isLoginOpen && (
                            <div className="dropdown-menu" ref={dropdownRef}>
                                {user == null ? (
                                    <>
                                        <h3>Login</h3>
                                        <form id="navigation-login-form" onSubmit={onHeaderLogin}>
                                            <label>
                                                <span>Email</span>
                                                <input type="text" name="email" placeholder="Email" onChange={(e) => setHeaderEmail(e.target.value)}/>
                                            </label>
                                            <label>
                                                <span>Password</span>
                                                <input type="password" name="password" placeholder="Password" onChange={(e) => setHeaderPassword(e.target.value)}/>
                                            </label>

                                            <button id="submit-btn" type="submit">Login</button>
                                        </form>
                                        <Link to="/register" >Register</Link>
                                        { headerIsLoginSuccessful === false && (
                                            <div>
                                                <p>Login is not successful, try again!</p>
                                            </div>
                                        )}
                                    </>
                                ) : (
                                    <>
                                        <h4>Welcome, {user.userName}</h4>
                                        <ul>
                                            <li onClick={handleAccountClick}>Account</li>
                                            <li onClick={handleLogout}>Logout</li>
                                        </ul>
                                    </>
                                )
                                }
                            </div>
                        )}

                    </div>
                </div>
            </div>
        </header>
    )
}