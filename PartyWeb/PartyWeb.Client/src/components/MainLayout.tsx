import React from 'react';
import Header from './Header';
import Footer from './Footer';
import 'bootstrap/dist/css/bootstrap.css';
import '../styles/css/Style.css'
interface MainLayoutProps {
    children: React.ReactNode;
}

const MainLayout: React.FC<MainLayoutProps> = ({ children }) => {
    return (
        <div className="sub_page">

            <div className="hero_area">
                <Header />
            </div>
            
            {children}
            <Footer />
        </div>
    );
};

export default MainLayout;