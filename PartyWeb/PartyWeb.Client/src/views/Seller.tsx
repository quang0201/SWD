import { Link } from 'react-router-dom';
import MainLayout from '../components/MainLayout';

function Home() {
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
                        <li data-filter="."><Link to="/room-host">Phòng</Link></li>
                        <li data-filter=""><Link to="/decor">Trang trí</Link></li>
                        <li data-filter=""><Link to="/food">Thức ăn & Đồ uống</Link></li>
                        <li data-filter=""><Link to="/food">Lịch sử đơn hàng</Link></li>
                    </ul>
                </div>
            </section>
        </MainLayout>
    );
}

export default Home;