-- Asumiendo el usuario con id = 1 

-- 1. Insertar empresa con usuario_id = 1
INSERT INTO Empresa (nombre, usuario_id, descripcion)
VALUES (
    'Samsung Electronics',
    1,
    'L�der mundial en tecnolog�a, innovaci�n y soluciones electr�nicas avanzadas.'
);
DECLARE @empresa_id INT = SCOPE_IDENTITY();

-- 2. Insertar Misi�n
INSERT INTO Mision (descripcion, empresa_id)
VALUES (
    N'Inspirar al mundo y crear el futuro con ideas y tecnolog�as innovadoras que enriquecen la vida de las personas y contribuyen a la prosperidad social global.',
    @empresa_id
);

-- 3. Insertar Visi�n
INSERT INTO Vision (descripcion, empresa_id)
VALUES (
    N'Ser la empresa m�s innovadora y confiable de soluciones electr�nicas y digitales, liderando la revoluci�n tecnol�gica a nivel mundial.',
    @empresa_id
);

-- 4. Insertar Valores
INSERT INTO Valores (descripcion, empresa_id)
VALUES (
    N'Personas, excelencia, cambio, integridad y prosperidad conjunta.',
    @empresa_id
);

-- 5. Insertar Unidad Estrat�gica
INSERT INTO UNID_ESTRA (descripcion, empresa_id)
VALUES (
    N'Desarrollo y comercializaci�n de dispositivos electr�nicos avanzados, soluciones digitales y servicios inteligentes para mercados globales.',
    @empresa_id
);

-- 6. Insertar Objetivo General y obtener su id
INSERT INTO ObjetivoG (descripcion, empresa_id)
VALUES (
    N'Expandir el liderazgo global de Samsung a trav�s de la innovaci�n continua en productos electr�nicos y servicios digitales, superando las expectativas de los clientes.',
    @empresa_id
);
DECLARE @objetivoG_id INT = SCOPE_IDENTITY();

-- 7. Insertar Objetivo Espec�fico
INSERT INTO ObjetivoE (descripcion, objetivo_id)
VALUES (
    N'Lanzar al menos cinco productos innovadores anualmente en diferentes mercados y aumentar la inversi�n en I+D en un 15% cada a�o.',
    @objetivoG_id
);

-- 8. Insertar Fortalezas
INSERT INTO Fortaleza (descripcion, empresa_id) VALUES
(N'Marca reconocida mundialmente por innovaci�n y calidad.', @empresa_id),
(N'Fuerte capacidad de investigaci�n y desarrollo.', @empresa_id),
(N'Cadena de suministro global eficiente.', @empresa_id),
(N'Amplia cartera de productos y servicios.', @empresa_id);

-- 9. Insertar Debilidades
INSERT INTO Debilidad (descripcion, empresa_id) VALUES
(N'Alta dependencia de mercados internacionales.', @empresa_id),
(N'Exposici�n a fluctuaciones de precios de materias primas.', @empresa_id),
(N'Complejidad organizacional por tama�o global.', @empresa_id),
(N'Desaf�os en la gesti�n de propiedad intelectual.', @empresa_id);

-- 10. Insertar Oportunidades
INSERT INTO Oportunidad (descripcion, empresa_id) VALUES
(N'Crecimiento de la demanda de dispositivos inteligentes.', @empresa_id),
(N'Expansi�n en mercados emergentes.', @empresa_id),
(N'Colaboraciones estrat�gicas con empresas tecnol�gicas.', @empresa_id),
(N'Avances en inteligencia artificial y conectividad 5G.', @empresa_id);

-- 11. Insertar Amenazas
INSERT INTO Amenaza (descripcion, empresa_id) VALUES
(N'Competencia intensa de otras multinacionales.', @empresa_id),
(N'Cambios regulatorios en mercados clave.', @empresa_id),
(N'Riesgos asociados a ciberseguridad y privacidad.', @empresa_id),
(N'Volatilidad econ�mica y geopol�tica global.', @empresa_id);

-- 12. Insertar Matriz CAME (16 acciones, una por c�digo de 01 a 16)
INSERT INTO MatrizCAME (codigo_accion, descripcion, empresa_id) VALUES
('01', N'Fortalecer alianzas estrat�gicas globales.', @empresa_id),
('02', N'Diversificar fuentes de materias primas.', @empresa_id),
('03', N'Optimizar la estructura organizacional.', @empresa_id),
('04', N'Incrementar la inversi�n en inteligencia artificial.', @empresa_id),
('05', N'Expandir operaciones en nuevos mercados emergentes.', @empresa_id),
('06', N'Reforzar los protocolos de ciberseguridad.', @empresa_id),
('07', N'Implementar programas de desarrollo de talento.', @empresa_id),
('08', N'Mejorar la eficiencia de la cadena de suministro.', @empresa_id),
('09', N'Impulsar campa�as de branding digital.', @empresa_id),
('10', N'Fomentar la cultura de innovaci�n interna.', @empresa_id),
('11', N'Adoptar pr�cticas sostenibles en operaciones.', @empresa_id),
('12', N'Actualizar procesos de gesti�n de propiedad intelectual.', @empresa_id),
('13', N'Impulsar la integraci�n de tecnolog�as 5G.', @empresa_id),
('14', N'Expandir la oferta de servicios digitales.', @empresa_id),
('15', N'Participar en iniciativas globales de responsabilidad social.', @empresa_id),
('16', N'Monitorear tendencias tecnol�gicas emergentes.', @empresa_id);

-- 13. Insertar Identificaci�n Estrat�gica
INSERT INTO IDENT_ESTRA (descripcion, empresa_id)
VALUES (
    N'Mediante un an�lisis exhaustivo del entorno global y las capacidades internas, Samsung identific� la necesidad de reforzar la innovaci�n continua, expandir alianzas estrat�gicas y optimizar su presencia en mercados emergentes.',
    @empresa_id
);

-- 14. Insertar Conclusi�n
INSERT INTO CONCLUSION (descripcion, empresa_id)
VALUES (
    N'El plan estrat�gico de Samsung Electronics establece un marco para el crecimiento sostenible y la innovaci�n, permitiendo a la empresa mantener su liderazgo global y enfrentar con �xito los desaf�os del entorno tecnol�gico.',
    @empresa_id
);