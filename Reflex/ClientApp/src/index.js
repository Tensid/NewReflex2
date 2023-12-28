import '@sokigo/design-system-bootstrap/index.css';
import { createRoot } from 'react-dom/client';
import { Provider } from 'react-redux';
import { DndProvider } from 'react-dnd';
import { MultiBackend } from 'react-dnd-multi-backend';
import { HTML5toTouch } from 'rdndmb-html5-to-touch';
import topMenuApps from './topMenuApps';
import Reflex from './Reflex';
import Administration from './Administration';
import App from '@sokigo-sbwebb/recommended';
import { store } from './app/store';

// const apps = [SkolskjutsWeb, ...(topMenuApps || [])];
// const apps = [Reflex, Administration, ...([])];
const apps = [Reflex, Administration, ...(topMenuApps || [])];

const container = document.getElementById('app');
const root = createRoot(container);

root.render(
  <Provider store={store}>
    <DndProvider backend={MultiBackend} options={HTML5toTouch}>
      {/* <App applications={apps} params={{ navbar: { disableSide: true, defaultTheme: "off", disableTheme: true } }} /> */}
      <App applications={apps} params={{ transformTranslateZ: false, navbar: { defaultSide: "top", disableSide: true, defaultTheme: "off", disableTheme: true } }} />
    </DndProvider>
  </Provider>
);