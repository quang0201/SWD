import { useEffect, useState } from 'react';
import MainLayout from '../components/MainLayout';

interface Order {
    id: number;
    price: number;
    name: string;
    status: number;
}

function Home() {
    const [orders, setOrders] = useState<Order[]>([]);
    const [currentPage] = useState<number>(1);
    const [pageSize] = useState<number>(6); // Giá trị mặc định

    useEffect(() => {
        fetchOrders();
    }, [currentPage, pageSize]); // Cập nhật danh sách đơn hàng khi currentPage hoặc pageSize thay đổi

    const fetchOrders = async () => {
        try {
            const token = localStorage.getItem('jwt'); // Lấy mã JWT từ local storage
            const response = await fetch(`/api/order/get-order-host-food?index=${currentPage}&pageSize=${pageSize}`, {
                headers: {
                    'Authorization': `Bearer ${token}` // Thêm mã JWT vào tiêu đề Authorization
                }
            });
            if (response.ok) {
                const data = await response.json();
                setOrders(data.data);
            } else {
                console.error('Failed to fetch orders');
            }
        } catch (error) {
            console.error('Error fetching orders:', error);
        }
    };

    return (
        <MainLayout>
            <section className="food_section layout_padding">
                <div className="container">
                    <div className="heading_container heading_center">
                        <h2>
                            Các dịch vụ
                        </h2>
                    </div>
                    <button className='btn btn-green'>Thêm</button>

                    <table className="table">
                        <thead>
                            <tr>
                                <th>Mã Food</th>
                                <th>Tên</th>
                                <th>Giá</th>
                            </tr>
                        </thead>
                        <tbody>
                            {orders.map(order => (
                                <tr key={order.id}>
                                    <td>{order.id}</td>
                                    <td>{order.price}</td>
                                    <td>{order.status === 0 ? 'Đang xử lý' : 'Đã hoàn thành'}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </section>
        </MainLayout>
    );
}

export default Home;
