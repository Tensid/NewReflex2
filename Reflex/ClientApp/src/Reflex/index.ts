import '@sokigo/design-system-bootstrap/index.css';
import { lazyComponent } from '@sokigo-sbwebb/react';
import { faHome } from '@fortawesome/pro-solid-svg-icons';
import { permissions } from '../settings';
// import { settings, permissions } from './settings';
// import { SkolskjutsSettings } from './SkolskjutsSettings';

export const settings = {
  // mainRoute: '//',
  mainRoute: '/reflex',
  title: 'Reflex',
  appName: 'sokigo-sbwebb-reflex-reflexapp'
};

export default {
  name: settings.appName,
  title: 'Reflex',
  navbar: { title: 'Hem' },
  route: settings.mainRoute,
  icon: faHome,
  // fullscreen: true,
  permissions,
  settings: settings,
  view: lazyComponent(() => import('../App'))
};