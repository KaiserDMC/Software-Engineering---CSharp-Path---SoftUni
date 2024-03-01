function setup(app, data) {
  app.get('/api', function(req, res) {
    let routes = app._router.stack
      .filter(r => r.route && r.route.path.startsWith('/api'))
    .map(rt => ({
      route: rt.route.path,
      method: rt.route.stack[0].method
    }));
    res.send(routes);
  });

  app.get('/api/contacts', function(req, res) {
    let result = data.getContacts();
    res.send(result);
  });

  app.get('/api/contacts/search/:keyword', async function(req, res) {
    let result = data.findContactsByKeyword(req.params.keyword);
    if (result.errMsg)
      res.status(404).send(result);
    else
      res.send(result);
  });

  app.get('/api/contacts/:id', function(req, res) {
    let result = data.findContactById(req.params.id);
    if (result.errMsg)
      res.status(404).send(result);
    else
      res.send(result);
  });

  app.post('/api/contacts', function(req, res) {
    let result = data.addContact(
	  req.body.firstName, req.body.lastName,
	  req.body.email, req.body.phone, req.body.comments);
    if (result.errMsg)
      res.status(400).send(result);
    else
      res.status(201).send(result);
  });
  
  app.delete('/api/contacts/:id', function(req, res) {
    let result = data.deleteContactById(req.params.id);
    if (result.errMsg)
      res.status(404).send(result);
    else
      res.send(result);
  });
}

module.exports = { setup };
