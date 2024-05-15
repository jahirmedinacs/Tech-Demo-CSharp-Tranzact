# Tech Demo C# Tranzac

# Important

This project contains 2 versions, the first one ***"SolutionV1"*** is the base version
of the project, and the second one ***"SolutionV2"*** is the improved version of the project.

Both of them behave the same way, but the second version has some improvements in the code 
and file organization.

So, please , check the ***"SolutionV2"*** for the Interview, because the ***"SolutionV1"*** is 
not longer maintained.

## Introduction

This project is the given solution for the Technicall Interview Challenge, check the 
file [Challenge.pdf](Challenge.pdf "Challenge.pdf") for more information.

## Requirements

- Dotnet Core 6.0
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
allure serve bin/Debug/net6.0/allure-results
```



