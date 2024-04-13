const assert = require('assert');
const fetch = require('node-fetch');

suite('Home page', function() {
  test('Page title', async function() {
    let res = await fetch("http://localhost:8888/");
    let body = await res.text();
    assert.ok(body.includes("<h1>My Grades</h1>"));
  });
  
  test('Grades count', async function() {
    let res = await fetch("http://localhost:8888/");
    let body = await res.text();
    assert.ok(body.includes("Grades: <b>3</b>"));
  });
});
