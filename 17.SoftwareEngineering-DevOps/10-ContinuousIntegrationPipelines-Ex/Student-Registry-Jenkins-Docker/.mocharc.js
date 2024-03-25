// .mocharc.js - Mocha config file
const {colors, symbols} = 
  require('mocha/lib/reporters/base');
// Change the default console UI colors
colors.pass = 32;
colors.fail = 33;
colors["error stack"] = 36;
colors["error message"] = 33;

// Example config from Mocha repo       
module.exports = {
    diff: true,
    extension: ['js'],
    package: './package.json',
    reporter: 'spec',
    slow: 75,
    timeout: 3000,
    ui: 'tdd',
    'watch-files': ['lib/**/*.js','test/**/*.js'],
    'watch-ignore': ['lib/vendor']
  };