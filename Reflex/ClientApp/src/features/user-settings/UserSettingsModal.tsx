import React, { useState } from 'react';
import { Button, Modal } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import { Tab } from '../../api/api';
import { RootState } from '../../app/store';
import { fetchUpdateUserSettings } from './userSettingsSlice';

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

interface UserSettingsModalProps {
  setShow: (show: boolean) => void;
};

const UserSettingsModal = ({ setShow }: UserSettingsModalProps) => {
  const defaultTab = useSelector((state: RootState) => state.userSettings.defaultTab);
  const [selectedTab, setSelectedTab] = useState((settingsTabs.find(x => x.value === defaultTab)));
  const dispatch = useDispatch();

  return (
    <Modal show onHide={() => setShow(false)}>
      <Modal.Header closeButton>
        <Modal.Title>Inställningar</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <div className="row pt-2">
          <div className="col-12">
            <label>Flik som öppnas vid sökträff</label>
          </div>
        </div>
        {settingsTabs?.map((tab) =>
          <div className="row" key={tab.value}>
            <div className="col-12">
              <input className="mr-2"
                type="radio"
                value={tab.value}
                checked={selectedTab?.value === tab.value}
                onChange={() => setSelectedTab(tab)} />
              {tab.text}
            </div>
          </div>
        )}
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={() => setShow(false)}>Stäng</Button>
        <Button variant="primary" onClick={() => { dispatch(fetchUpdateUserSettings({ defaultTab: selectedTab!.value })); setShow(false); }}>Spara</Button>
      </Modal.Footer>
    </Modal>
  );
};

export default UserSettingsModal;
