# Employee Management system
## OVERVIEW 
&emsp;  The`Employee management system` enables organization of employees for better management and easier access. This application aims to create a `class-based architecture` to categorize their employees and provide robust features like logging, secure login.

## SPECIFICATIONS
### <u>Segregation of Employees :
**Employee** (Base Class)
&rarr; Management Staff
&rarr; Engineers (Base Class)
&emsp;&emsp;&rarr; Hardware Engineer
&emsp;&emsp;&rarr; Software Engineer
### <u>Employee Properties :  
1.  Employee ID -> int 
2.  Name -> string
3.  Position -> enum
4.  Salary -> double
### <u>Specific Properties :
* **Hardware Engineer** &rarr; Hardware Units -> int
### <u>Employee Management System :
* Only single instance of employee management is allowed at a time (`Singleton `design is used to ensure a single instance).
## CORE FEATURES 
### <u>Login System
* For secure credentials, it is mandatory for the password to contain `special characters, numbers, small and capital case alphabets`.
* Login option is launched where the user is asked to enter his/her corresponding username and password.
* Data retention is used in this case to validate the credentials and allow the user to login.
### <u>CRUD OPERATIONS
#### COMMON OPERATIONS : 
**View Employees :**
* The employees can be filtered according to category or position.
* Then the employee details (except salary) can be viewed by any employee after login and the total number of employees is also visible.

**Search for an employee :**
* Any specific employee details (except salary) can be viewed by searching for their ID or by their position.
#### ADMIN OPERATIONS  
**Add Employee :**
* Whenever a new employee is created by the management staff, a new file 
`(Employee_ID.txt)` is created in the `docs` folder to store the employee details. 
* The file consists of the employee password, category of the employee, name, position and salary.
* Whenever a new employee is created, the management staff is prompted to enter these mandatory details.  

**Remove Employee :**
* The employee is chosen by their ID and the management staff can remove the employee and the file specific to the employee is deleted.

**Update Employee Details :**
* The employee salary and position can be updated by the management staff.
### <u>FILE LOGGING
* Error codes are thrown based on the use case such as :
1.  9000 – Creation of a duplicate instance of the Employee Management System.
2.  9001 – Attempt to check or update hardware count for a non-hardware engineer.
3.  9002 – Employee ID not found during search, update, or removal.
4.  9003 – Unauthorized access attempt (failed login).

* Whenever an error code is caught, it is logged on to a common file `Error_Logs` with the current date and time.
* Other information such as a successful login attempt, addition and deletion of employee are logged into `Info_Logs` along with the date and time.
* Whenever the log file reaches a predefined size limit `(1 MB)`, a new log file is created to store the consecutive log data.



