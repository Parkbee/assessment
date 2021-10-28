# ParkBee DevOps Assessment

We'd like to thank you for taking the time to do our DevOps assessment. It consists of a [pratical test](#pratical-test).

We'll provide an AWS account, and a MongoDB credentials for you to create & configure the resouces needed for this assessment.

## Completed assessment

In order for us to review your completed assessment, please, share the results via ~private~ GitHub repository.

## Pratical test

At ParkBee, we want to know if a Kubernetes cluster is functioning as expected.

Your task is to create the following resources:

* Kubernetes cluster
* Create an account on Kubernetes with limited permissions (e.g. only access in a specific namespace)
* Set up & deploy the [dockers](./docker) containers in the cluster. One needs to be only accessible in the cluster, the other one exposed externally
* The [API container](./docker/Dockerfile-api) needs to be configure to access a MongoDB cluster

### Personal choice

You can create the resouces using Infra-as-a-Code (IaaC) tool(s) of your choice. Feel free to use a module created by the community or create your own from scratch. You can also use AWS services, modules, tools, frameworks, or libraries of your choice.
However please indicate what projects we need to set to startup or provide us with details on how to run the projects.

### Additional information

* The [Dockerfiles](./docker) needs to be deployed in the cluster
* The MongoDB connection string needs to be configured as a environment variable
* The app has three endpoints, `/`, `/ping` (can be used in the POD's health check), and `/health` (can be used in the POD's health check).
* The app reads three environment variables, `API_HOST` (the host configured in the API), `API_PORT` (the port configured in the API), and `HTTP_PORT` (the port to expose the app).
* The API reads three environment variables, `MONGODB_USER` (the user to connect with the MongoDB), `MONGODB_PASSWORD` (the password to connect with the MongoDB), and `HTTP_PORT` (the port to expose the API).
* The API has three endpoints, `/random-text`, `/ping` (can be used in the POD's health check), and `/health` (can be used in the POD's health check).
* You'll have to build & publish the [docker containers](./docker)

## Requirements

You can spends as much or as little time on the assessment as you want, but try your best to meet the following requirements:

* Healthy cluster & PODs
* Cluster is secure
* Share your IaaC & answers in a private repository
* **We must be able to replica your solution**

### Added awesomeness

We would like to get a feel for how you would code on a day-to-day basis. Therefor consider the following:

* Cluster is fully monitored
* Cost-efficience
* Following the best practices
* Fix (or don't) bugs if you spot them
* Don't expose your cluster's API to the whole internet
* Don't set the environment variables in the [Dockerfiles](./docker)

We thank you for your time in completing this assessment. If you have questions or comments, please forward them to the person who assigned you the assessment.
