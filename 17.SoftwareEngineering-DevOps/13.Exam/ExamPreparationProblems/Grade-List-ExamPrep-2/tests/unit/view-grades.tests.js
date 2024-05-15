const assert = require("assert");
const fetch = require("node-fetch");

suite("View My Grades page", function () {
	test("Page title", async function () {
		let res = await fetch("http://localhost:8888/my-grades");
		let body = await res.text();
		assert.ok(body.includes("<h1>My Grades</h1>"));
	});

	test("My Grades", async function () {
		let res = await fetch("http://localhost:8888/my-grades");
		let body = await res.text();
		let correctList = body.includes(
			"<ul><li>English (5.50)</li><li>Math (4.50)</li><li>Programming Basics (6.00)</li></ul>",
		);
		assert.ok(correctList, "Grades list content mismatch");
	});
});
