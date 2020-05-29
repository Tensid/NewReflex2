export function setTopowebbConfig(coordinateSystem) {
  let topowebbConfig = {};

  topowebbConfig.resolutions = [256, 128, 64, 32, 16, 8, 4, 2, 1, 0.5, 0.25, 0.125, 0.0625, 0.03125, 0.015625];

  const origins = {
    'EPSG:3006': [218128.7031, 7692850.9468],
    'EPSG:3007': [60436.5084, 6682784.4276],
    'EPSG:3008': [60857.4994, 6906693.7888],
    'EPSG:3009': [56294.0365, 6835499.2391],
    'EPSG:3010': [97213.6352, 6916524.0785],
    'EPSG:3011': [96664.5565, 6727103.5879],
    'EPSG:3012': [30462.5263, 7154168.0208],
    'EPSG:3013': [34056.6264, 7224144.732],
    'EPSG:3014': [-1420.28, 7459585.3378],
    'EPSG:3015': [58479.4774, 7276832.4419],
    'EPSG:3016': [-93218.3385, 7676279.8691],
    'EPSG:3017': [67451.0699, 7254837.254],
    'EPSG:3018': [38920.7048, 7597992.2419]
  };

  if (!Object.prototype.hasOwnProperty.call(origins, coordinateSystem)) {
    throw new Error(`'${coordinateSystem}' är ett okänt koordinatsystem`);
  }

  topowebbConfig.origin = origins[coordinateSystem];

  topowebbConfig.matrixIds = [
    coordinateSystem + ':0', coordinateSystem + ':1', coordinateSystem + ':2', coordinateSystem + ':3',
    coordinateSystem + ':4', coordinateSystem + ':5', coordinateSystem + ':6', coordinateSystem + ':7',
    coordinateSystem + ':8', coordinateSystem + ':9', coordinateSystem + ':10',
    coordinateSystem + ':11', coordinateSystem + ':12', coordinateSystem + ':13',
    coordinateSystem + ':14'
  ];

  return topowebbConfig;
}
