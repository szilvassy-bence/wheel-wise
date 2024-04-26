import "./MainBanner.css";
import {useRef, useEffect} from "react";

export default function MainBanner() {

    const slideRef = useRef([]);
    const dotRef = useRef([]);
    let slideIndex = 1;
    
    // next previous controls
    function plusSlide(n) {
        showSlides(slideIndex += n);
    }

    // thumbnail image
    function currentSlide(n) {
        showSlides(slideIndex = n);
    }

    useEffect(() => {
        showSlides(slideIndex);
    }, []);

    function showSlides(n) {
        let i;

        console.log(slideRef.current.length)
        if (n > slideRef.current.length) {
            slideIndex = 1;
        }
        if (n < 1) {
            slideIndex = slideRef.current.length;
        }

        for (i = 0; i < slideRef.current.length; i++) {
            slideRef.current[i].style.display = "none";
        }
        for (i = 0; i < dotRef.current.length; i++) {
            dotRef.current[i].className = dotRef.current[i].classList.remove("active");
        }
        slideRef.current[slideIndex - 1].style.display = "block";
        dotRef.current[slideIndex - 1].classList.add("active");
    }

    return (
        <>
            {console.log("this runs")}
            <div id="main-banner-wrapper">

                <div className="slide fade" ref={(el) => slideRef.current.push(el)}>
                    <img src="./wheel-wise-main-banner.jpg"/>
                    <div className="text">
                        <h2>Biggest online car dealership</h2>
                        <h4>We guarantee that you sell your car!</h4>
                    </div>
                </div>
                <div className="slide fade" ref={el => slideRef.current.push(el)}>
                    <img src="./wheel-wise-main-banner-2.jpg"/>
                    <div className="text">
                        <h2>Biggest online car dealership</h2>
                        <h4>We guarantee that you sell your car!</h4>
                    </div>
                </div>
                <div className="slide fade" ref={el => slideRef.current.push(el)}>
                    <img src="./wheel-wise-main-banner-3.jpg"/>
                    <div className="text">
                        <h2>Biggest online car dealership</h2>
                        <h4>We guarantee that you sell your car!</h4>
                    </div>
                </div>
                <a className="prev" onClick={() => plusSlide(-1)}>&#10094;</a>
                <a className="next" onClick={() => plusSlide(1)}>&#10095;</a>
                <div id="dot-wrapper">
                    <span className="dot" ref={el => dotRef.current.push(el)} onClick={() => currentSlide(1)}></span>
                    <span className="dot" ref={el => dotRef.current.push(el)} onClick={() => currentSlide(2)}></span>
                    <span className="dot" ref={el => dotRef.current.push(el)} onClick={() => currentSlide(3)}></span>
                </div>
            </div>


        </>

    )
}