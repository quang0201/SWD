import { Link } from 'react-router-dom';
import MainLayout from '../components/MainLayout';
import { FaShoppingCart } from 'react-icons/fa';

function Home() {
    return (
        <MainLayout>
            <section className ="food_section layout_padding">
                <div className="container">
                    <div className="heading_container heading_center">
                        <h2>
                            Các dịch vụ
                        </h2>
                    </div>

                    <ul className="filters_menu">
                        <li className="active" data-filter="*">Tất cả</li>
                        
                        <li  data-filter=".burger"><Link to="/viewroom">Phòng</Link></li>
                        <li data-filter=".pizza">Trang trí</li>
                        <li data-filter=".pasta">Thức ăn & Đồ uống</li>
                    </ul>

                    <div className="filters-content">
                        <div className="row grid">
                            <div className="col-sm-6 col-lg-4 all pizza">
                                <div className="box">
                                    <div>
                                        <div className="img-box">
                                            <img src="images/f1.png" alt=""/>
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
                            <div className="col-sm-6 col-lg-4 all burger">
                                <div className="box">
                                    <div>
                                        <div className="detail-box">
                                            <h5>
                                                Delicious Burger
                                            </h5>
                                            <p>
                                                Veniam debitis quaerat officiis quasi cupiditate quo, quisquam velit, magnam voluptatem repellendus sed eaque
                                            </p>
                                            <div className="options">
                                                <h6>
                                                    $15
                                                </h6>
                                                <a href="">
                                                   
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-sm-6 col-lg-4 all pizza">
                                <div className="box">
                                    <div>
                                        <div className="img-box">
                                            <img src="images/f3.png" alt=""/>
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
                                                    $17
                                                </h6>
                                                <a href="">
                                                   
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-sm-6 col-lg-4 all pasta">
                                <div className="box">
                                    <div>
                                        <div className="img-box">
                                            <img src="images/f4.png" alt=""/>
                                        </div>
                                        <div className="detail-box">
                                            <h5>
                                                Delicious Pasta
                                            </h5>
                                            <p>
                                                Veniam debitis quaerat officiis quasi cupiditate quo, quisquam velit, magnam voluptatem repellendus sed eaque
                                            </p>
                                            <div className="options">
                                                <h6>
                                                    $18
                                                </h6>
                                                <a href="">
                                                    
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-sm-6 col-lg-4 all fries">
                                <div className="box">
                                    <div>
                                        <div className="img-box">
                                            <img src="images/f5.png" alt=""/>
                                        </div>
                                        <div className="detail-box">
                                            <h5>
                                                French Fries
                                            </h5>
                                            <p>
                                                Veniam debitis quaerat officiis quasi cupiditate quo, quisquam velit, magnam voluptatem repellendus sed eaque
                                            </p>
                                            <div className="options">
                                                <h6>
                                                    $10
                                                </h6>
                                                <a href="">
                                                    
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-sm-6 col-lg-4 all pizza">
                                <div className="box">
                                    <div>
                                        <div className="img-box">
                                            <img src="images/f6.png" alt=""/>
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
                                                    $15
                                                </h6>
                                                <a href="">
                                                    
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-sm-6 col-lg-4 all burger">
                                <div className="box">
                                    <div>
                                        <div className="img-box">
                                            <img src="images/f7.png" alt=""/>
                                        </div>
                                        <div className="detail-box">
                                            <h5>
                                                Tasty Burger
                                            </h5>
                                            <p>
                                                Veniam debitis quaerat officiis quasi cupiditate quo, quisquam velit, magnam voluptatem repellendus sed eaque
                                            </p>
                                            <div className="options">
                                                <h6>
                                                    $12
                                                </h6>
                                                <a href="">
                                                    
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-sm-6 col-lg-4 all burger">
                                <div className="box">
                                    <div>
                                        <div className="img-box">
                                            <img src="images/f8.png" alt=""/>
                                        </div>
                                        <div className="detail-box">
                                            <h5>
                                                Tasty Burger
                                            </h5>
                                            <p>
                                                Veniam debitis quaerat officiis quasi cupiditate quo, quisquam velit, magnam voluptatem repellendus sed eaque
                                            </p>
                                            <div className="options">
                                                <h6>
                                                    $14
                                                </h6>
                                                <a href="">
                                                    
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-sm-6 col-lg-4 all pasta">
                                <div className="box">
                                    <div>
                                        <div className="img-box">
                                            <img src="images/f9.png" alt=""/>
                                        </div>
                                        <div className="detail-box">
                                            <h5>
                                                Delicious Pasta
                                            </h5>
                                            <p>
                                                Veniam debitis quaerat officiis quasi cupiditate quo, quisquam velit, magnam voluptatem repellendus sed eaque
                                            </p>
                                            <div className="options">
                                                <h6>
                                                    $10
                                                </h6>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="btn-box">
                        <a href="">
                            View More
                        </a>
                    </div>
                </div>
            </section>
        </MainLayout>
    );
}

export default Home;