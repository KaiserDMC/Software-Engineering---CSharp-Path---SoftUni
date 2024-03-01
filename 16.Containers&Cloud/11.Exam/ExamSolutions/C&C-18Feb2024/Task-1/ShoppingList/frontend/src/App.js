import React, { useState, useEffect } from 'react';

import ProductInput from './components/products/ProductInput';
import ListProducts from './components/products/ListProducts';
import ErrorAlert from './components/UI/ErrorAlert';

function App() {
  const [loadedProducts, setLoadedProducts] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  useEffect(function () {
    async function fetchData() {
      setIsLoading(true);

      try {
        const response = await fetch('http://localhost/products');

        const resData = await response.json();

        if (!response.ok) {
          throw new Error(resData.message || 'Fetching the products failed.');
        }

        setLoadedProducts(resData.products);
      } catch (err) {
        setError(
          err.message ||
            'Fetching products failed - the server responsed with an error.'
        );
      }
      setIsLoading(false);
    }

    fetchData();
  }, []);

  async function addProductHandler(productText) {
    setIsLoading(true);

    try {
      const response = await fetch('http://localhost/products', {
        method: 'POST',
        body: JSON.stringify({
          text: productText,
        }),
        headers: {
          'Content-Type': 'application/json'
        }
      });

      const resData = await response.json();

      if (!response.ok) {
        throw new Error(resData.message || 'Adding the product failed.');
      }

      setLoadedProducts((prevProducts) => {
        const updatedProducts = [
          {
            id: resData.product.id,
            text: productText,
          },
          ...prevProducts,
        ];
        return updatedProducts;
      });
    } catch (err) {
      setError(
        err.message ||
          'Adding a product failed - the server responsed with an error.'
      );
    }
    setIsLoading(false);
  }

  async function deleteProductHandler(productId) {
    setIsLoading(true);

    try {
      const response = await fetch('http://localhost/products/' + productId, {
        method: 'DELETE',
      });

      const resData = await response.json();

      if (!response.ok) {
        throw new Error(resData.message || 'Deleting the product failed.');
      }

      setLoadedProducts((prevProducts) => {
        const updatedProducts = prevProducts.filter((product) => product.id !== productId);
        return updatedProducts;
      });
    } catch (err) {
      setError(
        err.message ||
          'Deleting the product failed - the server responsed with an error.'
      );
    }
    setIsLoading(false);
  }

  return (
    <div>
      {error && <ErrorAlert errorText={error} />}
      <ProductInput onAddProduct={addProductHandler} />
      {!isLoading && (
        <ListProducts products={loadedProducts} onDeleteProduct={deleteProductHandler} />
      )}
    </div>
  );
}

export default App;
