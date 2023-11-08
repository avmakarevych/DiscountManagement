# DiscountManagement

Welcome to the DiscountManagement system! This web application is designed to manage personalized discounts for customers efficiently and effectively. Below you will find the details of this project, including its features, requirements, and how to set it up for use.

## Features

The DiscountManagement system offers a variety of functionalities to cater to the needs of managing customer discounts:

- **Customer Account Creation:** Assign a unique personal account code to new customers.
- **Edit Personal Information:** Allows for the modification of customer's personal details.
- **Personalized Discounts Assignment:** Administer personalized discounts to customers.
- **Purchase History Tracking:** Keep a record of customer purchases/orders along with the product details like id, name, and price.
- **Discounted Price Calculation:** Implement a test method to calculate the price of a product considering the customer discount.

## Requirements

To run this project successfully, ensure that your system meets the following requirements:

- ASP.Net Core 5.0 or higher
- MS SQL Server
- Entity Framework Core

Note that the visual appearance is not a priority, and the project should utilize Clean Architecture for its design.

## Installation

Here’s a quick guide to get the DiscountManagement system up and running:

1. Clone the repository to your local machine:
    ```
    git clone https://github.com/avmakarevych/DiscountManagement.git
    ```
2. Ensure that ASP.NET Core 5.0 or higher is installed on your machine.
3. Set up an MS SQL Server instance and configure the connection string accordingly.
4. Use Entity Framework migrations to set up the database schema:
    ```
    dotnet ef database update
    ```
5. Build and run the project:
    ```
    dotnet build
    dotnet run
    ```
