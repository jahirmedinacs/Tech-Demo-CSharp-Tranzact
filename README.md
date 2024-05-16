# Tech Demo C# Tranzac

Report Published Status

[![pages-build-deployment](https://github.com/jahirmedinacs/Tech-Demo-CSharp-Tranzact/actions/workflows/pages/pages-build-deployment/badge.svg?branch=WebReport&event=deployment)](https://github.com/jahirmedinacs/Tech-Demo-CSharp-Tranzact/actions/workflows/pages/pages-build-deployment)

## Introduction

This project is the given solution for the Technicall Interview Challenge, check the 
file [Challenge.pdf](Challenge.pdf "Challenge.pdf") for more information.

## Requirements

- Dotnet Core 6.0
- Allure CLI 2
- Specflow 3
- Nunit 3
- Allure.Specflow Plugin

## How to run

To run the tests, you need to have the dotnet core 6.0 installed on your machine, 
then you can run the following command:

```bash
dotnet test "./TechDemoCSharpTranzsact.sln"
```

for the execution of a specific feature, you can use the following command:

```bash
dotnet test "./TechDemoCSharpTranzsact.sln" --filter TestCategory=TagName
```

## How to generate the report

To generate the report, you need to have the allure command line installed on your machine, 
then you can run the following command:

```bash
allure serve bin/Debug/net6.0/allure-results
```



