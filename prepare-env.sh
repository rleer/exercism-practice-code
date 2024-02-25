#!/usr/bin/env bash

exercise_name=$1

# download code
echo exercism download --track=csharp --exercise=${exercise_name}

# prepare SLN
echo dotnet sln list | tail -1 | xargs dotnet sln remove
echo dotnet sln add $(find ${exercise_name} -type f -name \*.csproj)

# commit
git add .
git commit -m "Add initial code for ${exercise_name} exercise"
