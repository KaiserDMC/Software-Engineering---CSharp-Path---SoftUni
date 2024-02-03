function setup(app, data) {
  app.get('/', function(req, res) {
    let contacts = data.getContacts();
    let model = { contacts };
    res.render('home', model);
  });

  app.get('/contacts', function(req, res) {
    let contacts = data.getContacts();
    let model = { contacts };
    res.render('contacts', model);
  });

  app.get('/contacts/create', function(req, res) {
      let model = {
        firstName: "", lastName: "",
        email: "", phone: "", comments: ""
      };
      res.render('create-contact', model);
  });

  app.post('/contacts/create', function(req, res) {
    let result = data.addContact(
      req.body.firstName, req.body.lastName,
      req.body.email, req.body.phone, req.body.comments);
    if (result.errMsg) {
      let model = {
        firstName: req.body.firstName, lastName: req.body.lastName,
        email: req.body.email, phone: req.body.phone,
        comments: req.body.comments,
        errMsg: result.errMsg
      };
      return res.render('create-contact', model);
    } else {
      res.redirect('/contacts');
    }
  });

  app.get('/contacts/search', function(req, res) {
    model = { keyword: "" };
    if (req.query.keyword) {
      model.keyword = req.query.keyword;
      let contacts = data.findContactsByKeyword(req.query.keyword);
      model.contacts = contacts;
    }

    res.render('search-contacts', model);
  });

  app.get('/contacts/:id', function(req, res) {
    let contact = data.findContactById(req.params.id);
    if (contact.errMsg) {
      model = {errText: 'Contact Not Found', 
        errDetails: contact.errMsg};
      res.render('error', model);
    }
    else { 
      let model = { contact };
	    res.render('contact-details', model);
    }
  });

  app.get('/contacts/find/:keyword', function(req, res) {
    let contacts = data.findContactByKeyword(req.params.keyword);
    let model = { contacts };
	  res.render('contacts', model);
  });
}

module.exports = { setup };
