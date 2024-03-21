import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from '../views/Home'
import Room from '../views/Room'
import Food from '../views/Food'
import Decor from '../views/Decor'
import Order from '../views/Order'
import Login from '../views/Login'
import Register from '../views/Register'
import OrderHistory from '../views/OrderHistory';
import Seller from '../views/Seller'
import RoomHost from '../views/RoomHost'
const AppRouter: React.FC = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/home" element={<Home />} />
                <Route path="/room" element={<Room />} />
                <Route path="/food" element={<Food />} />
                <Route path="/decor" element={<Decor />} />
                <Route path="/order" element={<Order />} />
                <Route path="/login" element={<Login />} />
                <Route path="/register" element={<Register />} />
                <Route path='/order-history' element={<OrderHistory/>}/>
                <Route path='/seller' element={<Seller/>}/>
                <Route path='/room-host' element={<RoomHost/>}/>

            </Routes>
        </Router>
    );
};

export default AppRouter;
