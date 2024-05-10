import React from "react"
import ReactDOM from "react-dom/client"
import App from "./App.jsx"
import "./index.css"
import {RouterProvider, createBrowserRouter} from "react-router-dom";
import Layout from "./Pages/Layout";
import ErrorPage from "./Pages/ErrorPage";
import Home from "./Pages/Home";
import AdvertisementDetail, {loader as adLoader} from "./Pages/AdvertisementDetail";
import AdvertisementCarousel from "./Components/AdvertisementCarousel";
import Advertisements, {loader as adsLoader} from "./Pages/Advertisements";
import Profile, {loader as profileLoader} from "./Pages/Profile";
import CreateAd from "./Pages/CreateAdvertisement/index.js";
import Registration from "./Pages/Registration";
import Login from "./Pages/Login";
import AdminEditor from "./Pages/AdminEditor/AdminEditor.jsx";



const router = createBrowserRouter(
    [
        {
            path: "/",
            element: <Layout/>,
            errorElement: <ErrorPage/>,
            children: [
                {
                    path: "/",
                    element: <Home/>,
                },
                {
                    path: "/ads",
                    element: <Advertisements/>,
                    loader: adsLoader
                },
                {
                    path: "/ads/:id",
                    element: <AdvertisementDetail/>,
                    loader: ({params}) => adLoader(params.id)
                },
                {
                    path: "/carousel",
                    element: <AdvertisementCarousel/>
                }
                ,{
                    path: "/users/:name",
                    element:( <Profile/>),
                    loader: ({params}) => profileLoader(params.name)
                },
                {
                    path: "/users/:name/createad",
                    element: <CreateAd/>
                } ,
                {
                    path: "/register",
                    element: <Registration />
                },
                {
                    path: "/admineditor",
                    element: <AdminEditor />

                },
                {
                    path: "/login",
                    element: <Login />
                },
            ],
        },
    ]);

ReactDOM.createRoot(document.getElementById("root")).render(
    <React.StrictMode>
        <RouterProvider router={router}/>
    </React.StrictMode>
)
