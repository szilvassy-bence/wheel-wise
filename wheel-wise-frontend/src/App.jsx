import { useEffect, useState } from 'react'
import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Home from './Pages/Home/Home.jsx'
import AdvertisementDetail from './Pages/AdvertisementDetail/AdvertisementDetail.jsx'

function App({ routes }) {

    return (
        <>
            <BrowserRouter>
                <Routes>    
                        <Route index element={<Home />} />
                        <Route path="advertisement/:id" element={<AdvertisementDetail />}></Route>         
                </Routes>
            </BrowserRouter>
        </>
    )
}

export default App
