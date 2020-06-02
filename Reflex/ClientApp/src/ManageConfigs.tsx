import React, { useEffect, useState } from 'react';
import { Col, Nav, NavDropdown, Row, Tab } from 'react-bootstrap';
import { Config, getAgsConfig, getByggrConfig, getConfig, getEcosConfig, getFullConfigs } from './api/api';
import AgsConfigForm from './features/manage-configs/AgsConfigForm';
import ByggrConfigForm from './features/manage-configs/ByggrConfigForm';
import EcosConfigForm from './features/manage-configs/EcosConfigForm';
import ReflexConfigForm from './features/manage-configs/ReflexConfigForm';

const ManageConfigs = () => {
  const [agsFormData, setAgsFormData] = useState<any>();
  const [byggrFormData, setByggrFormData] = useState<any>();
  const [ecosFormData, setEcosFormData] = useState<any>();
  const [reflexFormData, setReflexFormData] = useState<any>();
  const [activeForm, setActiveForm] = useState<string>();
  const [activeKey, setActiveKey] = useState<string>();
  const [configs, setConfigs] = useState<Config[]>([]);
  const [edit, setEdit] = useState(false);

  useEffect(() => {
    (async () => {
      setConfigs(await getFullConfigs());
    })();
  }, []);

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
                {configs.map((cfg) =>
                  <NavDropdown key={cfg.id} title={cfg.name} id="nav-dropdown">
                    {cfg.ecosConfigs && cfg.ecosConfigs?.map((x) =>
                      <NavDropdown.Item key={x.id} eventKey={x.id} onClick={async () => {
                        setActiveKey(x.id);
                        setEcosFormData(await getEcosConfig(x.id));
                        setActiveForm('Ecos');
                      }}>
                        Ecos
                      </NavDropdown.Item>)}
                    {cfg.byggrConfigs && cfg.byggrConfigs?.map((x) =>
                      <NavDropdown.Item key={x.id} eventKey={x.id} onClick={async () => {
                        setActiveKey(x.id);
                        setByggrFormData(await getByggrConfig(x.id));
                        setActiveForm('ByggR');

                      }}>
                        ByggR
                      </NavDropdown.Item>)}
                    {cfg.agsConfigs && cfg.agsConfigs?.map((x) =>
                      <NavDropdown.Item key={x.id} eventKey={x.id} onClick={async () => {
                        setActiveKey(x.id);
                        setAgsFormData(await getAgsConfig(x.id));
                        setActiveForm('AGS');
                      }}>
                        AGS
                      </NavDropdown.Item>)}
                    <NavDropdown.Divider />
                    <NavDropdown.Item key={cfg.id + ".1"} eventKey={cfg.id + ".1"} onClick={async () => {
                      setActiveKey(cfg.id + ".1");
                      setEdit(true);
                      setReflexFormData(await getConfig(cfg.id));
                      setActiveForm('Reflex');
                    }}>Redigera konfiguration</NavDropdown.Item>
                    <NavDropdown.Item key={cfg.id + ".2"} eventKey={cfg.id + ".2"} onClick={async () => {
                      setActiveKey('');
                      setEdit(true);
                      hideActiveForm();
                    }}>Välj konfiguration</NavDropdown.Item>
                  </NavDropdown>)}
              </Nav>
            </Col>
          </Row>
        </Tab.Container>
        <div>Välj, <a href="# " onClick={(e) => { e.preventDefault(); setActiveKey(''); setEdit(false); setReflexFormData({}); setActiveForm('Reflex'); }}>skapa</a> eller redigera en befintlig konfiguration i menyraden ovan.<br />
          <a href="api/documents/Reflex Manual.pdf">Öppna manual</a> för konfigurationshantering.</div>
      </div>
      <div className="col-6 col-form-label col-form-label-sm">
        {activeForm === 'Reflex' && <ReflexConfigForm edit={edit} formData={reflexFormData} hideActiveForm={hideActiveForm} setConfigs={setConfigs} />}
        {activeForm === 'AGS' && <AgsConfigForm formData={agsFormData} hideActiveForm={hideActiveForm} />}
        {activeForm === 'ByggR' && <ByggrConfigForm formData={byggrFormData} hideActiveForm={hideActiveForm} />}
        {activeForm === 'Ecos' && <EcosConfigForm formData={ecosFormData} hideActiveForm={hideActiveForm} />}
      </div>
    </div>
  );
};

export default ManageConfigs;
