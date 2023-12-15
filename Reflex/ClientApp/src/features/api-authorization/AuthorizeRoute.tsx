// import { Navigate } from 'react-router-dom';
import { Redirect } from 'react-router-dom';
// import { ApplicationPaths, QueryParameterNames } from './ApiAuthorizationConstants';
// import useAuthService from './useAuthService';

interface AuthorizeRouteProps {
  element: JSX.Element;
  path: string;
  requiredRoles?: string[];
}

const AuthorizeRoute = ({ element, path, requiredRoles, exact }: AuthorizeRouteProps) => {
  // const { user, authenticated, ready } = useAuthService();
  const ready = true;
  const authenticated = true;

  if (!ready) {
    return <div />;
  } else {
    // const hasRolepermission = !requiredRoles || requiredRoles.every((x: string) => user?.role?.includes(x));
    const hasRolepermission = !requiredRoles || true;

    if (hasRolepermission) {
      return element;
    } else if (!hasRolepermission) {
      return <h5>Behörighet saknas</h5>;
    }
  }
};

export default AuthorizeRoute;
