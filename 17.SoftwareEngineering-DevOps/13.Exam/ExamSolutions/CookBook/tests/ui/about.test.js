const { test, expect } = require("@playwright/test");

test("Check about page", async ({ page }) => {
	await page.goto("http://localhost:8080/about");
	const heading = await page.$("h1");
	const text = await heading.textContent();
	expect(text).toBe("About");
});

test("Check about page test", async ({ page }) => {
	await page.goto("http://localhost:8080/about");
	const heading = await page.$("p");
	const text = await heading.textContent();
	expect(text).toBe(
		"This is the Regular exam for Software Engineering and DevOps course @ SoftUni",
	);
});
