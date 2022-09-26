import axios from 'axios';
import { Extent } from 'ol/extent';
import authService from '../features/api-authorization/AuthorizeService';

export interface MapSettings {
  extent: Extent;
  projection: string;
}

const instance = axios.create({
  baseURL: 'api'
});

instance.interceptors.request.use(
  async (config) => {
    const token = await authService.getAccessToken();
    if (token && config.headers) {
      config.headers['Authorization'] = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);

export async function getMapSettings() {
  const { data } = await instance.get<MapSettings>('mapSettings');
  return data;
}

export async function getLayersSettings() {
  const { data } = await instance.get<any>('mapSettings/layers');
  return data;
}
