<?php
session_start();
session_destroy();
setcookie("order","",time() - 61200);
header("Location: login.php");
exit();
?>
