# DockerCompose.NET
Example ASP.NET Core project with PostgresQL database demonstrating deployment to VPS using docker and docker-compose.

### How To

1. Clone the repo to your development machine
2. Make necessary changes to `docker-compose-dev.yml`, `docker-compose-prod.yml` and `.env` files
3. Setup development environment: `docker-compose -f docker-compose-dev.yml --env-file .env up -d --build`
4. Create *EntityFramework* migrations: `dotnet ef migrations add <MigrationName>`
5. Generate *sql* file for the migration: `dotnet ef migrations script -s ./WebApp -p ./Infrastructure -o ./DbScripts/migration.sql`
6. Commit & push
7. Clone the repo to your server
8. `cd` into the project then: `source .env`
9. Build and deploy the containers: `docker-compose --env-file .env up -d --build`
10. Access the *todo_postgres* container: `docker exec -it todo_postgres /bin/bash`
11. Apply the database migration script: `psql -U "<your_db_username>" -d "<your_db_name>" -a -f scripts/migration.sql` or directly by: `docker exec -it todo_postgres psql -U "${DB_USERNAME}" -d "${DB_DATABASE}" -a -f scripts/migration.sql`
12. Setup a reverse proxy in front of your services
