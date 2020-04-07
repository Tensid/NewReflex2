import React from 'react';
import { connect } from 'react-redux';
import { Link, useHistory } from 'react-router-dom';
import { Config } from '../../api/api';
import { setConfig } from './configsSlice';

interface ConfigItemProps {
  config: Config;
  setConfig: (config: Config) => void;
}

const ConfigItem = ({ config, setConfig }: ConfigItemProps) => {
  const { push } = useHistory();

  function handleClick() {
    setConfig(config);
    push('/search');
  }

  return (
    <Link to="/search" className="list-group-item list-group-item-action" onClick={handleClick}>
      <div className="font-weight-bold text-primary">{config.name}</div>
      <div className="font-italic">{config.description}</div>
    </Link>);
};

const mapDispatch = { setConfig };

export default connect(
  null,
  mapDispatch
)(ConfigItem);
