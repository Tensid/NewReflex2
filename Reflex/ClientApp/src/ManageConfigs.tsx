import { useEffect, useState } from 'react';
import Col from 'react-bootstrap/Col';
import Nav from 'react-bootstrap/Nav';
import NavDropdown from 'react-bootstrap/NavDropdown';
import Row from 'react-bootstrap/Row';
import Tab from 'react-bootstrap/Tab';
import { AgsConfig, ByggrConfig, CaseSourceOption, Config, EcosConfig, IipaxConfig, SelectOption, getAgsConfig, getAgsConfigs, getByggrConfig, getByggrConfigs, getCaseSourceOptions, getConfigs, getDocumentTypes, getEcosConfig, getEcosConfigs, getFormData, getIipaxConfig, getIipaxConfigs, getRoles } from './api/api';
import { getLayersSettings } from './api/mapSettingsApi';
import AgsConfigForm from './features/manage-configs/AgsConfigForm';
import ByggrConfigForm from './features/manage-configs/ByggrConfigForm';
import EcosConfigForm from './features/manage-configs/EcosConfigForm';
import IipaxConfigForm from './features/manage-configs/IipaxConfigForm';
import ReflexConfigForm from './features/manage-configs/ReflexConfigForm';

const ManageConfigs = () => {
  const [agsConfigs, setAgsConfigs] = useState<AgsConfig[]>([]);
  const [byggrConfigs, setByggrConfigs] = useState<ByggrConfig[]>([]);
  const [ecosConfigs, setEcosConfigs] = useState<EcosConfig[]>([]);
  const [iipaxConfigs, setIipaxConfigs] = useState<IipaxConfig[]>([]);
  const [reflexConfigs, setReflexConfigs] = useState<Config[]>([]);
  const [agsFormData, setAgsFormData] = useState<any>();
  const [byggrFormData, setByggrFormData] = useState<any>();
  const [ecosFormData, setEcosFormData] = useState<any>();
  const [iipaxFormData, setIipaxFormData] = useState<any>();
  const [reflexFormData, setReflexFormData] = useState<any>();
  const [activeForm, setActiveForm] = useState<string>();
  const [activeKey, setActiveKey] = useState<string>();
  const [caseSourceOptions, setCaseSourceOptions] = useState<CaseSourceOption[]>([]);
  const [documentTypeOptions, setDocumentTypeOptions] = useState<SelectOption[]>();
  const [roleOptions, setRoleOptions] = useState<SelectOption[]>();
  const [edit, setEdit] = useState(false);
  const [layers, setLayers] = useState<any>([]);

  useEffect(() => {
    (async () => {
      setAgsConfigs(await getAgsConfigs());
      setByggrConfigs(await getByggrConfigs());
      setEcosConfigs(await getEcosConfigs());
      setIipaxConfigs(await getIipaxConfigs());
      setReflexConfigs(await getConfigs());
      setCaseSourceOptions(await getCaseSourceOptions());
      setDocumentTypeOptions(await getDocumentTypes() || []);
      setRoleOptions(await getRoles() || []);
      const mappedLayers = (await getLayersSettings()).map((x: any) => ({ value: x.id, label: x.title }));
      setLayers(mappedLayers);
    })();
  }, []);

  async function fetchAll() {
    setAgsConfigs(await getAgsConfigs());
    setByggrConfigs(await getByggrConfigs());
    setEcosConfigs(await getEcosConfigs());
    setIipaxConfigs(await getIipaxConfigs());
    setReflexConfigs(await getConfigs());
    setCaseSourceOptions(await getCaseSourceOptions());
  }

  function hideActiveForm() {
    setActiveForm('');
    setActiveKey('');
  };

  return (
    <div className="row">
      <div className="col-6 col-form-label col-form-label-sm">
        <h5>Hantera konfigurationer</h5>
        <Tab.Container activeKey={activeKey}>
          <Row>
            <Col sm={3}>
              <Nav variant="pills" className="flex-column" activeKey={activeKey}>
                <NavDropdown key="Reflex" title="Reflex" id="nav-dropdown">
                  {reflexConfigs?.map((cfg) =>
                    <NavDropdown.Item key={cfg.id} eventKey={cfg.id} onClick={async () => {
                      setActiveKey(cfg.id);
                      setEdit(true);
                      setReflexFormData(await getFormData(cfg.id));
                      setActiveForm('Reflex');
                    }}>
                      {cfg?.name}
                    </NavDropdown.Item>)}
                  {reflexConfigs.length > 0 && <NavDropdown.Divider />}
                  <NavDropdown.Item key="Reflex_new" eventKey="Reflex_new" onClick={() => {
                    setActiveKey('Reflex_new');
                    setEdit(false);
                    setReflexFormData({});
                    setActiveForm('Reflex');
                  }}>Skapa konfiguration</NavDropdown.Item>
                </NavDropdown>
                <NavDropdown key="ByggR" title="ByggR" id="nav-dropdown">
                  {byggrConfigs?.map((cfg) =>
                    <NavDropdown.Item key={cfg.id} eventKey={cfg.id} onClick={async () => {
                      setActiveKey(cfg.id);
                      setEdit(true);
                      setActiveForm('ByggR');
                      setByggrFormData(await getByggrConfig(cfg.id));
                    }}>
                      {cfg?.name}
                    </NavDropdown.Item>)}
                  {byggrConfigs.length > 0 && <NavDropdown.Divider />}
                  <NavDropdown.Item key="ByggR_new" eventKey="ByggR_new" onClick={() => {
                    setActiveKey('ByggR_new');
                    setEdit(false);
                    setByggrFormData({});
                    setActiveForm('ByggR');
                  }}>Skapa konfiguration</NavDropdown.Item>
                </NavDropdown>
                <NavDropdown key="AGS" title="AGS" id="nav-dropdown">
                  {agsConfigs?.map((cfg) =>
                    <NavDropdown.Item key={cfg.id} eventKey={cfg.id} onClick={async () => {
                      setActiveKey(cfg.id);
                      setEdit(true);
                      setActiveForm('AGS');
                      setAgsFormData(await getAgsConfig(cfg.id));
                    }}>
                      {cfg?.name}
                    </NavDropdown.Item>)}
                  {agsConfigs.length > 0 && <NavDropdown.Divider />}
                  <NavDropdown.Item key="AGS_new" eventKey="AGS_new" onClick={() => {
                    setActiveKey('AGS_new');
                    setEdit(false);
                    setAgsFormData({});
                    setActiveForm('AGS');
                  }}>Skapa konfiguration</NavDropdown.Item>
                </NavDropdown>
                <NavDropdown key="Ecos" title="Ecos" id="nav-dropdown">
                  {ecosConfigs?.map((cfg) =>
                    <NavDropdown.Item key={cfg.id} eventKey={cfg.id} onClick={async () => {
                      setActiveKey(cfg.id);
                      setEdit(true);
                      setActiveForm('Ecos');
                      setEcosFormData(await getEcosConfig(cfg.id));
                    }}>
                      {cfg?.name}
                    </NavDropdown.Item>)}
                  {ecosConfigs.length > 0 && <NavDropdown.Divider />}
                  <NavDropdown.Item key="Ecos_new" eventKey="Ecos_new" onClick={() => {
                    setActiveKey('Ecos_new');
                    setEdit(false);
                    setEcosFormData({});
                    setActiveForm('Ecos');
                  }}>Skapa konfiguration</NavDropdown.Item>
                </NavDropdown>
                <NavDropdown key="iipax" title="iipax" id="nav-dropdown">
                  {iipaxConfigs?.map((cfg) =>
                    <NavDropdown.Item key={cfg.id} eventKey={cfg.id} onClick={async () => {
                      setActiveKey(cfg.id);
                      setEdit(true);
                      setActiveForm('iipax');
                      setIipaxFormData(await getIipaxConfig(cfg.id));
                    }}>
                      {cfg?.name}
                    </NavDropdown.Item>)}
                  {iipaxConfigs.length > 0 && <NavDropdown.Divider />}
                  <NavDropdown.Item key="iipax" eventKey="iipax" onClick={() => {
                    setActiveKey('iipax');
                    setEdit(false);
                    setIipaxFormData({});
                    setActiveForm('iipax');
                  }}>Skapa konfiguration</NavDropdown.Item>
                </NavDropdown>
              </Nav>
            </Col>
          </Row>
        </Tab.Container>
      </div>
      <div className="col-6 col-form-label col-form-label-sm">
        {activeForm === 'Reflex' && <ReflexConfigForm edit={edit} formData={reflexFormData} caseSourceOptions={caseSourceOptions} layers={layers} fetchAll={fetchAll} hideActiveForm={hideActiveForm} />}
        {activeForm === 'AGS' && <AgsConfigForm edit={edit} formData={agsFormData} fetchAll={fetchAll} hideActiveForm={hideActiveForm} />}
        {(activeForm === 'ByggR' && documentTypeOptions && roleOptions) && <ByggrConfigForm edit={edit} formData={byggrFormData} documentTypeOptions={documentTypeOptions} roleOptions={roleOptions} fetchAll={fetchAll} hideActiveForm={hideActiveForm} />}
        {activeForm === 'Ecos' && <EcosConfigForm edit={edit} formData={ecosFormData} fetchAll={fetchAll} hideActiveForm={hideActiveForm} />}
        {activeForm === 'iipax' && <IipaxConfigForm edit={edit} formData={iipaxFormData} fetchAll={fetchAll} hideActiveForm={hideActiveForm} />}
      </div>
    </div>
  );
};

export default ManageConfigs;
