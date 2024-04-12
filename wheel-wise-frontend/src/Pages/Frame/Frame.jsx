import { Outlet } from "react-router-dom"
import MainNav from "../../Components/MainNav"
import Container from "react-bootstrap/Container";

export default function Frame() {

    return (
        <main>
            <MainNav />
            <Container>
                <Outlet />
            </Container>
        </main>
    )
}