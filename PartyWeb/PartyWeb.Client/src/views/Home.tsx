import React, { useState } from 'react';
import MainLayout from '../components/MainLayout';
import Notification from '../components/Notification/Notification';

interface Notification {
    id: number;
    message: string;
}

const Home: React.FC = () => {
    const [notifications, setNotifications] = useState<Notification[]>([]);

    const addNotification = (message: string) => {
        const newNotification: Notification = {
            id: notifications.length + 1,
            message: message
        };
        setNotifications([...notifications, newNotification]);
    };

    return (
        <MainLayout>
            <div className="App">
                <button onClick={() => addNotification(`Thông báo ${notifications.length + 1}`)}>Thêm thông báo</button>
                <div className="notification-container">
                    {notifications.map(notification => (
                        <Notification key={notification.id} message={notification.message} type="success" duration={3000} />
                    ))}
                </div>
            </div>
        </MainLayout>
    );
};

export default Home;