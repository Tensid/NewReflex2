import axios from 'axios';

let configId: string;

export function setConfigId(id: string) {
  configId = id;
}

export enum CaseSource {
  AGS = 'AGS',
  ByggR = 'ByggR',
  Ecos = 'Ecos'
}

export enum Tab {
  Search = 'Search',
  Map = 'Map',
  Cases = 'Cases',
  Population = 'Population',
  Property = 'Property'
}

export interface Case {
  caseId: string;
  dnr: string;
  title: string;
  caseSource: CaseSource;
  date: string;
  unavailableDueToSecrecy: boolean;
  status: string;
  arendegrupp: string;
  arendetyp: string;
  arendeslag: string;
  fastighetsbeteckning: string;
  kommun: string;
  beskrivning: string;
  handlaggareEfternamn: string;
  handlaggareFornamn: string;
  handlaggareSignatur: string;
}

export interface SearchResult {
  addressName?: string;
  estateId?: string;
  estateName: string;
}

export interface Config {
  id: string;
  name: string;
  description: string;
  map: string;
  visible: boolean;
  tabs: Tab[];
  caseSources: CaseSource[];
  fbWebbBoendeUrl?: string;
  fbWebbLagenhetUrl?: string;
  fbWebbFastighetUrl?: string;
  fbWebbFastighetUsrUrl?: string;
  fbWebbByggnadUrl?: string;
  fbWebbByggnadUsrUrl?: string;
  csmUrl?: string;
}

export interface ReflexUser {
  id: string;
  userName: string;
  roles: string[];
  configPermissions: ConfigPermission[];
  isEmailConfirmed: boolean;
}

export interface ConfigPermission {
  id: string;
  name: string;
}

export interface UpdateConfigPermissionsRequest {
  userId: string;
  configPermissions: ConfigPermission[];
}

export interface UpdateRolesRequest {
  userId: string;
  roles: string[];
}

export async function getCases(estateId: string) {
  let url = `api/cases/${estateId}`;
  if (configId) {
    url = `${url}?configId=${configId}`;
  }
  const { data } = await axios.get<Case[]>(url);
  return data;
}

export async function getConfigs() {
  const { data } = await axios.get<Config[]>('api/configs');
  return data;
}

export async function getUsers() {
  const { data } = await axios.get<ReflexUser[]>('api/users');
  return data;
}

export async function deleteUsers(ids: string[]) {
  return await axios.delete('api/users', { data: ids });
}

export async function updateRoles(requests: UpdateRolesRequest[]) {
  return await axios.put('api/users/roles', requests);
}

export async function updateConfigPermissions(requests: UpdateConfigPermissionsRequest[]) {
  return await axios.put('api/users/configPermissions', requests);
}
