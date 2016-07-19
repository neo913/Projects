///////////////////////////////////
/*       INT222 Assingment 1     */
/*       017-747-148 Insu Yun    */
///////////////////////////////////
/*
This project is developed for a JavaScript assignment.
This program receives sales records from user and analyses the entered data.
And finally this program shows the report of the best salesperson, and the best-selling car of the month as a result.
This program is developed with basic JavaScript logics.
*/
var salesPeople = new Array(10);
var i, j;
var pattChar = /[A-z\-\']/g;
var pattDig = /[^0-9\.]/g;
var carType = new Array("Mercedes Benz", "Audi", "Porsche","BMW");

var sales = {
  name: "",
  ID: [],
  amount: {},
};

// Creating Objects with for loop
for(i=0;i<10;i++){
  salesPeople[i] = Object.create(sales);
  salesPeople[i].name = nameEnter(i);
  if(salesPeople[i].name == 0){
    salesPeople.length = i--;
    break;
  }
  salesPeople[i].ID = idEnter(i);
  salesPeople[i].amount = {
                             MercedesBenz: parseFloat(enterAmount(i,0)),
                             Audi: parseFloat(enterAmount(i,1)),
                             Porsche: parseFloat(enterAmount(i,2)),
                             BMW: parseFloat(enterAmount(i,3)),
                             }
}

//Getting name functiion
function nameEnter(i){
  do{
    salesPeople[i].name = prompt("Enter name of sales person "+(i+1)+" (0 to quit)" ,"");
    if(salesPeople[i].name == ""){
      alert("You have to enter a value");
    }
    else if(salesPeople[i].name == 0){
      return salesPeople[i].name;
    }
    else if((salesPeople[i].name).search(pattChar) == -1){
      alert("Invalid Value\n(You can only enter characters)");
    }
    else{
      return salesPeople[i].name;
    }
  }while(1);
}

//Getting id function
function idEnter(i){
  do{
    salesPeople[i].ID = prompt("Enter "+salesPeople[i].name+"'s ID");
    if(isNaN(salesPeople[i].ID)){
      alert("Invalid Value\n(You can enter digits only)");
    }
  }while(isNaN(salesPeople[i].ID));
return salesPeople[i].ID;
}

//Getting amount function
function enterAmount(i,j){
  do{
    var temp = parseFloat(prompt("Name: "+ salesPeople[i].name+"\n"+
                               " ID : "+ salesPeople[i].ID+"\n"+
                               "Enter amount of "+carType[j]));
    if(temp < 0 || temp == null){
      alert("Invalid Value\nValue must greater than 0");
      }
      else if(isNaN(temp)){
      alert("Invalid value\nValue must be digits");
    }
    else{
      return temp;
    }
  }while(1);
}

//Best Person
var bestPerson = new Array(10);
for(i=0;i<10;i++){
  bestPerson[i] = 0;
}
for(i=0;i<salesPeople.length;i++){
  bestPerson[i] += salesPeople[i].amount.MercedesBenz+salesPeople[i].amount.Audi+
                   salesPeople[i].amount.Porsche+salesPeople[i].amount.BMW;
}
var tempBestPerson = Math.max.apply(null,bestPerson);
for(i=0;i<10;i++){
  if(tempBestPerson == bestPerson[i]){
    alert("The best salesperson of the month is "+salesPeople[i].name+",\n"+
          "with the sales amount of $"+tempBestPerson.toFixed(2)+"K");
  }
}

//Best Car
var bestCar = new Array(4);
for(i=0;i<4;i++){
  bestCar[i] = 0;
}
  for(i=0;i<salesPeople.length;i++){
    bestCar[0] += salesPeople[i].amount.MercedesBenz;
  }
  for(i=0;i<salesPeople.length;i++){
    bestCar[1] += salesPeople[i].amount.Audi;
  }
  for(i=0;i<salesPeople.length;i++){
    bestCar[2] += salesPeople[i].amount.Porsche;
  }
  for(i=0;i<salesPeople.length;i++){
    bestCar[3] += salesPeople[i].amount.BMW;
  }
var tempBestCar = Math.max.apply(null,bestCar);
for(i=0;i<4;i++){
  if(tempBestCar == bestCar[i]){
    alert("The best-selling car of the month is "+carType[i]+",\n"+
          "with the sales amount of $"+bestCar[i].toFixed(2)+"K");
  }
}
