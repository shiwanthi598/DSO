# DSO.EmailOTPModule

## Overview
The **DSO.EmailOTPModule** is a .NET 8.0-based module designed for handling OTP (One-Time Password) generation and validation services. This module is structured to provide secure and scalable OTP functionalities through a RESTful API.

## Features
- **Generate OTP**: Issue OTPs for secure authentication processes.
- **Validate OTP**: Verify the correctness of an OTP entered by the user.
- **RESTful API**: Easily integrate with other applications through HTTP requests.
- **Unit Testing**: Comprehensive test coverage using xUnit for quality assurance.

## Project Structure
The project contains the following directories and files:

DSO ├── DSO.EmailOTPModule │ ├── Controllers │ │ └── OtpController.cs 
│ ├── Models │ │ ├── OtpRequest.cs │ │ ├── OtpResponse.cs │ │ └── OtpValidationRequest.cs 
│ ├── Services │ │ ├── IOtpService.cs │ │ └── OtpService.cs 
│ ├── Utilities 
│ ├── Program.cs 
│ ├── appsettings.json 
│ ├── DSO.EmailOTPModule.csproj 
├── DSO.EmailOTPModule.Tests │ ├── OtpControllerTests.cs │ ├── OtpServiceTests.cs │ ├── UnitTest1.cs
│ └── DSO.EmailOTPModule.Tests.csproj
