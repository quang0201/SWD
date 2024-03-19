import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from '../views/Home';
import Room from '../views/Room'
import Food from '../views/Food'
import Decor from '../views/Decor'

const AppRouter: React.FC = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/home" element={<Home />} />
                <Route path="/room" element={<Room />} />
                <Route path="/food" element={<Food />} />
                <Route path="/decor" element={<Decor />} />

            </Routes>
        </Router>
    );
};

export default AppRouter;
