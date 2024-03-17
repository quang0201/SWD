import React from 'react';
import { Link } from 'react-router-dom';

const Header: React.FC = () => {
    return (
        <footer>
            <p>Desgin by Quang</p>
            <p>Quang's website copyright @2024</p>
            <Link to="https://www.facebook.com/">Connect Me</Link>
        </footer>
    );
};
export default Header;
