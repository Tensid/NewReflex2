import { SVGProps } from "react";

const SvgComponent = (props: SVGProps<SVGSVGElement>) => (
  <svg
    xmlns="http://www.w3.org/2000/svg"
    {...props}
    viewBox="0 0 510 510"
  >
    <path
      d="M229.5 382.5h51v-153h-51v153zM255 0C114.75 0 0 114.75 0 255s114.75 255 255 255 255-114.75 255-255S395.25 0 255 0zm0 459c-112.2 0-204-91.8-204-204S142.8 51 255 51s204 91.8 204 204-91.8 204-204 204zm-25.5-280.5h51v-51h-51v51z"
      style={{
        fill: "var(--ol-subtle-foreground-color)"
      }}
    />
  </svg>
);

export default SvgComponent;
