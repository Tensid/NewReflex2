export enum Action {
  AddConfig = 0,
  DeleteConfig,
  SetConfig,
  MakeAdmin,
  MakeUser,
  DeleteUser
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
  { action: Action.SetConfig, actionText: 'Tilldela konfiguration', modalBody: 'Vill du verkligen tilldela konfigurationer för', confirm: 'Bekräfta', cancel: 'Ångra' },
  { action: Action.MakeAdmin, actionText: 'Gör till administratör', modalBody: 'Vill du verkligen ge administratörsrättigheter till', confirm: 'Bekräfta', cancel: 'Ångra' },
  { action: Action.MakeUser, actionText: 'Gör till användare', modalBody: 'Vill du verkligen ge användarrättigheter till', confirm: 'Bekräfta', cancel: 'Ångra' },
  { action: Action.DeleteUser, actionText: 'Ta bort användare', modalBody: 'Vill du verkligen ta bort', confirm: 'Bekräfta', cancel: 'Ångra' }
];
