/**
 * <h1> JAC444 Assignment3<h1>
 * <h3> Name: Insu yun </h3>
 * <h3> SID: 017-747-148 </h3>
 * 
 */

/**
 * <h2> Step1 </h2> 
 * <h3> Credit Card validation algorithm </h3>
 * CardValidation class has algorithms that
 * validate the Credit Card numbers are valid or not.
 * <p>
 * 
 * @author Insu Yun
 * @version 1.0
 * @since 2016-04-03
 * 
 */
package Yun7148;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class CardValidation {
	/**
	 * This is the main method which makes use of toDigits, toDigitsReverse,
	 * doubleSecond, sumDigits, isValid methods.
	 * @param args Unused
	 * @return Nothing
	 */
	public static void main(String [] args){
		long creditCardNumber = 4012888888881881L;
		System.out.println("toDigit: " + toDigits(creditCardNumber));
		System.out.println("toDigitsReverse" + toDigitsReverse(creditCardNumber));
		System.out.println("doubleSecond: "+ doubleSecond(toDigits(creditCardNumber)));
		System.out.println("doubleSecond: "+ doubleSecond(toDigitsReverse(creditCardNumber)));
		System.out.println("sumDigits:"+ sumDigits(doubleSecond(toDigitsReverse(creditCardNumber))));
		System.out.println(isValid(creditCardNumber));
	}
	
	public static List<Long> toDigits(long l){
		/**
		 * This method is used to get numbers from long type to List<Long> type.
		 * @param l This is the parameter to toDigits method.
		 * @List<Long> tmp This is new ArrayList<Long> for temporary values.
		 * @while(l != 0){... This while loop will get single digit into tmp List
		 * @return List<Long> This returns tmp List which has all single digit.  
		 */
		List<Long> tmp = new ArrayList<Long>();
		while(l != 0){
			tmp.add(0, (l % 10));
			l = l / 10;
		}
		return tmp;
	}
	
	public static List<Long> toDigitsReverse(long l){
		/**
		 * This method is used to get numbers from long type to List<Long> type. 
		 * @param l This is the parameter to toDigitsReverse method.
		 * @List<Long> tmp This is new ArrayList<Long> for temporary values.
		 * @while(l != 0){... This while loop will get single digit into tmp List in reversed order.
		 * @return List<Long> This returns tmp List which has all single digit.
		 */
		List<Long> tmp = new ArrayList<Long>();
		while(l != 0){
			tmp.add(l % 10);
			l = l / 10;
		}
		return tmp;
	}
	
	public static List<Long> doubleSecond(List<Long> list){
		/**
		 * This method is used to double the value of every second digit.
		 * @param list This is the parameter to doubleSecond method.
		 * @long tmp This is the temporary value of long type.
		 * @for(... This for loop will run until the size of list,
		 * 			and if it's the second time of the list,
		 * 			get the value into tmp, and then set it into that position.
		 * @return This returns the modified List.
		 */
		long tmp;
		for(int i=0; i<list.size(); i++){
			if(i % 2 != 0){
				tmp = (list.get(i)) * 2;
				list.set(i, tmp);
			}
		}
		return list;
	}
	
	public static long sumDigits(List<Long> list){
		/**
		 * This method is used to take the sum of all the digits.
		 * If the number is greater than 9, then sum the each digits.
		 * For example, if the number is 16, it will take sum of 1 and 6.
		 * @param list This is the parameter to sumDigits method.
		 * @long result This value will get the result.
		 * @long tmp This value will be used for temporary calculation.
		 * @for(... This for loop will run until the size of list.
		 * 			First of all, save the value into tmp,
		 * 			and then if tmp is greater than 9,
		 * 			add the separated numbers at tmp into result,
		 * 			else, it will just add tmp to result.
		 * @return This returns the sum of all the digits.
		 */
		long result = 0;
		long tmp = 0;
		for(int i=0; i<list.size(); i++){
			tmp = list.get(i);
			if(tmp > 9){
				result += tmp % 10;
				result += tmp / 10;
			}
			else{
				result += tmp;
			}
		}
		return result;
	}
	
	public static boolean isValid(long l){
		/**
		 * This method is used to validate the numbers is valid or not.
		 * @param l This is the parameter of isValid method.
		 * @List<long> list This is new List for reversed digits.
		 * @doubleSecond(list) This will double the second digits.
		 * @long sum This will get sum of all the digits.
		 * @if(... This will check the total modulo 10 is equal to 0.
		 * @return If yes, this returns true,
		 * 			if no, this returns false.
		 */
		List<Long> list = toDigitsReverse(l);
		doubleSecond(list);
		long sum = sumDigits(list);
		if(sum % 10 == 0){
			return true;
		}
		else{
			return false;
		}
	}
}


/**
 * <h2> Step2 </h2> 
 * <h3> CreditCard class </h3>
 * CreditCard class has two fields:
 * one long variable that can keep the credit card number and 
 * the other Boolean that shows if the number is valid or not.
 * <p>
 * 
 * @author Insu Yun
 * @version 1.0
 * @since 2016-04-03
 * 
 */
package Yun7148;

import java.io.*;

public class CreditCard implements Serializable{
	/**
	 * This class implements Serializable.
	 * @long numbers This is CreditCard numbers.
	 * @boolean validation This is for the numbers are valid or not.
	 */
	private long numbers;
	private boolean validation;
	
	public CreditCard(){
		/**
		 * This method is non-argument constructor
		 */
		this.numbers = 0;
		this.validation = false;
	}
	public CreditCard(long l){
		/**
		 * This method is used as a constructor.
		 * @param l This is the parameter of constructor.
		 * @this.numbers This sets numbers value with l.
		 */
		this.numbers = l;
	}
	public long getNum(){
		/**
		 * This method is used to return numbers.
		 * @return This returns numbers of this class.
		 */
		return numbers;
	}

	public void setValidation(){
		/**
		 * This method is used to set validation.
		 * @validation This is setter which gets the boolean value from isValid method.
		 */
		validation = CardValidation.isValid(numbers);
	}
	
	public boolean getValidatioin() {
		/**
		 * This method is used to get validation.
		 * @return This returns validation.
		 */
		return validation;
	}
	public String toString(){
		/**
		 * This method is used to show numbers and validation.
		 * @rreturn This returns String value.
		 */
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

/**
 * <h2> Step3 </h2> 
 * <h3> Server </h3>
 * This is a Java server that runs on localhost 
 * on the port numbers equals with the last four digits of my student ID(7148)
 * The server receives a CreditCard object and validates its credit card number.
 * The server sends back to the client the CreditCard object with the Boolean value
 * set to true or false depending on the result of validation.
 * <p>
 * 
 * @author Insu Yun
 * @version 1.0
 * @since 2016-04-03
 * 
 */

package Yun7148;

import java.util.*;
import java.net.*;
import java.io.*;

public class Server {
	public static void main(String [] args){
		/**
		 * This is the main method which makes use of Server method.
		 * @param args Unused.
		 * @return Nothing.
		 * @exception IOException on input error.
		 * @see IOException.
		 * 
		 * When the server stopped, this will print the message 
		 * that server is stopped
		 * @serverSocket This is ServerSocket.
		 * 					in try scale, serverSocket will be 
		 * 					new ServerSocket with port 148
		 * @System.out.println These 3 lines will print
		 * 						what this project is,
		 * 						the purpose of this server,
		 * 						and listening for a connection.
		 * @serverSocket.accept() This accepts from client.
		 * @oosToClient This sends information to client.
		 * @oisFromClient This gets information from client.
		 * @card This is a temporary CreditCard object.
		 * @while(true){ This keeps on getting data from the client.
		 * @oisFromClient.readObject This reads an object from the client.
		 * @card.setValidation() This sets validation of the card number.
		 * @oosToClient.writeobject(card) This sends card object to client.
		 * @exception ClassNotFoudnException when it can't find a class.
		 * 				EOFException when it reaches to the end of file.
		 * 				IOException on input error.
		 * @see ClassNotFoundException, EOFException, and IOException.
		 * @.close These close oosToClient, oisFromClient, socketConnection.
		 * 
		 */
		ServerSocket serverSocket;
		try{
			serverSocket = new ServerSocket(7148);
			
			System.out.println("Assignment 3 - Insu Yun(017-747-148)");
			System.out.println("This server is going to validate the card numbers");
			System.out.println("Listening for a connection...");
			
			Socket socketConnection = serverSocket.accept();
			
			ObjectOutputStream oosToClient = new ObjectOutputStream(socketConnection.getOutputStream());
			ObjectInputStream oisFromClient = new ObjectInputStream(socketConnection.getInputStream());
			
			System.out.println("I/O streams connected to the socket");
			
			CreditCard card;
			
			try{
				while(true){
					card = (CreditCard) oisFromClient.readObject();
					System.out.println("\nReceived an object from the Client: "+ card.getNum());
					System.out.println("Starting validation card number: "+card.getNum());
					System.out.println(".\n.\n.");
				
					card.setValidation();
					oosToClient.writeObject(card);
				}

					
				
			}catch(ClassNotFoundException cnf){
				cnf.printStackTrace();
			}catch(EOFException eof){
				System.out.println("The Client has terminated connection");
			}catch(IOException e){
				e.printStackTrace();
			}
			oosToClient.close();
			oisFromClient.close();
			socketConnection.close();
		}catch(IOException e){
			e.printStackTrace();
		}
		System.out.println("Server is stopped.\nThank you");

	}
}

/**
 * <h2> Step4 </h2> 
 * <h3> Client </h3>
 * This is a Java client that sends a CreditCard object to server 
 * and receives back the object with the validation done. 
 * The client prints the credit card object before and after the server invocation.
 * <p>
 * 
 * @author Insu Yun
 * @version 1.0
 * @since 2016-04-03
 * 
 */

package Yun7148;

import java.net.*;
import java.io.*;
import java.util.*;

public class Client {
	/**
	 * This is main method which makes use of Client method.
	 * @param args Unused.
	 * @return Nothing.
	 * @exception IOException on input error.
	 * @see IOException
	 * @SOcket This is a new client socket 
	 * to connect to server IP address/server name : "localhost"
	 * port number: 8000
	 * @oisFromServer This is getInputStream
	 * @oosFromServer This is getOutputStream
	 * @scan This is new Scanner
	 * while(true){ This keeps on getting data from the client.
	 * @cardnumber This is temporary value for card numbers.
	 * @card This is new CreditCard object.
	 * @oosToServer.writeObject(card) This line is to write card object to server
	 * @oosToServer.flush() This clears buffer.
	 * @oisFromServer.readObject() This is to read object from server.
	 * if(... This if statement will print message 
	 * depend on the numbers are valid or not.
	 * After then Client will ask user to validate another numbers.
	 * @exception EOFException when it reaches to the end of file.
	 * 				IOException on input error,
	 * 				and Exception for any other possible error
	 * @see EOFException, IOException, and Exception.
	 * @.close These close oosToClient, oisFromClient, clientSocket.
	 * 
	 */
	public static void main(String [] args){
		Socket clientSocket;
		try{
			clientSocket = new Socket(InetAddress.getByName("localhost"), 7148);
			System.out.println("Connected to "+clientSocket.getInetAddress().getHostName());
			
			ObjectInputStream oisFromServer = new ObjectInputStream(clientSocket.getInputStream());
			ObjectOutputStream oosToServer = new ObjectOutputStream(clientSocket.getOutputStream());
			System.out.println("I/O streams connected to the socket");
			
			Scanner scan = new Scanner(System.in);
			
			try{
				
				while(true){
					System.out.print("\nEnter the card numbers(i.e. 4012888888881881): ");
					long cardnumber = scan.nextLong();
					CreditCard card = new CreditCard(cardnumber);
					
					oosToServer.writeObject(card);
					oosToServer.flush();
					
					System.out.println("\nSending this card numbers ("+ card.getNum() + ") to the server to validate");
					System.out.println(".\n.\n.");
					
					card = (CreditCard) oisFromServer.readObject();
					System.out.println("The result returned by the server");
					System.out.print("The card number ("+card.getNum()+")is ");
					if(card.getValidatioin()){
						System.out.println("valid");
					}
					else{
						System.out.println("not valid");
					}
					
					
					System.out.print("Do you want to validate anther card numbers?(Y/N):");
					char key = scan.next().charAt(0);
					if(key == 'N' || key == 'n'){
						break;
					}

					try{
						Thread.sleep(1000);
					}catch(InterruptedException e){
						
					}
				}
			
			}catch(EOFException eof){
				System.out.println("The server has terminated connection!");
			}catch(IOException e){
				e.printStackTrace();
			}catch(Exception e){
				System.out.println("Exception is"+e);
			}
			
			System.out.println("\nClient: closing the connection...");
			oosToServer.close();
			oisFromServer.close();
			clientSocket.close();
		}catch(IOException ioe){
			ioe.printStackTrace();
		}
		System.out.println("The Client is going to stop running..");
		System.out.println("Thank you");
	}
}

