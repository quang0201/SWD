import { FaShoppingCart } from 'react-icons/fa';
import MainLayout from '../components/MainLayout';
import { Link } from 'react-router-dom';
import { useEffect, useState } from 'react';
function ViewRoom() {
    const [products, setProducts] = useState([]);
    useEffect(() => {
        const fetchData = async () => {
            try {
                // Lấy dữ liệu từ API
                const response = await fetch('/api/food/pagging-food?index=1&pageSize=9');
                const data = await response.json();
                setProducts(data);
            } catch (error) {
                console.log(error);
            }
        };

        fetchData();
    }, []);

    return (
        <MainLayout>
            <section className="food_section layout_padding">
                <div className="container">
                    <div className="heading_container heading_center">
                        <h2>
                            Các dịch vụ
                        </h2>
                    </div>

                    <ul className="filters_menu">
                        <li  data-filter="."><Link to="/room">Phòng</Link></li>
                        <li data-filter=""><Link to="/decor">Trang trí</Link></li>
                        <li data-filter=""><Link to="/food">Thức ăn & Đồ uống</Link></li>
                    </ul>

                    <div className="filters-content">
                        <div className="row grid">
                            <div className="col-sm-6 col-lg-4 all pizza">
                                <div className="box">
                                    <div>
                                        <div className="img-box">
                                            <img src="images/f1.png" alt="" />
                                        </div>
                                        <div className="detail-box">
                                            <h5>
                                                Delicious Pizza
                                            </h5>
                                            <p>
                                                Veniam debitis quaerat officiis quasi cupiditate quo, quisquam velit, magnam voluptatem repellendus sed eaque
                                            </p>
                                            <h6>
                                                $20
                                            </h6>
                                            <div className="options">
                                                <h6>
                                                    $20
                                                </h6>
                                                
                                                <a href="">
                                                    <FaShoppingCart />
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>
            </section>
        </MainLayout >
    );
}

export default ViewRoom;