import { FaShoppingCart } from 'react-icons/fa';
import MainLayout from '../components/MainLayout';
import { Link } from 'react-router-dom';
import { useEffect, useState } from 'react';
import Cart from '../components/Cart';

function Decor() {
    const [isLoading, setIsLoading] = useState(true); // Trạng thái của loading

    const [items, setItems] = useState([{}]);
    const [currentPage, setCurrentPage] = useState(1);
    const [itemsPerPage, setItemsPerPage] = useState(6);
    const [searchValue, setSearchValue] = useState('');

    const [cartFood, setCartFood] = useState<any[]>([]);

    useEffect(() => {
        const cartFoodLocal = localStorage.getItem('food');
        if (cartFoodLocal) {
            const parsedCartFood = JSON.parse(cartFoodLocal);
            console.log(parsedCartFood);
            setCartFood(parsedCartFood);
        }
    }, [])

    const addToCart = (foodItem) => {
        const existingItemIndex = cartFood.findIndex(item => item.id === foodItem.id);
    
        if (existingItemIndex !== -1) {
            // Nếu món đã tồn tại trong giỏ hàng, cập nhật số lượng của món đó
            const updatedCart = [...cartFood];
            updatedCart[existingItemIndex].quantity++; // Tăng số lượng
            setCartFood(updatedCart);
            localStorage.setItem('food', JSON.stringify(updatedCart));
        } else {
            // Nếu món chưa tồn tại trong giỏ hàng, thêm món mới vào giỏ hàng với số lượng mặc định là 1
            const updatedCart = [...cartFood, { ...foodItem, quantity: 1 }];
            setCartFood(updatedCart);
            localStorage.setItem('food', JSON.stringify(updatedCart));
        }
    };
    const removeFromCart = (index) => {
        const updatedCart = [...cartFood];
        updatedCart.splice(index, 1); // Xóa món ở vị trí index khỏi giỏ hàng
        setCartFood(updatedCart); // Cập nhật giỏ hàng mới
        localStorage.setItem('food', JSON.stringify(updatedCart)); // Cập nhật localStorage
    };

    

    useEffect(() => {
        handleSearch();
    }, [currentPage]);

    const handleSearch = () => {
        fetchData();
    };

    const fetchData = async () => {
        try {
            const response = await fetch(`/api/food/pagging-food?index=${currentPage}&pageSize=${itemsPerPage}&search=${searchValue}`);
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
    const increaseQuantity = (index) => {
        const updatedCart = [...cartFood];
        updatedCart[index].quantity++; // Tăng số lượng
        setCartFood(updatedCart); // Cập nhật giỏ hàng mới
        localStorage.setItem('food', JSON.stringify(updatedCart)); // Cập nhật dữ liệu vào localStorage
    };

    const decreaseQuantity = (index) => {
        const updatedCart = [...cartFood];
        if (updatedCart[index].quantity > 1) {
            updatedCart[index].quantity--; // Giảm số lượng nếu lớn hơn 1
            setCartFood(updatedCart); // Cập nhật giỏ hàng mới
            localStorage.setItem('food', JSON.stringify(updatedCart)); // Cập nhật dữ liệu vào localStorage
        }
    };
    return (
        <MainLayout>

            <div>
                <div className=" cart-container col-md-2">
                    <div className="cart-header">
                        <h3>Giỏ hàng</h3>
                    </div>
                    <div className="cart-body">
                    <h3>Thức ăn</h3>
                        {cartFood.map((foodItem, index) => (
                            <div key={index}>
                                <p>Tên món ăn: {foodItem.name}</p>
                                <p>Giá: {foodItem.price}.000</p>
                                <div className="quantity-controls">
                                <button onClick={() => decreaseQuantity(index)} disabled={foodItem.quantity === 1}>-</button>
                                    <span>{foodItem.quantity}</span>
                                    <button onClick={() => increaseQuantity(index)}>+</button>
                                </div>
                                <button className='btn btn-remove' onClick={() => removeFromCart(index)}>Remove</button>
                            </div>
                        ))}
                    </div>
                    <div className="cart-footer">
                        <button className="btn-checkout">Thanh toán</button>
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
                        <li data-filter=""><Link to="/room">Phòng</Link></li>
                        <li data-filter=""><Link to="/decor">Trang trí</Link></li>
                        <li data-filter="" className='services'><Link to="/food">Thức ăn & Đồ uống</Link></li>
                    </ul>

                    <div>
                        <input
                            type="text"
                            className="form-control"
                            placeholder="Nhập tên thức ăn, tên người bán..."
                            value={searchValue}
                            onChange={(e) => setSearchValue(e.target.value)}
                        />
                        <div className="btn_box">
                            <button className="btn btn-gray" onClick={handleSearch}>
                                Tìm ngay
                            </button>
                        </div>
                    </div>

                    {isLoading ? <div className="loader"></div> :
                        <div>
                            <div className="filters-content">
                                <div className="row grid">
                                    {items.map(item => (
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
                                                            Nhà cung cấp: {item.foodProvider}
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
                                    ))
                                    }
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

export default Decor;