import {useEffect, useState} from "react";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import Container from "react-bootstrap/Container";
import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import "./SimpleFilter.css";
import * as service from "./service.js";
import CarTypeFormSelect from "../CarTypeFormSelect";
import PriceFormRange from "../PriceFormRange";

export default function SimpleFilter({setAllAdData, minPrice, maxPrice}) {
    const [carTypes, setCarTypes] = useState(null);
    const [selectedBrand, setSelectedBrand] = useState(null);
    const [carTypeModels, setCarTypeModels] = useState(null);

    const [formData, setFormData] = useState({
        brand: "", model: "", minPrice: 0, maxPrice: 0, fromYear: 0, tillYear: 0
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

    function setMinPrice(e) {
        console.log(e.target.value);
        setFormData({...formData, minPrice: e.target.value})
    }

    function setMaxPrice(e) {
        console.log(e.target.value);
        setFormData({...formData, maxPrice: e.target.value})
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

        //send fetch request to post new book
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

    //Maximum year shouldnt be smaller than minimum
    return (
        <Container fluid className="pt-4 pb-4 wrapper">
            <Container>
                <h2>Quick filter</h2>
                {carTypes ? (
                        <Form onSubmit={e => submitForm(e)} id="filterForm">
                            <Row className="mt-2 gy-3">
                                <CarTypeFormSelect formData={formData}
                                                   selectBrand={selectBrand}
                                                   selectedBrand={selectedBrand}
                                                   getUniqueBrands={getUniqueBrands}
                                                   carTypeModels={carTypeModels}
                                                   selectModel={selectModel}/>
                                <Col sm={6} md={4} xxl={2}>
                                    <PriceFormRange minPrice={minPrice} maxPrice={maxPrice}/>
                                </Col>
                                <Col sm={6} md={4} xxl={2}>
                                    <Form.Label htmlFor="minimumPriceInput">Minimum Price</Form.Label>
                                    <Form.Control
                                        className="quick-form"
                                        type="number"
                                        id="minimumPriceInput"
                                        aria-describedby="mincarprice"
                                        value={formData.minPrice}
                                        onChange={e => setMinPrice(e)}
                                    />
                                </Col>
                                <Col sm={6} md={4} xxl={2}>
                                    <Form.Label htmlFor="maximumPriceInput">Maximum Price</Form.Label>
                                    <Form.Control
                                        className="quick-form"
                                        type="number"
                                        id="maximumPriceInput"
                                        aria-describedby="maxcarprice"
                                        value={formData.maxPrice}
                                        onChange={e => setMaxPrice(e)}
                                    />
                                </Col>
                                <Col sm={6} md={4} xxl={2}>
                                    <Form.Label>Price From</Form.Label>
                                    <Form.Select
                                        className="quick-form"
                                        aria-label="fromyear"
                                        value={formData.fromYear}
                                        onChange={e => setFromYear(e)}>
                                        <option>Min Price</option>
                                        {service.yearCounter().map(year => (
                                            <option key={year} value={year}>{year}</option>))}
                                    </Form.Select>
                                </Col>
                                <Col sm={6} md={4} xxl={2}>
                                    <Form.Label>Price Till</Form.Label>
                                    <Form.Select
                                        className="quick-form"
                                        aria-label="tillyear"
                                        value={formData.tillYear}
                                        onChange={e => setTillYear(e)}>
                                        <option>Max Price</option>
                                        {service.yearCounter().map(year => (
                                            <option key={year} value={year}>{year}</option>))}
                                    </Form.Select>
                                </Col>
                            </Row>
                            <Button className="submit-btn mt-3" variant="primary" type="submit">
                                Submit
                            </Button>
                        </Form>) :
                    (<p>Loading...</p>)}
            </Container>
        </Container>
    )
}
