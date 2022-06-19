# RabbitMQ-Messaging-Net-Core-Microservices

Example of RabbiotMQ based on udemy course Get Started with .NET Core Microservices using RabbitMQ! in https://www.udemy.com/course/getting-started-net-core-microservices-rabbitmq 


## Use of RabbitMQ in docker

       
```
docker pull rabbitmq:management
```

Then run with the command (this command does both, pull & run):

```
docker run -p 15672:15672 -p 5672:5672 --name rabbit-image-name rabbitmq:management
```

Navigate to: http://localhost:15672/

It worked!

Make sure you stop the other container images before starting this one.

more info: 
+ https://www.rabbitmq.com/download.html
+ https://stackoverflow.com/questions/47290108/how-to-open-rabbitmq-in-browser-using-docker-container
