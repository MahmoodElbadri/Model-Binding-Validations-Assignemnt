
# E-Commerce Order Processing

## Overview

This repository contains a simple ASP.NET Core application for processing e-commerce orders. The application allows users to submit orders, and it verifies the correctness of the order details before processing.

## Features

- **Order Submission**: Users can submit orders through the `/order` endpoint.
- **Validation**: The application validates the order details, including the order date, invoice price, and product information.
- **Random Order Number**: Upon successful order submission, the application generates a random order number for tracking purposes.
- **Error Handling**: If there are validation errors or discrepancies in the order details, appropriate error messages are returned to the user.

## Setup

To run the application locally, follow these steps:

1. Clone this repository to your local machine.
2. Open the solution in Visual Studio or your preferred IDE.
3. Build the solution to restore dependencies and compile the code.
4. Run the application using the debugger or by pressing `Ctrl + F5`.
5. Access the application in your web browser at `http://localhost:<port>`.

## Usage

- **Submitting an Order**: Send a POST request to `/order` with the order details in the request body. Make sure to include the order date, invoice price, and product information.
- **Validation Errors**: If there are validation errors in the order details, the application will return a 400 Bad Request response with error messages describing the issues.
- **Successful Order**: Upon successful order submission, the application will return a JSON response containing the randomly generated order number.

