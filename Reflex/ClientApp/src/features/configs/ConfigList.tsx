import React from 'react';
import { Config } from '../../api/api';
import ConfigItem from './ConfigItem';

interface ConfigListProps {
  configs: Config[];
}

const ConfigList = ({ configs }: ConfigListProps) => {
  return (
    <div className="list-group" style={{ border: "0", padding: "0" }}>
      {configs.map((cfg: Config) => <ConfigItem key={cfg.id} config={cfg}></ConfigItem>)}
    </div>
  );
};

export default ConfigList;
