import { useState } from 'react';
import Col from 'react-bootstrap/Col';
import Nav from 'react-bootstrap/Nav';
import Row from 'react-bootstrap/Row';
import Tab from 'react-bootstrap/Tab';
import { AgsSettings, ByggrSettings, EcosSettings, FbSettings, IipaxSettings, MiscSettings, getAgsSettings, getByggrSettings, getEcosSettings, getFbSettings, getIipaxSettings, getMiscSettings } from './api/settings';
import AgsSettingsForm from './features/system-settings/AgsSettingsForm';
import ByggrSettingsForm from './features/system-settings/ByggrSettingsForm';
import EcosSettingsForm from './features/system-settings/EcosSettingsForm';
import FbSettingsForm from './features/system-settings/FbSettingsForm';
import IipaxSettingsForm from './features/system-settings/IipaxSettingsForm';
import MiscSettingsForm from './features/system-settings/MiscSettingsForm';

const ManageSystemSettings = () => {
  const [agsFormData, setAgsFormData] = useState<AgsSettings>();
  const [byggrFormData, setByggrFormData] = useState<ByggrSettings>();
  const [ecosFormData, setEcosFormData] = useState<EcosSettings>();
  const [iipaxFormData, setIipaxFormData] = useState<IipaxSettings>();
  const [fbFormData, setFbFormData] = useState<FbSettings>();
  const [miscFormData, setMiscFormData] = useState<MiscSettings>();
  const [activeKey, setActiveKey] = useState('');

  return (
    <div className="row">
      <div className="col-6 col-form-label col-form-label-sm">
        <h5>Systeminställningar</h5>
        <Tab.Container activeKey={activeKey}>
          <Row>
            <Col sm={3}>
              <Nav variant="pills" className="flex-column" activeKey={activeKey}>
                <Nav.Item key="FB" title="FB" onClick={async () => {
                  setActiveKey('FB');
                  setFbFormData(await getFbSettings());
                }}>
                  <Nav.Link eventKey="FB" title="FB">
                    FB
                  </Nav.Link>
                </Nav.Item>
                <Nav.Item key="ByggR" title="ByggR" onClick={async () => {
                  setActiveKey('ByggR');
                  setByggrFormData(await getByggrSettings());
                }}>
                  <Nav.Link eventKey="ByggR" title="ByggR">
                    ByggR
                  </Nav.Link>
                </Nav.Item>
                <Nav.Item key="AGS" title="AGS" onClick={async () => {
                  setActiveKey('AGS');
                  setAgsFormData(await getAgsSettings());
                }}>
                  <Nav.Link eventKey="AGS" title="AGS">
                    AGS
                  </Nav.Link>
                </Nav.Item>
                <Nav.Item key="Ecos" title="Ecos" onClick={async () => {
                  setActiveKey('Ecos');
                  setEcosFormData(await getEcosSettings());
                }}>
                  <Nav.Link eventKey="Ecos" title="Ecos">
                    Ecos
                  </Nav.Link>
                </Nav.Item>
                <Nav.Item key="iipax" title="iipax" onClick={async () => {
                  setActiveKey('iipax');
                  setIipaxFormData(await getIipaxSettings());
                }}>
                  <Nav.Link eventKey="iipax" title="iipax">
                    iipax
                  </Nav.Link>
                </Nav.Item>
                <Nav.Item key="Övrigt" title="Övrigt" onClick={async () => {
                  setActiveKey('Övrigt');
                  setMiscFormData(await getMiscSettings());
                }}>
                  <Nav.Link eventKey="Övrigt" title="Övrigt">
                    Övrigt
                  </Nav.Link>
                </Nav.Item>
              </Nav>
            </Col>
          </Row>
        </Tab.Container>
      </div>
      <div className="col-6 col-form-label col-form-label-sm">
        {activeKey === 'FB' && <FbSettingsForm formData={fbFormData} setActiveKey={setActiveKey} />}
        {activeKey === 'AGS' && <AgsSettingsForm formData={agsFormData} setActiveKey={setActiveKey} />}
        {activeKey === 'ByggR' && <ByggrSettingsForm formData={byggrFormData} setActiveKey={setActiveKey} />}
        {activeKey === 'Ecos' && <EcosSettingsForm formData={ecosFormData} setActiveKey={setActiveKey} />}
        {activeKey === 'iipax' && <IipaxSettingsForm formData={iipaxFormData} setActiveKey={setActiveKey} />}
        {activeKey === 'Övrigt' && <MiscSettingsForm formData={miscFormData} setActiveKey={setActiveKey} />}
      </div>
    </div>
  );
};

export default ManageSystemSettings;
