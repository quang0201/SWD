import { useState, useEffect } from 'react';
import MainLayout from '../components/MainLayout';
import { Link } from 'react-router-dom';
import { FaShoppingCart } from 'react-icons/fa';

interface DecorItem {
    id: number;
    name: string;
    content: string;
    decorProvider: string;
    price: number;
}

interface CartItem {
    id: number;
    name: string;
    price: number;
    quantity: number;
}

function Decor() {
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [items, setItems] = useState<DecorItem[]>([]);
    const [currentPage, setCurrentPage] = useState<number>(1);
    const [itemsPerPage, setItemsPerPage] = useState<number>(6);
    const [cartDecor, setCartDecor] = useState<CartItem[]>([]);

    useEffect(() => {
        const cartDecorLocal = localStorage.getItem('decor');
        if (cartDecorLocal) {
            const parsedCartDecor: CartItem[] = JSON.parse(cartDecorLocal);
            setCartDecor(parsedCartDecor);
        }
    }, []);

    useEffect(() => {
        fetchData();
    }, [currentPage]);

    const addToCart = (item: DecorItem) => {
        const existingItemIndex = cartDecor.findIndex(cartItem => cartItem.id === item.id);
        if (existingItemIndex !== -1) {
            const updatedCart = [...cartDecor];
            updatedCart[existingItemIndex].quantity++;
            setCartDecor(updatedCart);
            localStorage.setItem('decor', JSON.stringify(updatedCart));
        } else {
            const updatedCart = [...cartDecor, { id: item.id, name: item.name, price: item.price, quantity: 1 }];
            setCartDecor(updatedCart);
            localStorage.setItem('decor', JSON.stringify(updatedCart));
        }
    };

    const fetchData = async () => {
        try {
            const response = await fetch(`/api/decor/pagging-decor?index=${currentPage}&pageSize=${itemsPerPage}`);
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

    const increaseQuantity = (index: number) => {
        const updatedCart = [...cartDecor];
        updatedCart[index].quantity++;
        setCartDecor(updatedCart);
        localStorage.setItem('decor', JSON.stringify(updatedCart));
    };

    const decreaseQuantity = (index: number) => {
        const updatedCart = [...cartDecor];
        if (updatedCart[index].quantity > 1) {
            updatedCart[index].quantity--;
            setCartDecor(updatedCart);
            localStorage.setItem('decor', JSON.stringify(updatedCart));
        }
    };

    const removeFromCart = (index: number) => {
        const updatedCart = [...cartDecor];
        updatedCart.splice(index, 1);
        setCartDecor(updatedCart);
        localStorage.setItem('decor', JSON.stringify(updatedCart));
    };

    return (
        <MainLayout>
            <div>
                <div className="cart-container">
                    <div className="cart-header">
                        <h3>Trang trí</h3>
                    </div>
                    <div className="cart-body">
                        {cartDecor.map((item, index) => (
                            <div key={index}>
                                <p>Tên món ăn: {item.name}</p>
                                <p>Giá: {item.price}.000</p>
                                <div className="quantity-controls">
                                    <button onClick={() => decreaseQuantity(index)} disabled={item.quantity === 1}>-</button>
                                    <span>{item.quantity}</span>
                                    <button onClick={() => increaseQuantity(index)}>+</button>
                                </div>
                                <button className='btn btn-remove' onClick={() => removeFromCart(index)}>Remove</button>
                            </div>
                        ))}
                    </div>
                    <div className="cart-footer">
                        <button className="btn-checkout"><Link to="/order">Đặt tiệc</Link></button>
                    </div>
                </div>
            </div>

            <section className="food_section layout_padding">
                <div className="container">
                    <div className="heading_container heading_center">
                        <h2>Các dịch vụ</h2>
                    </div>

                    <ul className="filters_menu">
                        <li data-filter=""><Link to="/room">Phòng</Link></li>
                        <li data-filter="" className='services'><Link to="/decor">Trang trí</Link></li>
                        <li data-filter=""><Link to="/food">Thức ăn & Đồ uống</Link></li>
                    </ul>

                    <div>
                        <input type="text" className="form-control" placeholder="Nhập tên thức ăn, tên người bán..." />
                        <div className="btn_box">
                            <button className='btn btn-gray'>
                                Tìm ngay
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
                                                        <h5>{item.name}</h5>
                                                        <p>{item.content}</p>
                                                        <h6>Nhà cung cấp: {item.decorProvider}</h6>
                                                        <div className="options">
                                                            <h6>Giá: {item.price}.000</h6>
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
        </MainLayout>
    );
}

export default Decor;
