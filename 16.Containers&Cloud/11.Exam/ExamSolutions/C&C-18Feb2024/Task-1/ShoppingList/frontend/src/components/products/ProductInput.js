import React, { useState } from 'react';

import './ProductInput.css';
import Card from '../UI/Card';

function ProductInput(props) {
  const [enteredProductText, setEnteredProductText] = useState('');

  function updateProductTextHandler(event) {
    setEnteredProductText(event.target.value);
  }

  function productSubmitHandler(event) {
    event.preventDefault();

    if (enteredProductText.trim().length === 0) {
      alert('Invalid text - please enter a longer one!');
      return;
    }

    props.onAddProduct(enteredProductText);

    setEnteredProductText('');
  }

  return (
    <section id='product-input'>
      <Card>
        <form onSubmit={productSubmitHandler}>
          <label htmlFor='text'>New Product</label>
          <input
            type='text'
            id='text'
            value={enteredProductText}
            onChange={updateProductTextHandler}
          />
          <button>Add Product</button>
        </form>
      </Card>
    </section>
  );
}

export default ProductInput;
