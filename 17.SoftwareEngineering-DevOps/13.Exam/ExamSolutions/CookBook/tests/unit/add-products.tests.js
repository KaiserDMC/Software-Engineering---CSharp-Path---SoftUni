const assert = require("assert");
const fetch = require("node-fetch");

suite("Add Products page", function () {
	test("Page title", async function () {
		let res = await fetch("http://localhost:8888/add-product");
		let body = await res.text();
		assert.ok(body.includes("<h1>Add New Product</h1>"));
	});

	test("Product HTML form", async function () {
		let res = await fetch("http://localhost:8080/Add-Product");
		let body = await res.text();

		let nameFieldFound = body.includes(
			'<input id="name" type="text" name="name"/>',
		);
		assert.ok(nameFieldFound, "Field 'name' is missing");

		let quantityFieldFound = body.includes(
			'<input id="quantity" type="text" name="quantity"/>',
		);
		assert.ok(quantityFieldFound, "Field 'quantity' is missing");

		let buttonAddFound = body.includes('<button type="submit">Add</button>');
		assert.ok(buttonAddFound, "Button [Add] is missing");
	});

	test("Add valid product", async function () {
		let res = await fetch("http://localhost:8888/Add-Product", {
			method: "POST",
			headers: {
				"Content-Type": "application/x-www-form-urlencoded",
			},
			body: "name=Salami&quantity=100 g",
		});
		let body = await res.text();
		let productsReturned = body.includes(
			"<ul><li>Water - 1 cup</li><li>Eggs - 3</li><li>Flour - 1 cup</li><li>Salami - 100 g</li></ul>",
		);
		assert.ok(productsReturned, "Add product failed");
	});

	test("Add invalid product", async function () {
		let res = await fetch("http://localhost:8888/Add-Product", {
			method: "POST",
			headers: {
				"Content-Type": "application/x-www-form-urlencoded",
			},
			body: "name=&quantity=100 g",
		});
		let body = await res.text();
		let errMsg = body.includes(
			"Cannot add product. Name and quantity fields are required!",
		);
		assert.ok(errMsg, "Add invalid product should display an error message");

		res = await fetch("http://localhost:8888/");
		body = await res.text();
		assert.ok(
			body.includes("Cookbook: <b>3</b>"),
			"Add invalid product should not change the products count",
		);
	});
});
