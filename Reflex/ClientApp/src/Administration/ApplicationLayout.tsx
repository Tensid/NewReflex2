import { ReactNode } from 'react';
import { Container, Panel } from '@sokigo/components-react-bootstrap';
// import ErrorTopDisplay from '../Skolskjuts/features/errorHandling/errorTopDisplay';

const ApplicationLayout = ({ children }: { children: ReactNode }) => (
  <Container>
    {/* <div className="ml-3 mr-3">
      <ErrorTopDisplay />
    </div> */}
    <Panel className="p-3">
      {children}
    </Panel>
  </Container>
);

export default ApplicationLayout;