import React, { useEffect, useState } from 'react';
import { Config, getConfigs } from './api/api';
import ConfigList from './features/configs/ConfigList';

const Configs = () => {
  const [configs, setConfigs] = useState<Config[]>([]);

  useEffect(() => {
    (async () => {
      setConfigs(await getConfigs());
    })();
  }, []);

  return (
    <>
      <h5>Välj konfiguration</h5>
      {configs && <ConfigList configs={configs} />}
    </>
  );
};

export default Configs;
