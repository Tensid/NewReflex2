import React from 'react';
import Logo from './sokigo.svg';

const About = () => {
  return (
    <div className="container-fluid">
      <div className="row">
        <div className="col-form-label col-form-label-sm col">
          <h3 className="text-info font-weight-bold">Om Reflex 2.0</h3>
        </div>
      </div>
      <p>
        Reflex är en webb- och mobilanpassad applikation med syfte att erbjuda enkla och snabba funktioner för att tillgängligöra ärendeinformation från utvalda ärenderegister främst baserat på fastighet och adresssökningar.
        Ärenden i Ecos, ByggR och AGS kan snabbt och enkelt hämtas och presenteras överskådligt till sökt fastighet eller adress.
        Reflexapplikationen kan även konfigureras för att erbjuda direkt tillgång till fastighets- och befolkningsrapporter från FB.
        Reflex sökfunktioner kan utföras via intuitiva sökfält eller via det ingående kartstödet. Reflexkartan har stöd för positionering med tillhörande Googles och Bings ruttningstjänster till utsökt fastighet.
      </p>
      <p>
        Reflexanvändare kan erbjudas tillgång till olika informationsdataset baserat på olika Reflexkonfigurationer. Tilldelning och administration av användare och behörighet utförs av Reflexadministratören.
      </p>
      <div className="form-group">
        <a href="https://www.sokigo.com" target="_blank" rel="noopener noreferrer">www.sokigo.com</a>
      </div>
      <div className="form-group">
        För support, Ring: 0771-60 60 70, eller skicka E-post: <a href="mailto:support@sokigo.com">support@sokigo.com</a>
      </div>
      <div className="form-group">
        <a href="https://sokigo.com" target="_blank" rel="noopener noreferrer">
          <img alt="Sokigo logo" src={Logo} height="60" />
        </a>
      </div>
      <div className="form-group pt-1">
        <small>Icons made by <a href="https://www.flaticon.com/authors/google" title="Google" rel="noopener noreferrer">Google</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a> is licensed by <a href="http://creativecommons.org/licenses/by/3.0/" title="Creative Commons BY 3.0" target="_blank" rel="noopener noreferrer">CC 3.0 BY</a></small>
      </div>
    </div>
  );
};

export default About;
