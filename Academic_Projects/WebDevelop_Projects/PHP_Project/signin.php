<?php
session_start();
include 'regular.php';
include 'a1.lib';
$ErrMsg = "";
$dataValid = true;
top();
if ($_POST) { 
	$saltvalue =[ 'thisissalty'=>12 ];
	$hashed_password = password_hash($_POST['Password'], PASSWORD_BCRYPT, $saltvalue) ;
	$username = $_POST['UserName'];
	if (empty($_POST['UserName']) || empty($hashed_password) || (!preg_match("/^([a-zA-Z0-9]+[a-zA-Z0-9._%\-\+]*@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,4})$/",($_POST['UserName'])))){
		$ErrMsg = "Invalid Username or password";
		$dataValid = false;
	}
	else{
		$db = new DBLink('int322_151b27');
		$result = $db->query("INSERT INTO users (username, password) VALUES('". $username. "','" . $hashed_password . "')");
	}
}
if($dataValid && $_POST){
	header("Location: login.php");
	exit();
}
else{
?>
	<div class="emptydiv"><br /></div>
	<div class="box">
	<h1> Sign in </h1>
	<form method="post" action="">
	User name:<input type="text" name="UserName">
	<br/>
	Password:<input type="password" name="Password">
	<br />
	<?php echo '<span class="red">'.$ErrMsg;'</span>'?><br />
	<input type="submit">
	</form>
	</div>
<?php 
}
foot();
?>
