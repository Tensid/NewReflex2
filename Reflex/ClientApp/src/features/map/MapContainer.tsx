import { CSSProperties, FC, ReactNode, useEffect, useRef } from 'react';
import { useMap } from './MapProvider';

interface MapContainerProps {
  className: string | undefined;
  style?: CSSProperties | undefined;
  children?: ReactNode;
}

export const MapContainer: FC<MapContainerProps> = ({ className, style, children }) => {
  const containerRef = useRef(null);
  const map = useMap();

  useEffect(() => {
    const container = containerRef.current! as Element;
    if (!container || !map) return;
    // @ts-ignore
    const resizeObserver = new ResizeObserver(() => {
      map.updateSize();
    });
    resizeObserver.observe(container);

    return () => {
      resizeObserver.unobserve(container);
    };
  }, [containerRef, map]);

  return (
    <div
      className={className}
      id="map"
      style={style}
      ref={containerRef}
    >
      {children}
    </div>
  );
};
