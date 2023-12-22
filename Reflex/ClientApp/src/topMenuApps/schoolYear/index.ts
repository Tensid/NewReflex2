import { faAddressBook } from '@fortawesome/pro-solid-svg-icons';
import { SchoolYearSwitcher } from './SchoolYearSwitcher';

export default {
  name: 'sokigo-sbwebb-default-schoolyear-switcher-app',
  title: 'Vega Skolår',
  icon: faAddressBook,
  navbar: {
    component: SchoolYearSwitcher
  }
};