# Blazor OnlineShop CourseSubmission CS  [![Tests](https://github.com/EmmaGabrielsson/OnlineShop_CourseSubmission_CS/actions/workflows/tests.yml/badge.svg)](https://github.com/EmmaGabrielsson/OnlineShop_CourseSubmission_CS/actions/workflows/tests.yml)

## Introduction
This project is an online shop app built with Blazor WebAssembly and includes 
unit tests for various features. The app fetches products from an API (https://fakestoreapi.com/) and displays
them on the page. Users can navigate through the menu or search for different 
products using a search bar. The app includes the ability to add, remove, 
and update products in a cart. There is also the option to add items to a wishlist. 
The cart functionality has been tested with unit tests.

##Project Structure
The solution includes both the Blazor WebAssembly online shop project and 
unit tests for the cart functionality in the same solution.

## Getting Started
To run this project, you will need to have the following installed on your machine:
- .NET 7.0
- Visual Studio

### Running the App
1. Clone the repository to your local machine
2. Open the solution in Visual Studio
3. Restore the NuGet packages by right-clicking on the solution and selecting "Restore NuGet Packages" or running dotnet restore from the command line in the root directory of the solution.
4. Build the solution by running dotnet build from the command line in the root directory of the solution.
5. Run the tests by right-clicking on the test project and choosing "Run Tests" or by running dotnet test from the command line in the test project's directory.
6. Run the project by clicking on the "Start" button or by pressing F5

## Unit Tests
The project includes unit tests for features including the shopping cart. To run the tests, follow these steps:
1. Open the solution in Visual Studio or Visual Studio Code
2. Right-click on the solution and select "Restore NuGet Packages"
3. Right-click on the solution and select "Build Solution"
4. Right-click on the test project and select "Run Tests"

## Features
- Fetch products from an API
- Display products on the page
- Navigation menu
- Search bar
- Shopping cart with functions:
  - Add items
  - Remove items
  - Update total price and quantity
- Wishlist with ability to add items
- Unit tests for the shopping cart

## Technology Stack
- Blazor WebAssembly
- .NET 7.0
- Visual Studio
- NuGet packages

## Conclusion
This Blazor WebAssembly online shop app provides a simple and intuitive 
interface for users to browse and purchase products. The app includes features 
such as a shopping cart and a wishlist, with the ability to add and remove items 
and update the total price and quantity. The cart functions are tested with unit 
tests to ensure high-quality code. Try it out by following the instructions above!
