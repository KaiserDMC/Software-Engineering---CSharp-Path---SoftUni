const express = require('express');
const server = express();
const bodyParser = require('body-parser');

server.use(bodyParser.json());

let books = [];

server.get('/books', (req, res) => {
    res.json(books);
});

server.post('/books', (req, res) => {
    const book = req.body;
    books.push(book);
    res.status(201).json(book);
});

server.get('/books/:id', (req, res) => {
    const book = books.find(b => b.id === req.params.id);
    if (book) res.json(book);
    else res.status(404).json({ message: 'Book not found' });
});

server.put('/books/:id', (req, res) => {
    const bookIndex = books.findIndex(b => b.id === req.params.id);
    if (bookIndex > -1) {
        books[bookIndex] = req.body;
        res.json(books[bookIndex]);
    } else {
        res.status(404).json({ message: 'Book not found' });
    }
});

server.delete('/books/:id', (req, res) => {
    const bookIndex = books.findIndex(b => b.id === req.params.id);
    if (bookIndex > -1) {
        books.splice(bookIndex, 1);
        res.status(204).end();
    } else {
        res.status(404).json({ message: 'Book not found' });
    }
});

server.listen(3000, () => console.log('Server is up and running'));

module.exports = server; // Exporting for testing