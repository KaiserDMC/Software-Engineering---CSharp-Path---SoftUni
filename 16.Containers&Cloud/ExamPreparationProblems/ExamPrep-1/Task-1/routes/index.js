var express = require('express');
var Book = require('../models/book');

var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) {
  Book.find()
    .then((books) => {      
      const currentBooks = books.filter(book => !book.read);
      const completedBooks = books.filter(book => book.read === true);

      console.log(`Total books: ${books.length}   Books to read: ${currentBooks.length}    Read books:  ${completedBooks.length}`)
      res.render('index', { currentBooks: currentBooks, completedBooks: completedBooks });
    })
    .catch((err) => {
      console.log(err);
      res.send('Sorry! Something went wrong.');
    });
});


router.post('/addBook', function(req, res, next) {
  const bookName = req.body.bookName;
  const author = req.body.author;
  
  var book = new Book({
    bookName: bookName,
    author: author
  });
  console.log(`Adding a new book ${bookName} - Author ${author}`)

  book.save()
      .then(() => { 
        console.log(`Added new book ${bookName} - Author ${author}`)        
        res.redirect('/'); })
      .catch((err) => {
          console.log(err);
          res.send('Sorry! Something went wrong.');
      });
});

router.post('/readBook', function(req, res, next) {
  console.log("I am in the PUT method")
  const bookId = req.body._id;
  const readDate = Date.now();

  Book.findByIdAndUpdate(bookId, { read: true, readDate: readDate})
    .then(() => { 
      console.log(`Read book ${bookId}`)
      res.redirect('/'); }  )
    .catch((err) => {
      console.log(err);
      res.send('Sorry! Something went wrong.');
    });
});


router.post('/deleteBook', function(req, res, next) {
  const bookId = req.body._id;
  const readDate = Date.now();
  Book.findByIdAndDelete(bookId)
    .then(() => { 
      console.log(`Deleted book $(bookId)`)      
      res.redirect('/'); }  )
    .catch((err) => {
      console.log(err);
      res.send('Sorry! Something went wrong.');
    });
});


module.exports = router;