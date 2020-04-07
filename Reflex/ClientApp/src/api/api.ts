import axios from 'axios';

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

export async function getConfigs() {
  const { data } = await axios.get<Config[]>('api/configs');
  return data;
}
