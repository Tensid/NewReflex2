import { faLock } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

interface LockProps {
  show: boolean;
  title: string;
}
export default function Lock({ show, title }: LockProps) {
  return (show ? <>{' '}<FontAwesomeIcon title={title} icon={faLock} /></> : null);
}
