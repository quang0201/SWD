import React from 'react';
import MainLayout from '../components/MainLayout';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const Home: React.FC = () => {
    const handleClick = () => {
        toast.success('Thành công!', {
            position: "top-right",
            autoClose: 5000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
        });
    };

    return (
        <MainLayout>
            <button onClick={handleClick}>Hiển thị thông báo</button>
            <ToastContainer />
        </MainLayout>
    );
};

export default Home;