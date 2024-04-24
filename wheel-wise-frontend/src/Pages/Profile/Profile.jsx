import "./Profile.css";
import {useLoaderData} from "react-router-dom";

export default function Profile(){
    const profile = useLoaderData();
    console.log(profile);
    
    return (
        <div id="profile-wrapper">
            <div id="profile-content">
                <div id="profile-menu">
                    <ul>
                        <li>
                            
                                <p>
                                    Details
                                </p>
                            
                        </li>
                        <li>
                            
                                <p>
                                    Favorites
                                </p>
                            
                        </li>
                    </ul>
                </div>
                <div id="menu-content">
                    <h2>Menu content</h2>
                </div>
            </div>
        </div>
    )
}