import { Link } from 'react-router-dom';
import { useAppSelector } from './app/hooks';

const Footer = () => {
  const name = useAppSelector((state) => state?.config?.name);
  const description = useAppSelector((state) => state?.config?.description ? ' - ' + state?.config?.description : '');

  return (
    <div className="fixed-bottom bg-primary text-white flex-shrink-0">
      {name ? name + description : 'Konfiguration ej vald'}
      <Link to={'/about'} onClick={(e) => e.stopPropagation()}>
        <span className="float-right text-white">Om Reflex</span>
      </Link>
    </div>
  );
};

export default Footer;
