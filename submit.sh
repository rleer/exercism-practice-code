#!/usr/bin/env bash

exercise_name=$1

file_name=$(grep -ohE "([[:alnum:]]+\.cs)" ${exercise_name}/HELP.md)
echo exercism submit ${exercise_name}/${file_name}

if [ "$(git status --porcelain)" ]; then 
  echo git add .
  echo git commit -m "Add solution for ${exercise_name} exercise"
else 
  echo "Nothing to commit"
fi
