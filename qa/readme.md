# ParkBee QA Assessment
We'd like to thank you for taking the time to do our assessment. It consists of a coding test and some technical questions.

## Completed assessment
In order for us to review your completed assessment, please put your answers to the technical questions in the technical.md file and ensure that your completed coding test is in a single folder. Compress the folder to a zip file and place it on a shared Google Drive folder or similar and send the link to your recruiter or ParkBee employee who assigned you the test.

## Coding test
### 1. Automated UI testing

At ParkBee, we want to make sure our garages are used at the full capacity and users get the best prices possible. That is why we are using dynamic pricing in our most popular locations. 

Your task is to create automated tests that validate the dynamic pricing feature on [https://parkbee.com](https://parkbee.com). 
Feature: 

#### Scenario 1
- `Given` I am on the [parkbee.com](https://parkbee.com) home page
- `When` I input location
- `Then` I should be redirected to [https://maps-web.parkbee.com](https://maps-web.parkbee.com)

#### Scenario 2
- `Given` I am on the [maps-web.parkbee.com](https://maps-web.parkbee.com)
- `When` I input location and time 
- `Then` I should see the prices of the nearest locations for that range of time

#### Scenario 3
- `Given` I am on the [maps-web.parkbee.com](https://maps-web.parkbee.com)
- `When` I change the desired parking time 
- `Then` parking prices are updated accordingly

You can use "Nassaukade" as a reference parking location.

Feel free to use any frameworks, libraries and tools of your choice.

### 2. API testing

ParkBee partners are using our public API to provide their users access to Parkbee locations. Our goal is to make sure the API runs smoothly and flawlessly. That is where the automated tests come in use. 

Your next task will be to write the test automation for "Creating booking than start and stop parking session". Its one of the most common flow within ParkBee. 

#### Scenario 1
- `Given` I am Parkbee developer
- `When` I make booking [https://developers.parkbee.net/booking/create]
- `Then` I should create booking in system.

#### Scenario 2
- `Given` I am ParkBee developer
- `When` I confirm booking  [https://developers.parkbee.net/booking/confirm]
- `Then` My booking status should be active instead of in progress.

#### Scenario 3
- `Given` I am ParkBee developer
- `When` I want to start parking session [https://developers.parkbee.net/booking/start-parking]
- `Then` this action should start parking session for my booking

#### Scenario 4
- `Given` I am ParkBee developer
- `When` I want to stop parking session [https://developers.parkbee.net/booking/stop-parking]
- `Then` This action should stop parking session for my booking

Happy and unhappy paths needs be covered based on api documentation.

#### Test data:
You can mock api response in your needs. 

Feel free to use any frameworks, libraries, and tools of your choice.

## Requirements
You can spend as much or as little time on the assessment as you want, but try your best to meet the following requirements:

- Tests should cover success-path as well as edge cases.
- The code must compile and run in one step.
- Provide instructions on how to run your code; include them in the readme file.
- Do not include artifacts from your local builds such as third party packages and bin folders.

## Added awesomeness
We would like to get a feel for how you would work on a day-to-day basis. Therefore consider the following:

- Add (or don't add) comments, documentation, etc.
- Apply your code style and structure the test cases.
- Report (or don't) the bugs if you spot them.

## Technical questions
Please put answers to the following questions in the technical.md file before adding it to the final zip file:

- What testing frameworks are you using currently or have worked on recently?
- What do you think of them and would you want to use them again?
- What future or current technology do you look forward to using the most and why?
- How would you improve the dynamic pricing functionality or API methods you were testing (bug fixes, usability suggestions, etc.)?
- How would you improve your test suite if you had more time?

We thank you for your time in completing this assessment. If you have questions or comments, please forward them to the person who assigned you the assessment.
