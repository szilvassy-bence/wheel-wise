import "./PriceFormRange.css";
import {useRef, useState, useEffect} from "react";

export default function PriceFormRange({adsMinPrice, adsMaxPrice, setFilterMinPrice, setFilterMaxPrice}) {

    const [sliderThumbLeftValue, setSliderThumbLeftValue] = useState(adsMinPrice);
    const [sliderThumbRightValue, setSliderThumbRightValue] = useState(adsMaxPrice);

    var inputLeftRef = useRef(null);
    var inputRightRef = useRef(null);
    var sliderRangeRef = useRef(null);
    var sliderThumbLeftRef = useRef(null);
    var sliderThumbRightRef = useRef(null);

    function setLeftValue() {
        var _this = inputLeftRef.current,
            min = parseInt(_this.min),
            max = parseInt(_this.max);
        var percent = Math.min((((_this.value - min) / (max - min)) * 100), (inputRightRef.current.value - min) / (max - min) * 100 - 1);
        sliderThumbLeftRef.current.style.left = percent + "%";
        sliderRangeRef.current.style.left = percent + "%";
        //var value = Math.round((max - min) * (percent / 100) + min);
        setFilterMinPrice( _this.value);
        setSliderThumbLeftValue(_this.value);
    }

    function setRightValue() {
        var _this = inputRightRef.current,
            min = parseInt(_this.min),
            max = parseInt(_this.max);

        // setting the circle and the range position
        var percent = Math.min((((max - _this.value) / (max - min) * 100)), (max - inputLeftRef.current.value) / (max - min) * 100 - 1);
        sliderThumbRightRef.current.style.right = percent + "%";
        sliderRangeRef.current.style.right = percent + "%";
        //var value = Math.round(max - (max - min) * (percent / 100));
        setFilterMaxPrice(_this.value);
        setSliderThumbRightValue(_this.value);
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
            //inputLeftRef.current.removeEventListener("input", setLeftValue);
            //inputRightRef.current.removeEventListener("input", setRightValue);
        }
    }, []);

    useEffect(() => {
        setSliderThumbLeftValue(adsMinPrice);
        setSliderThumbRightValue(adsMaxPrice);
        sliderThumbLeftRef.current.style.left = 0;
        sliderThumbRightRef.current.style.right = 0;
        sliderRangeRef.current.style.left = 0;
        sliderRangeRef.current.style.right = 0;
    }, [adsMinPrice, adsMaxPrice]);

    return (
        <div id="price-range-div">
            <label id="price-range-label">
                Price Range
            </label>
            <div className="multi-range-slider">
                <input
                    type="range"
                    id="input-left"
                    min={adsMinPrice}
                    max={adsMaxPrice}
                    value={sliderThumbLeftValue}
                    ref={inputLeftRef}/>
                <input
                    type="range"
                    id="input-right"
                    min={adsMinPrice}
                    max={adsMaxPrice}
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

    )
}
