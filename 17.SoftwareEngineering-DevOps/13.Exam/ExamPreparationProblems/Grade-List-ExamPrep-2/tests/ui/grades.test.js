const { test, expect } = require("@playwright/test");

test("Check grades page", async ({ page }) => {
	await page.goto("http://localhost:8080/my-grades");
	const list = await page.$("ul");
	expect(list).toBeTruthy();
});
