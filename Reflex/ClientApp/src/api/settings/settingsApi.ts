import axios from 'axios';
import { FbWebbSettings, MiscSettings } from '.';
import authService from '../../features/api-authorization/AuthorizeService';

const instance = axios.create({
  baseURL: 'api'
});

instance.interceptors.request.use(
  async (config) => {
    const token = await authService.getAccessToken();
    if (token) {
      config.headers['Authorization'] = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);

export async function getFbWebbSettings() {
  const url = `systemsettings/fb-webb`;
  const { data } = await instance.get<FbWebbSettings>(url);
  return data;
}

export async function getFbSettings() {
  const url = `systemsettings/fb`;
  const { data } = await instance.get<any>(url);
  return data;
}

export async function updateFbSettings(settings: any) {
  const url = `systemsettings/fb`;
  const { data } = await instance.put<any>(url, settings);
  return data;
}

export async function getMiscSettings() {
  const url = `systemsettings/misc`;
  const { data } = await instance.get<MiscSettings>(url);
  return data;
}

export async function updateMiscSettings(settings: MiscSettings) {
  const url = `systemsettings/misc`;
  const { data } = await instance.put<MiscSettings>(url, settings);
  return data;
}

export async function getAgsSettings() {
  const url = `systemsettings/ags`;
  const { data } = await instance.get<any>(url);
  return data;
}

export async function updateAgsSettings(agsSettings: any) {
  const url = `systemsettings/ags`;
  const { data } = await instance.put<any>(url, agsSettings);
  return data;
}

export async function getByggrSettings() {
  const url = `systemsettings/byggr`;
  const { data } = await instance.get<any>(url);
  return data;
}

export async function updateByggrSettings(byggrSettings: any) {
  const url = `systemsettings/byggr`;
  const { data } = await instance.put<any>(url, byggrSettings);
  return data;
}

export async function getEcosSettings() {
  const url = `systemsettings/ecos`;
  const { data } = await instance.get<any>(url);
  return data;
}

export async function updateEcosSettings(ecosSettings: any) {
  const url = `systemsettings/ecos`;
  const { data } = await instance.put<any>(url, ecosSettings);
  return data;
}
