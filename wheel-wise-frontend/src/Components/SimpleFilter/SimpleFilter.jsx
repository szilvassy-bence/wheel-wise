import {useEffect, useState} from "react";
import "./SimpleFilter.css";
import * as service from "./service.js";
import CarTypeFormSelect from "../CarTypeFormSelect";
import PriceFormRange from "../PriceFormRange";

export default function SimpleFilter({setAllAdData, adsMinPrice, adsMaxPrice}) {
    const [carTypes, setCarTypes] = useState(null);
    const [selectedBrand, setSelectedBrand] = useState(null);
    const [carTypeModels, setCarTypeModels] = useState(null);

    const [filterMinPrice, setFilterMinPrice] = useState(adsMinPrice);
    const [filterMaxPrice, setFilterMaxPrice] = useState(adsMaxPrice);
    const [formData, setFormData] = useState({
        brand: "", model: "", minPrice: adsMinPrice, maxPrice: adsMaxPrice, fromYear: 0, tillYear: 0
    })

    useEffect(()=> {
        setFormData({...formData, minPrice: filterMinPrice})
    }, [filterMinPrice]);

    useEffect(()=> {
        setFormData({...formData, maxPrice: filterMaxPrice})
    }, [filterMaxPrice]);

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
    useEffect(() => {
        fetchCarTypeData();
    }, []);


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

    function selectModel(e) {
        console.log(e.target.value);
        setFormData({...formData, model: e.target.value})
    }

    function setFromYear(e) {
        console.log(e.target.value);
        setFormData({...formData, fromYear: isNaN(parseInt(e.target.value)) ? 0 : parseInt(e.target.value)})
    }

    function setTillYear(e) {
        console.log(e.target.value);
        setFormData({...formData, tillYear: isNaN(parseInt(e.target.value)) ? 0 : parseInt(e.target.value)})
    }

    useEffect(() => {
        console.log(`selected brand: ${selectedBrand}`);
        if (selectedBrand != null) {
            let modelsFilteredByBrands = [];
            console.log(`selected brand: ${selectedBrand}`);
            carTypes.forEach(c => {
                if (c.brand === selectedBrand) {
                    modelsFilteredByBrands.push(c.model);
                }
            });
            modelsFilteredByBrands.sort();
            setCarTypeModels(modelsFilteredByBrands);
        }
    }, [selectedBrand])

    async function submitForm(e) {
        e.preventDefault();
        console.log(e.target);

        console.log(formData);

        //send fetch request to send the form
        const response = await fetch("/api/Ads/SimpleForm", {
            method: "POST", headers: {"Content-Type": "application/json"}, body: JSON.stringify(formData)
        });

        if (response.status === 200) {
            const data = await response.json();
            console.log(data);
            setAllAdData(data);
        } else { // else log error
            console.error("Problem fetching data from server")
        }
    }

    useEffect(() => {
        console.log(formData);
    }, [formData])

    //Maximum year shouldnt be smaller than minimum
    return (
        <div id="simple-filter-wrapper">
            <div id="simple-filter-content">
                <h2>Find your dream car simply!</h2>
                {carTypes ? (
                        <form onSubmit={e => submitForm(e)} >
                            <div id="simple-filter-form" >

                                <CarTypeFormSelect formData={formData}
                                                   selectBrand={selectBrand}
                                                   selectedBrand={selectedBrand}
                                                   getUniqueBrands={getUniqueBrands}
                                                   carTypeModels={carTypeModels}
                                                   selectModel={selectModel}/>

                                <label className="simple-filter-label simple-filter-items">
                                    <span>From Year</span>
                                    <select value={formData.fromYear} className="quick-form" name="from-year"
                                            placeholder="From year" onChange={e => setFromYear(e)}>
                                        <option>Min Year</option>
                                        {service.yearCounter().map(year => (
                                            <option key={year} value={year}>{year}</option>))}
                                    </select>
                                </label>
                                <label className="simple-filter-label simple-filter-items">
                                    <span>Till Year</span>
                                    <select value={formData.tillYear} className="quick-form" name="till-year"
                                            placeholder="Till year" onChange={e => setTillYear(e)}>
                                        <option>Max Year</option>
                                        {service.yearCounter().map(year => (
                                            <option key={year} value={year}>{year}</option>))}
                                    </select>
                                </label>
                                <PriceFormRange adsMinPrice={adsMinPrice} adsMaxPrice={adsMaxPrice} setFilterMinPrice={setFilterMinPrice} setFilterMaxPrice={setFilterMaxPrice}/>
                            </div>
                            <button className="form-submit-btn" type="submit">
                                Submit
                            </button>
                        </form>) :
                    (<p>Loading...</p>)}
            </div>
        </div>
    )
}
