# ParkBee DevOps Assessment

We'd like to thank you for taking the time to do our DevOps assessment. It consists of a [pratical test](#pratical-test).

We'll provide an AWS account for you to create & configure the resouces needed for this assessment.

You'll have to use EKS and ECR for deploying the kubernetes cluster and docker images

## Completed assessment

In order for us to review your completed assessment, please, share the results via GitHub repository.

## Pratical test

At ParkBee, we want to know if a Kubernetes cluster is functioning as expected.

Your task is to create the following resources:

* Kubernetes cluster
* Create an account on Kubernetes with limited permissions (e.g. only access in a specific namespace)
* Set up & deploy the [dockers](./docker) containers in the cluster. One needs to be only accessible in the cluster, the other one exposed externally

### Personal choice

You can create the resouces using Infra-as-a-Code (IaaC) tool(s) of your choice. Feel free to use a module created by the community or create your own from scratch. You can also use AWS services, modules, tools, frameworks, or libraries of your choice.
However please indicate what projects we need to set to startup or provide us with details on how to run the projects.

### Additional information

* The `./docker/api` and `./docker/app` needs to be deployed in the cluster
* The `app` reads three environment variables, `API_HOST` (the host configured in the API), `API_PORT` (the port configured in the API), and `PORT` (the port to expose the app).
* The `api` reads one environment variable, `HTTP_PORT` (the port to expose the API).
* The API has three endpoints, `/random-text`, `/ping` (can be used in the POD's health check), and `/health` (can be used in the POD's health check).
* * The app has three endpoints, `/`, `/ping` (can be used in the POD's health check), and `/health` (can be used in the POD's health check).
* You'll have to build & publish the [docker containers](./docker)

## Requirements

You can spends as much or as little time on the assessment as you want, but try your best to meet the following requirements:

* Healthy cluster & PODs
* Cluster is secure
* EKS and ECR are used
* Terraform is used for deploying the infra
* **We must be able to replica your solution**

### Added awesomeness

We would like to get a feel for how you would code on a day-to-day basis. Therefor consider the following:

* Cluster is fully monitored
* Cluster is having a log management platform (it can be ELK)
* A pipeline (GitHub actions is fine) for terraform and k8s deployment 
* Cost-efficience
* Following the best practices
* Fix (or don't) bugs if you spot them
* Don't expose your cluster's API to the whole internet
* Don't set the environment variables in the [Dockerfiles](./docker)

We thank you for your time in completing this assessment. If you have questions or comments, please forward them to the person who assigned you the assessment.
