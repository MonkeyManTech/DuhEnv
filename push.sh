#!/usr/bin/env bash
set -euo pipefail

TARGET_PACKAGE=$1
NUGET_TARGET_SERVICE=$2
NUGET_API_KEY=$3

if [ "$TARGET_PACKAGE" = "duhenv" ]; then
  TARGET_PACKAGES="$(find -wholename "./src/DuhEnv/**/*.nupkg")"
else
  echo "Unexpected target package name \"$TARGET_PACKAGE\"; Accepted values: duhenv"
  exit 1
fi
  

if [ "$NUGET_TARGET_SERVICE" = "noob" ]; then
  NUGET_TARGET_URL="https://nuget.nickthenoob.com/v3/index.json"
elif [ "$NUGET_TARGET_SERVICE" = "nuget" ]; then
  NUGET_TARGET_URL="https://api.nuget.org/v3/index.json"
else
  echo "Unexpected NuGet service name \"$NUGET_TARGET_SERVICE\"; Accepted values: noob, nuget"
  exit 1
fi

for package in $(echo "$TARGET_PACKAGES" | grep "test" -v); do
  echo "${0##*/}": Pushing $package to $NUGET_TARGET_SERVICE \($NUGET_TARGET_URL\)...
  dotnet nuget push $package --source $NUGET_TARGET_URL --api-key $NUGET_API_KEY
done
