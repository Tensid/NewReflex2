import React from 'react';
import { Tab, Tabs } from 'react-bootstrap';
import { CasePerson, CaseSource, Occurence, Preview } from '../../api/api';
import OccurenceContent from './OccurenceContent';
import PersonContent from './PersonsContent';
import PreviewContent from './PreviewContent';

interface ByggrCaseContentProps {
  dnr: string;
  caseSource: CaseSource;
  occurences: Occurence[];
  persons: CasePerson[];
  preview: Preview;
}

const ByggrCaseContent = ({ dnr, caseSource, occurences, persons, preview }: ByggrCaseContentProps) => {
  return (
    <Tabs defaultActiveKey="Förhandsgranskning" variant="pills">
      <Tab eventKey="Förhandsgranskning" title="Förhandsgranskning">
        <PreviewContent {...preview} dnr={dnr} />
      </Tab>
      <Tab eventKey="Händelser" title="Händelser">
        <OccurenceContent occurences={occurences} caseSource={caseSource} />
      </Tab>
      <Tab eventKey="Intressenter" title="Intressenter">
        <PersonContent persons={persons} />
      </Tab>
    </Tabs>
  );
};

export default ByggrCaseContent;
