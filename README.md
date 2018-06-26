# Developing a (SNS triggered) Lambda function locally

# Overview

This is a proof of concept. It tries to put into practice the following idea. When a message gets published to an Amazon SNS topic, a Lambda function is triggered. The Lambda function tries to execute some business logic, and might succeed or fail.

When the function returns successfully, we expect the message in the SNS topic to be de-queued.

When the function fails, we expect it to fail a maximum of three times, after which the message should be de-queued, and routed/enqueued to a deadletter queue.

When a message gets routed/enqueued from the deadletter to the operational queue, we expect to be able to retry the process.

# Todo

To validate the idea, we have composed the following acceptance criteria.

- [ ] It is possible to develop the AWS function 
- [ ] A failed Lambda function puts the SNS message on a deadletter queue
- [ ] We can trigger a Lambda function by publishing a message to an SNS topic
- [ ] We can test an AWS Lambda function 
- [ ] We can test the integration of the SNS topic and Lambda function 
- [ ] We can re-queue messages from the deadletter queue to the SNS topic 

# Steps

```
powershell
.\build.ps1 -Target=Package
sam local start-api
```
