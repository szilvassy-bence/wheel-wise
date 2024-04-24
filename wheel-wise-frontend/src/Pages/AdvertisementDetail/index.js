import AdvertisementDetail from "./AdvertisementDetail";

export default AdvertisementDetail;

export async function loader(id) {
    try {
        const resp = await fetch(`/api/Ads/${id}`);
        const ad = await resp.json();
        return ad;
    } catch (e) {
        console.log(e);
    }
}
