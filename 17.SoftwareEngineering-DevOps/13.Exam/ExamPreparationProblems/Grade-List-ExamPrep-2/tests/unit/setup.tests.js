let server;

setup(function() {
  let products = [
    {"subject" : "English", "value" : "5.50"},
    {"subject" : "Math", "value" : "4.50"},
    {"subject" : "Programming Basics", "value" : "6.00"}
  ];
  const express = require('express');
  const app = express();
  server = require('http').createServer(app);
  app.set('view engine', 'pug');
  app.use(require('body-parser')
    .urlencoded({extended:true}));
  const gradesController = 
    require("../../controllers/grades-controller");
    gradesController.setup(app, products);
  server.listen(8888);
});

teardown(function() {
  server.close();
});