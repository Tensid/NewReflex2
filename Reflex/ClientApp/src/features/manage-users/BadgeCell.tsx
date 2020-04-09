import React from 'react';
import OverlayTrigger from 'react-bootstrap/OverlayTrigger';
import Tooltip from 'react-bootstrap/Tooltip';

interface Props {
  values: string[];
  cutOff: number;
}

const BadgeCell = ({ values, cutOff }: Props) => {
  const visbleValues = values.slice(0, cutOff).join(', ');
  const remainingValues = values.slice(cutOff, values.length).join(', ');
  return (
    <>
      {visbleValues}
      {values.length > cutOff &&
        <OverlayTrigger overlay={<Tooltip id="id">{remainingValues}</Tooltip>}>
          <span className="badge badge-secondary badge-pill mx-2">+{values.length - cutOff}</span>
        </OverlayTrigger>
      }
    </>);
};

export default BadgeCell;
