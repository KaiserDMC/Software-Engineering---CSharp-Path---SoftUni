const mongoose = require('mongoose');

const bookSchema = new mongoose.Schema({
  bookName: {
    type: String,
    trim: true,
  },
  author: String,
  readDate: Date,
  read: Boolean
});

module.exports = mongoose.model('Book', bookSchema);