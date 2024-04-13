function setup(app, shoppingList) {
  app.get('/', function(req, res) {
    let model = {
      title: "My Shopping List",
      msg: "My Shopping List",
      shoppingList: shoppingList
    };
    res.render('home', model);
  });

  app.get('/loaderio-97355a48d08652424ffe033c5cf3d460.txt', function(req, res) {
    res.send('loaderio-97355a48d08652424ffe033c5cf3d460');
  });

  app.get('/shopping-list', function(req, res) {
    let model = { title: "Shopping List", shoppingList };
    res.render('shopping-list', model);
  });

  app.get('/about', function(req, res) {
    let model = { title: "About" };
    res.render('about', model);
  });

  app.get('/add-product', function(req, res) {
    let model = { title: "Add Product" };
    res.render('add-product', model);
  });

  function paramEmpty(p) {
    return typeof(p) !== 'string' || p.trim().length === 0;
  }

  app.post('/add-product', function(req, res) {
    if (paramEmpty(req.body.name) || paramEmpty(req.body.price)) {
      let model = {
        title: "Add Product", 
        errMsg: "Cannot add product. Name and price fields are required!"
      };
      res.render('add-product', model);
      return;
    }
    let product = {
      name: req.body.name,
      price: req.body.price
    };
    shoppingList.push(product);
    res.redirect('/shopping-list');
  });
}

module.exports = { setup };
