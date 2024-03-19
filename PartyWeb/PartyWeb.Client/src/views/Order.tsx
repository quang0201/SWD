import { Link } from 'react-router-dom';
import MainLayout from '../components/MainLayout';
import { FaShoppingCart } from 'react-icons/fa';
import { useEffect, useState } from 'react';

function Order() {
    const [decorFood, setDecorFood] = useState<any[]>([]);
    const [cartRoom, setCartRoom] = useState<any | null>(null);
    const [cartFood, setCartFood] = useState<any[]>([]);
    useEffect(() => {
        const decor = localStorage.getItem('decor');
        if (decor) {
            setDecorFood(JSON.parse(decor));
        }
        const room = localStorage.getItem('room');
        if (room) {
            setCartRoom(JSON.parse(room));
        }
        const food = localStorage.getItem('food');
        if (food) {
            setCartFood(JSON.parse(food));
        }
    }, []);
    return (
        <MainLayout>
            <section className="food_section layout_padding">
                <div className="container">
                    <div className="heading_container heading_center">
                        <h2>Thông tin bữa tiệc của bạn</h2>
                    </div>
                    {cartRoom && (
                        <div>
                            <h3>Thông tin phòng:</h3>
                            <div>
                                <p>Tên phòng: {cartRoom.name}</p>
                                <p>Giá: {cartRoom.price}</p>
                                <p>Ngày đặt: {cartRoom.startDate}</p>
                                <p>Ngày kết thúc: {cartRoom.endDate}</p>
                            </div>
                        </div>
                    )}
                    <div className="table-container">
                        {decorFood.length > 0 && (
                            <div>
                                <h3>Thông tin trang trí:</h3>
                                <table className="table">
                                    <thead>
                                        <tr>
                                            <th>Tên</th>
                                            <th>Số lượng</th>
                                            <th>Giá</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {decorFood.map((item, index) => (
                                            <tr key={index}>
                                                <td>{item.name}</td>
                                                <td>{item.quantity}</td>
                                                <td>{item.price}.000</td>
                                            </tr>
                                        ))}
                                    </tbody>
                                </table>
                            </div>
                        )}
                        {cartFood.length > 0 && (
                            <div>
                                <h3>Thông tin thức ăn & đồ uống:</h3>
                                <table className="table">
                                    <thead>
                                        <tr>
                                            <th>Tên</th>
                                            <th>Số lượng</th>
                                            <th>Giá</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {cartFood.map((item, index) => (
                                            <tr key={index}>
                                                <td>{item.name}</td>
                                                <td>{item.quantity}</td>
                                                <td>{item.price}.000</td>
                                            </tr>
                                        ))}
                                    </tbody>
                                </table>
                            </div>
                        )}
                    </div>
                    <button>Thanh toán</button>

                    {decorFood.length === 0 && !cartRoom && cartFood.length === 0 && (
                        <p>Vui lòng chọn ít nhất một mục trước khi hiển thị thông tin.</p>
                    )}
                </div>
            </section>
        </MainLayout>
    );
}

export default Order;
