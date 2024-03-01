const fs = require('fs');
const path = require('path');

const express = require('express');
const mongoose = require('mongoose');
const bodyParser = require('body-parser');
const morgan = require('morgan');

const Product = require('./models/product');

const app = express();

const accessLogStream = fs.createWriteStream(
  path.join(__dirname, 'logs', 'access.log'),
  { flags: 'a' }
);

app.use(morgan('combined', { stream: accessLogStream }));

app.use(bodyParser.json());

app.use((req, res, next) => {
  res.setHeader('Access-Control-Allow-Origin', '*');
  res.setHeader('Access-Control-Allow-Methods', 'GET, POST, DELETE, OPTIONS');
  res.setHeader('Access-Control-Allow-Headers', 'Content-Type');
  next();
});

app.get('/products', async (req, res) => {
  console.log('TRYING TO FETCH PRODUCTS');
  try {
    const products = await Product.find();
    res.status(200).json({
      products: products.map((product) => ({
        id: product.id,
        text: product.text,
      })),
    });
    console.log('FETCHED PRODUCTS');
  } catch (err) {
    console.error('ERROR FETCHING PRODUCTS');
    console.error(err.message);
    res.status(500).json({ message: 'Failed to load products.' });
  }
});

app.post('/products', async (req, res) => {
  console.log('TRYING TO STORE PRODUCTS');
  const productText = req.body.text;

  if (!productText || productText.trim().length === 0) {
    console.log('INVALID INPUT - NO TEXT');
    return res.status(422).json({ message: 'Invalid product text.' });
  }

  const product = new Product({
    text: productText,
  });

  try {
    await product.save();
    res
      .status(201)
      .json({ message: 'Product saved', product: { id: product.id, text: productText } });
    console.log('STORED NEW PRODUCT');
  } catch (err) {
    console.error('ERROR FETCHING PRODUCTS');
    console.error(err.message);
    res.status(500).json({ message: 'Failed to save product.' });
  }
});

app.delete('/products/:id', async (req, res) => {
  console.log('TRYING TO DELETE PRODUCT');
  try {
    await Product.deleteOne({ _id: req.params.id });
    res.status(200).json({ message: 'Deleted product!' });
    console.log('DELETED PRODUCT');
  } catch (err) {
    console.error('ERROR FETCHING PRODUCTS');
    console.error(err.message);
    res.status(500).json({ message: 'Failed to delete product.' });
  }
});

mongoose.connect(
  `mongodb://max:secret@mongodb:27017/list-products?authSource=admin`,
  {
    useNewUrlParser: true,
    useUnifiedTopology: true,
  },
  (err) => {
    if (err) {
      console.error('FAILED TO CONNECT TO MONGODB');
      console.error(err);
    } else {
      console.log('CONNECTED TO MONGODB!!');
      app.listen(80);
    }
  }
);
