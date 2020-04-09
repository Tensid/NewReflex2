import React, { ChangeEvent, useEffect, useMemo, useState } from 'react';
import * as _ from 'lodash';
import Modal from 'react-bootstrap/Modal';
import { CellValue, Row } from 'react-table';
import { Config, ReflexUser, deleteUsers, getConfigs, getUsers, updateConfigPermissions, updateRoles } from './api/api';
import BadgeCell from './features/manage-users/BadgeCell';
import ConfigDialog from './features/manage-users/ConfigDialog';
import Table from './features/manage-users/Table';
import UserDialog from './features/manage-users/UserDialog';
import { Action, options } from './features/manage-users/constants';

export type OptionType = {
  value: string;
  label: string;
};

const ManageUsers = () => {
  const [users, setUsers] = useState<ReflexUser[]>([]);
  const [configs, setConfigs] = useState<Config[]>([]);
  const [selectedOptions, setSelectedOptions] = useState<OptionType[]>([]);
  const [select, setSelect] = useState<number>(0);
  const [selectedRows, setSelectedData] = useState<any>([]);
  const [show, setShow] = useState(false);
  const toggleShow = () => setShow(!show);

  useEffect(() => {
    (async () => {
      setUsers(await getUsers());
      setConfigs(await getConfigs());
    })();
  }, []);

  const columns = useMemo(
    () => [
      {
        Header: 'Användarnamn',
        accessor: 'userName'
      },
      {
        Header: 'Bekräftad',
        accessor: (originalRow: ReflexUser) => originalRow.isEmailConfirmed ? 'Ja' : 'Nej'
      },
      {
        Header: 'Roll',
        accessor: (originalRow: ReflexUser) =>
          originalRow.roles.map((role: string) => {
            switch (role) {
              case 'Admin':
                return 'Administratör';
              case 'User':
                return 'Användare';
              default:
                return role;
            }
          }),
        Cell: ({ cell: { value } }: CellValue) => value.join(', ')
      },
      {
        Header: 'Har behörighet till',
        accessor: (originalRow: ReflexUser) => originalRow.configPermissions.map((x) => x.name),
        Cell: ({ cell: { value } }: CellValue) => <BadgeCell values={value} cutOff={4} />
      }
    ],
    []
  );

  const onSelectedRows = (rows: Row[]) => {
    const mappedRows = rows.map((r) => r.original);
    setSelectedData(mappedRows);
  };

  const handleDeleteUsersClick = async () => {
    const ids = selectedRows.map((x: any) => x.id);
    await deleteUsers(ids);
    setUsers(await getUsers());
  };

  const handleRolesClick = async (roles: string[]) => {
    const newRoles = selectedRows.map((user: ReflexUser) => {
      return { userId: user.id, roles: roles };
    });


    await updateRoles(newRoles);
    const data = await getUsers();
    setUsers(data);
  };

  const handleConfigsClick = async (selectedOptions: OptionType[]) => {
    if (!selectedOptions)
      selectedOptions = [];

    const configPermissions = selectedOptions.map(({ value: id, label: name }) => ({
      id,
      name
    }));

    const newData = selectedRows.map((user: ReflexUser) => {
      return { userId: user.id, configPermissions: configPermissions };
    });

    await updateConfigPermissions(newData);
    setUsers(await getUsers());
  };

  const handleDeleteConfigsClick = async (selectedOptions: OptionType[]) => {
    const selectedPermissions = selectedOptions.map(({ value: id, label: name }) => ({
      id,
      name
    }));
    const newData = selectedRows.map((user: ReflexUser) => {
      return { userId: user.id, configPermissions: _.differenceWith(user.configPermissions, selectedPermissions, _.isEqual) };
    });

    await updateConfigPermissions(newData);
    setUsers(await getUsers());
  };

  const handleAddConfigsClick = async (selectedOptions: OptionType[]) => {
    const selectedPermissions = selectedOptions.map(({ value: id, label: name }) => ({
      id,
      name
    }));

    const newData = selectedRows.map((user: ReflexUser) => {
      return { userId: user.id, configPermissions: _.unionWith(user.configPermissions, selectedPermissions, _.isEqual) };
    });

    await updateConfigPermissions(newData);
    setUsers(await getUsers());
  };

  function confirmHandler(action: Action) {
    switch (action) {
      case Action.AddConfig:
        return handleAddConfigsClick(selectedOptions);
      case Action.DeleteConfig:
        return handleDeleteConfigsClick(selectedOptions);
      case Action.SetConfig:
        return handleConfigsClick(selectedOptions);
      case Action.MakeAdmin:
        return handleRolesClick(['Admin']);
      case Action.MakeUser:
        return handleRolesClick(['User']);
      case Action.DeleteUser:
        return handleDeleteUsersClick();
      default:
        return;
    }
  }

  return (
    <>
      <h4>Hantera användare</h4>
      <div className="form-row float-right mb-1">
        <select value={select} className="mr-1" onChange={(evt: ChangeEvent<HTMLSelectElement>) => setSelect(Number(evt.target.value))}>
          {options.map((option) => <option key={option.action} value={option.action}>{option.actionText}</option>
          )}
        </select>
        <button className="btn btn-primary" title="Utför handling" onClick={toggleShow}
          disabled={!(Array.isArray(selectedRows) && selectedRows.length)}>
          Utför
        </button>
      </div>
      <Table onSelectedRows={onSelectedRows} columns={columns} data={users} />
      <Modal show={show} onHide={toggleShow}>
        <Modal.Header closeButton>
          <Modal.Title>{options[select].actionText} ({selectedRows.length} användare)</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {options[select].modalBody}{selectedRows.configName}
          {(options[select].action === 0 || options[select].action === 1 || options[select].action === 2) &&
            <ConfigDialog users={selectedRows} configs={configs} setSelectedOptions={setSelectedOptions} />}
          {(options[select].action === 3 || options[select].action === 4 || options[select].action === 5) &&
            <UserDialog users={selectedRows} />}
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

export default ManageUsers;
