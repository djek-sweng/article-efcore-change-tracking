#!/bin/sh

dotnet ef migrations remove \
  --context "DatabaseContext" \
  --project "./../ChangeTracking.Library/ChangeTracking.Library.csproj" \
  --force
