import { useContext, useState, useEffect } from "react";
import CarTypeFormSelect from "../../Components/CarTypeFormSelect"
import { AuthContext } from "../Layout/Layout";



export default function AdminEditor() {

    const { user } = useContext(AuthContext);
    const [carTypes, setCarTypes] = useState(null);
    const [carTypeModel, setCarTypeModel] = useState({ brand: "", model: "" })
    const [selectedBrand, setSelectedBrand] = useState(null)
    const [selectedModels, setSelectedModels] = useState(null);
    const [formData, setFormData] = useState({ brand: "", model: "" })


    const fetchCarTypeData = async () => {
        console.log("fetching")
        try {
            const response = await fetch("/api/CarType");
            const data = await response.json();
            setCarTypes(data);
            console.log(data);
        } catch (error) {
            console.error("Error fetching car type data", error);
        }
    }
    useEffect(() => {
        fetchCarTypeData();
    }, []);

    const handleInputChange = (e, setData) => {
        const { name, value } = e.target;
        setData((prevData) => ({
            ...prevData, [name]: value
        }))
    }

    //ADD
    async function addCarType() {
        console.log(carTypeModel.brand, carTypeModel.model)
        try {
            const response = await fetch(`/api/cartype`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${user.token}`
                },
                body: JSON.stringify(carTypeModel)
            });

            if (!response.ok) {
                throw new Error("Can't post cartype");
            }

            console.log('New cartype added');
        } catch (err) {
            console.error(err);
        }
    }

    //CARTYPE DELETE

    function getUniqueBrands() {
        let brands = [];
        carTypes.map(x => {
            if (!brands.includes(x)) {
                brands.push(x);
            }
        })
        return brands.sort();
    }

    function selectBrand(e) {
        console.log(e.target.value);
        setSelectedBrand(e.target.value);
        if (e.target.value === "Select Brand") {
            setFormData({...formData, brand: e.target.value, model: "Select Model"})
        } else {
            setFormData({...formData, brand: e.target.value})
        }
    }

    function selectModel(e) {
        console.log(e.target.value);
        setFormData({...formData, model: e.target.value})
    }

    useEffect(() => {
        console.log(`selected brand: ${selectedBrand}`);
        if (selectedBrand != null) {
            let modelsFilteredByBrands = [];
            console.log(`selected brand: ${selectedBrand}`);
            carTypes.forEach(c => {
                if (c.brand === selectedBrand) {
                    modelsFilteredByBrands.push(c);
                }
            });
            modelsFilteredByBrands.sort(c => c.model);
            setSelectedModels(modelsFilteredByBrands);
        }
    }, [selectedBrand])



    return (
        <div id="simple-filter-wrapper">
            <div id="simple-filter-content">
                <h2>Editor</h2>
                <form onSubmit={addCarType}>
                    <h3>CarType</h3>
                    <label>
                        <span>Add </span>
                        <label>
                            <span>Brand: </span>
                            <input required name="brand" value={carTypeModel.brand} onChange={(e) => handleInputChange(e, setCarTypeModel)}></input>
                        </label>
                        <label>
                            <span>Model: </span>
                            <input required name="model" value={carTypeModel.model} onChange={(e) => handleInputChange(e, setCarTypeModel)}></input>
                        </label>
                    </label>
                    <button>Add CarType</button>
                </form>
                <form>
                    {carTypes ?<>
                <label className="simple-filter-label simple-filter-items">
                <span>Brand</span>
                <select name="brand" placeholder="Brand" onChange={(e) => selectBrand(e)}>
                    <option>Select Brand</option>
                    {getUniqueBrands().map(b => (<option key={b.id} value={b.brand}>{b.brand}</option>))}
                </select>
            </label>
            <label className="simple-filter-label simple-filter-items">
            <span>Model</span>
            <select name="model" placeholder="Model" onChange={(e) => selectModel(e)}>
                <option>Select Brand</option>
                {selectedModels.map(b => (<option key={b.id} value={b.model}>{b.model}</option>))}
            </select>
        </label> </>:
                        <select name="brand" placeholder="Brand" onChange={(e) => selectBrand(e)}>
                            <option>Loading Brands</option>
                        </select>}
                </form>
            </div>
        </div>
    )
}