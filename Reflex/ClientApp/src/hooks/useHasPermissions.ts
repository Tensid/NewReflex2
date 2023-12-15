import { useApplicationPermissions } from '@sokigo-sbwebb/application-services';
import { Permissions } from '../settings';

export const useHasPermissions = (
  ...permissions: Permissions[]
): boolean[] => {
  const { hasPermission } = useApplicationPermissions();
  return permissions.map((permission) => hasPermission(permission));
};