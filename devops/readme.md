# ParkBee DevOps Assessment

We'd like to thank you for taking the time to do our DevOps assessment. It consists of a [pratical test](#pratical-test) and some [technical questions](#technical-questions).

We'll provide an AWS account, and a MongoDB credentials for you to create & configure the resouces needed for this assessment.

## Completed assessment

In order for us to review your completed assessment, please put your answers to the technical questions in the [technical.md](technical.md) file and ensure that your completed pratical test is in a single folder. Please, share the results via GitHub.

## Pratical test

At ParkBee, we want to know if a Kubernetes cluster is functioning as expected.

Your task is to create the following resources:

* Kubernetes cluster
* Create an account on Kubernetes with limited permissions (e.g. only access in a specific namespace)
* Deploy the [dockers](./docker) containers in the cluster. One needs to be only accessible in the cluster, the other one exposed externally
* The [API container](./docker/Dockerfile-api) needs to be configure to access a MongoDB cluster

### Personal choice

You can create the resouces using Infra-as-a-Code (IaaC) tool(s) of your choice. Feel free to use a module created by the community or create your own from scratch. You can also use AWS services, modules, tools, frameworks, or libraries of your choice.
However please indicate what projects we need to set to startup or provide us with details on how to run the projects.

### Additional information

* The [Dockerfiles](./docker) needs to be deployed in the cluster
* The MongoDB connection string needs to be configured as a environment variable
* Don't expose your cluster's API to the whole internet
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
* Share your

## Technical questions

Please, put answers to the following questions in the a [technical.md](./technical.md).

1. 
2. 

We thank you for your time in completing this assessment. If you have questions or comments, please forward them to the person who assigned you the assessment.
