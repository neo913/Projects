<?php
session_start();
if(!isset($_SESSION['UserName'])){
	header("Location: login.php");
	exit();
}
else{
	include 'a1.lib';
	$db = new DBLink('int322_151b27');
	if($_GET["deleted"] =="y") 
		$result = $db->query('update inventory set deleted = "n" where id = "' .$_GET["id"]. '" ;');
	else
		$result = $db->query('update inventory set deleted = "y" where id = "' .$_GET["id"]. '" ;');
    if($result){
        if (!headers_sent()) {
			header('Location: view.php');
			exit();
        }
    }
}
?>
