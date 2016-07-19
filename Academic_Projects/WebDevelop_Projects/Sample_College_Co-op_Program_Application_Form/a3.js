// Assignment 3 javascript
// a3.js
// Insu Yun 017-747-148
// I didn't make function for "The age by graduation must be at least 16 years old at the current year" because there is no birthday information
// I didn't make province check function because there is "required" in select form

var alpha = "bcedfghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'-"
var mastercheck = 0;
var clickCount = 0;
function check(){
	mastercheck = 0;
	fNameCheck();
	lNameCheck();
	student_IDCheck();
	learn_IDCheck();
	graduate_DateCheck();
	phone_NumberCheck();

	if(mastercheck = 0){
		return true;
	}
	else{
		return false;
	}
}
function fNameCheck(){
	var fname = document.getElementById("first_Name").value;
	if(fname.length != 0){
		for(var i=0; i<fname.length; I++){
			if(alpha.indexOf(fname.substr(i,1))>= 0){
				document.getElementById("fnameErr").innerHTML = "";
			}
			else{
				document.getElementById("fnameErr").innerHTML = "Alphabetic characters, apostrophe and hyphen are only allowed";
				mastercheck = 1;
			}
		}
	}
	else{
		document.getElementById("fnameErr").innerHTML = "You need to enter First Name";
		mastercheck = 1;
	}
}
function lNameCheck(){
	var lname = document.getElementById("last_Name").value;
	if(lname.length != 0){
		for(var i=0; i<lname.length; I++){
			if(alpha.indexOf(lname.substr(i,1))>= 0){
				document.getElementById("lnameErr").innerHTML = "";
			}
			else{
				document.getElementById("lnameErr").innerHTML = "Alphabetic characters, apostrophe and hyphen are only allowed";
				mastercheck = 1;
			}
		}
	}
	else{
		document.getElementById("lnameErr").innerHTML = "You need to enter Last Name";
		mastercheck = 1;
	}
}
function student_IDCheck(){
	document.getElementById("student_IDErr").innerHTML = "";
	var sid = document.getElementById("student_ID").value;

	if(parseInt(sid) != sid || sid.length != 10){
		document.getElementById("student_IDErr").innerHTML = "10 digits only";
		mastercheck = 1;
	}
}
function learn_IDCheck(){
	document.getElementById("learn_IDErr").innerHTML = "";
	document.getElementById("seneca_Email").value= document.getElementById("learn_ID").value.toLowerCase()+"@myseneca.ca";
	var fname = document.getElementById("first_Name").value;
	var lname = document.getElementById("last_Name").value;
	var lname_len = lname.length;
	var lid = document.getElementById("learn_ID").value;

	if( lid.charAt(0).toLowerCase() != fname.charAt(0).toLowerCase() ){
		document.getElementById("learn_IDErr").innerHTML = "The first character should be same as the first character of the field 'First Name'";
		mastercheck = 1;
	}
	else if( lid.substr(1,lname_len).toLowerCase() != lname.toLowerCase()){
		document.getElementById("learn_IDErr").innerHTML = "The following characters should be the field value of 'Last Name'";
		mastercheck = 1;
	}
}
function phone_NumberCheck(){

	document.getElementById("phone_NumberErr").innerHTML = "";
	var phone = document.getElementById("phone_Number").value;
	var phone_digits = phone.substr(1,3) + phone.substr(6,3) + phone.substr(10,4);
	if(phone.charAt(0) != '(' || phone.charAt(4) != ')' || phone.charAt(5) != ' ' || phone.charAt(9) != '-'){
		document.getElementById("phone_NumberErr").innerHTML = "Invalid Format";
		mastercheck = 1;
	}
	else if( isNaN(phone_digits) == true || phone_digits.length != 10){
		document.getElementById("phone_NumberErr").innerHTML = "10 digits only";
		mastercheck = 1;
	}
	else if( parseInt(phone_digits.substr(0,3)) == 000){
		document.getElementById("phone_NumberErr").innerHTML = "Area code cannot be all zeros";
		mastercheck = 1;
	}
	else if( parseInt(phone_digits.substr(3,7)) == 0000000){
		document.getElementById("phone_NumberErr").innerHTML = "Actual phone numbers cannot be all zeros";
		mastercheck = 1;
	}

}
function graduate_DateCheck(){
	document.getElementById("graduate_DateErr").innerHTML = "";
	var seasons = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
	var gDate = document.getElementById("graduate_Date").value.toUpperCase();
	var gcheck = 0;
	var gDateYear = gDate.substr(3,4);

	for(var i=0; i<12; i++){
		if(gDate.substr(0,3) == seasons[i]){
			gcheck++;
		}
	}
	if(gcheck == 0){
		document.getElementById("graduate_DateErr").innerHTML = "Invalid Month Name";
		mastercheck = 1;
	}
	else if(parseInt(gDateYear) != gDateYear){
		document.getElementById("graduate_DateErr").innerHTML = "Year must numeric";
		mastercheck = 1;
	}
}
function toggleEdu(){
	var addMore=document.getElementById("a3eduForm");
	var target=document.getElementById("addEdu");
	target.innerHTML = target.innerHTML + "<hr/>";
	target.innerHTML = target.innerHTML + addMore.innerHTML;
	for(var i=0; i < clickcount; i++){
		target.innerHTML = target.innerHTML + "<hr/>";
		target.innerHTML = target.innerHTML + addMore.innerHTML;
	}
	clickCount++;
}
function toggleWork(){
	var addMore=document.getElementById("a3workForm");
	var target=document.getElementById("addWork");
	target.innerHTML = target.innerHTML + "<hr/>";
	target.innerHTML = target.innerHTML + addMore.innerHTML;
	for(var i=0; i < clickcount; i++){
		target.innerHTML = target.innerHTML + "<hr/>";
		target.innerHTML = target.innerHTML + addMore.innerHTML;
	}
	clickCount++;
}
function toggleAttach(){
	var addMore=document.getElementById("a3attachForm");
	var target=document.getElementById("addAttach");
	target.innerHTML = target.innerHTML + "<hr/>";
	target.innerHTML = target.innerHTML + addMore.innerHTML;
	for(var i=0; i < clickcount; i++){
		target.innerHTML = target.innerHTML + "<hr/>";
		target.innerHTML = target.innerHTML + addMore.innerHTML;
	}
	clickCount++;
}