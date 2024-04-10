import { useEffect, useState } from 'react'
import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Home from './Pages/Home/Home.jsx'

function App({ routes }) {

    return (
        <>
            <BrowserRouter>
                <Routes>    
                        <Route index element={<Home />} />          
                </Routes>
            </BrowserRouter>
        </>
    )
}

export default App
