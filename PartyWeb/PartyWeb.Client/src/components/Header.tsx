import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { toast } from 'react-toastify';

const Header: React.FC = () => {
    const [isLoggedIn, setIsLoggedIn] = useState(false); // Trạng thái đăng nhập

    // Hàm kiểm tra và cập nhật trạng thái đăng nhập
    const checkLoginStatus = () => {
        const jwt = localStorage.getItem('jwt');
        if (jwt) {
            // Thực hiện kiểm tra valid token
            // Nếu token hợp lệ, cập nhật trạng thái đăng nhập
            setIsLoggedIn(true);
        } else {
            setIsLoggedIn(false);
        }
    };

    // Kiểm tra trạng thái đăng nhập khi thành phần được tạo hoặc khi thay đổi
    useEffect(() => {
        checkLoginStatus();
    }, []);

    // Hàm xử lý đăng xuất
    const handleLogout = () => {
        toast.success('Đăng xuất thành công');
                setTimeout(() => {
                    window.location.href = '/';
                }, 3000);
        localStorage.removeItem('jwt'); // Xóa mã JWT khỏi local storage
        setIsLoggedIn(false);
    };

    return (
        <header className="header_section">
            <div className="container">
                <nav className="navbar navbar-expand-lg custom_nav-container ">
                    <a className="navbar-brand" href="index.html">
                        <span>
                            Party Booking
                        </span>
                    </a>

                    <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span className=""> </span>
                    </button>

                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav  mx-auto ">
                            <li className="nav-item">
                                <Link className="nav-link" to="/">Trang chủ</Link>
                            </li>
                            {isLoggedIn ? (
                                <React.Fragment>
                                    <li className="nav-item">
                                        <Link className="nav-link" to="/order-history">Lịch sử đặt tiệc</Link>
                                    </li>
                                    <li className="nav-item">
                                    <Link className="nav-link" to="/order">Đặt tiệc</Link>
                                    </li>
                                    <li className="nav-item">
                                        <button className="nav-link btn-link" onClick={handleLogout}>Đăng xuất</button>
                                    </li>
                                </React.Fragment>
                            ) : (
                                <li className="nav-item">
                                    <Link className="nav-link" to="/login">Đăng nhập</Link>
                                </li>
                            )}
                        </ul>
                    </div>
                </nav>
            </div>
        </header>
    );
};

export default Header;