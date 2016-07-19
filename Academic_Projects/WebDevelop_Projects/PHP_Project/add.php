<?php
session_start();
if(!isset($_SESSION['UserName'])){
	header("Location: login.php");
	exit();
}
else{
	$itemErr = "";
	$descriptionErr= "";
	$codeErr= "";
	$costErr= "";
	$sellingErr = "";
	$handErr = "";
	$reorderErr = "";
	$itemErr = "";
	$descriptionErr= "";
	$codeErr= "";
	$costErr= "";
	$sellingErr = "";
	$handErr = "";
	$reorderErr = "";
	$dataValid = true;

	function test_input($data){
			$data = trim($data);
			$data = stripslashes($data);
			$data = htmlspecialchars($data);
			return $data;
		}
	if($_POST && !$_GET["mod"]){ 
		if(empty(test_input($_POST["item"]))){
			$itemErr = "Item Name is required";
			$dataValid = false;
		}
		else{
			if(!preg_match("/^[A-Za-z0-9 :;\-,']+$/",test_input($_POST["item"]))){
				$itemErr = "Item Name is not valid";
				$dataValid = false;
			}
		}
		if(empty(test_input($_POST["description"]))){
			$descriptionErr = "Description is required";
			$dataValid = false;
		}
		else{
			if(!preg_match("/^[A-Za-z0-9.,'\- ]+$/",test_input($_POST["description"]))){
				$discriptionErr = "Description is not valid";
				$dataValid = false;
			}
		}
		if(empty(test_input($_POST["code"]))){
			$codeErr = "Supplier Code is required";
			$dataValid = false;
		}
		else{
			if(!preg_match("/^[A-Za-z0-9 \-]+$/",test_input($_POST["code"]))){
				$codeErr = "Supplier Code is not valid";
				$dataValid = false;
			}
		}
		if(empty(test_input($_POST["cost"]))){
			$costErr = "Cost is required";
			$dataValid = false;
		}
		else {
			if(!preg_match("/^\d*\.?\d{0,2}$/",test_input($_POST["cost"]))){
				$costErr = "Cost is not valid";
				$dataValid = false;
			}
		}
		if(empty(test_input($_POST["selling"]))){
			$sellingErr = "Selling price is required";
			$dataValid = false;
		} 
		else{
			if(!preg_match("/^\d*\.?\d{0,2}$/",test_input($_POST["selling"]))){
				$sellingErr = "Selling price is not valid";
				$dataValid = false;
			}
		}
		if(empty(test_input($_POST["hand"]))){
			$handErr = "Number on hand is required";
			$dataValid = false;
		} 
		else{
			if(!preg_match("/^[0-9]+$/",test_input($_POST["hand"]))){
				$handErr = "Number on hand is not valid";
				$dataValid = false;
			}
		}
		if(empty(test_input($_POST["reorder"]))){
			$reorderErr = "Reorder Point is required";
			$dataValid = false;
		} 
		else{
			if(!preg_match("/^[0-9]+$/",test_input($_POST["reorder"]))){
				$reorderErr = "Reorder Point is not valid";
				$dataValid = false;
			}
		}	
	}
	else if($_POST && $_GET["mod"]){
		if(!preg_match("/^[A-Za-z0-9 :;\-,']+$/",test_input($_POST["item"]))){
			$itemErr = "Item Name is not valid";
			$dataValid = false;
		}
		if(!preg_match("/^[A-Za-z0-9.,'\- ]+$/",test_input($_POST["description"]))){
			$discriptionErr = "Description is not valid";
			$dataValid = false;
		}
		if(!preg_match("/^[A-Za-z0-9 \-]+$/",test_input($_POST["code"]))){
			$codeErr = "Supplier Code is not valid";
			$dataValid = false;
		}
		if(!preg_match("/^([0-9]+\.[0-9]{2})$/",test_input($_POST["cost"]))){
			$costErr = "Cost is not valid";
			$dataValid = false;
		}
		if(!preg_match("/^([0-9]+\.[0-9]{2})$/",test_input($_POST["selling"]))){
			$sellingErr = "Selling price is not valid";
			$dataValid = false;
		}
		if(!preg_match("/^[0-9]+$/",test_input($_POST["hand"]))){
			$handErr = "Number on hand is not valid";
			$dataValid = false;
		}
		if(!preg_match("/^[0-9]+$/",test_input($_POST["reorder"]))){
			$reorderErr = "Reorder Point is not valid";
			$dataValid = false;
		}
	}
	if($_POST && $dataValid){ 
		$result="";
		if($_GET["mod"]){
			include 'a1.lib';
			$db = new DBLink('int322_151b27');
			$backcheck ="n";
			if($_POST['back']) $backcheck = "y";	
			$result = $db->query('UPDATE inventory SET ' .
								((!empty(test_input($_POST["item"])))? ' itemName="'. $_POST["item"]. '",' : '' ). 
								((!empty(test_input($_POST["description"])))? ' description="' .$_POST["description"]. '", ' :'') .
								((!empty(test_input($_POST["code"])))? ' supplierCode="' . $_POST["code"] . '", ' : '').
								((!empty(test_input($_POST["cost"])))? ' cost=' .$_POST["cost"]. ', ' : '').
								((!empty(test_input($_POST["selling"])))? ' price = ' . $_POST["selling"]. ', ' : '' ).
								((!empty(test_input($_POST["hand"])))? ' onHand =' . $_POST["hand"]. ' , ' : '') .
								((!empty(test_input($_POST["reorder"])))? ' reorderPoint=' .$_POST["reorder"]. ', ' : '') .
								'backOrder = "' .$backcheck . '", '.
								'deleted = "n" WHERE id ='.$_GET['mod']);
		}
		else{
			include 'a1.lib';
			$db = new DBLink('int322_151b27');
			$backcheck ="n";
			if($_POST['back']) $backcheck = "y";	
			$result = $db->query('INSERT INTO inventory set itemName="' . $_POST["item"] . '", 
									description="' .$_POST["description"]. '", 
									supplierCode="' . $_POST["code"] . '", 
									cost="' .$_POST["cost"]. '", 
									price = "' . $_POST["selling"]. '", 
									onHand ="' . $_POST["hand"]. '" ,
									reorderPoint="' .$_POST["reorder"]. '", 
									backOrder = "' .$backcheck . '", 
									deleted = "n"');
		}
		if($result){
			header('Location: view.php');
			exit();
		}else{
			echo "Error ! <a href=add.php>Try again.</a>";
		}
	}
	else {
	include 'regular.php';
	top(); 
	?>
	<div class="emptydiv"><br /></div>
	<div class="box">
	<form method="post">
		<table class="tset"><br />
		<?php 
		if($_GET["mod"]){
			$db = new DBLink('int322_151b27');
			$result = $db->query("select * from inventory where id=".$_GET["mod"]);	
			$row = mysqli_fetch_assoc($result)
		?>
			<tr>
			<td>Id:</td>
			<td><input name="id" type="text" value="<?php echo $_GET['mod']; ?>" readonly="readonly"></td>
			</tr><tr>
			<td>Item name:</td>
			<td><input name="item" type="text" value="<?php print $row['itemName']; ?>"></td>
			<td><font color="red"><?php echo $itemErr;?></font></td>
			</tr><tr>
			<td>Description:</td>
			<td><textarea name="description" id="desc"><?php print $row['description']; ?></textarea></td>
			<td><font color="red"><?php echo $descriptionErr;?></font></td>
			</tr><tr>
			<td>Supplier Code:</td>
			<td><input name="code" type="text" value="<?php print $row['supplierCode']; ?>"></td>
			<td><font color="red"><?php echo $codeErr;?></font></td>
			</tr><tr>
			<td>Cost:</td>
			<td><input name="cost" type="text" value="<?php print $row['cost']; ?>"></td>
			<td><font color="red"><?php echo $costErr;?></font></td>
			</tr><tr>
			<td>Selling price:</td>
			<td><input name="selling" type="text" value="<?php print $row['price']; ?>"></td>
			<td><font color="red"><?php echo $sellingErr;?></font></td>
			</tr><tr>
			<td>Number on hand:</td>
			<td><input name="hand" type="text" value="<?php print $row['onHand']; ?>"></td></td>
			<td><font color="red"><?php echo $handErr;?></font></td>
			</tr><tr>
			<td>Reorder Point:</td>
			<td><input name="reorder" type="text" value="<?php print $row['reorderPoint']; ?>"></td></td>
			<td><font color="red"><?php echo $reorderErr;?></font></td>
			</tr><tr>
			<td>On Back Order:</td>
			<td><input name="back" value="back" type="checkbox" <?php if($row['backOrder'] == "y") echo "CHECKED"; ?>></td>
			<td><font color="red"><?php echo $backErr; ?></font></td>
			</tr><tr>
			<td></td>
			<td><input name="submit" type="submit" value="Submit" /><input name="reset" type="reset" value="Reset" /></td>
			<td></td>
		<?php
		}else{
		?>
			<tr>
			<td>Item name:</td>
			<td><input name="item" type="text" value="<?php if ($_POST['item']) echo $_POST['item']; ?>"></td>
			<td><font color="red"><?php echo $itemErr;?></font></td>
			</tr><tr>
			<td>Description:</td>
			<td><textarea name="description" id="desc"><?php if ($_POST['description']) echo $_POST['description']; ?></textarea></td>
			<td><font color="red"><?php echo $descriptionErr;?></font></td>
			</tr><tr>
			<td>Supplier Code:</td>
			<td><input name="code" type="text" value="<?php if ($_POST['code']) echo $_POST['code']; ?>"></td>
			<td><font color="red"><?php echo $codeErr;?></font></td>
			</tr><tr>
			<td>Cost:</td>
			<td><input name="cost" type="text" value="<?php if ($_POST['cost']) echo $_POST['cost']; ?>"></td>
			<td><font color="red"><?php echo $costErr;?></font></td>
			</tr><tr>
			<td>Selling price:</td>
			<td><input name="selling" type="text" value="<?php if ($_POST['selling']) echo $_POST['selling']; ?>"></td>
			<td><font color="red"><?php echo $sellingErr;?></font></td>
			</tr><tr>
			<td>Number on hand:</td>
			<td><input name="hand" type="text" value="<?php if ($_POST['hand']) echo $_POST['hand']; ?>"></td></td>
			<td><font color="red"><?php echo $handErr;?></font></td>
			</tr><tr>
			<td>Reorder Point:</td>
			<td><input name="reorder" type="text" value="<?php if ($_POST['reorder']) echo $_POST['reorder']; ?>"></td></td>
			<td><font color="red"><?php echo $reorderErr;?></font></td>
			</tr><tr>
			<td>On Back Order:</td>
			<td><input name="back" value="back" type="checkbox" <?php if($_POST['back']) echo "CHECKED"; ?>>
			</td>
			<td><font color="red"><?php echo $backErr; ?></font></td>
			</tr><tr><td></td>
			<td><input name="submit" type="submit" value="Submit" /><input name="reset" type="reset" value="Reset" /></td>
			<td></td></tr>
		<?php 
		} 
		?>
		</table>
		<span class="red"><em> All fields mandatory except "On Back Order" </em></span>
		</form>
<?php
}
foot();
}
?>
