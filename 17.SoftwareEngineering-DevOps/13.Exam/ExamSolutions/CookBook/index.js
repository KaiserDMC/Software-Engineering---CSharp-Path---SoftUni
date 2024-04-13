const express = require('express');
const app = express();
app.set('view engine', 'pug');
app.use(require('body-parser').urlencoded({ extended: true }));

const cookbookController = require("./controllers/cookbook-controller");
let cookbook = require("./models/cookbook");

cookbookController.setup(app, cookbook);

let port = process.argv[2];
if (!port) port = process.env['PORT'];
if (!port) port = 8080;

app.listen(port, () => {
  console.log(`App started. Listening at http://localhost:${port}`);
})
.on('error', function(err) {
  if (err.errno === 'EADDRINUSE')
    console.error(`Port ${port} busy.`);
  else 
    throw err;
});
