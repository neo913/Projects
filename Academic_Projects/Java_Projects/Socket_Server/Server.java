package Yun7148;

import java.util.*;
import java.net.*;
import java.io.*;

public class Server {
	public static void main(String [] args){
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