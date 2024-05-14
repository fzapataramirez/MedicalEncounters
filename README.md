# MedicalEncounters

How to run the project on your local machine.

## 1. Create a local development certificate to be used in the API container

### Windows


```bash
dotnet dev-certs https -ep "$env:USERPROFILE\.aspnet\https\aspnetapp.pfx"  -p $CREDENTIAL_PLACEHOLDER$
```

### macOS or Linux

```bash
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p $CREDENTIAL_PLACEHOLDER$
```

In the preceding commands, replace ```$CREDENTIAL_PLACEHOLDER$``` with a password.


## 2. Trust development certificates

```bash
dotnet dev-certs https --trust
```

```dotnet dev-certs https --trust``` is only supported on macOS and Windows. You need to trust certificates on Linux in the way that is supported by your distribution. It is likely that you need to trust the certificate in your browser.




## 3. Update docker-compose.override.yml 

Update the password in the ```docker-compose.override.yml``` file that is in the root of the solution folder.

```code
ASPNETCORE_Kestrel__Certificates__Default__Password=password
```

The password specified in the file must match the password used for the certificate.

## 4. Run docker compose

```bash
docker-compose up
```

## Deliverables

- [Docker file](MedicalEncounters/MedicalEncounters.Api/Dockerfile)
- [Docker compose file](MedicalEncounters/docker-compose.yml)
- [DB initialization script](MedicalEncounters/init.sql): Database is automatically initialized when the postgres container is created.