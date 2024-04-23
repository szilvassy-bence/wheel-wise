import Col from "react-bootstrap/Col";
import Form from "react-bootstrap/Form";

export default function CarTypeFormSelect({formData, selectBrand, selectedBrand, getUniqueBrands, carTypeModels, selectModel}){
    return(
        <>
            <Col sm={6} md={4} xxl={2}>
                <Form.Label>Brand</Form.Label>
                <Form.Select
                    className="quick-form"
                    aria-label="brand"
                    value={formData.brand}
                    onChange={e => selectBrand(e)}>
                    <option>Select Brand</option>
                    {getUniqueBrands().map(b => (<option key={b} value={b}>{b}</option>))}
                </Form.Select>
            </Col>
            <Col sm={6} md={4} xxl={2}>
                <Form.Label>Model</Form.Label>
                {(selectedBrand != null && selectedBrand != "Select Brand" ) && carTypeModels != null ? (
                    <Form.Select
                        className="quick-form"
                        aria-label="model"
                        value={formData.model}
                        onChange={e => selectModel(e)}>
                        <option>Select Model</option>
                        {carTypeModels.map(m => (<option key={m} value={m}>{m}</option>))}
                    </Form.Select>) : (
                    <Form.Select
                        className="quick-form"
                        aria-label="model"
                        disabled={true}>
                        <option>Select Model</option>
                    </Form.Select>)}
            </Col>
        </>
        )
}