<?php 
ob_start();
session_start();
if(!isset($_SESSION['UserName'])){
	header("Location: login.php");
	exit();
}
else{						
	include 'regular.php';
	top();
	$db = new DBLink('int322_151b27');
	if($_GET["order"]){
		setcookie("order", $_GET["order"], time()+259200);
		header("Location: view.php");
		exit();
	}
	if(isset($_SESSION['searchhistory'])){
		if(isset($_COOKIE['order'])){
			$result = $db->query("select * from inventory where upper(description) like upper('%". $_SESSION['searchhistory'] . "%') order by " .$_COOKIE['order']);
		}
		else{ 
			$result = $db->query("select * from inventory where upper(description) like upper('%". $_SESSION['searchhistory'] . "%')");
		}
	}
	else{
		if(isset($_COOKIE['order'])){
			$result = $db->query("select * from inventory order by " .$_COOKIE['order']);
		}
		else{ 
			$result = $db->query("select * from inventory");
		}
	}
	$numofRows = mysqli_num_rows($result);
	$db->set($numberofRows);
	?>
	<div class="emptydiv"><br /></div>
	<div class="box">
		<table class="tsetv">
		<tr>
		<th><a href="view.php?order=id">ID</a></th>
		<th><a href="view.php?order=itemName">ItemName</a></th>
		<th><a href="view.php?order=description">Description</a></th>
		<th><a href="view.php?order=supplierCode">Supplier</a></th>
		<th><a href="view.php?order=cost">Cost</a></th>
		<th><a href="view.php?order=price">Price</a></th>
		<th><a href="view.php?order=onHand">Number on Hand</a></th>
		<th><a href="view.php?order=reorderPoint">Reorder Level</a></th>
		<th><a href="view.php?order=backOrder">On Back Order?</a></th>
		<th><a href="view.php?order=deleted"> Delete/Restore </a></th>
		</tr>
<?php
			if(!$numofRows)
				echo "There is No Data in the list";
			else{
				while($row = mysqli_fetch_assoc($result)){
?>
					<tr style="background-color: <?php if((int)$row['id']%2) echo "#D8D8D8";?>;">
					<td><a href="add.php?mod=<?=$row['id']?>"><?php print $row['id']; ?></a></td>
					<td><?php print $row['itemName']; ?></td>
					<td><?php print $row['description']; ?></td>
					<td><?php print $row['supplierCode']; ?></td>
					<td><?php print $row['cost']; ?></td>
					<td><?php print $row['price']; ?></td>
					<td><?php print $row['onHand']; ?></td>
					<td><?php print $row['reorderPoint']; ?></td>
					<td><?php print $row['backOrder']; ?></td>
					<td><a href="delete.php?id=<?=$row['id']?>&deleted=<?=$row['deleted']?>">
		<?php				if($row['deleted']=='n') print 'Delete';
						else if($row['deleted']=='y') print 'Restore';
?>
					</a></td></tr>
<?php
				}
			}
?>
		</table></div>
<?php
foot();
}
?>
