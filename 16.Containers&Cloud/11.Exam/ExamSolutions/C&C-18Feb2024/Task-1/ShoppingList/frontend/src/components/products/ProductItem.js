import React from 'react';

import './ProductItem.css';

function ProductItem(props) {
  return <li className="product-item" onClick={props.onDelete.bind(null, props.id)}>{props.text}</li>;
}

export default ProductItem;
