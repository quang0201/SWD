import React, { useState, useEffect } from 'react';

interface LoadingProps {
    delay?: number; // Optional delay in milliseconds (default: 3000)
}

const Loading: React.FC<LoadingProps> = ({ delay = 3000 }) => {
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        const timeoutId = setTimeout(() => {
            setIsLoading(false);
        }, delay);

        return () => clearTimeout(timeoutId);
    }, [delay]); // Re-run useEffect if delay changes

    return (
        <div className="loading-container">
            {/* Your loading content here (e.g., spinner, text) */}
            <div className="loading-spinner"></div>  {/* Example spinner element */}
            <p className="loading-text">Đang xử lý...</p>  {/* Example loading text */}
        </div>
    );
};

export default Loading;