-- Asumiendo el usuario con id = 1 

-- 1. Insertar empresa con usuario_id = 1
INSERT INTO Empresa (nombre, usuario_id, descripcion)
VALUES (
    'Samsung Electronics',
    1,
    'Líder mundial en tecnología, innovación y soluciones electrónicas avanzadas.'
);
DECLARE @empresa_id INT = SCOPE_IDENTITY();

-- 2. Insertar Misión
INSERT INTO Mision (descripcion, empresa_id)
VALUES (
    N'Inspirar al mundo y crear el futuro con ideas y tecnologías innovadoras que enriquecen la vida de las personas y contribuyen a la prosperidad social global.',
    @empresa_id
);

-- 3. Insertar Visión
INSERT INTO Vision (descripcion, empresa_id)
VALUES (
    N'Ser la empresa más innovadora y confiable de soluciones electrónicas y digitales, liderando la revolución tecnológica a nivel mundial.',
    @empresa_id
);

-- 4. Insertar Valores
INSERT INTO Valores (descripcion, empresa_id)
VALUES (
    N'Personas, excelencia, cambio, integridad y prosperidad conjunta.',
    @empresa_id
);

-- 5. Insertar Unidad Estratégica
INSERT INTO UNID_ESTRA (descripcion, empresa_id)
VALUES (
    N'Desarrollo y comercialización de dispositivos electrónicos avanzados, soluciones digitales y servicios inteligentes para mercados globales.',
    @empresa_id
);

-- 6. Insertar Objetivo General y obtener su id
INSERT INTO ObjetivoG (descripcion, empresa_id)
VALUES (
    N'Expandir el liderazgo global de Samsung a través de la innovación continua en productos electrónicos y servicios digitales, superando las expectativas de los clientes.',
    @empresa_id
);
DECLARE @objetivoG_id INT = SCOPE_IDENTITY();

-- 7. Insertar Objetivo Específico
INSERT INTO ObjetivoE (descripcion, objetivo_id)
VALUES (
    N'Lanzar al menos cinco productos innovadores anualmente en diferentes mercados y aumentar la inversión en I+D en un 15% cada año.',
    @objetivoG_id
);

-- 8. Insertar Fortalezas
INSERT INTO Fortaleza (descripcion, empresa_id) VALUES
(N'Marca reconocida mundialmente por innovación y calidad.', @empresa_id),
(N'Fuerte capacidad de investigación y desarrollo.', @empresa_id),
(N'Cadena de suministro global eficiente.', @empresa_id),
(N'Amplia cartera de productos y servicios.', @empresa_id);

-- 9. Insertar Debilidades
INSERT INTO Debilidad (descripcion, empresa_id) VALUES
(N'Alta dependencia de mercados internacionales.', @empresa_id),
(N'Exposición a fluctuaciones de precios de materias primas.', @empresa_id),
(N'Complejidad organizacional por tamaño global.', @empresa_id),
(N'Desafíos en la gestión de propiedad intelectual.', @empresa_id);

-- 10. Insertar Oportunidades
INSERT INTO Oportunidad (descripcion, empresa_id) VALUES
(N'Crecimiento de la demanda de dispositivos inteligentes.', @empresa_id),
(N'Expansión en mercados emergentes.', @empresa_id),
(N'Colaboraciones estratégicas con empresas tecnológicas.', @empresa_id),
(N'Avances en inteligencia artificial y conectividad 5G.', @empresa_id);

-- 11. Insertar Amenazas
INSERT INTO Amenaza (descripcion, empresa_id) VALUES
(N'Competencia intensa de otras multinacionales.', @empresa_id),
(N'Cambios regulatorios en mercados clave.', @empresa_id),
(N'Riesgos asociados a ciberseguridad y privacidad.', @empresa_id),
(N'Volatilidad económica y geopolítica global.', @empresa_id);

-- 12. Insertar Matriz CAME (16 acciones, una por código de 01 a 16)
INSERT INTO MatrizCAME (codigo_accion, descripcion, empresa_id) VALUES
('01', N'Fortalecer alianzas estratégicas globales.', @empresa_id),
('02', N'Diversificar fuentes de materias primas.', @empresa_id),
('03', N'Optimizar la estructura organizacional.', @empresa_id),
('04', N'Incrementar la inversión en inteligencia artificial.', @empresa_id),
('05', N'Expandir operaciones en nuevos mercados emergentes.', @empresa_id),
('06', N'Reforzar los protocolos de ciberseguridad.', @empresa_id),
('07', N'Implementar programas de desarrollo de talento.', @empresa_id),
('08', N'Mejorar la eficiencia de la cadena de suministro.', @empresa_id),
('09', N'Impulsar campañas de branding digital.', @empresa_id),
('10', N'Fomentar la cultura de innovación interna.', @empresa_id),
('11', N'Adoptar prácticas sostenibles en operaciones.', @empresa_id),
('12', N'Actualizar procesos de gestión de propiedad intelectual.', @empresa_id),
('13', N'Impulsar la integración de tecnologías 5G.', @empresa_id),
('14', N'Expandir la oferta de servicios digitales.', @empresa_id),
('15', N'Participar en iniciativas globales de responsabilidad social.', @empresa_id),
('16', N'Monitorear tendencias tecnológicas emergentes.', @empresa_id);

-- 13. Insertar Identificación Estratégica
INSERT INTO IDENT_ESTRA (descripcion, empresa_id)
VALUES (
    N'Mediante un análisis exhaustivo del entorno global y las capacidades internas, Samsung identificó la necesidad de reforzar la innovación continua, expandir alianzas estratégicas y optimizar su presencia en mercados emergentes.',
    @empresa_id
);

-- 14. Insertar Conclusión
INSERT INTO CONCLUSION (descripcion, empresa_id)
VALUES (
    N'El plan estratégico de Samsung Electronics establece un marco para el crecimiento sostenible y la innovación, permitiendo a la empresa mantener su liderazgo global y enfrentar con éxito los desafíos del entorno tecnológico.',
    @empresa_id
);