import { Link } from 'react-router-dom';
import MainLayout from '../components/MainLayout';
import { useEffect, useState } from 'react';
import { toast } from 'react-toastify';

function Login() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [isBlock, setIsBlock] = useState(false); // Track registration state
    useEffect(() => {
        const jwt = localStorage.getItem('jwt');
        if(jwt !== null){
            window.location.href = '/';
        }
    }, []);
    const handleLogin = async () => {
        setIsBlock(true);
        try {
            const response = await fetch('/api/user/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    username: username,
                    password: password,
                }),
            });
            const responseData = await response.json();
            if (!response.ok) {
                toast.error(responseData.error);
                setIsBlock(false);

            } else {
                toast.success(responseData.mess);
                localStorage.setItem('jwt', responseData.token);
                setTimeout(() => {
                    // Sau 3 giây, chuyển hướng đến trang /register
                    window.location.href = '/';
                }, 3000);
            }
        } catch (error) {
            toast.error('Đăng nhập không thành công! Vui lòng thử lại.');
        }
    };
    return (
        <MainLayout>
            <section className="vh-100 gradient-custom">
                <div className="container py-5 h-100">
                    <div className="row d-flex justify-content-center align-items-center h-100">
                        <div className="col-12 col-md-8 col-lg-6 col-xl-5">
                            <div className="card bg-dark text-white" >
                                <div className="card-body p-5 text-center">
                                    <div className="mb-md-5 mt-md-4 pb-5">
                                        <h2 className="fw-bold mb-2 text-uppercase">Đăng nhập</h2>
                                        <div className="form-outline for    m-white mb-4">
                                            <label className="form-label">Tài khoản</label>
                                            <input
                                                type="text"
                                                id="typeUsername"
                                                className="form-control form-control-lg"
                                                value={username}
                                                onChange={(e) => setUsername(e.target.value)}
                                            />                                        </div>
                                        <div className="form-outline form-white mb-4">
                                            <label className="form-label">Mật khẩu</label>
                                            <input
                                                type="password"
                                                id="typePassword"
                                                className="form-control form-control-lg"
                                                value={password}
                                                onChange={(e) => setPassword(e.target.value)}
                                            />                                        </div>
                                        <p className="small mb-5 pb-lg-2"><a className="text-white-50" href="#!">Quên mật khẩu?</a></p>
                                        <button
                                            className="btn btn-outline-light btn-lg px-5"
                                            type="button"
                                            disabled={isBlock} // Disable button during registration
                                            onClick={handleLogin}
                                        >
                                            {isBlock ? 'Đang đăng nhập...' : 'Đăng nhập'}
                                        </button>
                                    </div>
                                    <div>
                                        <p className="mb-0">Chưa có tài khoản? <Link className="text-white-50 fw-bold" to={'/register'}>Đăng ký</Link>
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

export default Login;