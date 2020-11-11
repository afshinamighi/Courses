#!/bin/bash
path="./ConcurrentCSharp/"
file="ConcurrentCSharp.sln"
package="ConcurrentCSharp"
dest="/Users/amighi/Google Drive File Stream/Shared drives/AnalysisTeam/Courses/Analysis 6 - Concurrency/Practicum/"
solution="$path$file"
dotnet build $solution
dotnet clean $solution

zip -r "$package.zip" $package
mv "$package.zip" "$dest$package.zip"
