﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "AspNetRoles" (
    "Id" text NOT NULL,
    "Name" character varying(256) NULL,
    "NormalizedName" character varying(256) NULL,
    "ConcurrencyStamp" text NULL,
    CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id")
);

CREATE TABLE "AspNetUsers" (
    "Id" text NOT NULL,
    "UserName" character varying(256) NULL,
    "NormalizedUserName" character varying(256) NULL,
    "Email" character varying(256) NULL,
    "NormalizedEmail" character varying(256) NULL,
    "EmailConfirmed" boolean NOT NULL,
    "PasswordHash" text NULL,
    "SecurityStamp" text NULL,
    "ConcurrencyStamp" text NULL,
    "PhoneNumber" text NULL,
    "PhoneNumberConfirmed" boolean NOT NULL,
    "TwoFactorEnabled" boolean NOT NULL,
    "LockoutEnd" timestamp with time zone NULL,
    "LockoutEnabled" boolean NOT NULL,
    "AccessFailedCount" integer NOT NULL,
    "Nombres" character varying(20) NOT NULL,
    "Apellidos" character varying(20) NOT NULL,
    "FechaNacimiento" timestamp without time zone NULL,
    CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id")
);

CREATE TABLE "Cursos" (
    "CursoId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Nombre" character varying(30) NOT NULL,
    "Descripcion" character varying(100) NOT NULL,
    "Grado_academico" character varying(20) NOT NULL,
    CONSTRAINT "PK_Cursos" PRIMARY KEY ("CursoId")
);

CREATE TABLE "Docentes" (
    "DocenteId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Nombres" character varying(20) NOT NULL,
    "Apellidos" character varying(20) NOT NULL,
    "DNI" character varying(9) NOT NULL,
    "Domicilio" character varying(100) NOT NULL,
    "Correo" character varying(50) NOT NULL,
    "Disponibilidad" character varying(20) NOT NULL,
    "Numero_cuenta" character varying(20) NOT NULL,
    "Membresia" character varying(20) NOT NULL,
    CONSTRAINT "PK_Docentes" PRIMARY KEY ("DocenteId")
);

CREATE TABLE "Padres" (
    "PadreId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Nombres" character varying(20) NOT NULL,
    "Apellidos" character varying(20) NOT NULL,
    "DNI" character varying(9) NOT NULL,
    "Correo" character varying(50) NOT NULL,
    CONSTRAINT "PK_Padres" PRIMARY KEY ("PadreId")
);

CREATE TABLE "Tarjetas" (
    "TarjetaId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Fecha_expiracion" character varying(10) NOT NULL,
    "Nombre_poseedor" character varying(20) NOT NULL,
    "Numero_tarjeta" character varying(20) NOT NULL,
    CONSTRAINT "PK_Tarjetas" PRIMARY KEY ("TarjetaId")
);

CREATE TABLE "AspNetRoleClaims" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "RoleId" text NOT NULL,
    "ClaimType" text NULL,
    "ClaimValue" text NULL,
    CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserClaims" (
    "Id" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "UserId" text NOT NULL,
    "ClaimType" text NULL,
    "ClaimValue" text NULL,
    CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserLogins" (
    "LoginProvider" text NOT NULL,
    "ProviderKey" text NOT NULL,
    "ProviderDisplayName" text NULL,
    "UserId" text NOT NULL,
    CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
    CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserRoles" (
    "UserId" text NOT NULL,
    "RoleId" text NOT NULL,
    CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserTokens" (
    "UserId" text NOT NULL,
    "LoginProvider" text NOT NULL,
    "Name" text NOT NULL,
    "Value" text NULL,
    CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
    CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Alumnos" (
    "AlumnoId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "PadreId" integer NOT NULL,
    "Nombres" character varying(20) NOT NULL,
    "Apellidos" character varying(20) NOT NULL,
    "DNI" character varying(9) NOT NULL,
    "Grado_academico" character varying(20) NOT NULL,
    "Correo" character varying(50) NOT NULL,
    CONSTRAINT "PK_Alumnos" PRIMARY KEY ("AlumnoId"),
    CONSTRAINT "FK_Alumnos_Padres_PadreId" FOREIGN KEY ("PadreId") REFERENCES "Padres" ("PadreId") ON DELETE CASCADE
);

CREATE TABLE "Favoritos" (
    "FavoritoId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "PadreId" integer NOT NULL,
    "DocenteId" integer NOT NULL,
    CONSTRAINT "PK_Favoritos" PRIMARY KEY ("FavoritoId"),
    CONSTRAINT "FK_Favoritos_Docentes_DocenteId" FOREIGN KEY ("DocenteId") REFERENCES "Docentes" ("DocenteId") ON DELETE CASCADE,
    CONSTRAINT "FK_Favoritos_Padres_PadreId" FOREIGN KEY ("PadreId") REFERENCES "Padres" ("PadreId") ON DELETE CASCADE
);

CREATE TABLE "Membresias" (
    "MembresiaId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Cvc_tarjeta" character varying(3) NOT NULL,
    "Fecha_expiracion" character varying(10) NOT NULL,
    "TarjetaId" integer NOT NULL,
    "DocenteId" integer NOT NULL,
    CONSTRAINT "PK_Membresias" PRIMARY KEY ("MembresiaId"),
    CONSTRAINT "FK_Membresias_Docentes_DocenteId" FOREIGN KEY ("DocenteId") REFERENCES "Docentes" ("DocenteId") ON DELETE CASCADE,
    CONSTRAINT "FK_Membresias_Tarjetas_TarjetaId" FOREIGN KEY ("TarjetaId") REFERENCES "Tarjetas" ("TarjetaId") ON DELETE CASCADE
);

CREATE TABLE "Tutorias" (
    "TutoriaId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "AlumnoId" integer NOT NULL,
    "CursoId" integer NOT NULL,
    "DocenteId" integer NOT NULL,
    "Costo" double precision NOT NULL,
    "Descripcion" character varying(50) NOT NULL,
    "Cantidad_minutos" integer NOT NULL,
    CONSTRAINT "PK_Tutorias" PRIMARY KEY ("TutoriaId"),
    CONSTRAINT "FK_Tutorias_Alumnos_AlumnoId" FOREIGN KEY ("AlumnoId") REFERENCES "Alumnos" ("AlumnoId") ON DELETE CASCADE,
    CONSTRAINT "FK_Tutorias_Cursos_CursoId" FOREIGN KEY ("CursoId") REFERENCES "Cursos" ("CursoId") ON DELETE CASCADE,
    CONSTRAINT "FK_Tutorias_Docentes_DocenteId" FOREIGN KEY ("DocenteId") REFERENCES "Docentes" ("DocenteId") ON DELETE CASCADE
);

CREATE TABLE "Informes" (
    "InformeId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "TutoriaId" integer NOT NULL,
    "Descripcion" character varying(50) NOT NULL,
    "Fecha" character varying(20) NOT NULL,
    CONSTRAINT "PK_Informes" PRIMARY KEY ("InformeId"),
    CONSTRAINT "FK_Informes_Tutorias_TutoriaId" FOREIGN KEY ("TutoriaId") REFERENCES "Tutorias" ("TutoriaId") ON DELETE CASCADE
);

CREATE TABLE "Pagos" (
    "PagoId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "TarjetaId" integer NOT NULL,
    "TutoriaId" integer NOT NULL,
    "Descripcion" character varying(50) NOT NULL,
    "CvcTarjeta" character varying(4) NOT NULL,
    CONSTRAINT "PK_Pagos" PRIMARY KEY ("PagoId"),
    CONSTRAINT "FK_Pagos_Tarjetas_TarjetaId" FOREIGN KEY ("TarjetaId") REFERENCES "Tarjetas" ("TarjetaId") ON DELETE CASCADE,
    CONSTRAINT "FK_Pagos_Tutorias_TutoriaId" FOREIGN KEY ("TutoriaId") REFERENCES "Tutorias" ("TutoriaId") ON DELETE CASCADE
);

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('1f59d66b-4ed0-428d-aaa0-ba3a25cce484', 'd0912206-4555-4e6c-8a55-7cdb4d063d7f', 'ADMIN', 'ADMIN');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('a4591df9-304d-4518-8610-2eac030d8c62', 'b423964b-3cc7-4a65-aeff-b3337755f8e9', 'PADRE', 'PADRE');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('f47cc8a8-2ee4-45d0-b1be-745b0a8c9d14', '484fb5c2-8091-4d40-8cd0-04364bf9b1cb', 'DOCENTE', 'DOCENTE');

INSERT INTO "Cursos" ("CursoId", "Descripcion", "Grado_academico", "Nombre")
VALUES (1, 'aquellas herramientas que los usuarios pueden utilizar accediendo a un servidor web de internet', 'Secundaria', 'AplicacionesWeb');

INSERT INTO "Docentes" ("DocenteId", "Apellidos", "Correo", "DNI", "Disponibilidad", "Domicilio", "Membresia", "Nombres", "Numero_cuenta")
VALUES (1, ' Mendoza', 'henrry@gmail.com', '16534786', 'No Disponible', 'San Miguel calle puquina los condominios la waka', 'Activa', ' Henrry', '2534586198371450');

INSERT INTO "Padres" ("PadreId", "Apellidos", "Correo", "DNI", "Nombres")
VALUES (1, 'Cahuana', 'Moieses@hotmail.com', ' 35826791', ' Moises');

INSERT INTO "Tarjetas" ("TarjetaId", "Fecha_expiracion", "Nombre_poseedor", "Numero_tarjeta")
VALUES (1, '20/02/2025', ' Henry Papi', '255.255.255.0');

INSERT INTO "Alumnos" ("AlumnoId", "Apellidos", "Correo", "DNI", "Grado_academico", "Nombres", "PadreId")
VALUES (1, 'Cardenas', 'lucho13@gmail.com', '75863340', 'Secundaria', 'Lucho', 1);

INSERT INTO "Membresias" ("MembresiaId", "Cvc_tarjeta", "DocenteId", "Fecha_expiracion", "TarjetaId")
VALUES (1, '123', 1, '12/05/2021', 1);

INSERT INTO "Tutorias" ("TutoriaId", "AlumnoId", "Cantidad_minutos", "Costo", "CursoId", "Descripcion", "DocenteId")
VALUES (1, 1, 3, 30.25, 1, 'Repaso de codigo Api', 1);

INSERT INTO "Informes" ("InformeId", "Descripcion", "Fecha", "TutoriaId")
VALUES (1, ' no hizo nada en todo el ciclo', '12/02/2000', 1);

INSERT INTO "Pagos" ("PagoId", "CvcTarjeta", "Descripcion", "TarjetaId", "TutoriaId")
VALUES (1, '123', ' Pago de tutoria de redes', 1, 1);

CREATE INDEX "IX_Alumnos_PadreId" ON "Alumnos" ("PadreId");

CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ("RoleId");

CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("NormalizedName");

CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId");

CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId");

CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId");

CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");

CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");

CREATE INDEX "IX_Favoritos_DocenteId" ON "Favoritos" ("DocenteId");

CREATE INDEX "IX_Favoritos_PadreId" ON "Favoritos" ("PadreId");

CREATE INDEX "IX_Informes_TutoriaId" ON "Informes" ("TutoriaId");

CREATE INDEX "IX_Membresias_DocenteId" ON "Membresias" ("DocenteId");

CREATE INDEX "IX_Membresias_TarjetaId" ON "Membresias" ("TarjetaId");

CREATE INDEX "IX_Pagos_TarjetaId" ON "Pagos" ("TarjetaId");

CREATE INDEX "IX_Pagos_TutoriaId" ON "Pagos" ("TutoriaId");

CREATE INDEX "IX_Tutorias_AlumnoId" ON "Tutorias" ("AlumnoId");

CREATE INDEX "IX_Tutorias_CursoId" ON "Tutorias" ("CursoId");

CREATE INDEX "IX_Tutorias_DocenteId" ON "Tutorias" ("DocenteId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20201001214713_init', '3.1.3');

