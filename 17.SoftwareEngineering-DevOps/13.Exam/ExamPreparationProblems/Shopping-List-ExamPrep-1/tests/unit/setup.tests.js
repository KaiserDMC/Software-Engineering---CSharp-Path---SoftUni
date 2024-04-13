let server;

setup(function() {
  let products = [
    {"name" : "Bread", "price" : "2.30"},
    {"name" : "Cheese", "price" : "15.97"},
    {"name" : "Milk", "price" : "3.20"}
  ];
  const express = require('express');
  const app = express();
  server = require('http').createServer(app);
  app.set('view engine', 'pug');
  app.use(require('body-parser')
    .urlencoded({extended:true}));
  const shoppingListController = 
    require("../../controllers/shoppingList-controller");
    shoppingListController.setup(app, products);
  server.listen(8888);
});

teardown(function() {
  server.close();
});
