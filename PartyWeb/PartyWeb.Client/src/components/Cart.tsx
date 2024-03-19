import React from 'react';
import { Link } from 'react-router-dom';

const Cart: React.FC = () => {
    return (
        <div>
            <div className="cart-container">
                <div className="cart-header">
                    <h3>Giỏ hàng</h3>
                </div>
                <div className="cart-body">
                    abc
                </div>
                <div className="cart-footer">
                    <button className="btn-checkout">Thanh toán</button>
                </div>
            </div>
        </div>
    );
};
export default Cart;
