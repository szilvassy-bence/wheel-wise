import Profile from "./Profile";
export default Profile;

export async function loader(name){
    try {
        const res = await fetch(`/api/user/${name}`);
        const data = await res.json();
        return data;
    } catch (e) {
        console.log(e);
    }
}