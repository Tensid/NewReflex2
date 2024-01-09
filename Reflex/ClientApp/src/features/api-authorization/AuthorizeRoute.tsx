import { useHasPermissions } from '../../hooks/useHasPermissions';
import { Permissions } from '../../settings/permissions';
// import Permissions from ''

interface AuthorizeRouteProps {
  element: JSX.Element;
  path: string;
  requiredPermissions?: Permissions[];
}

const AuthorizeRoute = ({ element, requiredPermissions }: AuthorizeRouteProps) => {
  const hasPermission = useHasPermissions(...(requiredPermissions || []));

  // const hasRolepermission = !requiredRoles || requiredRoles.every((x: string) => user?.role?.includes(x));
  //const hasRolepermission = !requiredPermissions || hasPermission;
  console.log("requiredPermissions", requiredPermissions);
  console.log("hasPermission", hasPermission);

  if (hasPermission) {
    return element;
  } else if (!hasPermission) {
    return <h5>Behörighet saknas</h5>;
  }
};

export default AuthorizeRoute;
