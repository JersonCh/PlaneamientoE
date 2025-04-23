	-- Crear la base de datos SOFTPETI si no existe
	IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'SOFTPETI')
	BEGIN
		CREATE DATABASE SOFTPETI;
	END
	GO

	-- Usar la base de datos SOFTPETI
	USE SOFTPETI;
	GO

	-- Crear la tabla USUARIO si no existe
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'USUARIO')
	BEGIN
		CREATE TABLE USUARIO(
			id INT IDENTITY(1,1) PRIMARY KEY,
			nombre VARCHAR(100) NOT NULL,
			apellido VARCHAR(120) NOT NULL,
			email VARCHAR(100) NOT NULL,
			password_hash VARCHAR(64) NOT NULL
		);
	END
	GO

	
		INSERT INTO USUARIO (nombre, apellido, email, password_hash)
		VALUES  ('jaime', 'flores', 'jf@gmail.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3'),
    ('elvis', 'leyva', 'el@gmail.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3'),
	('jerson', 'chambi', 'jc@gmail.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3'),
	('blast', 'flores', 'af@gmail.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3');
	
	GO

	-- Crear la tabla Mision si no existe
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Mision')
	BEGIN
		CREATE TABLE Mision (
			id INT PRIMARY KEY IDENTITY,
			descripcion NVARCHAR(MAX),
			fecha_registro DATETIME DEFAULT GETDATE(),
			usuario_id INT,  
			FOREIGN KEY (usuario_id) REFERENCES USUARIO(id)  
		);
	END
	GO

	-- Crear la tabla Vision si no existe
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Vision')
	BEGIN
		CREATE TABLE Vision (
			id INT PRIMARY KEY IDENTITY,
			descripcion NVARCHAR(MAX),
			fecha_registro DATETIME DEFAULT GETDATE(),
			usuario_id INT, 
			FOREIGN KEY (usuario_id) REFERENCES USUARIO(id) 
		);
	END
	GO

	-- Crear la tabla Empresa si no existe
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Empresa')
	BEGIN
		CREATE TABLE Empresa (
			id INT PRIMARY KEY IDENTITY,
			nombre NVARCHAR(200),
			usuario_id INT, 
			FOREIGN KEY (usuario_id) REFERENCES USUARIO(id)  
		);
	END
	GO

	IF NOT EXISTS (SELECT * FROM Empresa WHERE nombre = 'SOFTPETI')
	BEGIN
		INSERT INTO Empresa (nombre, usuario_id)
		VALUES ('SOFTPETI', 1);
	END
	GO

	IF NOT EXISTS (SELECT * FROM Mision WHERE descripcion = 'Nuestra misión es proporcionar soluciones tecnológicas innovadoras que mejoren la calidad de vida de las personas.')
	BEGIN
		INSERT INTO Mision (descripcion, usuario_id)
		VALUES ('Nuestra misión es proporcionar soluciones tecnológicas innovadoras que mejoren la calidad de vida de las personas.', 1);
	END
	GO

	-- Insertar datos en la tabla Vision si no existe
	IF NOT EXISTS (SELECT * FROM Vision WHERE descripcion = 'Ser líderes en la creación de software empresarial a nivel global, fomentando el desarrollo y crecimiento continuo.')
	BEGIN
		INSERT INTO Vision (descripcion, usuario_id)
		VALUES ('Ser líderes en la creación de software empresarial a nivel global, fomentando el desarrollo y crecimiento continuo.', 1);
	END
	GO


-- SP: Registrar Empresa
IF OBJECT_ID('SP_RegistrarEmpresa') IS NOT NULL
    DROP PROCEDURE SP_RegistrarEmpresa;
GO
CREATE PROCEDURE SP_RegistrarEmpresa
    @nombre NVARCHAR(200),
    @usuario_id INT
AS
BEGIN
    INSERT INTO Empresa (nombre, usuario_id)
    VALUES (@nombre, @usuario_id);
END;
GO

-- SP: Listar Empresas por Usuario
IF OBJECT_ID('SP_ListarEmpresasPorUsuario') IS NOT NULL
    DROP PROCEDURE SP_ListarEmpresasPorUsuario;
GO
CREATE PROCEDURE SP_ListarEmpresasPorUsuario
    @usuario_id INT
AS
BEGIN
    SELECT id, nombre
    FROM Empresa
    WHERE usuario_id = @usuario_id;
END;
GO

-- SP: Registrar Misión
IF OBJECT_ID('SP_RegistrarMision') IS NOT NULL
    DROP PROCEDURE SP_RegistrarMision;
GO
CREATE PROCEDURE SP_RegistrarMision
    @descripcion NVARCHAR(MAX),
    @usuario_id INT
AS
BEGIN
    INSERT INTO Mision (descripcion, usuario_id)
    VALUES (@descripcion, @usuario_id);
END;
GO

-- SP: Listar Misión por Usuario
IF OBJECT_ID('SP_ListarMisionPorUsuario') IS NOT NULL
    DROP PROCEDURE SP_ListarMisionPorUsuario;
GO
CREATE PROCEDURE SP_ListarMisionPorUsuario
    @usuario_id INT
AS
BEGIN
    SELECT id, descripcion, fecha_registro
    FROM Mision
    WHERE usuario_id = @usuario_id;
END;
GO

-- SP: Registrar Visión
IF OBJECT_ID('SP_RegistrarVision') IS NOT NULL
    DROP PROCEDURE SP_RegistrarVision;
GO
CREATE PROCEDURE SP_RegistrarVision
    @descripcion NVARCHAR(MAX),
    @usuario_id INT
AS
BEGIN
    INSERT INTO Vision (descripcion, usuario_id)
    VALUES (@descripcion, @usuario_id);
END;
GO

-- SP: Listar Visión por Usuario
IF OBJECT_ID('SP_ListarVisionPorUsuario') IS NOT NULL
    DROP PROCEDURE SP_ListarVisionPorUsuario;
GO
CREATE PROCEDURE SP_ListarVisionPorUsuario
    @usuario_id INT
AS
BEGIN
    SELECT id, descripcion, fecha_registro
    FROM Vision
    WHERE usuario_id = @usuario_id;
END;
GO


CREATE PROCEDURE SP_Autenticar
    @Email VARCHAR(100),
    @PasswordHash VARCHAR(64)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        id,
        nombre,
        apellido,
        email
    FROM 
        USUARIO
    WHERE 
        email = @Email 
        AND password_hash = @PasswordHash;
END