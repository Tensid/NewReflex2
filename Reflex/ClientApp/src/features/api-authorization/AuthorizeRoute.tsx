import { Navigate } from 'react-router-dom';
import { ApplicationPaths, QueryParameterNames } from './ApiAuthorizationConstants';
import useAuthService from './useAuthService';

interface AuthorizeRouteProps {
  element: JSX.Element;
  path: string;
  requiredRoles?: string[];
}

const AuthorizeRoute = ({ element, path, requiredRoles }: AuthorizeRouteProps) => {
  const { user, authenticated, ready } = useAuthService();

  var link = document.createElement("a");
  link.href = path;
  const returnUrl = `${link.protocol}//${link.host}${link.pathname}${link.search}${link.hash}`;
  const redirectUrl = `${ApplicationPaths.Login}?${QueryParameterNames.ReturnUrl}=${encodeURIComponent(returnUrl)}`;

  if (!ready) {
    return <div />;
  } else {
    const hasRolepermission = !requiredRoles || requiredRoles.every((x: string) => user?.role?.includes(x));

    if (authenticated && hasRolepermission) {
      return element;
    } else if (authenticated && !hasRolepermission) {
      return <h5>Behörighet saknas</h5>;
    }
    else {
      return <Navigate to={redirectUrl} />;
    }
  }
};

export default AuthorizeRoute;
