/*@author Vaibhavibahen Patel -cs576 */



package priorityqueue;

import static org.junit.Assert.*;
import org.junit.Test;
import  priorityqueue.Priorityqueuestable;
import java.util.LinkedHashMap;
import java.util.Map;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class JunitTestMain {
	Priorityqueuestable p1=new Priorityqueuestable();
	 Map<String, Integer>  testmap=new LinkedHashMap<String, Integer>();
	 Map<String, Integer>  sortmap=new LinkedHashMap<String, Integer>();
@Before
	public void addingElements(){
	
		 p1.addElements("hello", 4);
		 p1.addElements("nice", 1);
		 p1.addElements("user", 3);
		 p1.addElements("baby", 1);
		  
	}	
@Before
public void hashelemts()
	{
	testmap.put("hello", 4);
	testmap.put("nice", 1);
	testmap.put("user", 3);
	testmap.put("baby", 1);

	}
@Before
public void sortReult()
	{
	
	sortmap.put("nice", 1);
	sortmap.put("baby", 1);
	sortmap.put("user", 3);
	sortmap.put("hello", 4);
	}


	@Test
	public void sizeofQueue(){
	Assert.assertEquals(4, p1.size());
	}
	
	@Test
	public void printqueue()
	{
		p1.printqueue();;	
		
	}
	@Test
	public void eaxElement()
	{
	
		String max=p1.getMax();
		Assert.assertEquals("nice", max);
		
	}
	@Test
	public void extractmax()
	{
		String extarctmax=p1.extractMax();
		Assert.assertEquals("nice", extarctmax);
		
	}
	@Test
	public void maxSizezero()
	{
		 p1.clearQueue();
		String s=p1.getMax();
		 Assert.assertEquals(null,s);
		
	}
	@Test
	public void extractmaxsizeZero()
	{
		 p1.clearQueue();
			String s=p1.extractMax();
			 Assert.assertEquals(null,s);
		
	}
	
	@Test
	public void sorting()
	{
		 hashelemts();
		 sortReult();
			Assert.assertEquals( sortmap,p1.sortMap(testmap));
	}
	

	

}
