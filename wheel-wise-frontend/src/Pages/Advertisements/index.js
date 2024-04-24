import Advertisements from "./Advertisements";
export default Advertisements;

export async function loader(){
    try {
        const response = await fetch("/api/Ads");
        const data = await response.json();
        return data;
    } catch (error) {
        console.error("Error fetching advertisement data", error);
    }
}