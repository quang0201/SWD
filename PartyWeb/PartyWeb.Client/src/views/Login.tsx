import React, { useState } from 'react';
import MainLayout from '../components/MainLayout';
import { Link } from 'react-router-dom';
import {
    MDBContainer,
    MDBInput,
    MDBCheckbox,
} from 'mdb-react-ui-kit';
interface SuccessMessageProps {
    message: string;
}

const SuccessMessage: React.FC<SuccessMessageProps> = ({ message }) => {

    return (
        <div className="check">
            <i className="far fa-check-circle color"></i> &nbsp; &nbsp;
            <span>{message}</span>
        </div>
    );
};

const Login: React.FC = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [messages, setMessages] = useState<string[]>([]);

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
                addMessage('Đăng nhập thành công!');
            } else {
                // Xử lý đăng nhập thất bại
                console.error('Login failed');
            }
        } catch (error) {
            console.error('Error:', error);
        }
        
    };
    const addMessage = (message: string) => {
        setMessages([...messages, message]);
        setTimeout(() => {
            removeMessage(message);
        }, 5000); // Xóa thông báo sau 5 giây
    };

    const removeMessage = (message: string) => {
        setMessages(messages.filter(msg => msg !== message));
    };
    return (
        <MainLayout>
            <main id="main">
                <section className="sample-page">
                    <div className="container" data-aos="fade-up">
                    </div>
                </section>
                {messages.map((msg, index) => (
                    <SuccessMessage key={index} message={msg} />
                ))}
                <form onSubmit={handleSubmit}>
                    <MDBContainer className="p-3 my-5 d-flex flex-column w-50">
                        <h2>Đăng nhập</h2>

                        <label>
                            Tài khoản:
                            <MDBInput wrapperClass='mb-4' type='text' value={username}
                                onChange={(e) => setUsername(e.target.value)} />
                        </label>
                        <label>
                        Mật khẩu:
                        <MDBInput wrapperClass='mb-4' type='password' value={password}
                            onChange={(e) => setPassword(e.target.value)} />
                        </label>
                        <div className="d-flex justify-content-between mx-3 mb-4">
                            <MDBCheckbox name='flexCheck' value='' id='flexCheckDefault' label='Remember me' />
                            <a href="!#">Forgot password?</a>
                        </div>
                        <button>Đăng nhập</button>
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