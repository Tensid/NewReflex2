import Logo from './sokigo';

const About = () => {
  console.log("about");
  return (
    <>
      <h3 className="py-1 text-brand fw-bold">Om Reflex 3.0</h3>
      <p>
        Reflex är en webb- och mobilanpassad applikation med syfte att erbjuda enkla och snabba funktioner för att tillgängligöra ärendeinformation från utvalda ärenderegister främst baserat på fastighet och adresssökningar.
        Ärenden i Ecos, ByggR och AGS kan snabbt och enkelt hämtas och presenteras överskådligt till sökt fastighet, adress eller ärende.
        Reflexapplikationen kan även konfigureras för att erbjuda direkt tillgång till fastighets- och befolkningsrapporter från FB.
        Reflex sökfunktioner kan utföras via intuitiva sökfält eller via det ingående kartstödet. Reflexkartan har stöd för positionering med tillhörande Googles och Bings ruttningstjänster till utsökt fastighet.
      </p>
      <p>
        Reflexanvändare kan erbjudas tillgång till olika informationsdataset baserat på olika Reflexkonfigurationer. Tilldelning och administration av användare och behörighet utförs av Reflexadministratören.
      </p>
      <div className="mb-1">
        <a href="https://www.sokigo.com" target="_blank" rel="noopener noreferrer">www.sokigo.com</a>
      </div>
      <div className="mb-1">
        <a href="https://sokigo.com" target="_blank" rel="noopener noreferrer">
          <Logo />
        </a>
      </div>
      <div className="pt-1">
        <small>Icons made by <a href="https://www.flaticon.com/authors/google" title="Google" rel="noopener noreferrer">Google</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a> is licensed by <a href="http://creativecommons.org/licenses/by/3.0/" title="Creative Commons BY 3.0" target="_blank" rel="noopener noreferrer">CC 3.0 BY</a></small>
      </div>
    </>
  );
};

export default About;
