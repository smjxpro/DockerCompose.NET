CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Todos" (
    "Id" uuid NOT NULL,
    "Name" text NULL,
    "IsComplete" boolean NOT NULL,
    CONSTRAINT "PK_Todos" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211225061451_Initial', '6.0.1');

COMMIT;

