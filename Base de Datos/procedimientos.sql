CREATE SEQUENCE id_dpto
    INCREMENT BY 1
    START WITH 1
    MINVALUE 1
    MAXVALUE 9999
    NOCYCLE
    CACHE 20;
    
CREATE SEQUENCE id_inv
    INCREMENT BY 1
    START WITH 1
    MINVALUE 1
    MAXVALUE 9999
    NOCYCLE
    CACHE 20;
    
CREATE SEQUENCE id_servicio
    INCREMENT BY 1
    START WITH 1
    MINVALUE 1
    MAXVALUE 9999
    NOCYCLE
    CACHE 20;
    
CREATE SEQUENCE id_cliente
    INCREMENT BY 1
    START WITH 1
    MINVALUE 1
    MAXVALUE 9999
    NOCYCLE
    CACHE 20;

CREATE SEQUENCE id_reserva
    INCREMENT BY 1
    START WITH 1
    MINVALUE 1
    MAXVALUE 9999
    NOCYCLE
    CACHE 20;
    
CREATE SEQUENCE id_checkeo
    INCREMENT BY 1
    START WITH 1
    MINVALUE 1
    MAXVALUE 9999
    NOCYCLE
    CACHE 20;    
    
CREATE SEQUENCE id_revision
    INCREMENT BY 1
    START WITH 1
    MINVALUE 1
    MAXVALUE 9999
    NOCYCLE
    CACHE 20;
    
CREATE SEQUENCE id_multa
    INCREMENT BY 1
    START WITH 1
    MINVALUE 1
    MAXVALUE 9999
    NOCYCLE
    CACHE 20;    
 
    
/* CRUD USUARIO */

CREATE OR REPLACE PROCEDURE insert_usuario (rut_usuario IN VARCHAR2, contrasenia IN VARCHAR2, rol IN VARCHAR2, nombre_usuario IN VARCHAR2, apellido_p IN VARCHAR2, apellido_m IN VARCHAR2, estado_usuario IN VARCHAR2, email IN VARCHAR2 ) IS
BEGIN
INSERT INTO usuario (rut_usuario, contrasenia, rol, nombre_usuario, apellido_p, apellido_m, estado_usuario, email)
VALUES (rut_usuario, contrasenia, rol, nombre_usuario, apellido_p, apellido_m, estado_usuario, email);
END;

CREATE OR REPLACE PROCEDURE inhabilitar_usuario (rut_usuarioU IN VARCHAR2) IS
BEGIN
UPDATE usuario SET estado_usuario = 'INHABILITADO'
WHERE rut_usuario = rut_usuarioU;
END;

CREATE OR REPLACE PROCEDURE update_usuario(rut_usuarioU in VARCHAR2, rolU in VARCHAR2, nombre_usuarioU in VARCHAR2, apellido_pU in VARCHAR2, apellido_mU in VARCHAR2, estado_usuarioU in VARCHAR2, emailU in VARCHAR2) IS
BEGIN
UPDATE usuario
SET
rol = rolU, nombre_usuario = nombre_usuarioU, apellido_p = apellido_pU, apellido_m = apellido_mU, estado_usuario = estado_usuarioU, email = emailU
WHERE rut_usuario = rut_usuarioU;
END;


/* CRUD CLIENTE */
CREATE OR REPLACE PROCEDURE insert_cliente (rut_cliente IN VARCHAR2, pasaporte IN VARCHAR2, passwrd in VARCHAR2, nombre in VARCHAR2, apellido_p IN VARCHAR2, apellido_m IN VARCHAR2, num_celular IN NUMBER, correo IN VARCHAR2, nacionalidad IN VARCHAR2, cliente_frecuente IN CHAR, estado_cliente IN VARCHAR2) IS
BEGIN
INSERT INTO cliente (id_cliente, rut_cliente, pasaporte, passwrd, nombre, apellido_p, apellido_m, num_celular, correo, nacionalidad, cliente_frecuente, estado_cliente)
VALUES (id_cliente.nextval, rut_cliente, pasaporte, passwrd, nombre, apellido_p, apellido_m, num_celular, correo, nacionalidad, cliente_frecuente, estado_cliente);
END;

CREATE OR REPLACE PROCEDURE inhabilitar_cliente (id_clienteC IN NUMBER) IS
BEGIN
UPDATE cliente SET estado_cliente = 'INHABILITADO'
WHERE id_cliente = id_clienteC;
END;

CREATE OR REPLACE PROCEDURE update_cliente (id_clienteC in NUMBER, rut_clienteC in VARCHAR2, pasaporteC in VARCHAR2, nombreC in VARCHAR2, apellido_pC in VARCHAR2, apellido_mC in VARCHAR2, num_celularC in NUMBER, correoC in VARCHAR2, nacionalidadC in VARCHAR2, cliente_frecuenteC in CHAR,estado_clienteC in VARCHAR2) IS
BEGIN
UPDATE cliente
SET
rut_cliente = rut_clienteC, pasaporte = pasaporteC, nombre = nombreC, apellido_p = apellido_pC, apellido_m = apellido_mC, num_celular = num_celularC, correo = correoC, nacionalidad = nacionalidadC, cliente_frecuente = cliente_frecuenteC,estado_cliente = estado_clienteC
WHERE id_cliente = id_clienteC;
END;

/* CRUD DPTO */
CREATE OR REPLACE PROCEDURE insert_dpto (num_depto IN VARCHAR2, direccion IN VARCHAR2, descripcion IN VARCHAR2, region IN VARCHAR2, estado IN VARCHAR2, valor_diario IN NUMBER) IS
BEGIN
INSERT INTO dpto (id_dpto, num_depto, direccion, descripcion, region, estado, valor_diario)
VALUES (id_dpto.nextval, num_depto, direccion, descripcion, region, estado, valor_diario);
END;

CREATE OR REPLACE PROCEDURE inhabilitar_dpto (id_dptoD IN NUMBER) IS
BEGIN
UPDATE dpto SET estado = 'NO DISPONIBLE'
WHERE id_dpto = id_dptoD;
END;

CREATE OR REPLACE PROCEDURE update_dpto (id_dptoD in NUMBER, num_deptoD in VARCHAR2, direccionD in VARCHAR2, descripcionD in VARCHAR2, regionD in VARCHAR2, estadoD in VARCHAR2,valor_diarioD IN NUMBER) IS
BEGIN
UPDATE dpto
SET
num_depto = num_deptoD, direccion = direccionD, descripcion = descripcionD, region = regionD, estado = estadoD, valor_diario = valor_diarioD
WHERE id_dpto = id_dptoD;
END;

/* CRUD SERVICIO */ 
CREATE OR REPLACE PROCEDURE insert_servicio (nombre IN VARCHAR2, tipo IN VARCHAR2, horario_inicio IN DATE, horario_fin IN DATE, punto_reunion IN VARCHAR2, valor IN NUMBER, recorrido IN VARCHAR2, vehiculo IN VARCHAR2, chofer IN VARCHAR2, estado_servicio IN VARCHAR2,cupo IN NUMBER  ) IS
BEGIN
INSERT INTO servicio (id_servicio, nombre, tipo, horario_inicio, horario_fin, punto_reunion, valor, recorrido, vehiculo, chofer,estado_servicio,cupo)
VALUES (id_servicio.nextval, nombre, tipo, horario_inicio, horario_fin, punto_reunion, valor, recorrido, vehiculo, chofer,estado_servicio,cupo);
END;
    

CREATE OR REPLACE PROCEDURE inhabilitar_servicio (id_servicioS IN NUMBER) IS
BEGIN
UPDATE servicio SET estado_servicio = 'NO DISPONIBLE'
WHERE id_servicio = id_servicioS;
END;

CREATE OR REPLACE PROCEDURE update_servicio (id_servicioS IN NUMBER, nombreS IN VARCHAR2, tipoS IN VARCHAR2, horario_inicioS IN DATE, horario_finS IN DATE, punto_reunionS IN VARCHAR2, valorS IN NUMBER, recorridoS IN VARCHAR2, vehiculoS IN VARCHAR2, choferS IN VARCHAR2,estado_servicioS IN VARCHAR2,cupoS IN NUMBER) IS
BEGIN
UPDATE servicio
SET 
nombre = nombreS, tipo = tipoS, horario_inicio = horario_inicioS, horario_fin = horario_finS, punto_reunion = punto_reunionS, valor = valorS, recorrido = recorridoS, vehiculo = vehiculoS, chofer = choferS,estado_servicio=estado_servicioS,cupo=cupoS
WHERE id_servicio = id_servicioS;
END;
   
/* CRUD INVENTARIO */ 
CREATE OR REPLACE PROCEDURE insert_inventario (nombre_arti IN VARCHAR2, tipo_arti IN VARCHAR2, valor_arti IN NUMBER, dpto_id_dpto IN NUMBER,estado_inventario IN VARCHAR2) IS
BEGIN
INSERT INTO inventario (id_inv, nombre_arti, tipo_arti, valor_arti, dpto_id_dpto,estado_inventario)
VALUES (id_inv.nextval, nombre_arti, tipo_arti, valor_arti, dpto_id_dpto,estado_inventario);
END;

CREATE OR REPLACE PROCEDURE update_inventario (id_invI IN NUMBER, nombre_artiI IN VARCHAR2, tipo_artiI IN VARCHAR2, valor_artiI IN NUMBER, dpto_id_dptoI IN NUMBER,estado_inventarioI IN VARCHAR2) IS
BEGIN
UPDATE inventario
SET
nombre_arti = nombre_artiI, tipo_arti = tipo_artiI, valor_arti = valor_artiI, dpto_id_dpto = dpto_id_dptoI,estado_inventario=estado_inventarioI
WHERE id_inv = id_invI;
END;

CREATE OR REPLACE PROCEDURE inhabilitar_inventario (id_invI IN NUMBER) IS
BEGIN
UPDATE inventario SET estado_inventario = 'NO DISPONIBLE'
WHERE id_inv = id_invI;
END;
    
    
/* crud checkeo*/    
CREATE OR REPLACE PROCEDURE insert_chequeo (tipo_checkeo IN VARCHAR2, fecha IN DATE, usuario_rut_usuario IN VARCHAR2, reserva_id_reserva IN NUMBER) IS
BEGIN
INSERT INTO checkeo (id_checkeo, tipo_checkeo, fecha, usuario_rut_usuario, reserva_id_reserva)
VALUES (id_checkeo.nextval, tipo_checkeo, fecha, usuario_rut_usuario, reserva_id_reserva);
END;

CREATE OR REPLACE PROCEDURE inhabilitar_chequeo (id_checkeoC IN NUMBER) IS
BEGIN
DELETE FROM checkeo WHERE id_checkeo = id_checkeoC;
END;

CREATE OR REPLACE PROCEDURE check_out(id_checkeoCH IN NUMBER, tipo_checkeoCH IN VARCHAR2, fechaCH IN DATE, usuario_rut_usuarioCH IN VARCHAR2, reserva_id_reservaCH IN NUMBER) IS
BEGIN
UPDATE checkeo
SET
tipo_checkeo = tipo_checkeoCH, fecha = fechaCH, usuario_rut_usuario = usuario_rut_usuarioCH, reserva_id_reserva = reserva_id_reservaCH
WHERE id_checkeo = id_checkeoCH AND tipo_checkeo='REVISADO' ;
END;
    

/*para revision revision */  

CREATE OR REPLACE PROCEDURE insert_revision (usuario_rut_usuario IN VARCHAR2, fecha_revision IN DATE, dpto_id_dpto IN NUMBER) IS
BEGIN
INSERT INTO revision_inv (id_revision, usuario_rut_usuario, fecha_revision, dpto_id_dpto)
VALUES (id_revision.nextval, usuario_rut_usuario, fecha_revision, dpto_id_dpto);
END;

CREATE OR REPLACE PROCEDURE previa_check_out(id_checkeoR IN NUMBER) IS
BEGIN
UPDATE checkeo SET tipo_checkeo='REVISADO'
WHERE id_checkeo = id_checkeoR ;
END;

CREATE OR REPLACE PROCEDURE inhabilitar_multa (id_revisionR IN NUMBER) IS
BEGIN
DELETE FROM revision_inv WHERE id_revision = id_revisionR;
END;

/* multas*/

CREATE OR REPLACE PROCEDURE insert_multa (descripcion IN VARCHAR2, monto IN NUMBER, reserva_id_reserva IN NUMBER) IS
BEGIN
INSERT INTO multa (id_multa, descripcion, monto, reserva_id_reserva)
VALUES (id_multa.nextval, descripcion, monto, reserva_id_reserva);
END;    

/* RESERVAS */

CREATE OR REPLACE PROCEDURE insert_reserva (fecha_inicio IN DATE, fecha_fin IN DATE, estado IN VARCHAR2, cliente_id_cliente IN NUMBER) IS
BEGIN
INSERT INTO reserva (id_reserva, fecha_inicio, fecha_fin, estado, cliente_id_cliente)
VALUES (id_reserva.nextval, fecha_inicio, fecha_fin, estado, cliente_id_cliente);
END;

PROCEDURE update_reserva (id_reservaU IN NUMBER, fecha_inicioU IN DATE, fecha_finU IN DATE, estadoU IN VARCHAR2, cliente_id_clienteU IN NUMBER) IS
BEGIN
UPDATE reserva
SET
fecha_inicio = fecha_inicioU, fecha_fin = fecha_finU, estado = estadoU, cliente_id_cliente = cliente_id_clienteU
WHERE id_reserva = id_reservaU;
END;


CREATE OR REPLACE PROCEDURE delete_reserva (id_r IN NUMBER) IS
BEGIN
DELETE FROM reserva 
WHERE id_reserva = id_r;
END;
