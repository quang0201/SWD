import { Link } from 'react-router-dom';
import MainLayout from '../components/MainLayout';
import { useState } from 'react';
import { toast } from 'react-toastify';

function Register() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');
    const [isRegistering, setIsRegistering] = useState(false); // Track registration state

    const handleRegister = async () => {
        setIsRegistering(true); // Set loading state to disable button
        try {
            const response = await fetch('/api/user/register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    username,
                    password,
                    email,
                }),
            });
            const responseData = await response.json();
            if (!response.ok) {
                toast.error(responseData.error);
            } else {
                toast.success('Đăng ký thành công!');
                // Redirect to login page after successful registration
                setTimeout(() => {
                    // Sau 3 giây, chuyển hướng đến trang /register
                    window.location.href = '/login';
                }, 3000);
            }
        } catch (error) {
            toast.error('Đăng ký không thành công! Vui lòng thử lại.');
            setIsRegistering(false);
        } finally {
        }
    };

    return (
        <MainLayout>
            <section className="vh-100 gradient-custom">
                <div className="container py-5 h-100">
                    <div className="row d-flex justify-content-center align-items-center h-100">
                        <div className="col-12 col-md-8 col-lg-6 col-xl-5">
                            <div className="card bg-dark text-white">
                                <div className="card-body p-5 text-center">
                                    <div className="mb-md-5 mt-md-4 pb-5">
                                        <h2 className="fw-bold mb-2 text-uppercase">Đăng kí</h2>
                                        <div className="form-outline form-white mb-4">
                                            <label className="form-label">Tài khoản</label>
                                            <input
                                                type="text"
                                                id="typeUsername"
                                                className="form-control form-control-lg"
                                                value={username}
                                                onChange={(e) => setUsername(e.target.value)}
                                            />
                                        </div>
                                        <div className="form-outline form-white mb-4">
                                            <label className="form-label">Mật khẩu</label>
                                            <input
                                                type="password"
                                                id="typePassword"
                                                className="form-control form-control-lg"
                                                value={password}
                                                onChange={(e) => setPassword(e.target.value)}
                                            />
                                        </div>
                                        <div className="form-outline form-white mb-4">
                                            <label className="form-label">Email</label>
                                            <input
                                                type="email"
                                                id="typeEmail"
                                                className="form-control form-control-lg"
                                                value={email}
                                                onChange={(e) => setEmail(e.target.value)}
                                            />
                                        </div>
                                        <button
                                            className="btn btn-outline-light btn-lg px-5"
                                            type="button"
                                            disabled={isRegistering} // Disable button during registration
                                            onClick={handleRegister}
                                        >
                                            {isRegistering ? 'Đang đăng ký...' : 'Đăng kí'}
                                        </button>
                                    </div>
                                    <div>
                                        <p className="mb-0">
                                            Chưa có tài khoản?{' '}
                                            <Link className="text-white-50 fw-bold" to={'/login'}>
                                                Đăng nhập
                                            </Link>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </MainLayout>
    );
}

export default Register;
