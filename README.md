SupportTicket
=============


This is a project to demonstrate some of the technologies that I am working on, using DevOps best practices (broadly based upon the [Twelve Factor App approach](https://12factor.net/)).  

## Running Deployments

### AWS
* http://react.ticket-track.com
* http://webapi.ticket-track.com

### Azure
* http://dev.react.ticket-track.com
* http://dev.webapi.ticket-track.com

## Overview
Support Ticket is a simple application which allows you to capture support tickets into a database. You can add, view and edit tickets. 

## Authentication
You need to register, and sign in order to capture tickets.  The authentication is implemented on the browser (using JWT tokens) as well as in the back end, using .Net Core "Authorize" attributes and JWT integration.

## Kubernetes
The application demonstrates full DevOps automation from end to end, allowing you to deploy to multiple Kubernetes cloud hosts (AWS and Azure AKS are supported).

## Versioning
The deployed version appears at the foot of each of the pages of the application e.g. **Docker: virasana/streact:2.0.20190103.3**

## Technologies and architecture
It is a React front end, with a .Net Core REST API. There is also a legacy .Net Core front end. 
There are three Docker containers (all Linux): 

* React front end
* .Net Core Web API with Entity Framework Core
* SQL Server

All dev and test is done using the Microsoft Linux SQL Server image.  (Containers facilitate parity between dev and test - we see a great reduction in configuration drift!)
Production uses a managed SQL Server database, hosted on AWS using their Relational Database Service (RDS)

## Devops Practices
### Configuration as Code
The application is automated from top to bottom (I have been calling this "Systems As Code" - see [here](https://www.slideshare.net/virasana/clipboards/systems-as-code-a-model-for-devops-automation?rftp=success_toast).  


See my presentation [on SlideShare](https://www.slideshare.net/virasana/deployment-for-dev-ops-with-service-fabric-127250670).








