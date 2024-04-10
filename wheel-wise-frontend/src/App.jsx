import { useEffect, useState } from 'react'
import './App.css'
import Frame from "./Pages/Frame"
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Home from './Pages/Home/Home.jsx'
import AdvertisementDetail from './Pages/AdvertisementDetail/AdvertisementDetail.jsx'

function App({ routes }) {

    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Frame />}>
                        <Route index element={<Home />} />
                        <Route path="advertisement/:id" element={<AdvertisementDetail />}></Route>
                    </Route>
                </Routes>
            </BrowserRouter>
        </>
    )
}

export default App
