import React from 'react';
import { Link } from 'react-router-dom';
import logo from '../assets/Logo.png';

const Header: React.FC = () => {
    const token = localStorage.getItem('jwt');
    const isLoggedIn = !!token;

    return (
        <header>
            <img src={logo} alt="Logo" className="logo" />
            <h1>Party Online</h1>
            <nav>
                <Link to="/">Trang chủ</Link>
                {isLoggedIn ? null : <Link to="/login">Đăng nhập</Link>}
                <Link to="/services">Dịch vụ</Link>
                {!isLoggedIn ? null : <Link to="/profile">Cá nhân</Link>}
            </nav>
        </header>
    );
};
export default Header;
