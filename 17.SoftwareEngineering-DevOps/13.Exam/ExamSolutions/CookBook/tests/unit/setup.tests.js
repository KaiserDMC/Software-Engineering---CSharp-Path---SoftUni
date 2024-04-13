let server;

setup(function() {
  let products = [
    {"name" : "Water", "quantity" : "1 cup"},
    {"name" : "Eggs", "quantity" : "3"},
    {"name" : "Flour", "quantity" : "1 cup"}
  ];
  const express = require('express');
  const app = express();
  server = require('http').createServer(app);
  app.set('view engine', 'pug');
  app.use(require('body-parser')
    .urlencoded({extended:true}));
  const cookbookController = 
    require("../../controllers/cookbook-controller");
    cookbookController.setup(app, products);
  server.listen(8888);
});

teardown(function() {
  server.close();
});
