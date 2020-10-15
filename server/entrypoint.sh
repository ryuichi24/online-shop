#!/bin/bash

set -e
run_cmd="dotnet ./out/server.dll"

until dotnet-ef database update; do
>&2 echo "SQL Server is starting up"
sleep 1
done

>&2 echo "SQL Server is ready"
exec $run_cmd