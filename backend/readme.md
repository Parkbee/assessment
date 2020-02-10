# ParkBee Developer Assessment

We'd like to thank you for taking the time to do our developer assessment. It consists of a [coding test](#coding-test) and some [technical questions](#technical-questions).

## Completed assessment

In order for us to review your completed assessment, please put your answers to the technical questions in the [technical.md](technical.md) file and ensure that your completed coding test is in a single folder. Compress the folder to a zip file and place it on a shared Google Drive folder, DropBox folder or similar and send the link to your recruiter or ParkBee employee who assigned you the test.

## Coding test

At ParkBee, we want to know if a garage is functioning as expected.

Your task is to create an application that calls an API that accepts a garage identifier and display:

* Garage details e.g. Name, Address, Status, etc.
* The collection of doors for the garage
* Visual indicator if a door is online

To help you get started, we've created a .NET Core Web API with some simple features:

* An in-memory database context with a Garages db set.
* Jwt authentication that compares the username and password. If they match, it returns a hard-coded claim with some user details and a garage identifier. To request a token you can call the `http://{{url}}/token` endpoint.
* Swagger documentation to help you call the API.

### Personal choice

You can create the front-end as an Angular app, ASP.NET MVC or framework of your choice. Feel free to use the provided API or create your own from scratch. You can also use packages, frameworks or libraries of your choice. You don't need to use entity framework etc. from the current API.
However please indicate what projects we need to set as startup projects in the Visual Studio solution or provide us with details on how to run the projects. It **must** compile and run in one step.

### Additional information

* The garage entity in the sample project needs to be extended to include more properties.
* Door, owner and/or other entities must be added as needed.
* Each garage contains one or more door(s).
* Each door has an IP address that can be pinged to determine status.
* If no ping response is returned, then the door is offline.
* A login page is not required. The token can be requested when the application starts up.
* An owner can have only one garage or vice versa. Implementation is up to you.

## Requirements

You can spends as much or as little time on the assessment as you want, but try your best to meet the following requirements:

* Complete the user stories below and ensure that the acceptance criteria are met.
* **You must include tests for the API (back-end).** Front-end tests are note required.
* Call the context/repository from a service and not directly from the controllers.
* Do not include artifacts from your local builds such as nuget packages and bin folders.
* **The code must compile and run in one step.**
* Each request must be authorized by checking the bearer token in the header.

## User stories

As a **garage owner**  
I want to **view my garage details and all the doors for the garage**  
So that **I know if my garage is online or not**  

#### Acceptance criteria

* See details of the supplied garage only.
* Status for each door is displayed.

As a **garage owner**  
I want to **refresh the status of the my garage**  
So that **I get the actual status for each door**

#### Acceptance criteria

* Must be able to manually trigger the refresh action.
* If a door is not reached/offline, then the system should retry 2 more times before updating the status to offline.
* A history of status changes should be persisted (only when status has changed).

### Added awesomeness

We would like to get a feel for how you would code on a day-to-day basis. Therefor consider the following:

* Refactor the existing code or the new code that you've added.
* Add (or don't add) comments, swagger documentation, logging, etc.
* Apply your code style.
* Fix (or don't) bugs if you spot them.

## Technical questions

Please put answers to the following questions in the [technical.md](technical.md) file before adding it to the final zip file:

1. What architectures or patterns are you using currently or have worked on recently?
2. What do you think of them and would you want to implement it again?
3. What version control system do you use or prefer?
4. What is your favorite language feature and can you give a short snippet on how you use it?
5. What future or current technology do you look forward to the most or want to use and why?
6. How would you find a production bug/performance issue? Have you done this before?
7. How would you improve the sample API (bug fixes, security, performance, etc.)?

We thank you for your time in completing this assessment. If you have questions or comments, please forward them to the person who assigned you the assessment.

