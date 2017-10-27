## Run MSSQL on Linux/MacOS using Docker

```
docker run --name sharpenter-iam -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=password.123' -p 1433:1433 -d microsoft/mssql-server-linux:latest
```
