const { test, expect } = require("@playwright/test");

// Verify if a user can add a task
test("user can add a tast", async ({ page }) => {
	await page.goto("http://localhost:5500");
	await page.fill("#task-input", "Test Task");
	await page.click("#add-task");

	const taskText = await page.textContent(".task");
	expect(taskText).toContain("Test Task");
});

// Verify if a user can delete a task
test("user can delete a task", async ({ page }) => {
	// Add a task
	await page.goto("http://localhost:5500/");
	await page.fill("#task-input", "Test Task");
	await page.click("#add-task");

	// Delete the task
	await page.click(".task .delete-task");

	const tasks = await page.$$eval(".task", (tasks) =>
		tasks.map((tasks) => tasks.textContent),
	);
	expect(tasks).not.toContain("Test Task");
});

// Verify if a user can mark a task as completed
test("user can mark a task as completed", async ({ page }) => {
	// Add a task
	await page.goto("http://localhost:5500/");
	await page.fill("#task-input", "Test Task");
	await page.click("#add-task");

	// Mark the task as complete
	await page.click(".task .task-complete");

	const completedTask = await page.$(".task.completed");
	expect(completedTask).not.toBeNull();
});

// Verify if a user can filter
test("user can filter tasks", async ({ page }) => {
	// Add a task
	await page.goto("http://localhost:5500/");
	await page.fill("#task-input", "Test Task");
	await page.click("#add-task");

	// Mark the task as complete
	await page.click(".task .task-complete");

	// Filter tasks
	await page.selectOption("#filter", "Completed");

	const incompleteTask = await page.$(".task:not(.completed)");
	expect(incompleteTask).toBeNull();
});
