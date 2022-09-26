import { Link, useNavigate } from 'react-router-dom';
import { Config } from '../../api/api';
import { useAppDispatch } from '../../app/hooks';
import { setConfig } from './configsSlice';

interface ConfigItemProps {
  config: Config;
}

const ConfigItem = ({ config }: ConfigItemProps) => {
  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  function handleClick() {
    dispatch(setConfig(config));
    navigate('/search');
  }

  return (
    <Link to="/search" className="list-group-item list-group-item-action" onClick={handleClick}>
      <div className="fw-bold text-primary">{config.name}</div>
      <div className="font-italic">{config.description}</div>
    </Link>);
};

export default ConfigItem;
