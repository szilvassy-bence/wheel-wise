import "./Profile.css";
import { useState, useContext, useRef, useEffect } from "react";
import {useLoaderData, useNavigate} from "react-router-dom";
import {AuthContext, FavoriteContext} from "../../Pages/Layout/Layout";
import CardAd from "../../Components/CardAd";


export default function Profile() {
    const profile = useLoaderData();
    const {user, logout} = useContext(AuthContext);
    const [favorites, setFavorites, userAds, setUserAds] = useContext(FavoriteContext);
    const profileMenuLiRef = useRef([]);
    const navigate = useNavigate();
    const [incorrectPass, setIncorrectPass] = useState(false);
    const [badPassword, setBadPassword] = useState(false);
    const [profileState, setProfileState] = useState({
        userName: profile.identityUser.userName,
        email: profile.identityUser.email,
        existingPassword: "",
        newPassword: "",
        confirmPassword: ""
    });

    const [profileTab, setProfileTab] = useState("details");

    const handleUserDataChange = async (e) => {
        e.preventDefault();
        
        // check the password equality, and validity
        try {
            const res = await fetch(`/api/user/update/${profile.identityUser.id}`,{
                method: "PATCH",
                headers: { "Content-Type": "application/json",
                            "Authorization": `Bearer ${user.token}`
                    },
                body: JSON.stringify({
                    email: profileState.email,
                    userName: profileState.userName,
                })
            });
            if (res.ok){
                const data = await res.json();
                //console.log(data);
                logout();
                navigate("/login");
            }
        } catch(e){
            console.log(e);
        }
        
    }

    const handlePasswordChange = async (e) => {
        e.preventDefault();
        // check the password equality, and validity
        if (profileState.newPassword === profileState.confirmPassword){
            try {
                setIncorrectPass(false);
                const res = await fetch(`/api/user/update-pass/${profile.identityUser.id}`,{
                    method: "PATCH",
                    headers: { "Content-Type": "application/json",
                                "Authorization": `Bearer ${user.token}`
                        },
                    body: JSON.stringify({
                        existingPassword: profileState.existingPassword,
                        newPassword: profileState.newPassword,
                    })
                });
                console.log(res);
                if (res.ok){
                    const data = await res.json();
                    console.log(data);
                    logout();
                    navigate("/login");
                } else if (res.status === 401) {
                    setBadPassword(true);
                }
            } catch(e){
                console.log(e);
            }
        } else {
            // set an informational tab to passwords
            setIncorrectPass(true);
        }
    }

    function changeTab(e) {
        const node = e.target.closest("li");
        profileMenuLiRef.current.map(el => {
            if(el != null && el.classList.contains("active")){
                el.classList.remove("active");
            }
        })
        profileMenuLiRef.current = [];
        node.classList.add("active");
        setProfileTab(node.getAttribute("tab"));
    }

    const handleClickOnCreateAd = () => {
        navigate(`/users/${profileState.userName}/createad`)
    }


    return (
        <div id="profile-wrapper">
            <div id="profile-content">
                <div id="profile-menu-tabs">
                    <ul>
                        <li id="menu-img">
                        <svg className="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="40" height="40" fill="currentColor" viewBox="0 0 24 24">
                        <path fillRule="evenodd" d="M17 10v1.126c.367.095.714.24 1.032.428l.796-.797 1.415 1.415-.797.796c.188.318.333.665.428 1.032H21v2h-1.126c-.095.367-.24.714-.428 1.032l.797.796-1.415 1.415-.796-.797a3.979 3.979 0 0 1-1.032.428V20h-2v-1.126a3.977 3.977 0 0 1-1.032-.428l-.796.797-1.415-1.415.797-.796A3.975 3.975 0 0 1 12.126 16H11v-2h1.126c.095-.367.24-.714.428-1.032l-.797-.796 1.415-1.415.796.797A3.977 3.977 0 0 1 15 11.126V10h2Zm.406 3.578.016.016c.354.358.574.85.578 1.392v.028a2 2 0 0 1-3.409 1.406l-.01-.012a2 2 0 0 1 2.826-2.83ZM5 8a4 4 0 1 1 7.938.703 7.029 7.029 0 0 0-3.235 3.235A4 4 0 0 1 5 8Zm4.29 5H7a4 4 0 0 0-4 4v1a2 2 0 0 0 2 2h6.101A6.979 6.979 0 0 1 9 15c0-.695.101-1.366.29-2Z"clipRule="evenodd"/>
                        </svg>

                        </li>
                        <li className="active" tab="details" 
                            ref={el => profileMenuLiRef.current.push(el)} onClick={changeTab}>
                            <p>
                                Details
                            </p>
                        </li>
                        <li tab="ads" ref={el => profileMenuLiRef.current.push(el)} onClick={changeTab}>
                            <p>
                                Your ads
                            </p>
                        </li>
                        <li tab="favorites" ref={el => profileMenuLiRef.current.push(el)} onClick={changeTab}>
                            <p>
                                Favorites
                            </p>
                        </li>
                        <li>
                            <p onClick={handleClickOnCreateAd}>
                                Create Advertisment
                            </p>
                        </li>
                        {/*admin role check needs to be implemented later*/}
                        {user.email === "admin@admin.com" &&<li>
                            <p onClick={() => navigate('/admineditor')}>
                                Edit Content
                            </p>
                        </li>}
                    </ul>
                </div>
                <div id="menu-content">
                    { profileTab === "details" ? (
                        <>
                            <h2>Profile details</h2>
                            <form id="user-data-update-form" className="user-update-form" onSubmit={handleUserDataChange}>
                                <fieldset><legend>Edit user name and email</legend>
                                    <div className="user-update-form-group">
                                        <label htmlFor="profile-user-name">
                                            <span>User name</span>
                                            <input 
                                                type="text" id="profile-user-name" 
                                                value={profileState.userName} 
                                                onChange={e => {
                                                    setProfileState({...profileState, 
                                                        userName: e.target.value});
                                                }}
                                            />
                                        </label>
                                        <label htmlFor="profile-email">
                                            <span>Email</span>
                                            <input 
                                                type="text" 
                                                id="profile-email" 
                                                value={profileState.email} 
                                                onChange={e => {
                                                setProfileState({...profileState, 
                                                    email: e.target.value});
                                                }}
                                            />
                                        </label>
                                    </div>
                                    <button id="data-form-submit-btn">Submit</button>
                                </fieldset>
                            </form>
                            <form id="password-update-form" className="user-update-form" onSubmit={handlePasswordChange}>   
                                <fieldset><legend>Edit your password</legend>
                                    <div className="user-update-form-group">
                                        <label htmlFor="existing-profile-password">
                                            <span>Current password</span>
                                            <input 
                                                type="password" 
                                                id="existing-password" 
                                                value={profileState.existingPassword} 
                                                onChange={e => {
                                                    setProfileState({...profileState, 
                                                        existingPassword: e.target.value});
                                                }}
                                            />
                                        </label>
                                        <label htmlFor="new-profile-password">
                                            <span>New password</span>
                                            <input 
                                                type="password" 
                                                id="new-password" 
                                                value={profileState.newPassword} 
                                                onChange={e => {
                                                    setProfileState({...profileState, 
                                                        newPassword: e.target.value});
                                                }}
                                            />
                                        </label>
                                        <label htmlFor="confirm-profile-password">
                                            <span>Confirm password</span>
                                            <input 
                                                type="password" 
                                                id="confirm-password" 
                                                value={profileState.confirmPassword} 
                                                onChange={e => {
                                                    setProfileState({...profileState, 
                                                        confirmPassword: e.target.value});
                                                }}
                                            />
                                        </label>
                                    </div>
                                    {
                                        incorrectPass && (
                                            <div>
                                                <span id="password-warning">The new and confirmed password do not match!</span>
                                            </div>
                                        )
                                    }
                                    {
                                        badPassword && (
                                            <div>
                                                <span id="password-warning">The current password is incorrect!</span>
                                            </div>
                                        )
                                    }
                                    <button id="password-form-submit-btn">Submit</button>
                                </fieldset>
                            </form>
                        </>
                    ) : profileTab === "ads" ? (
                        <div>
                            <h2>Your advertisements</h2>
                            { userAds.length === 0 ? (
                                <p>You have no advertisements currently.</p>
                            ) : (
                                <div className="profile-ads-wrapper">
                                    {userAds.map(ad => (
                                        <CardAd key={ad.id} ad={ad} user={user} favorites={favorites} userAds={userAds} setUserAds={setUserAds} deleteButtonCheck={true} handleClick={(e) => console.log(e.target)} />
                                    ))}
                                </div>
                            )}
                        </div>
                    ) : profileTab === "favorites" ? (
                        <div>
                            <h2>Favorite advertisements</h2>
                            { favorites.length === 0 ? (
                                <p>You have no advertisements currently.</p>
                            ) : (
                                <div className="profile-ads-wrapper">
                                {favorites.map(ad => (
                                    <CardAd key={ad.id} ad={ad} favorites={favorites} setFavorites={setFavorites} user={user} userAds={userAds} setUserAds={setUserAds}/>
                                ))}
                                </div>
                            )}
                        </div>
                    ) : (
                        <div>
                            Error
                        </div>)
                }
                </div>
            </div>
        </div>
    )
}