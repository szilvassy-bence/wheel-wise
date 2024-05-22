import CreateOrModifyAd from "./CreateOrModifyAd";

export default CreateOrModifyAd;

export async function loader() {
    try {
        const [carTypeResponse, colorResponse, fuelTypeResponse, transmissionTypeResponse, equipmentResponse] = await Promise.all([
            fetch("/api/CarType"),
            fetch("/api/Color"),
            fetch("/api/FuelType"),
            fetch("/api/Transmission"),
            fetch("/api/Equipment"),
        ]);

        const carTypeData = await carTypeResponse.json();
        const colorData = await colorResponse.json();
        const fuelTypeData = await fuelTypeResponse.json();
        const transmissionTypeData = await transmissionTypeResponse.json();
        const equipmentData = await equipmentResponse.json();
        
        const carProps = {
            carTypes: carTypeData,
            colors: colorData,
            fuelTypes: fuelTypeData,
            transmissionTypes: transmissionTypeData,
            equipments: equipmentData
        }
        console.log(carProps)

        return carProps;
    } catch (e) {
        console.log(e);
    }
}