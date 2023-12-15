const path = require("path");

module.exports = (env, argv) => {
  // eslint-disable-next-line no-unused-vars
  const isProduction = argv && argv.mode === "production";

  return {
    resolve: {
      modules: [path.resolve("./src")],
    },
    devServer: {
      port: 44362,
    },
  };
};
