# DockerCompose.NET
Example ASP.NET Core project with PostgresQL database demonstrating deployment to VPS using docker and docker-compose.

### How To

1. Clone the repo to your development machine
2. Make necessary changes to `docker-compose.yml` and `.env` files
3. Create *EntityFramework* migrations: `dotnet ef migrations add MigrationName`
4. Generate *sql* file for the migration: `dotnet ef migrations script -s ./WebApp -p ./Infrastructure -o ./DbScripts/migration.sql`
5. Commit & push
6. Clone the repo to your server
7. cd into the project then: `source .env`
8. Build and deploy the containers: `docker-compose --env-file=.env up -d --build`
9. Access the *db* container: `docker-compose exec db bash`
10. Apply the database migration script: `psql -U "<your_db_username>" -d "<your_db_name>" -a -f scripts/migration.sql`
11. Setup a reverse proxy in front of your services
