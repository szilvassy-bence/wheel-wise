import { useContext, useState } from "react";
import CarTypeFormSelect from "../../Components/CarTypeFormSelect"
import { AuthContext } from "../Layout/Layout";


export default function AdminEditor() {

    const {user} = useContext(AuthContext);
    const [carTypes, setCarTypes] = useState(null);
    const [carTypeModel, setCarTypeModel] = useState({  brand: "", model: "" })
    const [formData, setFormData] = useState({
        brand: "", model: ""
    })

    const fetchCarTypeData = async () => {
        try {
            const response = await fetch("/api/CarType");
            const data = await response.json();
            setCarTypes(data);
            console.log(data);
        } catch (error) {
            console.error("Error fetching car type data", error);
        }
    }
    const handleInputChange = (e, setData) => {
        const { name, value } = e.target;
        setData((prevData) => ({
          ...prevData, [name]: value
        }))
      }



      //ADD
    async function addCarType(){
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

    //DELETE

    /*const fetchCarTypeData = async () => {
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
    }, []);*/


    function getUniqueBrands() {
        let brands = [];
        carTypes.map(x => {
            if (!brands.includes(x.brand)) {
                brands.push(x.brand);
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
                            <input required name="brand" value={carTypeModel.brand} onChange={(e)=>handleInputChange(e, setCarTypeModel)}></input>
                        </label>
                        <label>
                            <span>Model: </span>
                            <input required name="model" value={carTypeModel.model} onChange={(e)=>handleInputChange(e, setCarTypeModel)}></input>
                        </label>
                    </label>
                    <button>Add CarType</button>
                </form>
              {/*<CarTypeFormSelect formData={formData} selectBrand={selectBrand} selectedBrand={selectBrand} getUniqueBrands={getUniqueBrands} ></CarTypeFormSelect>*/}
            </div>
        </div>
    )
}