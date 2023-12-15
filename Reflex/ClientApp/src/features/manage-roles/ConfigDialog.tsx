import { useEffect } from 'react';
import OverlayTrigger from 'react-bootstrap/OverlayTrigger';
import Tooltip from 'react-bootstrap/Tooltip';
import Select from 'react-select';
import { OptionType } from '../../ManageUsers';
import { Config } from '../../api/api';
import { Role } from '../../api/rolesApi';

interface ConfigDialogProps {
  configs: Config[];
  users: Role[];
  setSelectedOptions: (o: OptionType[]) => void;
}

const ConfigDialog = ({ configs, users, setSelectedOptions }: ConfigDialogProps) => {
  console.log("configs", configs);
  console.log("users", users);
  const options = configs.map(({ id: value, name: label }) => ({ value, label }));

  const userNames = users.map(user => user.name).join('\n');
  useEffect(() => {
    setSelectedOptions([]);
  }, [setSelectedOptions]);

  return (
    <>
      {users.length > 1 ? ' dessa ' : ' denna '}
      <OverlayTrigger overlay={<Tooltip id="id">{userNames}</Tooltip>}>
        <b>roller</b>
      </OverlayTrigger>?
      <Select isMulti options={options} closeMenuOnSelect={false} placeholder="Välj..." noOptionsMessage={() => null} onChange={(s: any) => setSelectedOptions(s)} />
    </>
  );
};

export default ConfigDialog;
