import React from 'react';
import { Link } from 'react-router-dom';

const Header: React.FC = () => {
    return (
        <header id="header" className="header fixed-top d-flex align-items-center">
            <div className="container d-flex align-items-center justify-content-between">
                <div className="header">
                    <div className="container">
                        <Link to="/" className="logo d-flex align-items-center me-auto me-lg-0">
                            <h1>Party Booking</h1>
                        </Link>

                        <nav id="navbar" className="navbar">
                            <ul>
                                <li><Link to="/">Trang chủ</Link></li>
                                <li><Link to="/login">Đăng nhập</Link></li>
                            </ul>
                            <a className="btn-book-a-table" href="#book-a-table">Đặt tiệc ngay</a>
                            <i className="mobile-nav-toggle mobile-nav-show bi bi-list"></i>
                            <i className="mobile-nav-toggle mobile-nav-hide d-none bi bi-x"></i>
                        </nav>

                    </div>
                </div>
            </div >
        </header>
    );
};
export default Header;
