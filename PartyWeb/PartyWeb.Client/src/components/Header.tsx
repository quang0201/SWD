import React from 'react';
import { Link } from 'react-router-dom';
import logo from '../assets/Logo.png';

const Header: React.FC = () => {
    return (
        <header>
            <img src={logo} alt="Logo" className="logo" />
            <h1>Party Online</h1>
            <nav>
                <Link to="/">Trang chủ</Link>
                <Link to="/login">Đăng nhập</Link>
                <Link to="/services">Dịch vụ</Link>

            </nav>
        </header>
    );
};
export default Header;
