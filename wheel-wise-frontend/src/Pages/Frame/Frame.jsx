import { Outlet } from "react-router-dom"
import MainNav from "../../Components/MainNav"

export default function Frame() {

    return (
        <main>
            <MainNav />
            <div className="container-fluid frame-content">
                <Outlet />
            </div>
        </main>
    )
}