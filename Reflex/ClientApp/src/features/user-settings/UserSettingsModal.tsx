import { useEffect, useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { Tab, getConfigs } from '../../api/api';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { fetchUpdateUserSettings, fetchUserSettings } from './userSettingsSlice';

interface SettingTabs {
  value: Tab;
  text: string;
}

const settingsTabs: SettingTabs[] = [
  {
    value: Tab.Search,
    text: 'Stanna på sök'
  },
  {
    value: Tab.Map,
    text: 'Karta'
  },
  {
    value: Tab.Cases,
    text: 'Ärende'
  },
  {
    value: Tab.Population,
    text: 'Befolkning'
  },
  {
    value: Tab.Property,
    text: 'Fastighet'
  }
];

interface ConfigOption {
  id: string | undefined;
  name: string;
};

interface UserSettingsModalProps {
  setShow: (show: boolean) => void;
};

const UserSettingsModal = ({ setShow }: UserSettingsModalProps) => {
  const defaultConfigId = useAppSelector((state) => state.userSettings.defaultConfigId);
  const defaultTab = useAppSelector((state) => state.userSettings.defaultTab);
  const [configOptions, setConfigOptions] = useState<ConfigOption[]>([]);
  const [selectedConfigId, setSelectedConfigId] = useState<string>();
  const [selectedTab, setSelectedTab] = useState((settingsTabs.find(x => x.value === defaultTab)!));
  const dispatch = useAppDispatch();

  useEffect(() => {
    (async () => {
      const options: ConfigOption[] = (await getConfigs()).map(x => ({ id: x.id, name: x.name }));
      options.push({ id: '', name: "Ingen" });
      setConfigOptions(options);
      dispatch(fetchUserSettings());
    })();
  }, []);

  useEffect(() => {
    setSelectedConfigId(defaultConfigId ?? '');
  }, [defaultConfigId]);

  if (defaultConfigId === undefined)
    return null;

  return (
    <Modal show onHide={() => setShow(false)}>
      <Modal.Header closeButton>
        <Modal.Title>Personliga inställningar</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <label className="pt-2">Flik som öppnas vid sökträff</label>
        {settingsTabs?.map((tab) =>
          <div key={tab.value}>
            <input className="mr-2"
              type="radio"
              value={tab.value}
              checked={selectedTab?.value === tab.value}
              onChange={() => setSelectedTab(tab)} />
            {tab.text}
          </div>
        )}
        <label className="pt-2">Välj standardkonfiguration</label>
        <select className="form-control" value={selectedConfigId} onChange={(e) => setSelectedConfigId(e.target.value)}>
          {configOptions?.map((c) =>
            <option key={c.id} value={c.id}>{c.name}</option>
          )}
        </select>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={() => setShow(false)}>Stäng</Button>
        <Button
          variant="primary"
          onClick={() => {
            dispatch(fetchUpdateUserSettings({ defaultTab: selectedTab.value, defaultConfigId: selectedConfigId ? selectedConfigId : null }));
            setShow(false);
          }}>
          Spara
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default UserSettingsModal;
