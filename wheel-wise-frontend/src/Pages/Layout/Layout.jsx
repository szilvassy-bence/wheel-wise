import "./Layout.css"
import { Outlet } from "react-router-dom"
import MainNav from "../../Components/MainNav"
import Container from "react-bootstrap/Container";

export default function Layout() {

    return (
        <main>
            <MainNav />
            <Container fluid className="content">
                <Outlet />
            </Container>
        </main>
    )
}