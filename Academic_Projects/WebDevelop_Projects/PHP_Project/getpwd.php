<?php
session_start();
if ($_POST) { 
	$username = $_POST['UserName'];
	include 'a1.lib';
	$db = new DBLink('int322_151b27');
	$result = $db->query("SELECT * FROM users WHERE username = '$username'");
	
	$row = mysqli_fetch_assoc($result);
	if($row['username'] == $username){
		$to = "int322@localhost";
		$subject = "Password Hint from int322_151b27";
		$message = "Id : " . $username. "\n" . "Password Hint is : " . $row['passwordHint'];
		$from = "donotreply@example.com";
		$headers = "From: $from";
		mail($to, $subject, $message, $headers);
	}
	header("Location: login.php");
	exit();
}
else{
include 'regular.php';
top();
?>
	<div class="emptydiv"><br /></div>
	<div class="box">
	<h1> Forgot your password? </h1>
	<form method="post" action="">
	Input your username:<input type="text" name="UserName">
	<br/>
	<input type="submit">
	</form>
	</div>

<?php 
foot();
}
?>
