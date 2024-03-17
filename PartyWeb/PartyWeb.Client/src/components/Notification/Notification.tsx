import React, { useState, useEffect } from 'react';

interface NotificationProps {
    message: string;
    type: 'success' | 'danger';
    duration: number;
}

const Notification: React.FC<NotificationProps> = ({ message, type, duration }) => {
    const [isVisible, setIsVisible] = useState(false);

    useEffect(() => {
        let timer: NodeJS.Timeout;

        if (message) {
            setIsVisible(true);
            timer = setTimeout(() => {
                setIsVisible(false);
            }, duration);
        }

        return () => {
            clearTimeout(timer);
        };
    }, [message, duration]);

    return isVisible ? (
        <div className={`notification ${type}`} style={{ position: 'fixed', top: 0, right: 0 }}>
            {type === 'success' ? (
                <i className="far fa-check-circle"></i>
            ) : (
                <i className="far fa-times-circle"></i>
            )}
            <span>{message}</span>
        </div>
    ) : null;
};

export default Notification;