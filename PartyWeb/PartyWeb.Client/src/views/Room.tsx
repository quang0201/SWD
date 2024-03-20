import { FaShoppingCart } from 'react-icons/fa';
import MainLayout from '../components/MainLayout';
import { Link } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { toast } from 'react-toastify';

function Room() {
    const [isLoading, setIsLoading] = useState(true);
    const [items, setItems] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [itemsPerPage, setItemsPerPage] = useState(6);
    const [cartRoom, setCartRoom] = useState(null);
    const [startDate, setStartDate] = useState('');
    const [endDate, setEndDate] = useState('');
    useEffect(() => {
        fetchData();
    }, [currentPage]);

    useEffect(() => {
        const cartRoomLocal = localStorage.getItem('room');
        if (cartRoomLocal) {
            const item = JSON.parse(cartRoomLocal);
            setCartRoom(item);
            setStartDate(item.startDate);
            setEndDate(item.endDate);
        }
    }, []);

    const fetchData = async () => {
        try {
            const response = await fetch(`/api/room/pagging-room?index=${currentPage}&pageSize=${itemsPerPage}`);
            const data = await response.json();
            if (data.data.length === 0 && currentPage > 1) {
                setCurrentPage(1);
            }
            setItems(data.data);
        } catch (error) {
            console.log(error);
        } finally {
            setIsLoading(false);
        }
    };

    const addToCart = (item) => {
        setCartRoom(item); // Thêm phòng vào giỏ hàng
        localStorage.setItem('room', JSON.stringify(item));  // Lưu giỏ hàng vào local storage
    };
    const addToCartWithDate = async () => {
        if (startDate && endDate) {
            try {
                const url = `/api/order/check-room?id=${cartRoom.id}&startDate=${startDate}&endDate=${endDate}`;
                const response = await fetch(url, {
                    method: 'POST'
                });
                if (response.ok) {
                    toast.success('Bạn đã chọn phòng thành công');
                    const cartRoomWithDate = { ...cartRoom, startDate, endDate };
                    setCartRoom(cartRoomWithDate);
                    localStorage.setItem('room', JSON.stringify(cartRoomWithDate));
                } else {
                    toast.error('Phòng không thể đặt vào ngày đã chọn. Vui lòng chọn ngày khác.');
                }
            } catch (error) {
                toast.error('Đã xảy ra lỗi. Vui lòng thử lại sau.');
            }
        } else {
            console.log("Vui lòng chọn ngày bắt đầu và ngày kết thúc!");
        }
    };
    
    return (
        <MainLayout>
            <div>
                <div className=" cart-container">
                    <div className="cart-header">
                        <h3>Phòng của bạn</h3>
                    </div>
                    <div className="cart-body">
                        {cartRoom && (
                            <div>
                                <p>Tên phòng: {cartRoom.name}</p>
                                <p>Giá: {cartRoom.price}.000</p>
                                <h6>Chọn ngày đặt lịch</h6>
                                <p>Ngày tổ chức</p>
                                <input type='date' value={startDate} onChange={(e) => setStartDate(e.target.value)}></input>
                                <p>Ngày kết thúc</p>
                                <input type='date' value={endDate} onChange={(e) => setEndDate(e.target.value)}></input><br />
                                <button className='btn btn-green' onClick={addToCartWithDate}>Kiểm tra</button>
                            </div>
                        )}
                    </div>
                    <div className="cart-footer">
                        <button className="btn-checkout"><Link to="/order">Đặt tiệc</Link></button>
                    </div>
                </div>
            </div>

            <section className="food_section layout_padding">
                <div className="container">
                    <div className="heading_container heading_center">
                        <h2>
                            Các dịch vụ
                        </h2>
                    </div>

                    <ul className="filters_menu">
                        <li data-filter="" className='services'><Link to="/room">Phòng</Link></li>
                        <li data-filter=""><Link to="/decor">Trang trí</Link></li>
                        <li data-filter=""><Link to="/food">Thức ăn & Đồ uống</Link></li>
                    </ul>

                    <div>
                        <input type="text" className="form-control" placeholder="Nhập tên thức ăn,tên người bán..." />
                        <div className="btn_box">
                            <button className='btn btn-gray'>
                                Tìm ngay
                            </button>
                        </div>
                    </div>

                    {isLoading ? <div className="loader"></div> :
                        <div>
                            <div className="filters-content">
                                <div className="row grid">
                                    {items.map((item) => (
                                        <div className="col-sm-6 col-lg-4 all" key={item.id}>
                                            <div className="box">
                                                <div>
                                                    <div className="img-box">
                                                        <img src="images/f1.png" alt="" />
                                                    </div>
                                                    <div className="detail-box">
                                                        <h5>
                                                            {item.name}
                                                        </h5>
                                                        <p>
                                                            {item.content}
                                                        </p>
                                                        <h6>
                                                            Nhà cung cấp: {item.roomProvider}
                                                        </h6>
                                                        <h6>
                                                            Số người mua:
                                                        </h6>

                                                        <div className="options">
                                                            <h6>
                                                                Giá: {item.price}.000
                                                            </h6>
                                                            <button className='btn btn-cart' onClick={() => addToCart(item)}>
                                                                <FaShoppingCart />
                                                            </button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            </div>
                            <div className="pagination">
                                <button className="btn btn-green" onClick={() => setCurrentPage(currentPage - 1)} disabled={currentPage === 1}>
                                    Previous
                                </button>
                                <span>{currentPage}</span>
                                <button className="btn btn-green" onClick={() => setCurrentPage(currentPage + 1)}>
                                    Next
                                </button>
                            </div>
                        </div>
                    }


                </div>
            </section>
        </MainLayout >
    );
}

export default Room;