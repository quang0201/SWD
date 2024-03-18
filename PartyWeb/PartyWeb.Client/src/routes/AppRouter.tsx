import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from '../views/Home';
import ViewRoom from '../views/ViewRoom'
const AppRouter: React.FC = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/home" element={<Home />} />
                <Route path="/viewroom" element={<ViewRoom />} />

            </Routes>
        </Router>
    );
};

export default AppRouter;
