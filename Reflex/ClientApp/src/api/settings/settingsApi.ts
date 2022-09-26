import axios from 'axios';
import { AgsSettings, ByggrSettings, EcosSettings, FbSettings, FbWebbSettings, IipaxSettings, MiscSettings } from '.';
import authService from '../../features/api-authorization/AuthorizeService';

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

export async function getFbWebbSettings() {
  const url = `systemsettings/fb-webb`;
  const { data } = await instance.get<FbWebbSettings>(url);
  return data;
}

export async function getFbSettings() {
  const url = `systemsettings/fb`;
  const { data } = await instance.get<FbSettings>(url);
  return data;
}

export async function updateFbSettings(settings: FbSettings) {
  const url = `systemsettings/fb`;
  const { data } = await instance.put<FbSettings>(url, settings);
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
  const { data } = await instance.get<AgsSettings>(url);
  return data;
}

export async function updateAgsSettings(agsSettings: AgsSettings) {
  const url = `systemsettings/ags`;
  const { data } = await instance.put<AgsSettings>(url, agsSettings);
  return data;
}

export async function getByggrSettings() {
  const url = `systemsettings/byggr`;
  const { data } = await instance.get<ByggrSettings>(url);
  return data;
}

export async function updateByggrSettings(byggrSettings: ByggrSettings) {
  const url = `systemsettings/byggr`;
  const { data } = await instance.put<ByggrSettings>(url, byggrSettings);
  return data;
}

export async function getEcosSettings() {
  const url = `systemsettings/ecos`;
  const { data } = await instance.get<EcosSettings>(url);
  return data;
}

export async function updateEcosSettings(ecosSettings: EcosSettings) {
  const url = `systemsettings/ecos`;
  const { data } = await instance.put<EcosSettings>(url, ecosSettings);
  return data;
}

export async function getIipaxSettings() {
  const url = `systemsettings/iipax`;
  const { data } = await instance.get<IipaxSettings>(url);
  return data;
}

export async function updateIipaxSettings(iipaxSettings: IipaxSettings) {
  const url = `systemsettings/iipax`;
  const { data } = await instance.put<IipaxSettings>(url, iipaxSettings);
  return data;
}
