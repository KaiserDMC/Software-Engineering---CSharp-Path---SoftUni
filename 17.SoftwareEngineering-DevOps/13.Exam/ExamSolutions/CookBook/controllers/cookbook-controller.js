function setup(app, cookbook) {
  app.get('/', function(req, res) {
    let model = {
      title: "Cookbook",
      msg: "Cookbook",
      cookbook: cookbook
    };
    res.render('home', model);
  });

  app.get('/loaderio-97355a48d08652424ffe033c5cf3d460.txt', function(req, res) {
    res.send('loaderio-97355a48d08652424ffe033c5cf3d460');
  });

  app.get('/cookbook', function(req, res) {
    let model = { title: "Cookbook", cookbook };
    res.render('cookbook', model);
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
    if (paramEmpty(req.body.name) || paramEmpty(req.body.quantity)) {
      let model = {
        title: "Add Product", 
        errMsg: "Cannot add product. Name and quantity fields are required!"
      };
      res.render('add-product', model);
      return;
    }
    let product = {
      name: req.body.name,
      quantity: req.body.quantity
    };
    cookbook.push(product);
    res.redirect('/cookbook');
  });
}

module.exports = { setup };
