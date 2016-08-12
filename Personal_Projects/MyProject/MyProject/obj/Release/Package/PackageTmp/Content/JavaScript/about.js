(function(){
	var about = angular.module('about', []);

	about.controller("AboutController", function(){
		this.first = first;
		this.second = skills;
		this.education = education;
		this.academic = academic;
		this.experience = experience;

	});

	about.controller("TabController", function(){
		this.tab = 1;

		this.setTab = function(newValue){
			this.tab = newValue;
		};

		this.isSet = function(tabName){
			return this.tab === tabName;
		};

	});

	var first = [
	{
		name: "OBJECTIVE",
		list:
		[
			"Seeking a full-time job position in Information Technology field to further develop my computer programming skills while contributing to the goals of your organization."
		]
	},
	{
		name: "PROFILE",
		list:
		[
			"Strong research, analysis and problem solving skills.",
			"Enthusiastic, a quick learner, and a self-starter.",
			"Strong leadership skills from experience as Student President at Dong-A University.",
			"Excellent communication skills; fluent in English and Korean."
		]
	}
	]

	var skills = [
	{
		name: "Operating Systems",
		list:
		[
			"MS-DOS",
			"Windows XP/7/10",
			"Unix/Linux",
			"IBM OS/400"
		]
	},
	{
		name: "Programming/Languages",
		list:
		[
			"C",
			"C++",
			"C#",
			"Java",
			"AS/400 CL",
			"RPG"
		]
	},
	{
		name: "Database Technology",
		list:
		[
			"DB2/400",
			"SQL",
			"MySQL",
			"Oracle DB2",
			"MS Access"
		]
	},
	{
		name: "Web Development",
		list:
		[
			"HTML",
			"PHP",
			"CSS",
			"JavaScript: AngularJS",
			"MS SharePoint",
			"ASP .NET"
		]
	},
	{
		name: "Tools",
		list:
		[
			"IBM WebSphere Developement Studio Client",
			"IBM iSeries Access for Windows",
			"Photoshop",
			"MS Visual Studio",
			"MS Office",
			"Eclips",
			"Sublime Text"
		]
	},
	{
		name: "Software Development Life Cycle",
		list:
		[
			"Agile Methodology",
			"Waterfall"
		]
	}
	]

	var education = [
	{
		name: "Diploma - Computer Programmer",
		year: 2016,
		details: "Seneca College, Toronto, Ontario"
	},
	{
		name: "Bachelor Degree - Ethical Culture",
		year: 2012,
		details: "Dong-A University, Busan, South Korea"
	}
	]

	var academic = [
	{
		name: "Bank System Program",
		environment: "Windows10, MS Visual Studio, C#, ASP .NET, HTML, CSS and JavaScript(AngularJS)",
		details:
		[
			"Developed a bank system on a webpage to handle customer's needs and employee's convinience.",
			"Designed classes to build oriented-object programming logics.",
			"Managed database with DB2 and added logics to handle by the program.",
			"Focused on each role's interests of their action when they're using a bank system in real world."
		]
	},
	{
		name: "Music companies and industry management program/website",
		environment: "Windows10, MS Visual Studio, C#, ASP .NET MVC 5",
		details:
		[
			"Created a website with ASP .NET MVC 5 for a company in music industry.",
			"Designed structures and logics to easily handle all the contents."
		]
	},
	{
		name: "Payroll Program",
		environment: "IBM Rational Developer for i, AS/400 CL and RPG",
		details:
		[
			"Designed a program to allow the human resource manager to manage the payroll status.",
			"Created and designed logical/display files to get the best result."
		]
	},
	{
		name: "Garden Management Simulator",
		environment: "Linux and C++",
		details:
		[
			"provided a simulation program to manage crops, plants, and gardens for farmers.",
			"Created logics to manage memory, structure, and data."
		]
	},
	{
		name: "Statistic Analysis Software",
		environment: "Linux and C",
		details:
		[
			"Designed a simple C program which analyzes statistcs of train travelers.",
			"Created logics to import, analyzes and export data."
		]
	}
	]

	var experience = [
	{
		name: "Programmer/Analyst (Co-op)",
		period: "Sep 2015 - Dec 2015",
		company: "Toronto Transit Commission (TTC), Toronto, Ontario",
		details:
		[
			"Worked at the Rail Cars and Shops (RC&S) department to manage their internal webpages.",
			"Solved the current issues with MS SharePoint, JavaScript, HTML, and CSS.",
			"Analyzed status of train wheels by using internal modules and MS Excel program."
		]
	},
	{
		name: "System Testing Analyst (Co-op)",
		period: "May 2015 - Aug 2015",
		company: "Ministry of Community and Social Services (MCSS), Toronto, Ontario",
		details:
		[
			"Solved caseworkers' difficulties with Social Assistance Management System (SAMS) project.",
			"Managed and update data on database by using MS Access."
		]
	},
	{
		name: "Software Engineer/Web Developer (Part time)",
		period: "Oct 2014 - Dec 2014",
		company: "UP photoart Inc, Toronto, Ontario",
		details:
		[
			"Managed webpages to fix parts of pages by the client's requests.",
			"Upgraded logical programming system for internal management system by PHP and JavaScript."
		]
	},
	{
		name: "Bank Assistant",
		period: "Mar 2012 - Jan 2013",
		company: "NH Bank, Yang-San, Korea",
		details:
		[
			"Assisted bank tellers by managing cash and assoiated documents.",
			"Supported clients' transactions by documents to secure and protect their finance information."
		]
	}
	]
})();
