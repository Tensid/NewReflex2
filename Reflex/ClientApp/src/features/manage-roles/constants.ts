export enum Action {
  AddConfig = 0,
  DeleteConfig,
  SetConfig,
}

interface Option {
  action: Action;
  actionText: string;
  modalBody: string;
  confirm: string;
  cancel: string;
}

export const options: Option[] = [
  { action: Action.AddConfig, actionText: 'Lägg till konfiguration', modalBody: 'Vill du lägga till konfigurationer för', confirm: 'Bekräfta', cancel: 'Ångra' },
  { action: Action.DeleteConfig, actionText: 'Ta bort konfiguration', modalBody: 'Vill du ta bort konfigurationer för', confirm: 'Bekräfta', cancel: 'Ångra' },
  { action: Action.SetConfig, actionText: 'Tilldela konfiguration', modalBody: 'Vill du verkligen tilldela konfigurationer för', confirm: 'Bekräfta', cancel: 'Ångra' }
];
