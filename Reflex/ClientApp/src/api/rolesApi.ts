import axios from 'axios';
// import { FbWebbSettings, MiscSettings } from '.';
// import authService from '../../features/api-authorization/AuthorizeService';

export interface ApplicationRole {
  id: string;
  name: string;
  enabled: boolean;
}

export interface Role extends ApplicationRole {
  configPermissions: ConfigPermission[];
}

export interface ConfigPermission {
  id: string;
  name: string;
}


export interface UpdateConfigPermissionsRequest {
  roleId: string;
  configPermissions: ConfigPermission[];
}

const instance = axios.create({
  baseURL: 'api'
});

instance.interceptors.request.use(
  async (config) => {
    // const token = await authService.getAccessToken();
    // if (token && config.headers) {
    //   config.headers['Authorization'] = `Bearer ${token}`;
    // }
    return config;
  },
  (error) => Promise.reject(error)
);

export async function getRoles() {
  const url = `roles`;
  const { data } = await instance.get<any>(url);
  return data;
}

export async function updateConfigPermissions(requests: UpdateConfigPermissionsRequest[]) {
  return await instance.put('roles/configPermissions', requests);
}
