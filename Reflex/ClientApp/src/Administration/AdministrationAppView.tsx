import { Route, Switch } from 'react-router-dom';
import { useProvideNavbarSubItems } from '@sokigo-sbwebb/default-core';
import { ApplicationView } from '@sokigo-sbwebb/default-components';
import { useApplications } from '@sokigo-sbwebb/application-services';
import { AdministrationMainView } from './features/administration/AdministrationMainView';
// import { ErrorBoundary } from '../Skolskjuts/features/errorHandling/ErrorBoundary';
import ApplicationLayout from './ApplicationLayout';
import ManageSystemSettings from './ManageSystemSettings';
import ManageRoles from './ManageRoles';
import ManageConfigs from './ManageConfigs';

export function AdministrationAppView({ match: { url } }: any) {
  const apps = useApplications();
  const { hasPermission } = apps.find((x: any) => x.name === 'sokigo-sbwebb-reflex-reflexapp');
  // const isAdministrator: boolean = hasPermission('IsAdministrator');
  // const isAdmin: boolean = hasPermission('IsAdmin');
  const isAdministrator: boolean = hasPermission('IsAdmin');
  console.log("url", url);

  useProvideNavbarSubItems(isAdministrator && [
    { label: 'Hantera konfigurationer', to: url + '/manage-configs' },
    { label: 'Hantera roller', to: url + '/manage-roles' },
    { label: 'Systeminställningar', to: url + '/system-settings' }
  ]);
  console.log("AdministrationAppView");
  // console.log("isAdmin", isAdmin);
  // console.log("isAdministrator", isAdministrator);


  return (
    <ApplicationView role='main'>
      {/* <ErrorBoundary> */}
      <ApplicationLayout>
        {isAdministrator
          ? (
            <Switch>
              <Route
                path={url + '/manage-configs'}
                component={ManageConfigs}
              />
              <Route
                path={url + '/manage-roles'}
                component={ManageRoles}
              />
              <Route
                path={url + '/system-settings'}
                component={ManageSystemSettings}
              />
              <Route component={AdministrationMainView} />
            </Switch>
          ) : 'Aministratörsrättigheter saknas'}
      </ApplicationLayout>
      {/* </ErrorBoundary> */}
    </ApplicationView>
  );
}
export default AdministrationAppView;