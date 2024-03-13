import React from 'react';

const Header: React.FC = () => {
    return (
        <footer id="footer" className="footer">
            <div className="container">
                <div className="row gy-3">
                    <div className="col-lg-3 col-md-6 d-flex">
                        <i className="bi bi-geo-alt icon"></i>
                        <div>
                            

                        </div>

                        <div className="col-lg-3 col-md-6 footer-links d-flex">
                           

                        </div>
                    </div>

                    <div className="container">
                        <div className="copyright">
                            &copy; Copyright <strong><span>Yummy</span></strong>. All Rights Reserved
                        </div>
                        <div className="credits">
                            Designed by <a href="#">Quang</a>
                        </div>
                    </div>
                </div>
            </div>

        </footer >
    );
};
export default Header;
