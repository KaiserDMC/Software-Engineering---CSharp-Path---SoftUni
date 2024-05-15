const assert = require("assert");
const fetch = require("node-fetch");

suite("View Cookbook page", function () {
	test("Page title", async function () {
		let res = await fetch("http://localhost:8888/cookbook");
		let body = await res.text();
		assert.ok(body.includes("<h1>Cookbook</h1>"));
	});

	test("My Cookbook", async function () {
		let res = await fetch("http://localhost:8888/cookbook");
		let body = await res.text();

		let correctList = body.includes(
			"<ul><li>Water - 1 cup</li><li>Eggs - 3</li><li>Flour - 1 cup</li></ul>",
		);
		assert.ok(correctList, "Cookbook content mismatch");
	});
});
