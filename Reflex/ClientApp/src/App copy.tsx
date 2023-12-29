import { useEffect, useState } from 'react';
// import { Route, Routes } from 'react-router';
// import { Navigate } from 'react-router-dom';
import About from './About';
import './App.scss';
import styles from './App.scss';
import Cases from './Cases';
import Configs from './Configs';
import { Layout } from './Layout';
import ManageConfigs from './Administration/ManageConfigs';
import ManageSystemSettings from './Administration/ManageSystemSettings';
import ManageUsers from './ManageUsers';
import Map from './Map';
import Population from './Population';
import Property from './Property';
import Search from './Search';
import { useAppDispatch, useAppSelector } from './app/hooks';
import AuthorizeRoute from './features/api-authorization/AuthorizeRoute';
// import useAuthService from './features/api-authorization/useAuthService';
import { fetchLayers, fetchMapSettings } from './features/map/mapSettingsSlice';
import { fetchSystemSettings } from './features/system-settings/systemSettingsSlice';
import { fetchInitiateSettings } from './features/user-settings/userSettingsSlice';
import { fetchGetUser } from './features/user/userSlice';
import { Redirect, Route, Switch } from 'react-router-dom';
import ManageRoles from './Administration/ManageRoles';


const RemoveAllCSS = () => {
  const [loaded, setLoaded] = useState(false);
  useEffect(() => {
    console.log("styles", styles);
    console.log(" document.querySelectorAll('style')", document.querySelectorAll('style'));
    console.log("querySelectorAll", document.querySelectorAll('link[rel="stylesheet"]'))
    const style = document.querySelectorAll('style')[0];
    // const style2 = document.querySelectorAll('style')[1];
    // const style3 = document.querySelectorAll('style')[3];
    // const style4 = document.querySelectorAll('style')[4];
    // const style5 = document.querySelectorAll('style')[5];
    // const style6 = document.querySelectorAll('style')[6];
    // const style7 = document.querySelectorAll('style')[7];
    // const style8 = document.querySelectorAll('style')[8];
    // const style9 = document.querySelectorAll('style')[9];
    // const style10 = document.querySelectorAll('style')[10];
    // const style11 = document.querySelectorAll('style')[11];
    // const style12 = document.querySelectorAll('style')[12];
    // const style13 = document.querySelectorAll('style')[13];
    // const style14 = document.querySelectorAll('style')[14];
    // const style15 = document.querySelectorAll('style')[15];



    const styleElements = style.remove();
    // Select all style elements and remove them
    // const styleElements = document.querySelectorAll('style');
    // styleElements.forEach((styleElement) => {
    //   console.log("styleElement", styleElement);
    //   styleElement.remove();
    // });

    // Remove all link elements with rel="stylesheet"
    // const linkElements = document.querySelectorAll('link[rel="stylesheet"]');
    // console.log("linkElements", linkElements);
    // linkElements.forEach((linkElement) => {
    //   // if()
    //   linkElement.remove();
    // });
    setLoaded(true);
    return () => {
      console.log("append", style);
      document.head.appendChild(style);
    }
  }, []);

  return (
    <div>
      {/* Your component content */}
      {loaded && <App />}
    </div>
  );
};

function App() {
  const dispatch = useAppDispatch();
  const config = useAppSelector((state) => state.config);
  const hasReceived = useAppSelector((state) => state.userSettings.hasReceived);
  // const { authenticated } = useAuthService();

  useEffect(() => {
    // Remove all existing styles (stylesheets and inline styles)
    // const removeExistingStyles = () => {
    //   // Remove all style elements
    //   const styleElements = document.querySelectorAll('style');
    //   styleElements.forEach((styleElement) => {
    //     styleElement.remove();
    //   });

    //   // Remove all link elements with rel="stylesheet"
    //   const linkElements = document.querySelectorAll('link[rel="stylesheet"]');
    //   linkElements.forEach((linkElement) => {
    //     linkElement.remove();
    //   });

    //   // // Remove inline styles from all elements
    //   // document.querySelectorAll('*').forEach((el) => (el.style = ''));
    // };

    // removeExistingStyles();

    // Add your new CSS file
    // const link = document.createElement('link');
    // link.rel = 'stylesheet';
    // // link.href = '/path/to/your/css/file.css';
    // // link.href = 'https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css';
    // link.href = './App.scss';

    // document.head.appendChild(link);
  }, []); // Empty dependency array ensures the effect runs only once on mount

  useEffect(() => {


    // const applyNewCSS = async () => {
    //   // Dynamically import the CSS file
    //   try {
    //     const module = await import('./App.scss');
    //     console.log("module", module);
    //      const css = module.default;
    //     // const css = styles;


    //     // Create a style element and inject the CSS
    //     const styleElement = document.createElement('style');
    //     styleElement.innerHTML = css;
    //     document.head.appendChild(styleElement);
    //   } catch (error) {
    //     console.error('Error loading CSS:', error);
    //   }
    // };

    // const getStylesheetInfo = () => {
    //   const stylesheets = document.styleSheets;

    //   // Extract information about each stylesheet
    //   const stylesheetInfo = Array.from(stylesheets).map((stylesheet, index) => {
    //     // Check if the stylesheet has a title
    //     const name = stylesheet.title || `Stylesheet ${index + 1}`;

    //     // Check if the stylesheet is external (has an href)
    //     const isExternal = !!stylesheet.href;

    //     // Return an object with the stylesheet information
    //     return {
    //       name,
    //       isExternal,
    //       href: stylesheet,
    //     };
    //   });

    //   return stylesheetInfo;
    // };

    // // Call the function to get the stylesheet names
    // const stylesheetNames = getStylesheetInfo();

    // // Log the names to the console
    // console.log(stylesheetNames);


    const applyNewCSS = () => {
      // Create a style element and inject the CSS
      const styleElement = document.createElement('style');
      console.log("styles", styles);
      styleElement.innerHTML = styles; // Use the imported module directly
      document.head.appendChild(styleElement);
    };


    // Remove existing styles and then apply new CSS
    // removeExistingStyles();
    applyNewCSS();
  }, []);

  // useEffect(() => {
  //   if (authenticated) {
  //     dispatch(fetchInitiateSettings());
  //     dispatch(fetchMapSettings());
  //     dispatch(fetchSystemSettings());
  //     dispatch(fetchLayers());
  //     dispatch(fetchGetUser());
  //   }
  // }, [authenticated, dispatch]);

  useEffect(() => {
    if (true) {
      dispatch(fetchInitiateSettings());
      dispatch(fetchMapSettings());
      dispatch(fetchSystemSettings());
      dispatch(fetchLayers());
      dispatch(fetchGetUser());
    }
  }, [dispatch]);

  // const navbarSubItems = [
  //   {
  //     label: 'Ärenden', to: `/${settings.mainRoute}/cases`, icon: faTasks, permissions: ['IsAdministrator', 'IsReadOnlyUser']
  //   },
  //   {
  //     label: 'Elever', to: `/${settings.mainRoute}/pupils`, icon: faUserFriends, permissions: ['IsAdministrator', 'IsReadOnlyUser']
  //   },
  //   {
  //     label: 'Transporter', to: `/${settings.mainRoute}/transports`, icon: faBus, permissions: ['IsAdministrator', 'IsEntreprenour', 'IsReadOnlyUser']
  //   },
  //   {
  //     label: 'Skolor', to: `/${settings.mainRoute}/schools`, icon: faSchool, permissions: ['IsAdministrator', 'IsReadOnlyUser']
  //   },
  //   {
  //     label: 'Karta', to: `/${settings.mainRoute}/map`, icon: faGlobe, permissions: ['IsAdministrator', 'IsEntreprenour', 'IsReadOnlyUser']
  //   }
  // ];
  // const filteredNavbarSubItemsByPermission = navbarSubItems.filter((x) => x.permissions.some((p) => hasPermission(p)));
  // useProvideNavbarSubItems(filteredNavbarSubItemsByPermission);
  console.log("hasReceived", hasReceived);
  console.log("config", config);
  return (
    <Layout>
      {/* {hasReceived && <AuthorizeRoute exact path='/' element={config ? <Search /> : <Redirect to="/configs" />} />}
      <AuthorizeRoute path='/configs' element={<Configs />} />
      {hasReceived && <AuthorizeRoute path='/search' element={config ? <Search /> : <Redirect to="/configs" />} />}
      {hasReceived && <AuthorizeRoute path='/map' element={config ? <Map /> : <Redirect to="/configs" />} />}
      {hasReceived && <AuthorizeRoute path='/cases' element={config ? <Cases /> : <Redirect to="/configs" />} />}
      {hasReceived && <AuthorizeRoute path='/population' element={config ? <Population /> : <Redirect to="/configs" />} />}
      {hasReceived && <AuthorizeRoute path='/property' element={config ? <Property /> : <Redirect to="/configs" />} />} */}
      {/* <AuthorizeRoute requiredRoles={["Admin"]} path='/manage-users' element={<ManageUsers />} />
      <AuthorizeRoute requiredRoles={["Admin"]} path='/manage-configs' element={<ManageConfigs />} />
      <AuthorizeRoute requiredRoles={["Admin"]} path='/system-settings' element={<ManageSystemSettings />} /> */}


      <Switch>
        {/* <Route path='/' component={() => <AuthorizeRoute path='/search' element={(hasReceived && config) ? <Search /> : <Redirect to="/configs" />} />} /> */}
        <Route path='/configs' component={() => <AuthorizeRoute path='/configs' element={<Configs />} />} />
        <Route path='/search' component={() => <AuthorizeRoute path='/search' element={(hasReceived && config) ? <Search /> : <Redirect to="/configs" />} />} />
        <Route path='/map' component={() => <AuthorizeRoute path='/map' element={(hasReceived && config) ? <Map /> : <Redirect to="/configs" />} />} />
        <Route path='/cases' component={() => <AuthorizeRoute path='/cases' element={(hasReceived && config) ? <Cases /> : <Redirect to="/configs" />} />} />
        <Route path='/population' component={() => <AuthorizeRoute path='/population' element={(hasReceived && config) ? <Population /> : <Redirect to="/configs" />} />} />
        <Route path='/property' component={() => <AuthorizeRoute path='/property' element={(hasReceived && config) ? <Property /> : <Redirect to="/configs" />} />} />
        <Route path='/manage-users' component={() => <AuthorizeRoute requiredRoles={["Admin"]} path='/manage-users' element={<ManageUsers />} />} />
        <Route path='/manage-configs' component={() => <AuthorizeRoute requiredRoles={["Admin"]} path='/manage-configs' element={<ManageConfigs />} />} />
        <Route path='/manage-roles' component={() => <AuthorizeRoute requiredRoles={["Admin"]} path='/manage-roles' element={<ManageRoles />} />} />
        <Route path='/system-settings' component={() => <AuthorizeRoute requiredRoles={["Admin"]} path='/system-settings' element={<ManageSystemSettings />} />} />
        <Route path='/about' component={() => <About />} />
      </Switch>






      {/* <Route path='/' element={<AuthorizeRoute path='/search' element={(hasReceived && config) ? <Search /> : <Navigate to="/configs" />} />} />
      <Route path='/configs' element={<AuthorizeRoute path='/configs' element={<Configs />} />} />
      <Route path='/search' element={<AuthorizeRoute path='/search' element={(hasReceived && config) ? <Search /> : <Navigate to="/configs" />} />} />
      <Route path='/map' element={<AuthorizeRoute path='/map' element={(hasReceived && config) ? <Map /> : <Navigate to="/configs" />} />} />
      <Route path='/cases' element={<AuthorizeRoute path='/cases' element={(hasReceived && config) ? <Cases /> : <Navigate to="/configs" />} />} />
      <Route path='/population' element={<AuthorizeRoute path='/population' element={(hasReceived && config) ? <Population /> : <Navigate to="/configs" />} />} />
      <Route path='/property' element={<AuthorizeRoute path='/property' element={(hasReceived && config) ? <Property /> : <Navigate to="/configs" />} />} />
      <Route path='/manage-users' element={<AuthorizeRoute requiredRoles={["Admin"]} path='/manage-users' element={<ManageUsers />} />} />
      <Route path='/manage-configs' element={<AuthorizeRoute requiredRoles={["Admin"]} path='/manage-configs' element={<ManageConfigs />} />} />
      <Route path='/system-settings' element={<AuthorizeRoute requiredRoles={["Admin"]} path='/system-settings' element={<ManageSystemSettings />} />} />
      <Route path='/about' element={<About />} /> */}
    </Layout>
  );
}

// export default App;
export default RemoveAllCSS;