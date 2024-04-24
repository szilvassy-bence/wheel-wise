import AdvertisementCarousel from "./AdvertisementCarousel";
export default AdvertisementCarousel;

export async function loader() {
    try {
        const res = await fetch("/api/Ads/highlighted");
        const data = await res.json();
        return data;
    } catch (e){
        console.log(e);
    }
}