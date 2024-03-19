import { FaShoppingCart } from 'react-icons/fa';
import MainLayout from '../components/MainLayout';
import { Link } from 'react-router-dom';
import { useEffect, useState } from 'react';

function Decor() {
    const [isLoading, setIsLoading] = useState(true); // Trạng thái của loading
    const [items, setItems] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [itemsPerPage, setItemsPerPage] = useState(6);
    useEffect(() => {
        fetchData();
    }, [currentPage]);


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
                        <li data-filter=""><Link to="/room">Phòng</Link></li>
                        <li data-filter="active"><Link to="/decor">Trang trí</Link></li>
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
                                                            Nhà cung cấp: {item.foodProvider}
                                                        </h6>
                                                        <h6>
                                                            Số người mua:
                                                        </h6>
                                                        <div className="options">
                                                            <h6>
                                                                Giá: {item.price}.000
                                                            </h6>
                                                            <input type='number'></input>
                                                            <a href="">
                                                                <FaShoppingCart />
                                                            </a>
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

export default Decor;