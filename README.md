# BattleShip-Api

## Overview
The Batleship-Api is an web API appilcation that allows to build a complete Battleship game online

## Background & Assumtions
I assume here that we have a software house that is produce games and the development sector is divided into 2 teams . Backend Team and frontend Team. I'm a software Engineer in the backend Team.
The development Team has rules and guildlines which restrain the work to follow the best practices.

 ## Usefull Links

- [Swagger UI Link](https://localhost:44305/swagger/index.html) Please Replace the Port Number by your Port Number.
- [Health Ckeck](https://localhost:44305/status) Please Replace the Port Number by your Port Number.

## Branshes Names 

 The Guildlines says the branch name Must be The Type of story {Feature / hotfix} / Your team name - Story Number

 ## Why Doing such a big application while the test is far smaller ? ##

I Believe I need to show what I believe and how I solve issues.

## Stories Meaning 

I mean by the story is what needs to be done to add business value. For example create database as story won't add a value for business unless they use the database itself. so I will create the Database in Sub Task.
Sub-Tasks are Important to make the PR smaller. however I will name them as well as stories but I will mention here they are sub Tasks.

## Stories List
- Backend-001 : Add API Skeleton
- Backend-002 : Add API Basement
- Backend-003 : Add Database context (Sub - Task)
- Backend-004 : Add Nuget Packages (Sub - Task)
- Backend-005 : Add Logging (Sub - Task)
- Backend-006 : Add Swagger (Sub - Task)
- Backend-007 : Add Exception Handling (Sub - Task)
- Backend-008 : Create Game End Point
- Backend-009 : Player Place Ship End point
- Backend-010 : Player Shoot End Point
- Backend-011 : RandomMap End Point
 ## Developer Notes 

 - **Why using Persistance Layer?**

I built the application over the assumtion mentioned above and to create the website making multiple players play in the same time. we will need a database . I chose the simplest one as a prove of concept. beside the test has no time limit so why not make it better :) 
in the real time work I always follow the story and don't implement what is out of scope.

- **Integration Tests!**

Yes, As the Application has a persistance Layer we should add an integration Tests . but with InMemory Database! . You got the Idea anyway.
So Unit Tests Will be More Realistic.
    
- **Why Adding AutoMapper , FluentValidation , Problem details & Custome Exptions in the first commit without real need for it  ?** 

I Believe in Just enough design and I made a mistake by adding it to Backend-001 Branch. I was thinking about a head start.I should have been waiting until the real need feature branch to add them. 

- **Why Logging ?**

Every Application needs a loggin system this application uses both File and console logging. at later stage we can use ElasticSearch for logging.

- **Why Swagger  ?** 

To Give user interface to the frontend Team to know how to interact with the backend

- **Why adding Custom MVC class and Adding Swagger configuration in the same startup class ?** 

Swagger configuration is 1 line per function if things got more compicated in the future we should move them to a seprate class as extensions.

- **Why Pushing the Values controller in the first commit ?** 

For Testing Purpose during the PR Request. 

- **Why not Using Clean Archicture in the folder hirarchy ?**

I personally Prefer the features folder hirarchy for the ease of finding the files that belongs to a certain feature as well as it will align with the frontend project format. In the large applications the clean architecture folders hirarachy be become a bit missy. 


- **Game Controller** 

The Api gives fully flexibility to the frontend team to add the board size while Creating. however the defaults will be used if not provided.
The Api gives the board name as Unique id to allow the system to use multiple boards in the same time.

- **Player Controller** 
The API has a player controller where the player can shoot and Place the Ships Manually or Random.
I'd like to leave it for the frontend to validate that the player doesn't send wrong information while placing a ship inside his board . but I will validate it anyway to be more comfortable.
The points sequence is a frontend Concern. Also it can be nice we can add the ships in diagonal way :)
Player Move Ship from one position to another! 
Well not in this version. 
Start Game . I don't need a button to start game it's a frontend concern. 

- **Why PlaceShipOnBoard Function is private and why I tunred it to public**

I believe if the function serves only one class it should be private however it still can be tested via the public main method of the class. 
Why I turned it to public . cause the Test Scenario for the Main function is very long. I already demonstrated my skills in Board Service Test. 


- **Why Board Size is Limited?** 

We need to make sure that the players finishes the game within human life time :) 
Also adding a guard against adding invalid numbers.

- **Why returning 201 instead of 200?** 

I think it's better to return something to the consumer. I don't like sending back the id that he already has it. but the case is really simple. beside it's better in testing.

- **Why not using CQRS ?** 

Even when I added several things out of scope but the project itself doesn't need CQRS. sometimes over complicating things will make it worse. I believe I added only the things that is important to a Web API application.

- **Transactions**

With The Game Service Layer we will need to add the transaction to the code in order to RollBack in case of any Error Happened . it won't work with the In Memory Database but I put it here to consider it in the future.


- **Domain Folder**

Instead of calling domain objects from different features the folder should hold the domain models. as they are used in different features.

- **Double Validation!**

Yes I believe that the cost of the changes in 2 places is far more cheaper than introducing a production issue. 
Also when to work on seperating the service from the WebAPI we still can relay on the service that it will do it's work.

 ## What's Missing
 - Alot of Unit Testing for Player and Board Services
 - Integration Tests for the End Points
 
 ## Is the Code Needs Enhancements 
 
 Indeed Give infinite Time and will do the best code EVER. please note this test made within time limition. BUT it's maintainable 


