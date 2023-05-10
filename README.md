# Project Readme

This project consists of a microservices-based architecture for an e-commerce application. The project is built using Docker containers and the services communicate with each other using HTTP requests.

## Services

The project contains the following services:

- **catalogdb:** a MongoDB database used for storing product data
- **basketdb:** a Redis database used for storing customer shopping cart data
- **discountdb:** a PostgreSQL database used for storing discount data
- **identitydb:** a Microsoft SQL Server database used for storing user and authentication data
- **orderdb:** a Microsoft SQL Server database used for storing customer order data
- **rabbitmq:** a RabbitMQ message broker used for communication between services
- **catalog.api:** a .NET Core web API service responsible for handling product-related requests
- **identityserver.api:** a .NET Core web API service responsible for handling authentication and user-related requests
- **basket.api:** a .NET Core web API service responsible for handling shopping cart-related requests
- **photostock.api:** a .NET Core web API service responsible for handling photo-related requests
- **discount.api:** a .NET Core web API service responsible for handling discount-related requests
- **fakepayment.api:** a .NET Core web API service responsible for simulating payment processing
- **order.api:** a .NET Core web API service responsible for handling customer order-related requests
- **gateway.api:** a .NET Core web API service acting as an entry point for the application, responsible for routing requests to the appropriate services

## Volumes

The project contains the following volumes:

- **catalogdb_volume:** used to persist MongoDB data
- **discount_volume:** used to persist PostgreSQL data
- **identitydb_volume:** used to persist Microsoft SQL Server data
- **orderdb_volume:** used to persist Microsoft SQL Server data
- **products_photos:** used to store product photos

## Usage

To run the application, Docker and Docker Compose must be installed. Then, run the following command:

```
docker-compose up
```

This will start all the services and create the necessary containers. Once the services are up and running, the application can be accessed through the `gateway.api` service. The default URL for the gateway is `http://localhost:7000`.

## Conclusion

This project demonstrates a microservices-based architecture for an e-commerce application, built using Docker containers and various technologies such as MongoDB, Redis, PostgreSQL, and Microsoft SQL Server. It provides a scalable and flexible solution for developing and deploying large-scale applications.