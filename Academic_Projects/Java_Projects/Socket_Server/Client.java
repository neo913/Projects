package Yun7148;

import java.net.*;
import java.io.*;
import java.util.*;

public class Client {
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
