import { FaShoppingCart } from 'react-icons/fa';
import MainLayout from '../components/MainLayout';
import { Link } from 'react-router-dom';
import { useEffect, useState } from 'react';
function ViewRoom() {
    const [products, setProducts] = useState([]);
    useEffect(() => {
        // Fetch data from the API
        fetch('/api/decor/pagging-decor')
            .then(response => response.json())
            .then(data => setProducts(data))
            .catch(error => console.log(error));
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
                        <li className="active" data-filter="*">Tất cả</li>

                        <li data-filter=".burger"><Link to="/viewroom">Phòng</Link></li>
                        <li data-filter=".pizza">Trang trí</li>
                        <li data-filter=".pasta">Thức ăn & Đồ uống</li>
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