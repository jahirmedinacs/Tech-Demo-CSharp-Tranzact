
# Tech Demo CSharp Tranzact# Tech Demo C# Tranzac

## Introduction

This project is the given solution for the Technicall Interview Challenge, check the 
file [Challenge.pdf](Challenge.pdf "Challenge.pdf") for more information.

## Requirements

- Dotnet Core 8.0
- Allure Command Line 2
- Specflow 3
- Nunit 3
- Allure.SpecflowPlugin

## How to run

To run the tests, you need to have the dotnet core 6.0 installed on your machine, 
then you can run the following command:

```bash
dotnet test
```

for the execution of a specific feature, you can use the following command:

```bash
dotnet test --filter TestCategory=TagName
```

## How to generate the report

To generate the report, you need to have the allure command line installed on your machine, 
then you can run the following command:

```bash
allure serve .\bin\Debug\netcoreapp8.0\allure-results\
```



