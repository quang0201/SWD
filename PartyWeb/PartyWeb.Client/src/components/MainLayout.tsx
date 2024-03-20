import React from 'react';
import Header from './Header';
import Footer from './Footer';
import 'bootstrap/dist/css/bootstrap.css';
import '../styles/css/Style.css'
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
interface MainLayoutProps {
    children: React.ReactNode;
}

const MainLayout: React.FC<MainLayoutProps> = ({ children }) => {
    return (
        <div className="sub_page">
            <ToastContainer/>
            <div className="hero_area">
                <Header />
            </div>
            
            {children}
            <Footer />
        </div>
    );
};

export default MainLayout;