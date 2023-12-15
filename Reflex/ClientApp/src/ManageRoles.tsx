import { ChangeEvent, useEffect, useMemo, useState } from 'react';
import differenceWith from 'lodash/differenceWith';
import isEqual from 'lodash/isEqual';
import unionWith from 'lodash/unionWith';
import Modal from 'react-bootstrap/Modal';
import { CellValue, Row } from 'react-table';
import { Config, getConfigs } from './api/api';
import BadgeCell from './features/manage-roles/BadgeCell';
import ConfigDialog from './features/manage-roles/ConfigDialog';
import Table from './features/manage-roles/Table';
import { Action, options } from './features/manage-roles/constants';
import { Role, getRoles, updateConfigPermissions } from './api/rolesApi';

export type OptionType = {
  value: string;
  label: string;
};

const ManageRoles = () => {
  const [roles, setRoles] = useState<Role[]>([]);
  const [configs, setConfigs] = useState<Config[]>([]);
  const [selectedOptions, setSelectedOptions] = useState<OptionType[]>([]);
  const [select, setSelect] = useState<number>(0);
  const [selectedRows, setSelectedData] = useState<any>([]);
  const [show, setShow] = useState(false);
  const toggleShow = () => setShow(!show);

  useEffect(() => {
    (async () => {
      setRoles(await getRoles());
      setConfigs(await getConfigs());
    })();
  }, []);

  const columns = useMemo(
    () => [
      {
        Header: 'Roll',
        accessor: 'name'
      },
      {
        Header: 'Har behörighet till',
        accessor: (originalRow: Role) => originalRow.configPermissions.map((x) => x.name),
        Cell: ({ cell: { value } }: CellValue) => <BadgeCell values={value} cutOff={4} />
      }
    ],
    []
  );

  const onSelectedRows = (rows: Row[]) => {
    const mappedRows = rows.map((r) => r.original);
    setSelectedData(mappedRows);
  };

  const handleConfigsClick = async (selectedOptions: OptionType[]) => {
    if (!selectedOptions)
      selectedOptions = [];

    const configPermissions = selectedOptions.map(({ value: id, label: name }) => ({
      id,
      name
    }));

    const newData = selectedRows.map((role: Role) => {
      return { roleId: role.id, configPermissions: configPermissions };
    });

    await updateConfigPermissions(newData);
    setRoles(await getRoles());
  };

  const handleDeleteConfigsClick = async (selectedOptions: OptionType[]) => {
    const selectedPermissions = selectedOptions.map(({ value: id, label: name }) => ({
      id,
      name
    }));
    const newData = selectedRows.map((role: Role) => {
      return { roleId: role.id, configPermissions: differenceWith(role.configPermissions, selectedPermissions, isEqual) };
    });

    await updateConfigPermissions(newData);
    setRoles(await getRoles());
  };

  const handleAddConfigsClick = async (selectedOptions: OptionType[]) => {
    const selectedPermissions = selectedOptions.map(({ value: id, label: name }) => ({
      id,
      name
    }));

    const newData = selectedRows.map((role: Role) => {
      return { roleId: role.id, configPermissions: unionWith(role.configPermissions, selectedPermissions, isEqual) };
    });

    await updateConfigPermissions(newData);
    setRoles(await getRoles());
  };

  function confirmHandler(action: Action) {
    switch (action) {
      case Action.AddConfig:
        return handleAddConfigsClick(selectedOptions);
      case Action.DeleteConfig:
        return handleDeleteConfigsClick(selectedOptions);
      case Action.SetConfig:
        return handleConfigsClick(selectedOptions);
      default:
        return;
    }
  }

  return (
    <>
      <h4>Hantera roller</h4>
      <div className="d-flex align-items-center float-end mb-1">
        <select value={select} className="mr-1" onChange={(evt: ChangeEvent<HTMLSelectElement>) => setSelect(Number(evt.target.value))}>
          {options.map((option) => <option key={option.action} value={option.action}>{option.actionText}</option>
          )}
        </select>
        <button className="btn btn-primary" title="Utför handling" onClick={toggleShow}
          disabled={!(Array.isArray(selectedRows) && selectedRows.length)}>
          Utför
        </button>
      </div>
      <Table onSelectedRows={onSelectedRows} columns={columns} data={roles} />
      <Modal show={show} onHide={toggleShow}>
        <Modal.Header closeButton>
          <Modal.Title>{options[select].actionText} ({selectedRows.length} roller)</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {options[select].modalBody}{selectedRows.configName}
          {(options[select].action === 0 || options[select].action === 1 || options[select].action === 2) &&
            <ConfigDialog users={selectedRows} configs={configs} setSelectedOptions={setSelectedOptions} />}
        </Modal.Body>
        <Modal.Footer>
          <button className="btn btn-primary" onClick={toggleShow}>{options[select].cancel}</button> {' '}
          <button className="btn btn-danger" onClick={() => { confirmHandler(options[select].action); toggleShow(); }}>
            {options[select].confirm}
          </button>
        </Modal.Footer>
      </Modal>
    </>
  );
};

export default ManageRoles;
