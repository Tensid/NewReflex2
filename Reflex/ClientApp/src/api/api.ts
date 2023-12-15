import axios from 'axios';
// import authService from '../features/api-authorization/AuthorizeService';

const instance = axios.create({
  baseURL: 'api'
});

instance.interceptors.request.use(
  async (config) => {
    // const token = await authService.getAccessToken();
    // if (token && config.headers) {
    //   config.headers['Authorization']! = `Bearer ${token}`;
    // }
    return config;
  },
  (error) => Promise.reject(error)
);

let configId: string;

export function setConfigId(id: string) {
  configId = id;
}

export enum CaseSource {
  AGS = 'AGS',
  ByggR = 'ByggR',
  Ecos = 'Ecos',
  iipax = 'iipax'
}

export type CaseTab = 'Preview' | 'Occurences' | 'Persons' | 'Archive';

export enum Tab {
  Search = 'Search',
  Map = 'Map',
  Cases = 'Cases',
  Population = 'Population',
  Property = 'Property'
}

export enum ArendeStatus {
  Avslutat = 'Avslutat',
  Pågende = 'Pågende',
  Gallrat = 'Gallrat',
  Makulerat = 'Makulerat'
}

export interface Case {
  caseId: string;
  dnr: string;
  title: string;
  caseSource: CaseSource;
  date: string;
  unavailableDueToSecrecy: boolean;
  status: ArendeStatus;
  arendegrupp: string;
  arendetyp: string;
  arendeslag: string;
  fastighetsbeteckning: string;
  kommun: string;
  beskrivning: string;
  handlaggareEfternamn: string;
  handlaggareFornamn: string;
  handlaggareSignatur: string;
  caseSourceId: string;
  caseWithoutMainDecision: boolean;
  diarieprefix: string;
  tabs: CaseTab[];
  type: string;
}

export interface Occurence {
  title: string;
  arrival: string;
  documents: Document[];
  isSecret: boolean;
  isWorkingMaterial: boolean;
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
  isConfidential: boolean;
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
  secrecy: string;
  pulPersonalSecrecy: string;
  otherSecrecy: string;
  docs: Doc[];
  unavailableDueToSecrecy: boolean;
}

export interface Doc {
  title: string;
  secrecy: string;
  pulPersonalSecrecy: string;
  otherSecrecy: string;
  files: File[];
  unavailableDueToSecrecy: boolean;
}

export interface File {
  title: string;
  physicalDocumentId: string;
  secrecy: string;
  pulPersonalSecrecy: string;
  otherSecrecy: string;
  unavailableDueToSecrecy: boolean;
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
  caseSourceId?: string;
}

export interface Config {
  id: string;
  name: string;
  description: string;
  map: string | string[];
  tabs: Tab[];
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
  defaultConfigId?: string | null;
}

export enum Visibility {
  Hide,
  Restrict,
  Show
}

export interface AgsConfig {
  id: string;
  name: string;
  username: string;
  password: string;
  instance: string;
  department: string;
  searchWay: string;
  casePattern: string;
  documentPattern: string;
  dateField: string;
  estateNameSearch: boolean;
}

export interface ByggrConfig {
  id: string;
  name: string;
  documentTypes: string[];
  occurenceTypes: string[];
  personRoles: string[];
  diarieprefixes: string[];
  tabs: CaseTab[];
  hideNotesInPreview: boolean;
  workingMaterial: boolean;
  hideConfidentialOccurences: Visibility;
  hideCasesWithTextMatching: string[];
  hideOccurencesWithTextMatching: string[];
  hideDocumentsWithNoteTextMatching: string[];
  onlyCasesWithoutMainDecision: boolean;
  onlyActiveCases: boolean;
  minCaseStartDate: string | null;
  statuses: string[];
}

export interface HandlingTyp {
  typ: string;
  beskrivning: string;
  arAktiv: boolean;
  sortOrdn: number;
}

export interface Roll {
  rollKod: string;
  beskrivning: string;
  arAktiv: boolean;
}

export interface EcosConfig {
  id: string;
  name: string;
  hideConfidentialCases: Visibility;
  hideConfidentialDocuments: Visibility;
  documentTypes: string[];
  occurrenceTypes: string[];
  processTypes: string[];
}

export interface IipaxConfig {
  id: string;
  name: string;
  secrecyVisibility: Visibility;
  pulPersonalSecrecyVisibility: Visibility;
  otherSecrecyVisibility: Visibility;
  objectTypes: string[];
}

export interface ConfigFormData {
  id: string;
  name: string;
  description: string;
  map: string[];
  tabs: Tab[];
  caseSources: CaseSourceOption[];
}

export interface CaseSourceOption {
  value: string;
  label: string;
  caseSource: CaseSource;
}

export interface SelectOption {
  value: string;
  label: string;
  active: boolean;
}

export async function search(query: string) {
  let url = `search?query=${query}`;
  if (configId) {
    url = `${url}&configId=${configId}`;
  }
  const { data } = await instance.get<SearchResult[]>(url);
  return data;
}

export async function getPersons(estateId: string, distance: number | string) {
  let url = `persons?estateId=${estateId}&distance=${distance}`;
  if (configId) {
    url = `${url}&configId=${configId}`;
  }
  const { data } = await instance.get(url);
  return data;
}

export async function getOwners(estateId: string, distance: number | string) {
  let url = `owners?estateId=${estateId}&distance=${distance}`;
  if (configId) {
    url = `${url}&configId=${configId}`;
  }
  const { data } = await instance.get(url);
  return data;
}

export async function getCases(estateId: string, estateName?: string) {
  let url = `cases/${estateId}`;
  if (estateName) {
    url = `${url}/${estateName}`;
  }
  if (configId) {
    url = `${url}?configId=${configId}`;
  }
  const { data } = await instance.get<Case[]>(url);
  return data;
}

export async function getCase(caseId: string, caseSource: CaseSource, caseSourceId: string | undefined) {
  let url = `cases?caseId=${caseId}&caseSource=${caseSource}`;
  if (caseSourceId) {
    url = `${url}&caseSourceId=${caseSourceId}`;
  }
  const { data } = await instance.get<Case[]>(url);
  return data;
}

export async function getContact() {
  const { data } = await instance.get('contactSettings');
  return data;
}

export async function getConfigs() {
  const { data } = await instance.get<Config[]>('configs');
  return data;
}

export async function getCaseSourceOptions() {
  const { data } = await instance.get<CaseSourceOption[]>('configs/caseSourceOptions');
  return data;
}

export async function deleteConfig(id: string) {
  const url = `configs/${id}`;
  const { data } = await instance.delete(url);
  return data;
}

export async function createConfig(config: ConfigFormData) {
  const { data } = await instance.post('configs', config);
  return data;
}

export async function updateConfig(config: ConfigFormData) {
  const { data } = await instance.put('configs', config);
  return data;
}

export async function getFormData(id: string) {
  const url = `configs/formData/${id}`;
  const { data } = await instance.get<ConfigFormData>(url);
  return data;
}

export async function getAgsConfigs() {
  const { data } = await instance.get<AgsConfig[]>('ags');
  return data;
}

export async function getByggrConfigs() {
  const { data } = await instance.get<ByggrConfig[]>('byggr');
  return data;
}

export async function getDocumentTypes() {
  const { data } = await instance.get<SelectOption[]>('byggr/documentTypes');
  return data;
}

export async function getRoles() {
  const { data } = await instance.get<SelectOption[]>('byggr/roles');
  return data;
}

export async function getEcosConfigs() {
  const { data } = await instance.get<EcosConfig[]>('ecos');
  return data;
}

export async function getIipaxConfigs() {
  const { data } = await instance.get<IipaxConfig[]>('iipax');
  return data;
}

export async function deleteAgsConfig(id: string) {
  const url = `ags/${id}`;
  const { data } = await instance.delete(url);
  return data;
}

export async function deleteByggrConfig(id: string) {
  const url = `byggr/${id}`;
  const { data } = await instance.delete(url);
  return data;
}

export async function deleteEcosConfig(id: string) {
  const url = `ecos/${id}`;
  const { data } = await instance.delete(url);
  return data;
}

export async function deleteIipaxConfig(id: string) {
  const url = `iipax/${id}`;
  const { data } = await instance.delete(url);
  return data;
}

export async function createAgsConfig(agsConfig: AgsConfig) {
  const { data } = await instance.post('ags', agsConfig);
  return data;
}

export async function createByggrConfig(byggrConfig: ByggrConfig) {
  const { data } = await instance.post('byggr', byggrConfig);
  return data;
}

export async function createEcosConfig(ecosConfig: EcosConfig) {
  const { data } = await instance.post('ecos', ecosConfig);
  return data;
}

export async function createIipaxConfig(iipaxConfig: IipaxConfig) {
  const { data } = await instance.post('iipax', iipaxConfig);
  return data;
}

export async function updateAgsConfig(agsConfig: AgsConfig) {
  const { data } = await instance.put('ags', agsConfig);
  return data;
}

export async function updateByggrConfig(byggrConfig: ByggrConfig) {
  const { data } = await instance.put('byggr', byggrConfig);
  return data;
}

export async function updateEcosConfig(ecosConfig: EcosConfig) {
  const { data } = await instance.put('ecos', ecosConfig);
  return data;
}

export async function updateIipaxConfig(iipaxConfig: IipaxConfig) {
  const { data } = await instance.put('iipax', iipaxConfig);
  return data;
}

export async function getAgsConfig(id: string) {
  const url = `ags/${id}`;
  const { data } = await instance.get<AgsConfig>(url);
  return data;
}

export async function getByggrConfig(id: string) {
  const url = `byggr/${id}`;
  const { data } = await instance.get<ByggrConfig>(url);
  return data;
}

export async function getEcosConfig(id: string) {
  const url = `ecos/${id}`;
  const { data } = await instance.get<EcosConfig>(url);
  return data;
}

export async function getIipaxConfig(id: string) {
  const url = `iipax/${id}`;
  const { data } = await instance.get<IipaxConfig>(url);
  return data;
}

export async function getFnrFromPosition(lat: string | number, lon: string | number, srid: string | number, distance: number) {
  const url = `map/fnr?lat=${lat}&lon=${lon}&srid=${srid}&distance=${distance}`;
  const { data } = await instance.get<string>(url);
  return data;
}

export async function getGeometryFromFnr(fnr: number | string) {
  const url = `map/geometry?fnr=${fnr}`;
  const { data } = await instance.get(url);
  return data;
}

export async function getEstateName(fnr: number | string) {
  const url = `map/estateName?fnr=${fnr}`;
  const { data } = await instance.get<string>(url);
  return data;
}

export async function getEstatePosition(fnr: number | string) {
  const url = `map/estatePosition?fnr=${fnr}`;
  const { data } = await instance.get(url);
  return data;
}
export async function getOccurences(caseId: string, caseSource: string, caseSourceId: string) {
  let url = `cases/${caseId}/occurences?caseSourceId=${caseSourceId}&caseSource=${caseSource}`;
  if (configId) {
    url = `${url}&configId=${configId}`;
  }
  const { data } = await instance.get<Occurence[]>(url);
  return data;
}

export async function getPreview(caseId: string, caseSource: string, caseSourceId: string) {
  let url = `cases/${caseId}/preview?caseSourceId=${caseSourceId}&caseSource=${caseSource}`;
  if (configId) {
    url = `${url}&configId=${configId}`;
  }
  const { data } = await instance.get<Preview>(url);
  return data;
}

export async function getCasePersons(caseId: string, caseSource: string, caseSourceId: string) {
  let url = `cases/${caseId}/persons?caseSourceId=${caseSourceId}&caseSource=${caseSource}`;
  if (configId) {
    url = `${url}&configId=${configId}`;
  }
  const { data } = await instance.get<CasePerson[]>(url);
  return data;
}

export async function getArchivedDocuments(caseId: string, caseSource: string, caseSourceId: string) {
  let url = `cases/${caseId}/archivedDocuments?caseSourceId=${caseSourceId}&caseSource=${caseSource}`;
  if (configId) {
    url = `${url}&configId=${configId}`;
  }
  const { data } = await instance.get<ArchivedDocument[]>(url);
  return data;
}

export async function getUserSettings() {
  const { data } = await instance.get<UserSettings>('userSettings');
  return data;
}

export async function updateUserSettings(userSettings: UserSettings) {
  const { data } = await instance.put<UserSettings>('userSettings', userSettings);
  return data;
}

export async function getUsers() {
  const { data } = await instance.get<ReflexUser[]>('users');
  return data;
}

export async function getCurrentUser() {
  const { data } = await instance.get<ReflexUser>('users/me');
  return data;
}

export async function deleteUsers(ids: string[]) {
  return await instance.delete('users', { data: ids });
}

export async function getDocument(docLinkId: string, caseSource: any, caseSourceId: string) {
  const response = await instance.get(`cases/document?docId=${docLinkId}&caseSource=${caseSource}&caseSourceId=${caseSourceId}&configId=${configId}`, { responseType: 'blob' });

  if (!response.data)
    return;
  const url = URL.createObjectURL(response.data);
  const a = document.createElement('a');
  a.href = url;
  a.download = getFilenameFromHeaders(response.headers) || 'file';
  a.click();
  // Discard the object data
  URL.revokeObjectURL(url);
}

function getFilenameFromHeaders(headers: any) {
  // The content-disposition header should include a suggested filename for the file
  const contentDisposition = headers['content-disposition'];
  if (!contentDisposition) {
    return null;
  }
  var filename = '';
  if (contentDisposition.indexOf('attachment') !== -1) {
    var filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
    var matches = filenameRegex.exec(contentDisposition);
    if (matches != null && matches[1]) {
      filename = matches[1].replace(/['"]/g, '');
    }
  }
  return filename;
}

export async function updateRoles(requests: UpdateRolesRequest[]) {
  return await instance.put('users/roles', requests);
}

export async function updateConfigPermissions(requests: UpdateConfigPermissionsRequest[]) {
  return await instance.put('users/configPermissions', requests);
}
