import { Link, useHistory } from 'react-router-dom';
import { Config } from '../../api/api';
import { useAppDispatch } from '../../app/hooks';
import { setConfig } from './configsSlice';
import styles from './configs.module.scss';

interface ConfigItemProps {
  config: Config;
}

const ConfigItem = ({ config }: ConfigItemProps) => {
  const dispatch = useAppDispatch();
  const history = useHistory();

  function handleClick() {
    dispatch(setConfig(config));
    history.push('/search');
  }

  return (
    <div className={"list-group-item list-group-item-action " + styles.listGroupItem} onClick={handleClick}>
      <h5 className="text-primary">{config.name}</h5>
      <div className="font-italic">{config.description}</div>
    </div>);
};

export default ConfigItem;
