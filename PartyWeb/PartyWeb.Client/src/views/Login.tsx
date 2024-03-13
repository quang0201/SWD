import React, { useState } from 'react';
import MainLayout from '../components/MainLayout';
import { Link } from 'react-router-dom';
import {
    MDBContainer,
    MDBInput,
    MDBCheckbox,
} from 'mdb-react-ui-kit';


const Login: React.FC = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            const response = await fetch('/api/user/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ username, password }),
            });
            if (response.ok) {
                const data = await response.json();
                localStorage.setItem('jwt', data.token);
            } else {
            }
        } catch (error) {
            console.error('Error:', error);
        }
    };


    return (
        <MainLayout>
            <main id="main">
                <form onSubmit={handleSubmit}>
                    <MDBContainer className="p-3 my-5 d-flex flex-column w-50">
                        <h2>Đăng nhập</h2>

                        <label>
                            Tài khoản:
                            <MDBInput
                                wrapperClass='mb-4'
                                type='text'
                                value={username}
                                onChange={(e) => setUsername(e.target.value)}
                            />
                        </label>
                        <label>
                            Mật khẩu:
                            <MDBInput
                                wrapperClass='mb-4'
                                type='password'
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                            />
                        </label>
                        <div className="d-flex justify-content-between mx-3 mb-4">
                            <MDBCheckbox name='flexCheck' value='' id='flexCheckDefault' label='Remember me' />
                            <a href="!#">Forgot password?</a>
                        </div>
                        <button>Đăng nhập</button>
                        <div className="text-center">
                            <p>Bạn chưa có tài khoản? <Link to="/register">Đăng kí</Link></p>
                        </div>
                    </MDBContainer>
                </form>
                
            </main>
        </MainLayout>
    );
};

export default Login;
