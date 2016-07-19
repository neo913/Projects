<?php 
function top(){
?>
<!doctype html>
<html>
<head>
<style>
	.emptydiv{
		position: relative;
		width: 10%;
		float: left;
	}
	.box{	position: relative;
		width: 80%;
		float: left;
		text-align: center;
		border: black solid 1px;
	}
	nav{	position: relative;
		text-align: center;
		width: 100%;
		height: 40px;
		top: -20px;
		background-color: green;
		font-family: Arial;
		font-size: 20px;
		float: left;
		padding-bottom: 5px;
	}
	nav ul{	list-style: none;
		color: white;
	}
	nav ul li.menu{
		float: left;
		width: 100px;
	}
	nav ul li.search{
		float: left;
	}
	nav ul li a{
		display: block;
		text-decoration: none;
		color: white;
	}
	nav ul li.menu: hover a{
		background-color: #58FA82;
	}
	footer{	position: relative;
		margin-left: 25%;
		margin-right: auto;
		width: 50%;
		float: left;
		text-align: center;
	}
	.red{	color: red;}
	.tset{	width: 80%;
		margin-left: 10%;
		margin-right: auto;
	}
	.tsetv{	border: black solid 1px;}
	td{	width: 33%; }
	th{	background-color: #58FA82;}
</style>
<meta http-equiv="content-type" content="text/html; charset=-UTF-8">
<title>
<?php
$title = basename($_SERVER['PHP_SELF']);
if($title == "add.php"){
        print "Assignment2 ".$title;
}else if($title == "view.php"){
        print "Assignment2 ".$title;
}else if($title == "login.php"){
        print "Assignment2 ".$title;
}
?>
</title>
</head>
<body>
	<div class="emptydiv"><br /> </div>
	<div class="box"><a href="add.php"><img src = "gstore.jpg" title="title" width=100% /></a></div>
<?php 
if(isset($_SESSION['UserName'])){
include 'a1.lib';
	$linkList = array("Add", "View All", "Search","login");
	$Menu = new Menu($linkList);
	$Menu->displayMenu();
}}
?>
<?php
function foot(){
?>
<footer>
	<p style="text-align:center;">Copyright 2015 Designed by <em>Insu Yun</em></p>
</footer>
</body>
</html>
<?php
}
?>
