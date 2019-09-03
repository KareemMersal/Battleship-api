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


