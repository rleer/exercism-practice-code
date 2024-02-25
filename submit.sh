#!/usr/bin/env bash

exercise_name=$1

file_name=$(grep -ohE "([[:alnum:]]+\.cs)" ${exercise_name}/HELP.md)
exercism submit ${exercise_name}/${file_name}

if [ "$(git status --porcelain)" ]; then 
  git add .
  git commit -m "Add solution for ${exercise_name} exercise"
else 
  echo "Nothing to commit"
fi
