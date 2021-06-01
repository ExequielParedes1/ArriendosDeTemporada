-- Generado por Oracle SQL Developer Data Modeler 20.4.1.406.0906
--   en:        2021-05-30 23:17:52 CLT
--   sitio:      Oracle Database 11g
--   tipo:      Oracle Database 11g



-- predefined type, no DDL - MDSYS.SDO_GEOMETRY

-- predefined type, no DDL - XMLTYPE

CREATE TABLE acompanante (
    id_acompanante   NUMBER(10) NOT NULL,
    rut_acompanante  VARCHAR2(11),
    pasaporte        VARCHAR2(11),
    nombre           VARCHAR2(50) NOT NULL,
    apellido_p       VARCHAR2(50) NOT NULL,
    apellido_m       VARCHAR2(50) NOT NULL
);

ALTER TABLE acompanante ADD CONSTRAINT acompanante_pk PRIMARY KEY ( id_acompanante );

CREATE TABLE checkeo (
    id_checkeo           NUMBER(10) NOT NULL,
    tipo_checkeo         VARCHAR2(100) NOT NULL,
    fecha                DATE NOT NULL,
    usuario_rut_usuario  VARCHAR2(12) NOT NULL,
    reserva_id_reserva   NUMBER(10) NOT NULL
);

ALTER TABLE checkeo ADD CONSTRAINT checkeo_pk PRIMARY KEY ( id_checkeo );

CREATE TABLE cliente (
    id_cliente         NUMBER(20) NOT NULL,
    rut_cliente        VARCHAR2(12),
    pasaporte          VARCHAR2(12),
    passwrd            VARCHAR2(200) NOT NULL,
    nombre             VARCHAR2(100) NOT NULL,
    apellido_p         VARCHAR2(100) NOT NULL,
    apellido_m         VARCHAR2(100) NOT NULL,
    num_celular        NUMBER(9) NOT NULL,
    correo             VARCHAR2(200) NOT NULL,
    nacionalidad       VARCHAR2(100) NOT NULL,
    cliente_frecuente  CHAR(1) NOT NULL,
    estado_cliente     VARCHAR2(100) NOT NULL
);

ALTER TABLE cliente ADD CONSTRAINT cliente_pk PRIMARY KEY ( id_cliente );

CREATE TABLE dpto (
    id_dpto       NUMBER(10) NOT NULL,
    num_depto     VARCHAR2(50) NOT NULL,
    direccion     VARCHAR2(200) NOT NULL,
    descripcion   VARCHAR2(1000) NOT NULL,
    region        VARCHAR2(200) NOT NULL,
    estado        VARCHAR2(100) NOT NULL,
    valor_diario  NUMBER(10) NOT NULL
);

ALTER TABLE dpto ADD CONSTRAINT dpto_pk PRIMARY KEY ( id_dpto );

CREATE TABLE gastos (
    tipo_gasto    VARCHAR2(200) NOT NULL,
    valor         NUMBER(10) NOT NULL,
    fecha         DATE NOT NULL,
    dpto_id_dpto  NUMBER(10) NOT NULL
);

CREATE TABLE inventario (
    id_inv             NUMBER(10) NOT NULL,
    nombre_arti        VARCHAR2(150) NOT NULL,
    tipo_arti          VARCHAR2(150) NOT NULL,
    valor_arti         NUMBER(6) NOT NULL,
    dpto_id_dpto       NUMBER(10) NOT NULL,
    estado_inventario  VARCHAR2(100) NOT NULL
);

ALTER TABLE inventario ADD CONSTRAINT inventario_pk PRIMARY KEY ( id_inv );

CREATE TABLE mantencion (
    id_mantecion  NUMBER(10) NOT NULL,
    descripcion   VARCHAR2(50) NOT NULL,
    valor         NUMBER NOT NULL,
    fecha_ini     DATE NOT NULL,
    fecha_term    DATE NOT NULL,
    dpto_id_dpto  NUMBER(10) NOT NULL
);

ALTER TABLE mantencion ADD CONSTRAINT mantencion_pk PRIMARY KEY ( id_mantecion );

CREATE TABLE multa (
    id_multa            NUMBER(10) NOT NULL,
    descripcion         VARCHAR2(100) NOT NULL,
    monto               NUMBER(10) NOT NULL,
    reserva_id_reserva  NUMBER(10) NOT NULL
);

ALTER TABLE multa ADD CONSTRAINT multa_pk PRIMARY KEY ( id_multa );

CREATE TABLE pago (
    id_pago                 NUMBER(30) NOT NULL,
    monto                   NUMBER(10) NOT NULL,
    fecha_pago              DATE NOT NULL,
    tipo_pago               VARCHAR2(200),
    transbank_id_transbank  NUMBER(30) NOT NULL,
    reserva_id_reserva      NUMBER(10) NOT NULL
);

ALTER TABLE pago ADD CONSTRAINT pago_pk PRIMARY KEY ( id_pago );

CREATE TABLE reserva (
    id_reserva          NUMBER(10) NOT NULL,
    fecha_inicio        DATE NOT NULL,
    fecha_fin           DATE NOT NULL,
    estado              VARCHAR2(100) NOT NULL,
    cliente_id_cliente  NUMBER(20) NOT NULL
);

ALTER TABLE reserva ADD CONSTRAINT reserva_pk PRIMARY KEY ( id_reserva );

CREATE TABLE reserva_ac (
    acompanante_id_acompanante  NUMBER(10) NOT NULL,
    reserva_id_reserva          NUMBER(10) NOT NULL
);

CREATE TABLE reserva_depto (
    reserva_id_reserva  NUMBER(10) NOT NULL,
    dpto_id_dpto        NUMBER(10) NOT NULL
);

CREATE TABLE reserva_servicio (
    reserva_id_reserva    NUMBER(10) NOT NULL,
    servicio_id_servicio  NUMBER(10) NOT NULL,
    cantidad_cupo         NUMBER(6) NOT NULL
);

CREATE TABLE revision_inv (
    id_revision          NUMBER(10) NOT NULL,
    fecha_revision       DATE NOT NULL,
    dpto_id_dpto         NUMBER(10) NOT NULL,
    usuario_rut_usuario  VARCHAR2(12) NOT NULL
);

ALTER TABLE revision_inv ADD CONSTRAINT revision_inv_pk PRIMARY KEY ( id_revision );

CREATE TABLE servicio (
    id_servicio      NUMBER(10) NOT NULL,
    nombre           VARCHAR2(200) NOT NULL,
    tipo             VARCHAR2(200) NOT NULL,
    horario_inicio   DATE NOT NULL,
    horario_fin      DATE NOT NULL,
    punto_reunion    VARCHAR2(200) NOT NULL,
    valor            NUMBER(10) NOT NULL,
    recorrido        VARCHAR2(200),
    vehiculo         VARCHAR2(200),
    chofer           VARCHAR2(200),
    estado_servicio  VARCHAR2(100) NOT NULL,
    cupo             NUMBER(6) NOT NULL
);

ALTER TABLE servicio ADD CONSTRAINT servicio_pk PRIMARY KEY ( id_servicio );

CREATE TABLE transbank (
    id_transbank  NUMBER(30) NOT NULL,
    total_tbk     NUMBER(30) NOT NULL,
    estado_tbk    VARCHAR2(200),
    fecha_tbk     DATE NOT NULL
);

ALTER TABLE transbank ADD CONSTRAINT transbank_pk PRIMARY KEY ( id_transbank );

CREATE TABLE usuario (
    rut_usuario     VARCHAR2(12) NOT NULL,
    contrasenia     VARCHAR2(200) NOT NULL,
    rol             VARCHAR2(50) NOT NULL,
    nombre_usuario  VARCHAR2(100) NOT NULL,
    apellido_p      VARCHAR2(100) NOT NULL,
    apellido_m      VARCHAR2(100) NOT NULL,
    estado_usuario  VARCHAR2(50) NOT NULL,
    email           VARCHAR2(200) NOT NULL
);

ALTER TABLE usuario ADD CONSTRAINT usuario_pk PRIMARY KEY ( rut_usuario );

ALTER TABLE checkeo
    ADD CONSTRAINT checkeo_reserva_fk FOREIGN KEY ( reserva_id_reserva )
        REFERENCES reserva ( id_reserva );

ALTER TABLE checkeo
    ADD CONSTRAINT checkeo_usuario_fk FOREIGN KEY ( usuario_rut_usuario )
        REFERENCES usuario ( rut_usuario );

ALTER TABLE gastos
    ADD CONSTRAINT gastos_dpto_fk FOREIGN KEY ( dpto_id_dpto )
        REFERENCES dpto ( id_dpto );

ALTER TABLE inventario
    ADD CONSTRAINT inventario_dpto_fk FOREIGN KEY ( dpto_id_dpto )
        REFERENCES dpto ( id_dpto );

ALTER TABLE mantencion
    ADD CONSTRAINT mantencion_dpto_fk FOREIGN KEY ( dpto_id_dpto )
        REFERENCES dpto ( id_dpto );

ALTER TABLE multa
    ADD CONSTRAINT multa_reserva_fk FOREIGN KEY ( reserva_id_reserva )
        REFERENCES reserva ( id_reserva );

ALTER TABLE pago
    ADD CONSTRAINT pago_reserva_fk FOREIGN KEY ( reserva_id_reserva )
        REFERENCES reserva ( id_reserva );

ALTER TABLE pago
    ADD CONSTRAINT pago_transbank_fk FOREIGN KEY ( transbank_id_transbank )
        REFERENCES transbank ( id_transbank );

ALTER TABLE reserva_ac
    ADD CONSTRAINT reserva_ac_acompanante_fk FOREIGN KEY ( acompanante_id_acompanante )
        REFERENCES acompanante ( id_acompanante );

ALTER TABLE reserva_ac
    ADD CONSTRAINT reserva_ac_reserva_fk FOREIGN KEY ( reserva_id_reserva )
        REFERENCES reserva ( id_reserva );

ALTER TABLE reserva
    ADD CONSTRAINT reserva_cliente_fk FOREIGN KEY ( cliente_id_cliente )
        REFERENCES cliente ( id_cliente );

ALTER TABLE reserva_depto
    ADD CONSTRAINT reserva_depto_dpto_fk FOREIGN KEY ( dpto_id_dpto )
        REFERENCES dpto ( id_dpto );

ALTER TABLE reserva_depto
    ADD CONSTRAINT reserva_depto_reserva_fk FOREIGN KEY ( reserva_id_reserva )
        REFERENCES reserva ( id_reserva );

ALTER TABLE reserva_servicio
    ADD CONSTRAINT reserva_servicio_reserva_fk FOREIGN KEY ( reserva_id_reserva )
        REFERENCES reserva ( id_reserva );

ALTER TABLE reserva_servicio
    ADD CONSTRAINT reserva_servicio_servicio_fk FOREIGN KEY ( servicio_id_servicio )
        REFERENCES servicio ( id_servicio );

ALTER TABLE revision_inv
    ADD CONSTRAINT revision_inv_dpto_fk FOREIGN KEY ( dpto_id_dpto )
        REFERENCES dpto ( id_dpto );

ALTER TABLE revision_inv
    ADD CONSTRAINT revision_inv_usuario_fk FOREIGN KEY ( usuario_rut_usuario )
        REFERENCES usuario ( rut_usuario );



-- Informe de Resumen de Oracle SQL Developer Data Modeler: 
-- 
-- CREATE TABLE                            17
-- CREATE INDEX                             0
-- ALTER TABLE                             30
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE COLLECTION TYPE                   0
-- CREATE STRUCTURED TYPE                   0
-- CREATE STRUCTURED TYPE BODY              0
-- CREATE CLUSTER                           0
-- CREATE CONTEXT                           0
-- CREATE DATABASE                          0
-- CREATE DIMENSION                         0
-- CREATE DIRECTORY                         0
-- CREATE DISK GROUP                        0
-- CREATE ROLE                              0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE SEQUENCE                          0
-- CREATE MATERIALIZED VIEW                 0
-- CREATE MATERIALIZED VIEW LOG             0
-- CREATE SYNONYM                           0
-- CREATE TABLESPACE                        0
-- CREATE USER                              0
-- 
-- DROP TABLESPACE                          0
-- DROP DATABASE                            0
-- 
-- REDACTION POLICY                         0
-- 
-- ORDS DROP SCHEMA                         0
-- ORDS ENABLE SCHEMA                       0
-- ORDS ENABLE OBJECT                       0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0
