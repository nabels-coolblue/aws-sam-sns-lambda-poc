# Developing a (SNS triggered) Lambda function locally

# Overview

This is a proof of concept. It tries to put into practice the following idea. When a message gets published to an Amazon SNS topic, a Lambda function is triggered. The Lambda function tries to execute some business logic, and might succeed or fail.

When the function returns successfully, we expect the message in the SNS topic to be de-queued.

When the function fails, we expect it to fail a maximum of three times, after which the message should be routed to a deadletter queue. After that, we expect to be able to re-queue the message manually.

# Todo

To validate the idea, we have composed the following acceptance criteria.

- [X] It is possible to develop the AWS function locally
- [X] It is possible to hook the local AWS function up to an SQS queue 
- [X] A failed Lambda function puts the SQS message on a deadletter queue
- [X] We can trigger a Lambda function by publishing a message to an SQS queue
- [X] We can test an AWS Lambda function 
- [X] We can test the integration of the SNS topic and Lambda function 
- [X] We can re-queue messages from the deadletter queue to the SNS topic 

# Steps

```
powershell
.\build.ps1 -Target=Package
sam local start-api
```

# Role

Make sure there is a role defined with the following permissions:
- AmazonSQSFullAccess
- AWS managed policy

Example:

https://console.aws.amazon.com/iam/home?#/roles/niels-abels-lambda-sns-to-http-role

# Lambda

Setup the lambda as follows:

https://eu-west-1.console.aws.amazon.com/lambda/home?region=eu-west-1#/functions/niels-abels-aws-sns-to-http-lambda?tab=graph

Make sure the input is set to the SQS queue, and define two outputs. Amazon Cloudwatch logs and Amazon SQS.

Next to this, make sure the deadletter queue is provided. This is strange, since the queue also has these settings.

## Updating the lambda

```
aws lambda update-function-code --function-name niels-abels-aws-sns-to-http-lambda --profile=development --region=eu-west-1 --zip-file=fileb://C:\dev\aws-sam-sns-lambda-poc\artifacts\Lambda.zip
```

# Sending a test message

aws sqs send-message --queue-url 	https://sqs.eu-west-1.amazonaws.com/196441879050/restocking-accepted-proposals-dev --message-body "hello, world"
