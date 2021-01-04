# Home Programming Assessment
Repo for submitting coding assessments completed by potential hires.

## What to Include
### Schema
SQL for creating your database tables

### Dataset
Insert statements to populate your tables with

## Objective
In an object-oriented language of your choosing, create an api that will accept a US state abbreviation as input and return information regarding COVID.
The GET request should return the following stats.

* **Stage name**
* **Total cases**
* **Total number of deaths**
* **Cases w/in the last 7 days**
* **Total cases per 100k** (i.e. NC has a population of 10,500,000 and roughly 564,000 cases of COVID. That would be ~5,371/100k cases.
* **Total nubmer of deaths per 100k** (similar to above)

Additionally there should be a POST request that accepts input for new cases.
* State Abbreviation

Finally, we need a PUT request that will allow us to update a particular case of COVID as a death

## Submission
Create a fork of this repository to complete your work in. Once done submit a pull request containing
1. schema.sql
2. dataset.sql
3. README.md with instructions on how to setup and run your code. This should include details for how to do your GET/POST requests. 
4. The complete codeset
