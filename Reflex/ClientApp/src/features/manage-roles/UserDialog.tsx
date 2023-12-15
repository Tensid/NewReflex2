import React from 'react';
import { OverlayTrigger, Tooltip } from 'react-bootstrap';
import { Role } from '../../api/rolesApi';

interface Props {
  users: Role[];
}

const UserDialog = ({ users }: Props) => {
  const userNames = users.map(user => user.name).join('\n');
  return (
    <>
      {users.length > 1 ? ' dessa ' : ' denna '}
      <OverlayTrigger overlay={<Tooltip id="id">{userNames}</Tooltip>}>
        <b>roller</b>
      </OverlayTrigger>?
    </>
  );
};

export default UserDialog;
