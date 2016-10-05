These are the files enclosed in the folder
	- Stable priorityqueue java program(Priorityqueuestable.java)
	- Junit tests for stable priorityqueue(JunitTestMain.java)
	- Emma Coverage Report (Image of the coverage result -CodeCoverageEmma)
	- FindBugs Report for stable priorityqueue (FingbugReport.xml)
	
All of these reports were generated using an eclipse 
Using Eclipse:
Priorityqueuestable.java - to run this file go to elcipse,create new java 			           project,copy the contents from  				     		   Priorityqueuestable.java and run it as  				           java application.
			 - It will ask you to insert elements in to                                    priority queue.
	                 - Enter string and its priority separated by
                           space for example: Mike 1
			 - Further the operation max, 			   			   extractmax,clearqueue,printqueue can be done 			           based on user selection
JunitTestMain.java       - Within the same folder of                                                  Priorityqueuestable.java, make new junit test                            case file , copy contents from                            JunitTestMain.java and run it as junit test

To run emma coode coverage, install Emma code coverage tool (or add emma jar to directory, add jar to Run Configurations) , right click on project and Coverage as selecting emma.

To run FindBugs, install plugin, right click on project and FindBugs -> FindBugs.		
Coverage report is less than 100 due to the requirement that emma requires a main function. I have tested all methods of the class (those method are showing 100% results) which main is using. The only reason it is not getting 100% code coverage is due to main method.
No issues were reported by FindBugs.
In junitTesting all test are being passed.






VAIBHAVIBAHEN PATEL-14063841
CS576-PROJECT ASSIGNMENT
