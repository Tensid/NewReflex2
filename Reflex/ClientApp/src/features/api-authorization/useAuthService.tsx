import { useEffect, useState } from 'react';
import authService from './AuthorizeService';

async function populateState(setAuthenticated: (authenticated: boolean) => void, setUser: (user: any) => void, setReady: (ready: boolean) => void) {
  setReady(false);
  const [user] = await Promise.all([authService.getUser()]);
  const authenticated = !!user;
  setAuthenticated(authenticated);
  setUser(user);
  setReady(true);
}

function useAuthService() {
  const [authenticated, setAuthenticated] = useState(false);
  const [user, setUser] = useState<any>();
  const [ready, setReady] = useState(false);

  useEffect(() => {
    const subscription = authService.subscribe(() => populateState(setAuthenticated, setUser, setReady));
    populateState(setAuthenticated, setUser, setReady);

    return () => {
      authService.unsubscribe(subscription);
    };
  }, []);

  return { authenticated, user, setAuthenticated, ready };
}

export default useAuthService;
