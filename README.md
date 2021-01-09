# Home Programming Assessment
Repo for submitting coding assessments completed by potential hires.

## What to Include
### Schema
SQL for creating your database tables

### Dataset
Insert statements to populate your tables with

## Objective
In an object-oriented language of your choosing, create an api that will accept a US state abbreviation as input and return information regarding votes.
The GET request should return the following stats.

* **Full state name**
* **Total number of registered voters**
* **Total number of voters (ballots cast)**
* **Voter turnout** (percentage of registered voters who cast a ballot)
* **Number of valid votes**
* **Number of invalid votes**
* **Percentage of mail-in votes**
* **Percentage of in-person votes**
* **Percentage of early votes**

Additionally there should be a POST request that accepts input for new votes.
* Define what the input should be for this request

Finally, we need a PUT request that will allow us to update a particular vote to mark it invalid

## Submission
Create a fork of this repository to complete your work in. Once done submit a pull request containing
1. schema.sql
2. dataset.sql
3. README.md with instructions on how to setup and run your code. This should include details for how to do your GET/POST requests. 
4. The complete codeset

**Note:: You do not need to do all 50 states. Just a few to allow us to test the api should suffice. Also it does not have to use actual voter data. We are mainly looking for the schema, coding and logic.This assessment is intended to take 2 - 3 hours max.** 




# Submission Details
This project is built in C# using .net core, so you will need dotnet SDK installed to be able to run this locally.

The SDK can be found here: https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.404-macos-x64-installer
(Make sure you download version 3.1 as that is the version that I used to build this)

Once the SDK is installed and you verify the CLI works, you should be able to run `dotnet restore` to download any dependecies needed to run project. After that you should be able to run `dotnet run` this will expose port https://localhost:5001

In order to run the actual requests successfully you'll need to run a docker container with mysql with the following command:

```docker run -p 3306:3306 -p 33060:33060 --name=mysql57 -e MYSQL_ROOT_PASSWORD=secret -e MYSQL_PASSWORD=secret -e MYSQL_USER=admin -e MYSQL_DATABASE=VotingInformation -d mysql/mysql-server:5.7```

if you don't have docker installed locally, that can be downloaded here: https://www.docker.com/products/docker-desktop

I also added a postman collection here: [Postman Collection](VotingInformation.postman_collection.json) that you can use to run the get, post and put requests.