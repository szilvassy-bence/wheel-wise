import "./PriceFormRange.css";
import React, {useRef, useState, useEffect} from "react";
import Form from "react-bootstrap/Form";

export default function PriceFormRange({minPrice, maxPrice}) {

    const [sliderThumbLeftValue, setSliderThumbLeftValue] = useState(minPrice);
    const [sliderThumbRightValue, setSliderThumbRightValue] = useState(maxPrice);

    console.log(typeof minPrice === "number")

    var inputLeftRef = useRef(null);
    var inputRightRef = useRef(null);
    var sliderRangeRef = useRef(null);
    var sliderThumbLeftRef = useRef(null);
    var sliderThumbRightRef = useRef(null);

    function setLeftValue() {
        var _this = inputLeftRef.current,
            min = parseInt(_this.min),
            max = parseInt(_this.max);
        console.log(_this.value)
        console.log(inputRightRef.current.value)
        var percent = Math.min((((_this.value - min) / (max - min)) * 100), (inputRightRef.current.value - min) / (max - min) * 100 - 1);
        console.log(percent);
        sliderThumbLeftRef.current.style.left = percent + "%";
        sliderRangeRef.current.style.left = percent + "%";
        var value = Math.round((max - min) * (percent / 100) + min);
        setSliderThumbLeftValue(value);

        console.log(inputLeftRef.current);

        // why 0 always?
        console.log(sliderThumbLeftValue);
    }

    function setRightValue() {
        var _this = inputRightRef.current,
            min = parseInt(_this.min),
            max = parseInt(_this.max);

        var percent = Math.min((((max - _this.value) / (max - min) * 100)), (max - inputLeftRef.current.value) / (max - min) * 100 - 1);
        var value = Math.round(max - (max - min) * (percent / 100));
        setSliderThumbRightValue(value);
        sliderThumbRightRef.current.style.right = percent + "%";
        sliderRangeRef.current.style.right = percent + "%";
        console.log(inputRightRef.current);

        console.log(sliderThumbRightValue);
    }

    useEffect(() => {
        setLeftValue();
        inputLeftRef.current.addEventListener("input", setLeftValue);
        setRightValue();
        inputRightRef.current.addEventListener("input", setRightValue);
        inputLeftRef.current.addEventListener("mouseover", function () {
            sliderThumbLeftRef.current.classList.add("hover");
        });
        inputLeftRef.current.addEventListener("mouseout", function () {
            sliderThumbLeftRef.current.classList.remove("hover");
        });
        inputLeftRef.current.addEventListener("mousedown", function () {
            sliderThumbLeftRef.current.classList.add("active");
        });
        inputLeftRef.current.addEventListener("mouseup", function () {
            sliderThumbLeftRef.current.classList.remove("active");
        });
        inputRightRef.current.addEventListener("mouseover", function () {
            sliderThumbRightRef.current.classList.add("hover");
        });
        inputRightRef.current.addEventListener("mouseout", function () {
            sliderThumbRightRef.current.classList.remove("hover");
        });
        inputRightRef.current.addEventListener("mouseup", function () {
            sliderThumbRightRef.current.classList.remove("active");
        });
        inputRightRef.current.addEventListener("mousedown", function () {
            sliderThumbRightRef.current.classList.add("active");
        });
        return () => {
            inputLeftRef.current.removeEventListener("input", setLeftValue);
            inputRightRef.current.removeEventListener("input", setRightValue);
        }
    }, []);

    useEffect(() => {
        setSliderThumbLeftValue(minPrice);
        setSliderThumbRightValue(minPrice === maxPrice ? maxPrice + 1 : maxPrice);
    }, [minPrice, maxPrice]);

    return (
        <>
            <Form.Label>
                Price Range
            </Form.Label>
            <div className="middle">
                <div className="multi-range-slider">
                    <input
                        type="range"
                        id="input-left"
                        min={minPrice}
                        max={maxPrice}
                        value={sliderThumbLeftValue}
                        ref={inputLeftRef}/>
                    <input
                        type="range"
                        id="input-right"
                        min={minPrice}
                        max={maxPrice}
                        value={sliderThumbRightValue}
                        ref={inputRightRef}/>
                    <div className="slider">
                        <div className="track"></div>
                        <div className="range-value">
                            <span className="range-value-left">{sliderThumbLeftValue} Ft</span>
                            <span className="range-value-right">{sliderThumbRightValue} Ft</span>
                        </div>
                        <div className="range" ref={sliderRangeRef}></div>
                        <div className="thumb left" ref={sliderThumbLeftRef}></div>
                        <div className="thumb right" ref={sliderThumbRightRef}></div>
                    </div>
                </div>
            </div>
        </>
    )
}
