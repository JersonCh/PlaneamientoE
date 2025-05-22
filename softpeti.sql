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
			
	-- Crear la tabla Empresa si no existe
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Empresa')
	BEGIN
		CREATE TABLE Empresa (
			id INT PRIMARY KEY IDENTITY,
			nombre NVARCHAR(200),
			usuario_id INT,
			descripcion Text
			FOREIGN KEY (usuario_id) REFERENCES USUARIO(id)  
		);
	END
	GO

	-- Crear la tabla Mision si no existe
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Mision')
	BEGIN
		CREATE TABLE Mision (
			id INT PRIMARY KEY IDENTITY,
			descripcion NVARCHAR(MAX),
			fecha_registro DATETIME DEFAULT GETDATE(),
			empresa_id INT,  
			FOREIGN KEY (empresa_id) REFERENCES EMPRESA(id)  
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
			empresa_id INT, 
			FOREIGN KEY (empresa_id) REFERENCES EMPRESA(id) 
		);
	END
	GO

-- Crear la tabla Valores si no existe
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Valores')
	BEGIN
		CREATE TABLE Valores (
			id INT PRIMARY KEY IDENTITY,
			descripcion NVARCHAR(MAX),
			fecha_registro DATETIME DEFAULT GETDATE(),
			empresa_id INT, 
			FOREIGN KEY (empresa_id) REFERENCES EMPRESA(id) 
		);
	END
	GO

	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ObjetivoG')
	BEGIN
		CREATE TABLE ObjetivoG (
			id INT PRIMARY KEY IDENTITY,
			descripcion NVARCHAR(MAX),
			fecha_registro DATETIME DEFAULT GETDATE(),
			empresa_id INT, 
			FOREIGN KEY (empresa_id) REFERENCES EMPRESA(id) 
		);
	END
	GO

	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ObjetivoE')
	BEGIN
		CREATE TABLE ObjetivoE (
			id INT PRIMARY KEY IDENTITY,
			descripcion NVARCHAR(MAX),
			fecha_registro DATETIME DEFAULT GETDATE(),
			objetivo_id INT, 
			FOREIGN KEY (objetivo_id) REFERENCES OBJETIVOG(id) 
		);
	END
	GO


	--------------------tabla fortalezas
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Fortaleza')
	BEGIN
		CREATE TABLE Fortaleza (
			id INT PRIMARY KEY IDENTITY,
			descripcion NVARCHAR(MAX),
			fecha_registro DATETIME DEFAULT GETDATE(),
			empresa_id INT, 
			FOREIGN KEY (empresa_id) REFERENCES Empresa(id) 
		);
	END
	GO
	--tabla debilidades
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Debilidad')
	BEGIN
		CREATE TABLE Debilidad (
			id INT PRIMARY KEY IDENTITY,
			descripcion NVARCHAR(MAX),
			fecha_registro DATETIME DEFAULT GETDATE(),
			empresa_id INT, 
			FOREIGN KEY (empresa_id) REFERENCES Empresa(id) 
		);
	END
	GO
	--tabla oportunidades
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Oportunidad')
	BEGIN
		CREATE TABLE Oportunidad (
			id INT PRIMARY KEY IDENTITY,
			descripcion NVARCHAR(MAX),
			fecha_registro DATETIME DEFAULT GETDATE(),
			empresa_id INT, 
			FOREIGN KEY (empresa_id) REFERENCES Empresa(id) 
		);
	END
	GO
	--tabla amenazas
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Amenaza')
	BEGIN
		CREATE TABLE Amenaza (
			id INT PRIMARY KEY IDENTITY,
			descripcion NVARCHAR(MAX),
			fecha_registro DATETIME DEFAULT GETDATE(),
			empresa_id INT, 
			FOREIGN KEY (empresa_id) REFERENCES Empresa(id) 
		);
	END
	GO

	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UNID_ESTRA')
BEGIN
	CREATE TABLE UNID_ESTRA (
		id INT PRIMARY KEY IDENTITY,
		descripcion NVARCHAR(MAX),
		fecha_registro DATETIME DEFAULT GETDATE(),
		empresa_id INT,
		FOREIGN KEY (empresa_id) REFERENCES EMPRESA(id)
	);
END
GO
	-- TABLA MATRIZ CAME
	CREATE TABLE MatrizCAME (
    id INT PRIMARY KEY IDENTITY(1,1),
    codigo_accion CHAR(2) NOT NULL,  -- Código del 1 al 16
    descripcion VARCHAR(MAX) NOT NULL,
    empresa_id INT NOT NULL  -- ID de la empresa a la que pertenece la acción
);
	-- TABLA AUTO CADENA VA L O R
	CREATE TABLE AutoCadenaValor (
		id INT PRIMARY KEY IDENTITY(1,1),
		empresa_id INT NOT NULL,
		p1 INT NOT NULL,
		p2 INT NOT NULL,
		p3 INT NOT NULL,
		p4 INT NOT NULL,
		p5 INT NOT NULL,
		p6 INT NOT NULL,
		p7 INT NOT NULL,
		p8 INT NOT NULL,
		p9 INT NOT NULL,
		p10 INT NOT NULL,
		p11 INT NOT NULL,
		p12 INT NOT NULL,
		p13 INT NOT NULL,
		p14 INT NOT NULL,
		p15 INT NOT NULL,
		p16 INT NOT NULL,
		p17 INT NOT NULL,
		p18 INT NOT NULL,
		p19 INT NOT NULL,
		p20 INT NOT NULL,
		p21 INT NOT NULL,
		p22 INT NOT NULL,
		p23 INT NOT NULL,
		p24 INT NOT NULL,
		p25 INT NOT NULL,
		total INT NOT NULL
	);


----------------------------P R O C E D I M I E N T O S   -- A L M A C E N A D O S   ------------------------------------

-- SP: Registrar Empresa
IF OBJECT_ID('SP_RegistrarEmpresa') IS NOT NULL
    DROP PROCEDURE SP_RegistrarEmpresa;
GO

CREATE OR ALTER PROCEDURE SP_RegistrarEmpresa
    @nombre NVARCHAR(100),
    @usuario_id INT,
    @descripcion NVARCHAR(MAX),
    @nuevaEmpresaId INT OUTPUT
AS
BEGIN
    INSERT INTO Empresa (nombre, usuario_id, descripcion)
    VALUES (@nombre, @usuario_id, @descripcion)

    SET @nuevaEmpresaId = SCOPE_IDENTITY()
END
go

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
    @empresa_id INT
AS
BEGIN
    INSERT INTO Mision (descripcion, empresa_id)
    VALUES (@descripcion, @empresa_id);
END;
GO

-- SP: Registrar Visión
IF OBJECT_ID('SP_RegistrarVision') IS NOT NULL
    DROP PROCEDURE SP_RegistrarVision;
GO

CREATE PROCEDURE SP_RegistrarVision
    @descripcion NVARCHAR(MAX),
    @empresa_id INT
AS
BEGIN
    INSERT INTO Vision (descripcion, empresa_id)
    VALUES (@descripcion, @empresa_id);
END;
GO

IF OBJECT_ID('SP_RegistrarValores') IS NOT NULL
    DROP PROCEDURE SP_RegistrarValores;
GO

CREATE PROCEDURE SP_RegistrarValores
    @descripcion NVARCHAR(MAX),
    @empresa_id INT
AS
BEGIN
    INSERT INTO Valores (descripcion, empresa_id)
    VALUES (@descripcion, @empresa_id);
END;
GO

-- SP: Listar Visión por Usuario y Empresa
IF OBJECT_ID('SP_ListarVisionPorUsuario') IS NOT NULL
    DROP PROCEDURE SP_ListarVisionPorUsuario;
GO

-- SP: Listar Visión por Usuario y Empresa
IF OBJECT_ID('SP_ListarValores') IS NOT NULL
    DROP PROCEDURE SP_ListarValores;
GO

CREATE PROCEDURE SP_ListarValores
    @EmpresaId INT
AS
BEGIN
    SELECT id, descripcion, fecha_registro, empresa_id
    FROM Valores
    WHERE empresa_id = @EmpresaId
    ORDER BY fecha_registro DESC;
END
GO

CREATE PROCEDURE SP_ListarVisionPorUsuario
    @EmpresaId INT
AS
BEGIN
    SELECT *
    FROM VISION
    WHERE empresa_id = @EmpresaId
END

GO


IF OBJECT_ID('SP_ListarMisionPorUsuario') IS NOT NULL
    DROP PROCEDURE SP_ListarMisionPorUsuario;
GO

CREATE PROCEDURE SP_ListarMisionPorUsuario
    @EmpresaId INT
AS
BEGIN
    SELECT *
    FROM Mision
    WHERE empresa_id = @EmpresaId
END

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
GO



-- SP : PARA REGISTRAR FORTALEZAS
CREATE PROCEDURE SP_RegistrarFortaleza
    @descripcion NVARCHAR(MAX),
    @empresa_id INT
AS
BEGIN
    INSERT INTO Fortaleza(descripcion, empresa_id)
    VALUES (@descripcion, @empresa_id);
END;
GO
-- SP : PARA REGISTRAR DEBILIDADES
CREATE PROCEDURE SP_RegistrarDebilidad
    @descripcion NVARCHAR(MAX),
    @empresa_id INT
AS
BEGIN
    INSERT INTO Debilidad(descripcion, empresa_id)
    VALUES (@descripcion, @empresa_id);
END;
GO
-- SP : PARA REGISTRAR OPORTUNIDADES
CREATE PROCEDURE SP_RegistrarOportunidad
    @descripcion NVARCHAR(MAX),
    @empresa_id INT
AS
BEGIN
    INSERT INTO Oportunidad(descripcion, empresa_id)
    VALUES (@descripcion, @empresa_id);
END;
GO
-- SP : PARA REGISTRAR AMENAZAS
CREATE PROCEDURE SP_RegistrarAmenaza
    @descripcion NVARCHAR(MAX),
    @empresa_id INT
AS
BEGIN
    INSERT INTO Amenaza(descripcion, empresa_id)
    VALUES (@descripcion, @empresa_id);
END;
GO

CREATE PROCEDURE SP_RegistrarUnidEstra
    @descripcion NVARCHAR(MAX),
    @empresa_id INT
AS
BEGIN
    INSERT INTO UNID_ESTRA (descripcion, empresa_id)
    VALUES (@descripcion, @empresa_id)
END
GO

CREATE PROCEDURE SP_ListarUnidEstraPorEmpresa
    @EmpresaId INT
AS
BEGIN
    SELECT descripcion
    FROM UNID_ESTRA
    WHERE empresa_id = @EmpresaId;
END
GO

CREATE PROCEDURE SP_RegistrarObjetivos
    @descripcionG1 NVARCHAR(MAX),
    @descripcionG2 NVARCHAR(MAX),
    @descripcionG3 NVARCHAR(MAX),
    @empresa_id INT,
    @descripcionE1 NVARCHAR(MAX),
    @descripcionE2 NVARCHAR(MAX),
    @descripcionE3 NVARCHAR(MAX),
    @descripcionE4 NVARCHAR(MAX),
    @descripcionE5 NVARCHAR(MAX),
    @descripcionE6 NVARCHAR(MAX)
AS
BEGIN
    DECLARE @idObjetivoG INT;

    -- Insertar Objetivo General 1 (G1)
    INSERT INTO ObjetivoG (descripcion, empresa_id)
    VALUES (@descripcionG1, @empresa_id);

    -- Obtener el id generado para G1
    SET @idObjetivoG = SCOPE_IDENTITY();

    -- Insertar Objetivos Específicos relacionados con G1
    INSERT INTO ObjetivoE (descripcion, objetivo_id)
    VALUES 
        (@descripcionE1, @idObjetivoG),
        (@descripcionE2, @idObjetivoG);

    -- Insertar Objetivo General 2 (G2)
    INSERT INTO ObjetivoG (descripcion, empresa_id)
    VALUES (@descripcionG2, @empresa_id);

    -- Obtener el id generado para G2
    SET @idObjetivoG = SCOPE_IDENTITY();

    -- Insertar Objetivos Específicos relacionados con G2
    INSERT INTO ObjetivoE (descripcion, objetivo_id)
    VALUES 
        (@descripcionE3, @idObjetivoG),
        (@descripcionE4, @idObjetivoG);

    -- Insertar Objetivo General 3 (G3)
    INSERT INTO ObjetivoG (descripcion, empresa_id)
    VALUES (@descripcionG3, @empresa_id);

    -- Obtener el id generado para G3
    SET @idObjetivoG = SCOPE_IDENTITY();

    -- Insertar Objetivos Específicos relacionados con G3
    INSERT INTO ObjetivoE (descripcion, objetivo_id)
    VALUES 
        (@descripcionE5, @idObjetivoG),
        (@descripcionE6, @idObjetivoG);
END
GO

-- SP para Objetivos Generales
CREATE PROCEDURE SP_ListarObjetivosGenerales
    @empresa_id INT
AS
BEGIN
    SELECT O.id AS ObjetivoG_Id, O.descripcion AS ObjetivoG_Descripcion
    FROM ObjetivoG O
    WHERE O.empresa_id = @empresa_id
    ORDER BY O.id;
END
GO

-- SP para Objetivos Específicos
CREATE PROCEDURE SP_ListarObjetivosEspecificos
    @empresa_id INT
AS
BEGIN
    SELECT E.id AS ObjetivoE_Id, E.descripcion AS ObjetivoE_Descripcion, E.objetivo_id AS ObjetivoG_Id
    FROM ObjetivoE E
    WHERE EXISTS (
        SELECT 1 FROM ObjetivoG O WHERE O.id = E.objetivo_id AND O.empresa_id = @empresa_id
    )
    ORDER BY E.objetivo_id, E.id;
END
GO

CREATE PROCEDURE SP_ListarFortalezas
    @empresa_id INT
AS
BEGIN
    SELECT F.id AS Fortaleza_Id, F.descripcion AS Fortaleza_Descripcion
    FROM Fortaleza F
    WHERE F.empresa_id = @empresa_id
    ORDER BY F.id;
END
GO

CREATE PROCEDURE SP_ListarDebilidades
    @empresa_id INT
AS
BEGIN
    SELECT D.id AS Debilidad_Id, D.descripcion AS Debilidad_Descripcion
    FROM Debilidad D
    WHERE D.empresa_id = @empresa_id
    ORDER BY D.id;
END
GO

CREATE PROCEDURE SP_ListarOportunidades
    @empresa_id INT
AS
BEGIN
    SELECT O.id AS Oportunidad_Id, O.descripcion AS Oportunidad_Descripcion
    FROM Oportunidad O
    WHERE O.empresa_id = @empresa_id
    ORDER BY O.id;
END
GO

CREATE PROCEDURE SP_ListarAmenazas
    @empresa_id INT
AS
BEGIN
    SELECT A.id AS Amenaza_Id, A.descripcion AS Amenaza_Descripcion
    FROM Amenaza A
    WHERE A.empresa_id = @empresa_id
    ORDER BY A.id;
END
GO

-- REGISTRAR CAME
IF OBJECT_ID('SP_RegistrarMatrizCAME') IS NOT NULL
    DROP PROCEDURE SP_RegistrarMatrizCAME;
GO

CREATE OR ALTER PROCEDURE SP_RegistrarMatrizCAME
    @codigo_accion CHAR(2),
    @descripcion VARCHAR(MAX),
    @empresa_id INT,
    @nuevaMatrizCAMEId INT OUTPUT
AS
BEGIN
    INSERT INTO MatrizCAME (codigo_accion, descripcion, empresa_id)
    VALUES (@codigo_accion, @descripcion, @empresa_id);

    SET @nuevaMatrizCAMEId = SCOPE_IDENTITY();
END
GO
-- REGISTRAR C A D E N A   V A L O R ----
	IF OBJECT_ID('SP_RegistrarAutoCadenaValor') IS NOT NULL
		DROP PROCEDURE SP_RegistrarAutoCadenaValor;
	GO

	CREATE PROCEDURE SP_RegistrarAutoCadenaValor
		@empresa_id INT,
		@p1 INT, @p2 INT, @p3 INT, @p4 INT, @p5 INT,
		@p6 INT, @p7 INT, @p8 INT, @p9 INT, @p10 INT,
		@p11 INT, @p12 INT, @p13 INT, @p14 INT, @p15 INT,
		@p16 INT, @p17 INT, @p18 INT, @p19 INT, @p20 INT,
		@p21 INT, @p22 INT, @p23 INT, @p24 INT, @p25 INT,
		@total INT
	AS
	BEGIN
		INSERT INTO AutoCadenaValor (
			empresa_id, p1, p2, p3, p4, p5,
			p6, p7, p8, p9, p10,
			p11, p12, p13, p14, p15,
			p16, p17, p18, p19, p20,
			p21, p22, p23, p24, p25,
			total
		)
		VALUES (
			@empresa_id, @p1, @p2, @p3, @p4, @p5,
			@p6, @p7, @p8, @p9, @p10,
			@p11, @p12, @p13, @p14, @p15,
			@p16, @p17, @p18, @p19, @p20,
			@p21, @p22, @p23, @p24, @p25,
			@total
		);
	END;
	GO

	-- SP: Listar Matriz CAME
	IF OBJECT_ID('SP_ListarMatrizCAME') IS NOT NULL
		DROP PROCEDURE SP_ListarMatrizCAME;
	GO

	CREATE OR ALTER PROCEDURE SP_ListarMatrizCAME
		@empresa_id INT
	AS
	BEGIN
		SELECT 
			id,
			codigo_accion,
			descripcion,
			empresa_id
		FROM MatrizCAME
		WHERE empresa_id = @empresa_id
		ORDER BY codigo_accion;
	END
	GO


----------------------------I N S E R C I O N E S  --------------------------------------


INSERT INTO USUARIO (nombre, apellido, email, password_hash)
		VALUES  ('jaime', 'flores', 'jf@gmail.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3'),
    ('elvis', 'leyva', 'el@gmail.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3'),
	('jerson', 'chambi', 'jc@gmail.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3'),
	('blast', 'flores', 'af@gmail.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3');
	
	GO