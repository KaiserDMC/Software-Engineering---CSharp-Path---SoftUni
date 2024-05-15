const { test, expect } = require("@playwright/test");

test("Check shopping list page", async ({ page }) => {
	await page.goto("http://localhost:8080/shopping-list");
	const list = await page.$("ul");
	expect(list).toBeTruthy();
});
