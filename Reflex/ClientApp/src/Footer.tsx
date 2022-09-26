import { useAppSelector } from './app/hooks';

const Footer = () => {
  const name = useAppSelector((state) => state?.config?.name);
  const description = useAppSelector((state) => state?.config?.description ? ' - ' + state?.config?.description : '');

  return (
    <div className="fixed-bottom bg-brand text-white flex-shrink-0">
      {name ? name + description : 'Konfiguration ej vald'}
      <span className="float-end">Sokigo</span>
    </div>
  );
};

export default Footer;
