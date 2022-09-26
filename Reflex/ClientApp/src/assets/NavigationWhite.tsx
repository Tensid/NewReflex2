import { SVGProps } from "react";

const SvgComponent = (props: SVGProps<SVGSVGElement>) => (
  <svg
    xmlns="http://www.w3.org/2000/svg"
    viewBox="0 0 384 384"
    xmlSpace="preserve"
    {...props}
  >
    <path
      style={{
        fill: "var(--ol-subtle-foreground-color)"
      }}
      d="M0 160.747v21.013l145.813 56.533L202.347 384h21.013L384 0z"
    />
  </svg>
);

export default SvgComponent;
