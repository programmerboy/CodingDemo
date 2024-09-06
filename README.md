# Coding Demo

**A Repo with different projects like MAUI, Console (Upcoming Web API, Angular etc.)**

## MauiLoginSample ##


In order to compile and run **MauiLoginSample** project, make sure MAUI workloads are installed.

**Command for checking current workloads installed and installing required workloads**

`dotnet workload list`

```
dotnet workload install maui
dotnet workload install maui-android
dotnet workload install android
dotnet workload install maui-windows
dotnet workload install maccatalyst
dotnet workload install ios
```

***Sample Screenshots (for Android)***

![Mobile-Login-Demo](https://github.com/user-attachments/assets/d79166ad-38c0-4203-895c-8b1e93460d07)

## ServerSide ##

In order to run console application, make sure ***.NET 8*** or later is installed.

***Specify your Matrix Dimensions here:*** `var MATRIX_DIMENSIONS = 3;`

***Remember to replace:*** `private const string API_URL = "REPLACE_WITH_API_URL/";`

Sample Response for APIs below:

**api/numbers/init/{0}** = `{"Value":10,"Cause":null,"Success":true}`

**api/numbers/{0}/{1}/{2}** = `{"Value":[-5,4,9,6,-2,-9,-7,1,9,8],"Cause":null,"Success":true}`

**api/numbers/validate** = `{"Value":"A Sample Message","Cause":null,"Success":true}`