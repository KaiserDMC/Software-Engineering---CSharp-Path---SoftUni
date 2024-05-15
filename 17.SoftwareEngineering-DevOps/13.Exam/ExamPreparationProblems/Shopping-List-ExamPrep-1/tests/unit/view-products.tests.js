const assert = require('assert');
const fetch = require('node-fetch');

suite('View Shopping List page', function() {
  test('Page title', async function() {
    let res = await fetch("http://localhost:8888/shopping-list");
    let body = await res.text();
    assert.ok(body.includes("<h1>Shopping List</h1>"));
  });
  
  test('My Shopping list', async function() {
    let res = await fetch("http://localhost:8888/shopping-list");
    let body = await res.text();
    let correctList = body.includes("<ul><li>Bread (2.30)</li><li>Cheese (15.97)</li><li>Milk (3.20)</li></ul>");
    assert.ok(correctList, "Shopping list content mismatch");
  });  
});
