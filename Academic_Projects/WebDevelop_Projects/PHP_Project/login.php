<?php
session_start();
$ErrMsg = "";
$dataValid = true;
if (!function_exists('hash_equals')) {
    function hash_equals($known_string, $user_string)
    {
        if (func_num_args() !== 2) {
            trigger_error('hash_equals() expects exactly 2 parameters, ' . func_num_args() . ' given', E_USER_WARNING);
            return null;
        }
        if (is_string($known_string) !== true) {
            trigger_error('hash_equals(): Expected known_string to be a string, ' . gettype($known_string) . ' given', E_USER_WARNING);
            return false;
        }
        $known_string_len = strlen($known_string);
        $user_string_type_error = 'hash_equals(): Expected user_string to be a string, ' . gettype($user_string) . ' given'; 
        if (is_string($user_string) !== true) {
            trigger_error($user_string_type_error, E_USER_WARNING);
            $user_string_len = strlen($user_string);
            $user_string_len = $known_string_len + 1;
        } else {
            $user_string_len = $known_string_len + 1;
            $user_string_len = strlen($user_string);
        }
        if ($known_string_len !== $user_string_len) {
            $res = $known_string ^ $known_string;
            $ret = 1;
	 } else {
            $res = $known_string ^ $user_string;
            $ret = 0;
        }
        for ($i = strlen($res) - 1; $i >= 0; $i--) {
            $ret |= ord($res[$i]);
        }
        return $ret === 0;
    }
}
if ($_POST) { 
	$saltvalue =[ 'thisissalty'=>12 ];
    $hashed_password = password_hash($_POST['Password'], PASSWORD_BCRYPT, $saltvalue) ;
	if ($_POST['UserName'] == "" || $hashed_password == "") {
		$ErrMsg = "Invalid username or password";
		$dataValid = false;
	}
	else{
		$username = $_POST['UserName'];
		include 'a1.lib';
		$db = new DBLink('int322_151b27');
		$result = $db->query("SELECT * FROM users WHERE username = '".$username."'");
		if(mysqli_num_rows($result) > 0){
			$row = mysqli_fetch_assoc($result);
			if(strcmp($row['password'], $hashed_password)){
				$_SESSION['UserName'] = $username;
				$_SESSION['Role'] = $row['role'];
				header('Location: view.php');
				exit();
			}
			else{
				$ErrMsg = "Invalid username or password";
				$dataValid = false;
			}
		}
		else{
			$ErrMsg = "Invalid username or password";
			$dataValid = false;
		}
	}
}
if($dataValid && $_POST){
	
}
else{

	if(isset($_SESSION['UserName'])){
		header("Location: view.php");
		exit();
	}
else{
include 'regular.php';
top();
?>
<div class="emptydiv"><br /></div>
<div class="box">
<h1> Login </h1>
	<form method="post" action="">
	User name:<input type="text" name=UserName>
	<br/>
	Password:<input type="password" name=Password>
	<br />
	<input type="submit"><br />
	<?php echo "<span class='red'>".$ErrMsg."</span>";?>
	</form>
	<a href="signin.php">sign in?</a><br />
	<a href="getpwd.php">Forgot your password?</a>
</div>
<?php 
}
foot();
}
?>
