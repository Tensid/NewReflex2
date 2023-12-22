import { LinkButton } from '@sokigo-sbwebb/default-components';

export function AdministrationMainView({ match: { url } }) {
  return (
    <div className="d-flex justify-content-center">
      <LinkButton
        to={url + '/manage-configs'}
        color="primary"
        inline
        className="mr-1"
      >
        Hantera konfigurationer
      </LinkButton>
      <LinkButton
        to={url + '/manage-roles'}
        color="primary"
        inline
        className="mr-1"
      >
        Hantera roller
      </LinkButton>
      <LinkButton
        to={url + '/system-settings'}
        color="primary"
        inline
        className="mr-1"
      >
        Systeminställningar
      </LinkButton>
    </div>
  );
}