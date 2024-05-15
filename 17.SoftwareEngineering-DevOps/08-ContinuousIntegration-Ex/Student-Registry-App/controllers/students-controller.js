function setup(app, students) {
  app.get('/', function(req, res) {
    let model = {
      title: "MVC Example",
      msg: "Students Registry",
      students: students
    };
    res.render('home', model);
  });
  
  app.get('/loaderio-97355a48d08652424ffe033c5cf3d460.txt', function(req, res) {
    res.send('loaderio-97355a48d08652424ffe033c5cf3d460');
  });

  app.get('/students', function(req, res) {
    let model = {title: "Students", students};
    res.render('students', model);
  });

  app.get('/about', function(req, res) {
    let model = {title: "About"};
    res.render('about', model);
  });

  app.get('/add-student', function(req, res) {
    let model = {title: "Add Student"};
    res.render('add-student', model);
  });

  function paramEmpty(p) {
    if (typeof(p) != 'string')
      return true;
    if (p.trim().length == 0)
      return true;
    return false;
  }

  app.post('/add-student', function(req, res) {
    if (paramEmpty(req.body.name) || paramEmpty(req.body.email) ) {
      let model = {
        title: "Add Student", 
        errMsg: "Cannot add student. Name and email fields are required!"
      };
      res.render('add-student', model);
      return;
    }
    let student = {
      name: req.body.name,
      email: req.body.email
    };
    students.push(student);
    res.redirect('/students');
  });
}

module.exports = { setup };
