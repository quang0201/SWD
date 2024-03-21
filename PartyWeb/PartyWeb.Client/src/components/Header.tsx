import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { toast } from 'react-toastify';

const Header: React.FC = () => {
    const [isLoggedIn, setIsLoggedIn] = useState(false); // Trạng thái đăng nhập
    const [role, setRole] = useState(0); // Trạng thái vai trò người dùng

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

    useEffect(() => {
        checkLoginStatus();
    }, []);

    const handleLogout = () => {
        toast.success('Đăng xuất thành công');
        setTimeout(() => {
            window.location.href = '/';
        }, 3000);
        localStorage.removeItem('jwt'); // Xóa mã JWT khỏi local storage
        setIsLoggedIn(false);
    };

    useEffect(() => {
        const fetchUserData = async () => {
            try {
                const token = localStorage.getItem('jwt'); // Lấy mã JWT từ local storage
                const apiUrl = '/api/user/get-user'; // URL API để lấy thông tin người dùng

                const response = await fetch(apiUrl, {
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }
                });

                if (response.ok) {
                    const data = await response.json();
                    // Xử lý dữ liệu người dùng
                    console.log('role', data.data.role);
                    setRole(data.data.role); // Cập nhật trạng thái vai trò người dùng dựa trên dữ liệu từ API
                } else {
                    throw new Error('Lỗi khi lấy thông tin người dùng');
                }
            } catch (error) {
                // Xử lý lỗi
                console.error('Lỗi khi lấy thông tin người dùng:', error);
            }
        };

        fetchUserData();
    }, []);

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
                                    {role === 0 && (
                                        <li className="nav-item">
                                            <Link className="nav-link" to="/register">Đăng ký bán</Link>
                                        </li>
                                    )}
                                    {role === 2 && (
                                        <li className="nav-item">
                                            <Link className="nav-link" to="/admin">Trang admin</Link>
                                        </li>
                                    )}
                                    {role === 1 && (
                                        <li className="nav-item">
                                            <Link className="nav-link" to="/seller">Trang Người bán</Link>
                                        </li>
                                    )}
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