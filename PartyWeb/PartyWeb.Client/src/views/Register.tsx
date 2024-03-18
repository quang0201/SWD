import React, { useState } from 'react';
import MainLayout from '../components/MainLayout';
import { Link,useNavigate  } from 'react-router-dom';
import { MDBContainer, MDBInput } from 'mdb-react-ui-kit';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import LoadingComponent from '../components/Loading';

const Register: React.FC = () => {

    
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');
    const [buttonDisabled, setButtonDisabled] = useState(false);
    
    const [isLoading, setIsLoading] = useState(false); 
    const navigate = useNavigate();
    
    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const toastId = toast.loading('Đang tải dữ liệu...');
        if (!email || !password || !username) {
            toast.error('Vui lòng điền đầy đủ thông tin.');
            toast.dismiss(toastId);
            return;
        }
        setButtonDisabled(true);
        setIsLoading(true); // Set loading to true before the action
        try {
            const response = await fetch('/api/user/register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ username, password, email }),
            });

            if (response.ok) {
                const data = await response.json();
                toast.dismiss(toastId);
                toast.success(data.mess);
                toast.success('Chờ chuyển hướng đến đăng nhập sau vài giây.');
                setTimeout(() => {
                    navigate('/login');
                }, 3000); // 3 seconds delay
            } else {
                const errorData = await response.json();
                toast.dismiss(toastId);
                toast.error(errorData.error);
                setButtonDisabled(false);
            }
        } catch (error) {
            console.error('Error:', error);
        } finally {
            setButtonDisabled(false);
        }
    };

    return (
        <MainLayout>
            {isLoading && <LoadingComponent />}
            <ToastContainer />
            <main id="main">
                <form onSubmit={handleSubmit}>
                    <MDBContainer className="p-3 my-5 d-flex flex-column w-50">
                        <h2>Đăng kí</h2>
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
                        <label>
                            Email:
                            <MDBInput wrapperClass='mb-4' type='text' value={email}
                                onChange={(e) => setEmail(e.target.value)} />
                        </label>
                        <button disabled={buttonDisabled} className="btn btn-green">Đăng kí</button>
                        <div className="text-center">
                            <p>Bạn có tài khoản?<Link to="/login">Đăng nhập</Link>
                            </p>
                        </div>
                    </MDBContainer>
                </form>
            </main>
        </MainLayout>
    );
};

export default Register;
