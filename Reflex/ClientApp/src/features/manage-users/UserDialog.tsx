import React from 'react';
import OverlayTrigger from 'react-bootstrap/OverlayTrigger';
import Tooltip from 'react-bootstrap/Tooltip';
import { ReflexUser } from '../../api/api';

interface Props {
  users: ReflexUser[];
}

const UserDialog = ({ users }: Props) => {
  const userNames = users.map(user => user.userName).join('\n');
  return (
    <>
      {users.length > 1 ? ' dessa ' : ' denna '}
      <OverlayTrigger overlay={<Tooltip id="id">{userNames}</Tooltip>}>
        <b>användare</b>
      </OverlayTrigger>?
    </>
  );
};

export default UserDialog;
