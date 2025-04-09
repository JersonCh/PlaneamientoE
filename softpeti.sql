Create database SOFTPETI
go
use SOFTPETI
CREATE  TABLE USUARIO(
id INT IDENTITY(1,1) PRIMARY KEY,
nombre Varchar(100) not null,
apellido Varchar(120) not null,
email VARCHAR(100) NOT NULL,
password_hash VARBINARY(64) NOT NULL
)
go

INSERT INTO USUARIO (nombre, apellido, email, password_hash)
VALUES ('Juan', 'Pérez', 'juan.perez@example.com', 123456);
GO
