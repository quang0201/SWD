import React from 'react';


const Header: React.FC = () => {

    return (
        <header className="header_section">
            <div className="container">
                <nav className="navbar navbar-expand-lg custom_nav-container ">
                    <a className="navbar-brand" href="index.html">
                        <span>
                            Party Booking
                        </span>
                    </a>

                    <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span className=""> </span>
                    </button>

                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav  mx-auto ">
                            <li className="nav-item">
                                <a className="nav-link" href="index.html">Home </a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="menu.html">Menu  </a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="about.html">About</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="book.html">Book Table</a>
                            </li>
                        </ul>

                    </div>
                </nav>
            </div>
        </header>
    );
};

export default Header;
