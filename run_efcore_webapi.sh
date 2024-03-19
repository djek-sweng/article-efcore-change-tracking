#!/bin/sh

# set variables
SLN_FILE="./src/ChangeTracking/ChangeTracking.sln"
CSPORJ_FILE="./src/ChangeTracking/ChangeTracking.WebApi/ChangeTracking.WebApi.csproj"

# clean solution
dotnet clean "$SLN_FILE"

# run .NET application
dotnet run --project "$CSPORJ_FILE" -c Release
