
	  /*@author Vaibhavibahen Patel -cs576 */

package priorityqueue;


import java.util.Collections;
import java.util.Comparator;

import java.util.LinkedHashMap;
import java.util.LinkedList;
import java.util.Map;

import java.util.Scanner;
import java.util.Map.Entry;


 
 public class Priorityqueuestable
  
  {
	
	 Map<String, Integer>  hm=new LinkedHashMap<String, Integer>();

	/*add elements to linked hashmap*/
	  public void addElements(String x,int y)
	  {
		  hm.put(x, y);
		    		 
		  System.out.println(hm);

		  }
	  
/*sort the linked hashmap based on the priority value given by user*/
  public static Map<String,Integer> sortMap(
	            Map<String,Integer>  unsortedMap) {

	   LinkedList<Entry<String,Integer> > list = new LinkedList<Entry<String,Integer> >(unsortedMap.entrySet());

	        Collections.sort(list,
	                new Comparator<Entry<String,Integer> >() {

	                    public int compare(Entry<String,Integer> e1, Entry<String,Integer>  e2) {
	                        int priceResult = e1.getValue().compareTo(e2.getValue());
	                       return priceResult;
	                       
	                        
	                    }
	                });

	        Map<String,Integer> sortedMap = new LinkedHashMap<String,Integer>();
	        for(Entry<String,Integer> item : list){
	            sortedMap.put(item.getKey(), item.getValue());
	        }
	        return sortedMap;
	    }

	
	/*retrive maximum priority element*/  
	public String getMax()
	{ 
		  System.out.println(hm);
		 Integer keyFirst = null;
		 String valueFirst = null;
		  if (!hm.isEmpty()){
		      keyFirst = sortMap(hm).values().iterator().next();
		      
		      valueFirst = sortMap(hm).keySet().iterator().next();
		      System.out.println(valueFirst+" " +keyFirst);
		    }
		  return valueFirst;
		
	}
	/*remove maximum priority element from the queue*/
	public String extractMax()
	{ 
		System.out.println(hm);
		 Integer keyFirst = null;
		 String valueFirst = null;
		  if (!hm.isEmpty()){
		      keyFirst = sortMap(hm).values().iterator().next();
		      
		      valueFirst = sortMap(hm).keySet().iterator().next();
		      System.out.println("Removing max"+valueFirst+" " +keyFirst);
		      hm.remove( valueFirst, keyFirst);
		      System.out.println(hm);
		    }
		  return valueFirst;
		 
	}
   	
   	/*get the size of prioriity queue*/
	 public int size()
	  {
		  System.out.println("Size of the map: "+ hm.size());
		  return hm.size();
		  
	  }
	 
/*Print the sorted priority queue */
	  public void printqueue()
	  {
		  System.out.println(sortMap(hm)); 
	  }
	  /*remove all elements from queue*/
	  public void clearQueue()
	  {
		  hm.clear();
		  System.out.println("Priorityqueue Empty"+hm);
		
	  }
	  
  
  
  

	  
	  public static void main(String[] args) {
	
	  
	  Scanner scan = new Scanner(System.in,"UTF-8");
	  Priorityqueuestable p1=new Priorityqueuestable();
	  String x;
	   int y;
	  
	 
	  char ch;
      /*  Perform Priority Queue operations */
      do    
      {
    	 /*Taking user input to select operations*/ 
          System.out.println("\nPriority Queue Operations\n");
          System.out.println("1. insert");
          System.out.println("2. Max");
          System.out.println("3. ExtrctMax");
          System.out.println("4.Print Stable Priority Queue");
          System.out.println("5. Clear Priority Queue");
          System.out.println("Enter your choice");
         

          int choice = scan.nextInt();            
          switch (choice) 
          {
          case 1 :
        	  System.out.println("Enter string and priority(positive Integer) separated by space:");
        	  x=scan.next();
        	  y= scan.nextInt();
        	  p1.addElements(x,y);  
        	   break;  
         case 2 : 
        	  p1.getMax();
              break;        
         case 3 : 
        	  p1.extractMax();
              break; 
         case 4:
             p1.printqueue();
             break; 
         case 5:
        	  p1.clearQueue();
        	  break; 
       
          default : 
              System.out.println("Wrong Entry \n ");
              break;   
          }    

          System.out.println("\nDo you want to continue (Type y or n) \n");
          ch = scan.next().charAt(0);                        
      } while (ch == 'Y'|| ch == 'y');  
	  
	  System.out.println("Exited");
	  
	  
  }
}