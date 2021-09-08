import React from 'react';
import { connect } from 'react-redux';
import { RootState } from './app/store';

interface FooterProps {
  name: string;
  description: string;
}

const Footer = ({ name, description }: FooterProps) => (
  <footer className="fixed-bottom bg-brand text-white flex-shrink-0">
    {name ? name + description : 'Konfiguration ej vald'}
    <span className="float-right">Sokigo</span>
  </footer>
);

const mapStateToProps = (state: RootState, _ownProps: any) => ({
  name: state?.config?.name,
  description: state?.config?.description ? ' - ' + state?.config?.description : ''
});

export default connect(
  mapStateToProps,
  null
)(Footer);
