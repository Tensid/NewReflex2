import { lazyComponent } from "@sokigo-sbwebb/react";
import { faCog } from "@fortawesome/pro-solid-svg-icons";

export default {
  name: "sokigo-reflex-administration-app",
  title: "Reflex Administration",
  navbar: { title: 'Administration' },
  icon: faCog,
  route: "administration",
  view: lazyComponent(() => import("./AdministrationAppView"))
};
