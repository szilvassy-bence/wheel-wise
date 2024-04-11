import {useEffect, useState} from "react";
import Form from 'react-bootstrap/Form';
import Button from "react-bootstrap/Button";

export default function AdFilter() {
    const [carTypes, setCarTypes] = useState(null);
    const [selectedBrand, setSelectedBrand] = useState(null);
    const [carTypeModels, setCarTypeModels] = useState(null);
    
    const fetchCarTypeData = async () => {
        try {
            const response = await fetch('/api/CarType');
            const data = await response.json();
            setCarTypes(data);
            console.log(data);
        } catch (error) {
            console.error('Error fetching car type data', error);
        }
    }
    useEffect(() => {
        fetchCarTypeData();
    }, []);
    function yearCounter(){
        let years = [];
        for(let i = 1900; i <= new Date().getFullYear(); i++){
            years.push(i);
        }
        return years;
    }
    
    function getUniqueBrands(){
        let brands=[];
        carTypes.map(x => {
            if(!brands.includes(x.brand)){
                brands.push(x.brand);
            }
        })
        return brands.sort();
    }
    
    function selectBrand(e){
        console.log(e.target.value);
        setSelectedBrand(e.target.value);
    }
    
    
    useEffect(()=>{
        console.log(`selected brand: ${selectedBrand}`);
        if(selectedBrand != null){
            console.log(`selected brand: ${selectedBrand}`);
       let modelsFilteredByBrands = [];
       carTypes.forEach(c =>{
           if(c.brand == selectedBrand){
               modelsFilteredByBrands.push(c.model);
           }});
       setCarTypeModels(modelsFilteredByBrands);}
    },[selectedBrand])

    return (
        <div>
        {carTypes ? (<Form>
            <Form.Select aria-label="brand" value={selectedBrand} onChange={e => selectBrand(e)}>
                <option>Select Brand</option>
                {getUniqueBrands().map(b => (
                    <option key={b} value={b} >{b}</option>
                ))
                }
            </Form.Select>
            { selectedBrand != null ?(
            <Form.Select aria-label="model">
                <option>Select Model</option>
                {carTypeModels.map(m => (
                    <option key={m} value={m}>{m}</option>
                ))
                }
            </Form.Select>)
                :
                (
                    <Form.Select aria-label="model" disabled={true}>
                        <option>Select Model</option>
                    </Form.Select>)
            }
            <Form.Label htmlFor="minimumPriceInput">Minimum Price</Form.Label>
            <Form.Control
                type="text"
                id="minPriceControl"
                aria-describedby="mincarprice"
            />
            <Form.Text id="minimumPriceInput" value="" muted placeholder="Minimum Price">
            </Form.Text>
            <Form.Label htmlFor="maximumPriceInput">Maximum Price</Form.Label>
            <Form.Control
                type="text"
                id="maxPriceControl"
                aria-describedby="maxcarprice"
            />
            <Form.Text id="maximumPriceInput" value="" muted placeholder="Maximum Price">
            </Form.Text>
            <Form.Select aria-label="fromyear">
                <option>From</option>
                {yearCounter().map(year =>(
                    <option key={year} value={year}>{year}</option>))
                }
            </Form.Select>
            <Form.Select aria-label="tillyear">
                <option>Till</option>
                {yearCounter().map(year =>(
                    <option key={year} value={year}>{year}</option>))
                }
            </Form.Select>
            <Button variant="primary" type="submit">
                Submit
            </Button>
        </Form>): (<p>Loading...</p>)}
        </div>
    )
}