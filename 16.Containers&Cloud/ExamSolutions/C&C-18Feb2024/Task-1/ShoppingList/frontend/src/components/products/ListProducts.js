import React from 'react';

import './ListProducts.css';
import Card from '../UI/Card';
import ProductItem from './ProductItem';

function ListProducts(props) {
  const hasNoProducts = !props.products || props.products.length === 0;

  return (
    <section id='list-product'>
      <Card>
        <h2>Your Products</h2>
        {hasNoProducts && <h2>No products found. Start adding some!</h2>}
        <ul>
          {props.products.map((product) => (
            <ProductItem
              key={product.id}
              id={product.id}
              text={product.text}
              onDelete={props.onDeleteProduct}
            />
          ))}
        </ul>
      </Card>
    </section>
  );
}

export default ListProducts;
