package Yun7148;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class CardValidation {
	
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
		List<Long> tmp = new ArrayList<Long>();
		while(l != 0){
			tmp.add(0, (l % 10));
			l = l / 10;
		}
		return tmp;
	}
	
	public static List<Long> toDigitsReverse(long l){
		List<Long> tmp = new ArrayList<Long>();
		while(l != 0){
			tmp.add(l % 10);
			l = l / 10;
		}
		return tmp;
	}
	
	public static List<Long> doubleSecond(List<Long> list){
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
