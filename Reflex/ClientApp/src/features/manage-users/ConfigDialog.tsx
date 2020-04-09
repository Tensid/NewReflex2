import React, { useEffect } from 'react';
import OverlayTrigger from 'react-bootstrap/OverlayTrigger';
import Tooltip from 'react-bootstrap/Tooltip';
import Select from 'react-select';
import { OptionType } from '../../ManageUsers';
import { Config, ReflexUser } from '../../api/api';

interface ConfigDialogProps {
  configs: Config[];
  users: ReflexUser[];
  setSelectedOptions: (o: OptionType[]) => void;
}

const ConfigDialog = ({ configs, users, setSelectedOptions }: ConfigDialogProps) => {
  const options = configs.map(({ id: value, name: label }) => ({ value, label }));

  const userNames = users.map(user => user.userName).join('\n');
  useEffect(() => {
    setSelectedOptions([]);
  }, [setSelectedOptions]);

  return (
    <>
      {users.length > 1 ? ' dessa ' : ' denna '}
      <OverlayTrigger overlay={<Tooltip id="id">{userNames}</Tooltip>}>
        <b>användare</b>
      </OverlayTrigger>?
      <Select isMulti options={options} closeMenuOnSelect={false} placeholder="Välj..." noOptionsMessage={() => null} onChange={(s: any) => setSelectedOptions(s)} />
    </>
  );
};

export default ConfigDialog;
