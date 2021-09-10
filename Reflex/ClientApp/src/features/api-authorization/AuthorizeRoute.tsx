import React from 'react';
import { Redirect, Route } from 'react-router-dom';
import { ApplicationPaths, QueryParameterNames } from './ApiAuthorizationConstants';
import useAuthService from './useAuthService';

const AuthorizeRoute = (props: any) => {
  const { user, authenticated, ready } = useAuthService();

  var link = document.createElement("a");
  link.href = props.path;
  const returnUrl = `${link.protocol}//${link.host}${link.pathname}${link.search}${link.hash}`;
  const redirectUrl = `${ApplicationPaths.Login}?${QueryParameterNames.ReturnUrl}=${encodeURIComponent(returnUrl)}`;

  if (!ready) {
    return <div></div>;
  } else {
    const { component: Component, requiredRoles, ...rest } = props;
    const hasRolepermission = !requiredRoles || requiredRoles.every((x: string) => user?.role?.includes(x));
    return <Route {...rest}
      render={(props: any) => {
        if (authenticated && hasRolepermission) {
          return <Component {...props} />;
        } else if (authenticated && !hasRolepermission) {
          return <h5>Behörighet saknas</h5>;
        }
        else {
          return <Redirect to={redirectUrl} />;
        }
      }} />;
  }
};

export default AuthorizeRoute;
