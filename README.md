# AutoPark
### Information
AutoPark software is an automated parking system management software. This software works with a "autoparking" database 
that contains information about cars, car owners (clients) and park places. The database also contain information about database administrators.
The database was created using MySql WorkBench. Application uses ADO.NET to work with the database. 
This software product is created for the purpose of course work and is not intended for commercial use. 
This project was created in collaboration with two other students.

This application was created when I studied at the university at the third course in 2016.
### Functionality
A car arrives at the parking lot if the parking space has available places the driver is offered:
1) To register in the system (name, passport number, identification code, telephone, vehicle number, 
payment method and other information about the owner and the car) if he uses the services for the first time;
2) Or be identificated (password and passport) if it is already registered.

The system checks the condition of the car, if the owner has specified this option, the results are saved as binaries. 
Then the car gets to the parking lot, where with the help of special robotic elevators the car is placed on an empty place.
Owner, car, time of arrival and departure, and parking are stored in the database.

The car is stored in the parking lot until the owner wants to pick up his car, for this he must be identified, 
in the case of successful identification in the database search for the appropriate car, determine its exact location.
1) If the car is not in the parking lot, the owner will be shown a corresponding message, as well as information when the car was last parked.
2) If the car was found, then the robotic elevator picks up the car.

Next, the car's condition is checked, if the owner has set the appropriate option, the results of the checks are compared with the 
saved results.
1) If the results do not match, it is considered that the car was damaged during storage in the parking lot, 
then the user will receive a corresponding message.
2) If the results are the same, the system returns the car to the owner.

The owner interacts with the automated parking system through a dedicated terminal. The terminal, the automated elevator interacts 
with the system by means of special commands. It is assumed that the terminal and the automated elevator are already equipped with 
the necessary software compatible with the automated system, allowing them to perform their functions.
The system requires an administrator who can manage the system manually and has full access to the database. 
The system must run on Windows 10.

Through the terminal, the user can view his schedule of visits to the parking lot, perform the operations of transfer 
and return of the car, registration, identification, payment.

This repository contains three projects: Autoparking, CarCheckerEmulator, LiftEmulator.

Autoparking is the main project in which all the functionality is implemented.

CarCheckerEmulator project implements a vehicle validation system emulator.

LiftEmulator project implements a robotic elevator control system emulator.
