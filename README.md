SupportTicket
=============


This is a project to demonstrate some of the technologies that I am working on, to demonstrate DevOps best practices.

## Overview
Support Ticket is a simple application which allows you to capture support tickets into a database.  

## Authentication
You need to register, and sign in order to capture tickets.  The authentication is implemented on the browser (using JWT tokens) as well as in the back end, using .Net Core "Authorize" attributes and JWT integration.

## Kubernetes
The application demonstrates full DevOps automation from end to end, allowing you to deploy to multiple Kubernetes cloud hosts (AWS and Azure AKS are supported).

## Technologies and architecture
It is a React front end, with a .Net Core REST API.  
There are three Docker containers (all Linux): 

* React front end
* .Net Core Web API
* SQL Server

All dev and test is done using the Microsoft Linux SQL Server image.  (Containers facilitate parity between dev and test - we see a great reduction in configuration drift!)
Production uses a managed SQL Server database, hosted on AWS using their Relational Database Service (RDS)









