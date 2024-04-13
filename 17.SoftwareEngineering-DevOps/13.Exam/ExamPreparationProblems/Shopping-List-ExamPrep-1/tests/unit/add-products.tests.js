const assert = require('assert');
const fetch = require('node-fetch');

suite('Add Products page', function() {
  test('Page title', async function() {
    let res = await fetch("http://localhost:8888/add-product");
    let body = await res.text();
    assert.ok(body.includes("<h1>Add New Product</h1>"));
  });

  test('Product HTML form', async function() {
    let res = await fetch("http://localhost:8888/Add-Product");
    let body = await res.text();
    
    let nameFieldFound = body.includes('<input id="name" type="text" name="name"/>');
    assert.ok(nameFieldFound, "Field 'name' is missing");

    let priceFieldFound = body.includes('<input id="price" type="text" name="price"/>');
    assert.ok(priceFieldFound, "Field 'price' is missing");

    let buttonAddFound = body.includes('<button type="submit">Add</button>');
    assert.ok(buttonAddFound, "Button [Add] is missing");
  });

  test('Add valid product', async function() {
    let res = await fetch(
      "http://localhost:8888/Add-Product",
      {
        method: 'POST',
        headers: {
          "Content-Type": "application/x-www-form-urlencoded"
        },
        body: "name=Salami&price=17.75"
      }
    );
    let body = await res.text();
    let productsReturned = body.includes(
		"<ul><li>Bread (2.30)</li><li>Cheese (15.97)</li><li>Milk (3.20)</li><li>Salami (17.75)</li></ul>");
    assert.ok(productsReturned, "Add product failed");
  });

  test('Add invalid product', async function() {
     let res = await fetch(
      "http://localhost:8888/Add-Product",
      {
        method: 'POST',
        headers: {
          "Content-Type": "application/x-www-form-urlencoded"
        },
        body: "name=&price=15.97"
      }
    );
    let body = await res.text();
    let errMsg = body.includes("Cannot add product. Name and price fields are required!");
    assert.ok(errMsg, "Add invalid product should display an error message");

    res = await fetch("http://localhost:8888/");
    body = await res.text();
	  assert.ok(body.includes("Shopping List: <b>3</b>"), 
		"Add invalid product should not change the products count");
  });
});
