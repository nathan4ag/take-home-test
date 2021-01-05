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

**Note:: You do not need to do all 50 states. Just a few to allow us to test the api should suffice. Also it does not have to use actual voter data. We are mainly looking for the schema, coding and logic. 
