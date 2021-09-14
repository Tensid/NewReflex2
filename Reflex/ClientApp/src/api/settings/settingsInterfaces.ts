export interface AgsSettings {
  id: string;
  serviceUrl: string;
}

export interface ByggrSettings {
  id: string;
  serviceUrl: string;
}


export interface EcosSettings {
  id: string;
  serviceUrl: string;
  username: string;
  password: string;
}

export interface IipaxSettings {
  id: string;
  serviceUrl: string;
}

export interface FbSettings {
  id: string;
  fbServiceDatabase: string;
  fbServicePassword: string;
  fbServiceUrl: string;
  fbServiceUser: string;
  fbWebbBoendeUrl: string;
  fbWebbByggnadUrl: string;
  fbWebbByggnadUsrUrl: string;
  fbWebbFastighetUrl: string;
  fbWebbFastighetUsrUrl: string;
  fbWebbLagenhetUrl: string;
}

export interface FbWebbSettings {
  fbWebbBoendeUrl: string;
  fbWebbLagenhetUrl: string;
  fbWebbFastighetUrl: string;
  fbWebbFastighetUsrUrl: string;
  fbWebbByggnadUrl: string;
  fbWebbByggnadUsrUrl: string;
}

export interface MiscSettings {
  email: string;
  subject: string;
  body: string;
  csmUrl: string;
}
