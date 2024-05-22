import "./CardAd.css";
import { useNavigate } from "react-router-dom";

function CardAd({ ad, favorites, setFavorites, user, userAds, setUserAds, deleteButtonCheck }) {


    const navigate = useNavigate();
    async function addFav() {
        try {
            console.log(user.userName)
            console.log(ad)
            const response = await fetch(`/api/user/addfavorite/${user.userName}/${ad.id}`, {
                method: 'PATCH',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${user.token}`
                }
            });

            if (!response.ok) {
                throw new Error('Cant add advertisement to favorites');
            }

            console.log('Advertisement added to favorites');
        } catch (err) {
            console.error(err);
        }
    }

    async function removeFav() {
        try {
            const response = await fetch(`/api/user/removefavoritead/${user.userName}/${ad.id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${user.token}`
                }
            });

            if (!response.ok) {
                throw new Error('Failed to remove advertisement from favorites');
            }

        }
        catch (err) {
            console.error(err);
        }

    }

    function isFavorite() {
        console.log("favads:" + favorites);
        const filteredAds = favorites.filter(fav => fav.id == ad.id);
        if (filteredAds.length === 1) {
            return true;
        }
        else {
            return false;
        }
    }

    function handleFavButtonClick(e) {
        try {
            if (!isFavorite(ad, favorites)) {
                addFav(user, ad);
                console.log("ad: " + ad);
                setFavorites([...favorites, ad]);
            } else {
                removeFav(user, ad);
                setFavorites(favorites.filter(favAd => favAd.id !== ad.id));
            }
        } catch (error) {
            console.error('Failed to add or remove advertisement from favorites:', error);
        }}

    
        async function removeAd() {
            console.log(ad)
            try {
                const response = await fetch(`/api/ads/${ad.id}`, {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${user.token}`
                    }
                });

                if (!response.ok) {
                    throw new Error('Failed to remove advertisement from favorites');
                }

            }
            catch (err) {
                console.error(err);
            }

        }

        function handleDeleteAdButtonClick(e) {
          
            try {
                removeAd(ad, user);
                setUserAds(userAds.filter(uAd => uAd.id !== ad.id));
            } catch (error) {
                console.error('Failed to add or remove advertisement:', error);
            }
        }

        return (
            <>
                <div id={ad.id} className={ad.highlighted ? "highlighted ad-card" : "ad-card"}>
                    {ad.highlighted && <img className="highlighted-img" src="./../../public/highlighted-3.png" />}
                    <div className="card-img-wrapper">
                        <img className="card-img" src="./../../public/car.jpg" />
                    </div>
                    <div className="card-content-wrapper">
                        <h3>{ad.title}</h3>
                        <div className="card-price">
                            <svg className="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                                <path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M15.583 8.445h.01M10.86 19.71l-6.573-6.63a.993.993 0 0 1 0-1.4l7.329-7.394A.98.98 0 0 1 12.31 4l5.734.007A1.968 1.968 0 0 1 20 5.983v5.5a.992.992 0 0 1-.316.727l-7.44 7.5a.974.974 0 0 1-1.384.001Z" />
                            </svg>
                            <h4>{ad.car.price} Ft</h4>
                        </div>
                        <ul>
                            <li>{ad.car.carType.brand} {ad.car.carType.model}</li>
                            <li>{ad.car.year}</li>
                        </ul>
                    </div>
                    <div className="card-footer">
                        <button className="card-btn card-detail-btn" onClick={(e) => navigate(`/ads/${ad.id}`)}>Details</button>
                        {user && user.userName  && deleteButtonCheck===true && (
                            <>
                                <button className="card-btn card-edit-btn" onClick={(e) => handleDeleteAdButtonClick(e)}>Delete</button>
                                <button className="card-btn card-edit-btn" onClick={(e) => navigate(`/users/${ad.userName}/update/${ad.id}`)}>Update</button>
                            </>
                        )}
                        {user &&  user.userName !== ad.user?.userName  && !window.location.pathname.includes("users") && <button className="card-btn card-favorite-btn" onClick={(e) => handleFavButtonClick(e)}>
                            {isFavorite(ad, favorites) ? (
                                <svg className="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                                    <path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M17 13c-.889.086-1.416.543-2.156 1.057a22.322 22.322 0 0 0-3.958 5.084 1.6 1.6 0 0 1-.582.628 1.549 1.549 0 0 1-1.466.087 1.587 1.587 0 0 1-.537-.406 1.666 1.666 0 0 1-.384-1.279l1.389-4.114M17 13h3V6.5A1.5 1.5 0 0 0 18.5 5v0A1.5 1.5 0 0 0 17 6.5V13Zm-6.5 1H5.585c-.286 0-.372-.014-.626-.15a1.797 1.797 0 0 1-.637-.572 1.873 1.873 0 0 1-.215-1.673l2.098-6.4C6.462 4.48 6.632 4 7.88 4c2.302 0 4.79.943 6.67 1.475" />
                                </svg>) : (
                                <svg className="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                                    <path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M7 11c.889-.086 1.416-.543 2.156-1.057a22.323 22.323 0 0 0 3.958-5.084 1.6 1.6 0 0 1 .582-.628 1.549 1.549 0 0 1 1.466-.087c.205.095.388.233.537.406a1.64 1.64 0 0 1 .384 1.279l-1.388 4.114M7 11H4v6.5A1.5 1.5 0 0 0 5.5 19v0A1.5 1.5 0 0 0 7 17.5V11Zm6.5-1h4.915c.286 0 .372.014.626.15.254.135.472.332.637.572a1.874 1.874 0 0 1 .215 1.673l-2.098 6.4C17.538 19.52 17.368 20 16.12 20c-2.303 0-4.79-.943-6.67-1.475" />
                                </svg>
                            )}
                        </button>}

                    </div>

                </div>
            </>
        );
    
}
export default CardAd