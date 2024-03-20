const { test, expect } = require("@playwright/test");

const baseUrl = "http://localhost:3000";

// 1. Guest user tests

// Test for "All Books" link
test("Verify 'All Books' links is visible", async ({ page }) => {
	await page.goto(baseUrl);

	await page.waitForSelector("nav.navbar");

	const allBooksLink = await page.$('a[href="/catalog"]');

	const isLinkVisible = await allBooksLink.isVisible();
	expect(isLinkVisible).toBe(true);
});

// Test for "Login" button
test("Verify 'Login' buttons is visible", async ({ page }) => {
	await page.goto(baseUrl);

	await page.waitForSelector("nav.navbar");

	const loginButton = await page.$('a[href="/login"]');

	const isLoginButtonVisible = await loginButton.isVisible();
	expect(isLoginButtonVisible).toBe(true);
});

// Test for "Register" button
test("Verify 'Register' buttons is visible", async ({ page }) => {
	await page.goto(baseUrl);

	await page.waitForSelector("nav.navbar");

	const registerButton = await page.$('a[href="/register"]');

	const isRegisterButtonVisible = await registerButton.isVisible();
	expect(isRegisterButtonVisible).toBe(true);
});

// 2. Logged-in user tests

// Test for "All Books" link
test("Verify 'All Books' links is visible after user login", async ({
	page,
}) => {
	await page.goto(`${baseUrl}/login`);

	await page.fill("#email", "peter@abv.bg");
	await page.fill("#password", "123456");
	await page.click('input[type="submit"]');

	const allBooksLink = await page.$('a[href="/catalog"]');

	const isLinkVisible = await allBooksLink.isVisible();
	expect(isLinkVisible).toBe(true);
});

// Test for "My Books" link
test("Verify 'My Books' links is visible after user login", async ({
	page,
}) => {
	await page.goto(`${baseUrl}/login`);

	await page.fill("#email", "peter@abv.bg");
	await page.fill("#password", "123456");
	await page.click('input[type="submit"]');

	const myBooksLink = await page.$('a[href="/profile"]');

	const isLinkVisible = await myBooksLink.isVisible();
	expect(isLinkVisible).toBe(true);
});

// Test for email field
test("Verify email field (user) is visible after user login", async ({
	page,
}) => {
	await page.goto(`${baseUrl}/login`);

	await page.fill("#email", "peter@abv.bg");
	await page.fill("#password", "123456");
	await page.click('input[type="submit"]');

	const userEmailField = await page.$("#user > span");

	const isEmailVisible = await userEmailField.isVisible();
	expect(isEmailVisible).toBe(true);

	// Check if the email is actually inside the span
	const emailIncludesValue = (await userEmailField.innerHTML()).includes(
		"peter@abv.bg",
	);
	expect(emailIncludesValue).toBe(true);
});

// 3. Login page tests

// Test form with valid credentials
test("Login with valid credentials", async ({ page }) => {
	await page.goto(`${baseUrl}/login`);

	await page.fill("#email", "peter@abv.bg");
	await page.fill("#password", "123456");
	await page.click('input[type="submit"]');

	await page.$('a[href="/catalog"]');
	expect(page.url()).toBe(`${baseUrl}/catalog`);
});

// Test form with empty credentials
test("Login with empty credentials", async ({ page }) => {
	await page.goto(`${baseUrl}/login`);

	// Submit empty
	await page.click('input[type="submit"]');

	// Check the alert box
	page.on("dialog", async (dialog) => {
		expect(dialog.type()).toContain("alert");
		expect(dialog.message()).toContain("All fields are required!");
		await dialog.accept();
	});

	// Check the redirect
	await page.$('a[href="/login"]');
	expect(page.url()).toBe(`${baseUrl}/login`);
});

// Test form with empty email credentials
test("Login with empty email credentials", async ({ page }) => {
	await page.goto(`${baseUrl}/login`);

	await page.fill("#password", "123456");
	await page.click('input[type="submit"]');

	// Check the alert box
	page.on("dialog", async (dialog) => {
		expect(dialog.type()).toContain("alert");
		expect(dialog.message()).toContain("All fields are required!");
		await dialog.accept();
	});

	// Check the redirect
	await page.$('a[href="/login"]');
	expect(page.url()).toBe(`${baseUrl}/login`);
});

// Test form with empty password credentials
test("Login with empty password credentials", async ({ page }) => {
	await page.goto(`${baseUrl}/login`);

	await page.fill("#email", "peter@abv.bg");
	await page.click('input[type="submit"]');

	// Check the alert box
	page.on("dialog", async (dialog) => {
		expect(dialog.type()).toContain("alert");
		expect(dialog.message()).toContain("All fields are required!");
		await dialog.accept();
	});

	// Check the redirect
	await page.$('a[href="/login"]');
	expect(page.url()).toBe(`${baseUrl}/login`);
});

// 4. Register page tests

// Test form with valid credentials
test("Register with valid credentials", async ({ page }) => {
	await page.goto(`${baseUrl}/register`);

	await page.fill("#email", "pesho@abv.bg");
	await page.fill("#password", "123456");
	await page.fill("#repeat-pass", "123456");
	await page.click('input[type="submit"]');

	await page.$('a[href="/catalog"]');
	expect(page.url()).toBe(`${baseUrl}/catalog`);
});

// Test form with empty credentials
test("Register with empty credentials", async ({ page }) => {
	await page.goto(`${baseUrl}/register`);

	// Submit empty
	await page.click('input[type="submit"]');

	// Check the alert box
	page.on("dialog", async (dialog) => {
		expect(dialog.type()).toContain("alert");
		expect(dialog.message()).toContain("All fields are required!");
		await dialog.accept();
	});

	// Check the redirect
	await page.$('a[href="/register"]');
	expect(page.url()).toBe(`${baseUrl}/register`);
});

// Test form with empty email credentials
test("Register with empty email credentials", async ({ page }) => {
	await page.goto(`${baseUrl}/register`);

	await page.fill("#password", "123456");
	await page.fill("#repeat-pass", "123456");
	await page.click('input[type="submit"]');

	// Check the alert box
	page.on("dialog", async (dialog) => {
		expect(dialog.type()).toContain("alert");
		expect(dialog.message()).toContain("All fields are required!");
		await dialog.accept();
	});

	// Check the redirect
	await page.$('a[href="/register"]');
	expect(page.url()).toBe(`${baseUrl}/register`);
});

// Test form with empty password credentials
test("Register with empty password credentials", async ({ page }) => {
	await page.goto(`${baseUrl}/register`);

	await page.fill("#email", "gosho@abv.bg");
	await page.fill("#repeat-pass", "123456");
	await page.click('input[type="submit"]');

	// Check the alert box
	page.on("dialog", async (dialog) => {
		expect(dialog.type()).toContain("alert");
		expect(dialog.message()).toContain("All fields are required!");
		await dialog.accept();
	});

	// Check the redirect
	await page.$('a[href="/register"]');
	expect(page.url()).toBe(`${baseUrl}/register`);
});

// Test form with empty repeat password credentials
test("Register with empty repeat password credentials", async ({ page }) => {
	await page.goto(`${baseUrl}/register`);

	await page.fill("#email", "gosho@abv.bg");
	await page.fill("#password", "123456");
	await page.click('input[type="submit"]');

	// Check the alert box
	page.on("dialog", async (dialog) => {
		expect(dialog.type()).toContain("alert");
		expect(dialog.message()).toContain("All fields are required!");
		await dialog.accept();
	});

	// Check the redirect
	await page.$('a[href="/register"]');
	expect(page.url()).toBe(`${baseUrl}/register`);
});

// Test form with different password credentials
test("Register with different password credentials", async ({ page }) => {
	await page.goto(`${baseUrl}/register`);

	await page.fill("#email", "gosho@abv.bg");
	await page.fill("#password", "123456");
	await page.fill("#repeat-pass", "123");
	await page.click('input[type="submit"]');

	// Check the alert box
	page.on("dialog", async (dialog) => {
		expect(dialog.type()).toContain("alert");
		expect(dialog.message()).toContain("Passwords don't match!");
		await dialog.accept();
	});

	// Check the redirect
	await page.$('a[href="/register"]');
	expect(page.url()).toBe(`${baseUrl}/register`);
});

// 5. Add Book page

// Test form with correct data
test("Add book with correct data", async ({ page }) => {
	await page.goto(`${baseUrl}/login`);

	await page.fill("#email", "peter@abv.bg");
	await page.fill("#password", "123456");

	await Promise.all([
		page.click('input[type="submit"]'),
		page.waitForURL(`${baseUrl}/catalog`),
	]);

	await page.click('a[href="/create"]');
	await page.waitForSelector("#create-form");

	await page.fill("#title", "Test Book");
	await page.fill("#description", "This is a test book description");
	await page.fill(
		"#image",
		"https://i.pinimg.com/474x/26/7a/56/267a56a08dad6124d458fa67da140666.jpg",
	);
	await page.selectOption("#type", "Fiction");
	await page.click('#create-form input[type="submit"]');

	await page.waitForURL(`${baseUrl}/catalog`);
	expect(page.url()).toBe(`${baseUrl}/catalog`);
});

// Test form with with empty title field
test("Add book with empty title field", async ({ page }) => {
	await page.goto(`${baseUrl}/login`);

	await page.fill("#email", "peter@abv.bg");
	await page.fill("#password", "123456");

	await Promise.all([
		page.click('input[type="submit"]'),
		page.waitForURL(`${baseUrl}/catalog`),
	]);

	await page.click('a[href="/create"]');
	await page.waitForSelector("#create-form");

	await page.fill("#description", "This is a test book description");
	await page.fill(
		"#image",
		"https://i.pinimg.com/474x/26/7a/56/267a56a08dad6124d458fa67da140666.jpg",
	);
	await page.selectOption("#type", "Fiction");
	await page.click('#create-form input[type="submit"]');

	// Check the alert box
	page.on("dialog", async (dialog) => {
		expect(dialog.type()).toContain("alert");
		expect(dialog.message()).toContain("All fields are required!");
		await dialog.accept();
	});

	// Check the redirect
	await page.$('a[href="/create"]');
	expect(page.url()).toBe(`${baseUrl}/create`);
});

// Test form with with empty description field
test("Add book with empty description field", async ({ page }) => {
	await page.goto(`${baseUrl}/login`);

	await page.fill("#email", "peter@abv.bg");
	await page.fill("#password", "123456");

	await Promise.all([
		page.click('input[type="submit"]'),
		page.waitForURL(`${baseUrl}/catalog`),
	]);

	await page.click('a[href="/create"]');
	await page.waitForSelector("#create-form");

	await page.fill("#title", "Test Book");
	await page.fill(
		"#image",
		"https://i.pinimg.com/474x/26/7a/56/267a56a08dad6124d458fa67da140666.jpg",
	);
	await page.selectOption("#type", "Fiction");
	await page.click('#create-form input[type="submit"]');

	// Check the alert box
	page.on("dialog", async (dialog) => {
		expect(dialog.type()).toContain("alert");
		expect(dialog.message()).toContain("All fields are required!");
		await dialog.accept();
	});

	// Check the redirect
	await page.$('a[href="/create"]');
	expect(page.url()).toBe(`${baseUrl}/create`);
});

// Test form with with empty description field
test("Add book with empty image field", async ({ page }) => {
	await page.goto(`${baseUrl}/login`);

	await page.fill("#email", "peter@abv.bg");
	await page.fill("#password", "123456");

	await Promise.all([
		page.click('input[type="submit"]'),
		page.waitForURL(`${baseUrl}/catalog`),
	]);

	await page.click('a[href="/create"]');
	await page.waitForSelector("#create-form");

	await page.fill("#title", "Test Book");
	await page.fill("#description", "This is a test book description");
	await page.selectOption("#type", "Fiction");
	await page.click('#create-form input[type="submit"]');

	// Check the alert box
	page.on("dialog", async (dialog) => {
		expect(dialog.type()).toContain("alert");
		expect(dialog.message()).toContain("All fields are required!");
		await dialog.accept();
	});

	// Check the redirect
	await page.$('a[href="/create"]');
	expect(page.url()).toBe(`${baseUrl}/create`);
});

// 6. All Books page

// Test for "All Books"
test("Login and verify all books are displayed", async ({ page }) => {
	await page.goto(`${baseUrl}/login`);

	await page.fill("#email", "peter@abv.bg");
	await page.fill("#password", "123456");

	await Promise.all([
		page.click('input[type="submit"]'),
		page.waitForURL(`${baseUrl}/catalog`),
	]);

	await page.waitForSelector(".dashboard");

	const bookElements = await page.$$(".other-books-list li");
	expect(bookElements.length).toBeGreaterThan(0);
});

// Test for "All Books" -> No books
// test("Login and verify no books are displayed", async ({ page }) => {
// 	await page.goto(`${baseUrl}/login`);

// 	await page.fill("#email", "peter@abv.bg");
// 	await page.fill("#password", "123456");

// 	await Promise.all([
// 		page.click('input[type="submit"]'),
// 		page.waitForURL(`${baseUrl}/catalog`),
// 	]);

// 	await page.waitForSelector(".dashboard");

// 	const noBooksMessage = await page.textContent(".no-books");
// 	expect(noBooksMessage).toBe("No books in database!");
// });

// 7. Details page

// Test Logged-in user sees details
test("Login and verify details are displayed", async ({ page }) => {
	await page.goto(`${baseUrl}/login`);

	await page.fill("#email", "peter@abv.bg");
	await page.fill("#password", "123456");

	await Promise.all([
		page.click('input[type="submit"]'),
		page.waitForURL(`${baseUrl}/catalog`),
	]);

	await page.waitForSelector(".dashboard");

	await page.waitForSelector(".otherBooks");

	await page.click(".otherBooks a.button");
	await page.waitForSelector(".book-information");

	const detailsPageTitle = await page.textContent(".book-information h3");
	expect(detailsPageTitle).toBe("Test Book");
});

// Test Guest user sees details
test("Verify details are displayed for guests", async ({ page }) => {
	await page.goto(`${baseUrl}/catalog`);

	await page.waitForSelector(".dashboard");

	await page.waitForSelector(".otherBooks");

	await page.click(".otherBooks a.button");
	await page.waitForSelector(".book-information");

	const detailsPageTitle = await page.textContent(".book-information h3");
	expect(detailsPageTitle).toBe("Test Book");
});

// Test Logged-in user sees controls -> no dice
// test("Login and verify controls are displayed", async ({ page }) => {
// 	await page.goto(`${baseUrl}/login`);

// 	await page.fill("#email", "peter@abv.bg");
// 	await page.fill("#password", "123456");

// 	await Promise.all([
// 		page.click('input[type="submit"]'),
// 		page.waitForURL(`${baseUrl}/catalog`),
// 	]);

// 	await page.waitForSelector(".dashboard");
// 	await page.waitForSelector(".other-books-list");

// 	const bookElements = await page.$$(".other-books-list .otherBooks");

// 	for (const bookElement of bookElements) {
// 		const bookTitleElement = await bookElement.$("h3");
// 		const bookTitle = await page.evaluate(
// 			(element) => element.textContent.trim(),
// 			bookTitleElement,
// 		);
// 		if (bookTitle === "Outlander") {
// 			const detailsButton = await bookElement.$("a.button");
// 			if (detailsButton) {
// 				await detailsButton.click();
// 				break;
// 			}
// 		}
// 	}

// 	await page.waitForSelector(".book-information actions button");

// 	const actionButtons = await page.$$(".book-information actions button");
// 	expect(actionButtons.length).toBeGreaterThan(0);
// });

// Test Guest user does not sees controls -> no dice
// test("Guest user does not see controls", async ({ page }) => {
// 	page.waitForURL(`${baseUrl}/catalog`);

// 	await page.waitForSelector(".dashboard");
// 	await page.waitForSelector(".other-books-list");

// 	const bookElements = await page.$$(".other-books-list .otherBooks");

// 	for (const bookElement of bookElements) {
// 		const bookTitleElement = await bookElement.$("h3");
// 		const bookTitle = await page.evaluate(
// 			(element) => element.textContent.trim(),
// 			bookTitleElement,
// 		);
// 		if (bookTitle === "Outlander") {
// 			const detailsButton = await bookElement.$("a.button");
// 			if (detailsButton) {
// 				await detailsButton.click();
// 				break;
// 			}
// 		}
// 	}

// 	await page.waitForSelector(".book-information actions button");

// 	const actionButtons = await page.$$(".book-information actions button");
// 	expect(actionButtons.length).toBeGreaterThan(0);
// });

// Verify If Like Button Is Not Visible for Creator -> no dice

// Verify If Like Button Is Visible for Non-Creator -> no dice

// 8. Logout functionality

// Check is "Logout" is visible
test("Verify 'Logout' button is visible", async ({ page }) => {
	await page.goto(`${baseUrl}/login`);

	await page.fill("#email", "peter@abv.bg");
	await page.fill("#password", "123456");

	await Promise.all([
		page.click('input[type="submit"]'),
		page.waitForURL(`${baseUrl}/catalog`),
	]);

	await page.waitForSelector("nav.navbar");

	const logoutLink = await page.$('a[href="javascript:void(0)"]');

	const isLogoutVisible = await logoutLink.isVisible();
	expect(isLogoutVisible).toBe(true);
});

// Check if "Logout" redirects
test("Verify 'Logout' redirects correctly", async ({ page }) => {
	await page.goto(`${baseUrl}/login`);

	await page.fill("#email", "peter@abv.bg");
	await page.fill("#password", "123456");

	await Promise.all([
		page.click('input[type="submit"]'),
		page.waitForURL(`${baseUrl}/catalog`),
	]);

	await page.waitForSelector("nav.navbar");

	const logoutLink = await page.$('a[href="javascript:void(0)"]');
	await logoutLink.click();

	const redirectUrl = page.url();
	expect(redirectUrl).toBe(`${baseUrl}/catalog`);
});
