import React, { useEffect, useState } from 'react';
import MainLayout from '../components/MainLayout';

function MyProfile() {
    const [data, setData] = useState(null);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await fetch('your-api-endpoint');
            const jsonData = await response.json();
            setData(jsonData);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    return (
        <MainLayout>
            {data ? (
                <p>{data.message}</p>
            ) : (
                <p>Loading...</p>
            )}
        </MainLayout>
    );
}

export default MyProfile;