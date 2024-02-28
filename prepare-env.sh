#!/usr/bin/env bash

set -ex

exercise_name=$1

# download code
exercism download --track=csharp --exercise=${exercise_name}

# prepare SLN
dotnet sln list | tail -1 | xargs dotnet sln remove
dotnet sln add $(find ${exercise_name} -type f -name \*.csproj)

# remove skip annotations in tests
test_file=$(find ${exercise_name}  -type f -name \*Tests.cs)
sed -i '' -E 's/\(Skip.+\)//g' ${test_file}

# commit
git add .
git commit -m "Add initial code for ${exercise_name} exercise"
