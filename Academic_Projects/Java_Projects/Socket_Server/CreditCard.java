package Yun7148;

import java.io.*;

public class CreditCard implements Serializable{
	private long numbers;
	private boolean validation;
	
	public CreditCard(){
		this.numbers = 0;
		this.validation = false;
	}
	
	public CreditCard(long l){
		this.numbers = l;
	}
	
	public long getNum(){
		return numbers;
	}

	public void setValidation(){
		validation = CardValidation.isValid(numbers);
	}
	
	public boolean getValidatioin() {
		return validation;
	}
	public String toString(){
		String str = "";
		str += "Numbers are " + numbers +"\nAnd these numbers are";
		if(validation){
			 str += "valid"; 
		}
		else{
			str += "not valid";
		}
		return str;
	}
}
