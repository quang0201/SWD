import { useState, useEffect } from 'react';
import MainLayout from '../components/MainLayout';
import { FaShoppingCart } from 'react-icons/fa';

function OrderHistory() {
    const [orders, setOrders] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [pageSize, setPageSize] = useState(6); // Giá trị mặc định

    useEffect(() => {
        fetchOrders();
    }, [currentPage, pageSize]); // Cập nhật danh sách đơn hàng khi currentPage hoặc pageSize thay đổi

    const fetchOrders = async () => {
        try {
            const token = localStorage.getItem('jwt'); // Lấy mã JWT từ local storage
            const response = await fetch(`/api/order/get-order-customer?index=${currentPage}&pageSize=${pageSize}`, {
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
    const handleNextPage = () => {
            setCurrentPage(prevPage => prevPage + 1);
    };

    const handlePreviousPage = () => {
        if (currentPage > 1) {
            setCurrentPage(prevPage => prevPage - 1);
        }
    };
    const handlePayment = async (orderId) => {
    }
    const handleCancelOrder = async (orderId) => {
    }
    return (
        <MainLayout>
            <div>
                <div className="container">
                    <h2>Order History</h2>
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Mã đơn hàng</th>
                                <th>Giá</th>
                                <th>Trạng thái</th>
                            </tr>
                        </thead>
                        <tbody>
                            {orders.map(order => (
                                <tr key={order.id}>
                                    <td>{order.id}</td>
                                    <td>{order.price}.000</td>
                                    <td>
                                        {order.status === 2 ? 'Chờ thanh toán' :
                                            order.status === 1 ? 'Đã thanh toán' :
                                                order.status === 0 ? 'Đã hủy đơn hàng' : ''}
                                    </td>
                                    <td>
                                        {order.status === 2 && <button onClick={() => handlePayment(order.id)}>Thanh toán</button>}
                                        {order.status === 2 && <button onClick={() => handleCancelOrder(order.id)}>Hủy đơn hàng</button>}
                                    </td>
                                </tr>
                            ))}

                        </tbody>

                    </table>
                    <button onClick={handlePreviousPage}>Previous trang</button>
                    <button onClick={handleNextPage}>Next trang</button>
                </div>
            </div>
        </MainLayout>
    );
}

export default OrderHistory;
