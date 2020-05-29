import axios from 'axios';
import authService from '../features/api-authorization/AuthorizeService';

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

export interface Occurence {
  title: string;
  arrival: string;
  documents: Document[];
  isSecret: boolean;
}

export interface Handelse extends Occurence {
  anteckning: string;
  beslutsText: string;
  beslutNr: string;
  handelsetyp: string;
}

export interface Preview {
  caseId: string;
  dnr: string;
  persons: CasePerson[];
  handelser: Handelse[];
  status: string;
  arendegrupp: string;
  arendetyp: string;
  arendeslag: string;
  fastighetsbeteckning: string;
  handlaggareEfternamn: string;
  handlaggareFornamn: string;
  handlaggareSignatur: string;
}

export interface Document {
  docLinkId: string;
  title: string;
}

export interface CasePerson {
  fullName: string;
  roles: string[];
  communication: string[];
  adress: string;
  ort: string;
  postNr: string;
}

export interface ArchivedDocument {
  title: string;
  physicalDocumentId: string;
}

export type Type = 'Adress' | 'Fastighet' | 'Ärende';

export interface SearchResult {
  value?: string;
  addressName?: string;
  estateId?: string;
  displayName: string;
  estateName: string;
  source?: CaseSource | 'FB';
  type?: Type;
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

export interface UserSettings {
  defaultTab: Tab;
}

export async function search(query: string) {
  let url = `api/search?query=${query}`;
  if (configId) {
    url = `${url}&configId=${configId}`;
  }
  const { data } = await axios.get<SearchResult[]>(url);
  return data;
}

export async function getCases(estateId: string) {
  let url = `api/cases/${estateId}`;
  if (configId) {
    url = `${url}?configId=${configId}`;
  }
  const { data } = await axios.get<Case[]>(url);
  return data;
}

export async function getCase(id: string, caseSource: CaseSource) {
  let url = `api/cases?id=${id}&caseSource=${caseSource}`;
  if (configId) {
    url = `${url}&configId=${configId}`;
  }
  const { data } = await axios.get<Case[]>(url);
  return data;
}

export async function getConfigs() {
  const { data } = await axios.get<Config[]>('api/configs');
  return data;
}

export async function getFnrFromPosition(lat: string, lon: string, srid: number, distance: number) {
  const url = `api/map/fnr?lat=${lat}&lon=${lon}&srid=${srid}&distance=${distance}`;
  const { data } = await axios.get<string>(url);
  return data;
}

export async function getGeometryFromFnr(fnr: number) {
  const url = `api/map/geometry?fnr=${fnr}`;
  const { data } = await axios.get(url);
  return data;
}

export async function getEstateName(fnr: number) {
  const url = `api/map/estateName?fnr=${fnr}`;
  const { data } = await axios.get<string>(url);
  return data;
}

export async function getEstatePosition(fnr: number) {
  const url = `api/map/estatePosition?fnr=${fnr}`;
  const { data } = await axios.get(url);
  return data;
}

export async function getMapSettings() {
  const { data } = await axios.get('api/mapSettings');
  return data;
}

export async function getOccurences(caseId: string, caseSource: string) {
  let url = `api/cases/${caseId}/occurences?caseSource=${caseSource}`;
  if (configId) {
    url = `${url}&configId=${configId}`;
  }
  const { data } = await axios.get<Occurence[]>(url);
  return data;
}

export async function getPreview(caseId: string, caseSource: CaseSource) {
  let url = `api/cases/${caseId}/preview?caseSource=${caseSource}`;
  if (configId) {
    url = `${url}&configId=${configId}`;
  }
  const { data } = await axios.get<Preview>(url);
  return data;
}

export async function getCasePersons(caseId: string, caseSource: CaseSource) {
  let url = `api/cases/${caseId}/persons?caseSource=${caseSource}`;
  if (configId) {
    url = `${url}&configId=${configId}`;
  }
  const { data } = await axios.get<CasePerson[]>(url);
  return data;
}

export async function getArchivedDocuments(caseId: string, caseSource: CaseSource) {
  let url = `api/cases/${caseId}/archivedDocuments?caseSource=${caseSource}`;
  if (configId) {
    url = `${url}?configId=${configId}`;
  }
  const { data } = await axios.get<ArchivedDocument[]>(url);
  return data;
}

export async function getUserSettings() {
  const url = `api/userSettings`;
  const token = await authService.getAccessToken();
  const { data } = await axios.get<UserSettings>(url, {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  });
  return data;
}

export async function updateUserSettings(userSettings: UserSettings) {
  const url = `api/userSettings`;
  const token = await authService.getAccessToken();

  const { data } = await axios.put<UserSettings>(url, userSettings, {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  });
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
