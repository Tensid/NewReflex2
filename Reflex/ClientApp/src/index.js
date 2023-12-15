import React from 'react';
// import '@sokigo/design-system-bootstrap/index.css';
import { createRoot } from 'react-dom/client';
import { Provider } from 'react-redux';
import { DndProvider } from 'react-dnd';
import { MultiBackend } from 'react-dnd-multi-backend';
import { HTML5toTouch } from 'rdndmb-html5-to-touch';
import Reflex from './Reflex';
import App from '@sokigo-sbwebb/recommended';
import { store } from './app/store';

// const apps = [SkolskjutsWeb, ...(topMenuApps || [])];
const apps = [Reflex, ...([])];

const container = document.getElementById('app');
const root = createRoot(container);

root.render(
  <Provider store={store}>
    <DndProvider backend={MultiBackend} options={HTML5toTouch}>
      {/* <App applications={apps} fullscreen fullScreen params={{ navbar: { defaultSide: "top", disableSide: true, defaultTheme: "off", disableTheme: true, fullscreen: true, pinned: "fullscreen" }, pinned: "fullscreen" }} /> */}
      <App applications={apps} params={{ navbar: { defaultSide: "top", disableSide: true, defaultTheme: "off", disableTheme: true } }} />
    </DndProvider>
  </Provider>
);