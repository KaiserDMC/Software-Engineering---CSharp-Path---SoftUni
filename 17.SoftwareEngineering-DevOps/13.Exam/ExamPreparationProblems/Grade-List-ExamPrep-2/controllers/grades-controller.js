function setup(app, grades) {
	app.get("/", function (req, res) {
		let model = {
			title: "My grades",
			msg: "My Grades",
			grades: grades,
		};
		res.render("home", model);
	});

	app.get(
		"/loaderio-97355a48d08652424ffe033c5cf3d460.txt",
		function (req, res) {
			res.send("loaderio-97355a48d08652424ffe033c5cf3d460");
		},
	);

	app.get("/my-grades", function (req, res) {
		let model = { title: "My Grades", grades };
		res.render("my-grades", model);
	});

	app.get("/about", function (req, res) {
		let model = { title: "About" };
		res.render("about", model);
	});

	app.get("/add-grade", function (req, res) {
		let model = { title: "Add Grade" };
		res.render("add-grade", model);
	});

	function paramEmpty(p) {
		return typeof p !== "string" || p.trim().length === 0;
	}

	app.post("/add-grade", function (req, res) {
		if (paramEmpty(req.body.subject) || paramEmpty(req.body.value)) {
			let model = {
				title: "Add Grade",
				errMsg: "Cannot add grade. Subject and value fields are required!",
			};
			res.render("add-grade", model);
			return;
		}
		let grade = {
			subject: req.body.subject,
			value: req.body.value,
		};
		grades.push(grade);
		res.redirect("/my-grades");
	});
}

module.exports = { setup };
