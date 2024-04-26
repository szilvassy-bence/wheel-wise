import { useContext } from "react";
import { AuthContext, FavoriteContext } from "../../Pages/Layout/Layout";
import { useState, useEffect } from "react";



export async function addFav(user, ad) {
    try {
        const response = await fetch(`/api/user/addfavoritead/${user.userName}/${ad.id}`, {
            method: 'PATCH',
            headers: {
                'Content-Type': 'application/json'
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

export async function removeFav(user, ad) {
    try {
        const response = await fetch(`/api/user/removefavoritead/${user.userName}/${ad.id}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
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

export function isFavorite(ad, favorites) {
    console.log("favads:" + favorites);
    if (favorites.includes(ad)) {
        return true;
    }
    else {
        return false;
    }

}

export function handleFavButtonClick(e, ad, favorites, setFavorites, user) {
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
    }
}

