import MainLayout from '../components/MainLayout';
import { useEffect, useState } from 'react';
import { toast } from 'react-toastify';

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
    const [paymentMethod, setPaymentMethod] = useState('cash');

    const handlePaymentMethodChange = (event) => {
        setPaymentMethod(event.target.value);
    };

    const token = localStorage.getItem('jwt');
    const handlePayment = async ()  => {
        const decorFoodData = decorFood.map(item => ({
            id: item.id,
            quantity: item.quantity
        }));

        const cartFoodData = cartFood.map(item => ({
            id: item.id,
            quantity: item.quantity
        }));

        const paymentData = {
            orderRooms: {
                idRoom: cartRoom.id,
                startDate: cartRoom.startDate,
                endDate: cartRoom.endDate
            },
            orderDecors: decorFoodData,
            orderFoods: cartFoodData
        };
        try {
            // Gọi API ở đây, ví dụ:
            const response = await fetch('api/order/add-order', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                },
                body: JSON.stringify(paymentData)
            });
    
            if (response.status === 401) {
                toast.error("Vui lòng đăng nhập để đặt tiệc");
            }
            const responseData = await response.json();
            if (!response.ok) {
                toast.error(responseData.error);

            } else {
                toast.success(responseData.mess);
                setTimeout(() => {
                    window.location.href = responseData.data.checkoutUrl;
                }, 3000);
            }
        } catch (error) {
            console.error('Lỗi khi gọi API:', error);
            toast.error('Đã xảy ra lỗi khi đặt đơn hàng. Vui lòng thử lại.');
        }

    };
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
                    <div>
                        <h3>Chọn phương thức thanh toán</h3>
                        <div>
                            <input
                                type="radio"
                                id="credit_card"
                                name="paymentMethod"
                                value="credit_card"
                                checked={paymentMethod === 'credit_card'}
                                onChange={handlePaymentMethodChange}
                            />
                            <label htmlFor="credit_card">Thẻ tín dụng</label>
                        </div>
                        {/* Các phương thức thanh toán khác */}
                        <button onClick={handlePayment}>Thanh toán</button>
                    </div>

                    {decorFood.length === 0 && !cartRoom && cartFood.length === 0 && (
                        <p>Vui lòng chọn ít nhất một mục trước khi hiển thị thông tin.</p>
                    )}
                </div>
            </section>
        </MainLayout>
    );
}

export default Order;
