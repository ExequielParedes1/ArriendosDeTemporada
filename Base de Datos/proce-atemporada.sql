--------------------------------------------------------
--  DDL for Sequence SEQ_ID_RESERVA
--------------------------------------------------------

   CREATE SEQUENCE  "ATEMPORADA"."SEQ_ID_RESERVA"  MINVALUE 1 MAXVALUE 99999 INCREMENT BY 1 START WITH 761 CACHE 20 NOORDER CYCLE;
--------------------------------------------------------
--  DDL for Sequence SEQ_ID_CARACTERISTICA
--------------------------------------------------------

   CREATE SEQUENCE  "ATEMPORADA"."SEQ_ID_CARACTERISTICA"  MINVALUE 1 MAXVALUE 99999 INCREMENT BY 1 START WITH 281 CACHE 20 NOORDER  CYCLE ; 
--------------------------------------------------------
--  DDL for Sequence SEQ_ID_DEPARTAMENTO
--------------------------------------------------------

   CREATE SEQUENCE  "ATEMPORADA"."SEQ_ID_DEPARTAMENTO"  MINVALUE 1 MAXVALUE 99999 INCREMENT BY 1 START WITH 321 CACHE 20 ORDER  CYCLE;  
--------------------------------------------------------
--  DDL for Sequence SEQ_ID_DETALLEMULTA
--------------------------------------------------------

   CREATE SEQUENCE  "ATEMPORADA"."SEQ_ID_DMULTA"  MINVALUE 1 MAXVALUE 99999 INCREMENT BY 1 START WITH 341 CACHE 20 NOORDER  CYCLE;
--------------------------------------------------------
--  DDL for Sequence SEQ_ID_DETALLESERVICIO
--------------------------------------------------------

   CREATE SEQUENCE  "ATEMPORADA"."SEQ_ID_DETALLESERVICIO"  MINVALUE 1 MAXVALUE 99999 INCREMENT BY 1 START WITH 481 CACHE 20 NOORDER  CYCLE;  
--------------------------------------------------------
--  DDL for Sequence SEQ_ID_FOTO
--------------------------------------------------------

   CREATE SEQUENCE  "ATEMPORADA"."SEQ_ID_FOTO"  MINVALUE 1 MAXVALUE 99999 INCREMENT BY 1 START WITH 661 CACHE 20 NOORDER  CYCLE; 
--------------------------------------------------------
--  DDL for Sequence SEQ_ID_ITEM
--------------------------------------------------------

   CREATE SEQUENCE  "ATEMPORADA"."SEQ_ID_ITEM"  MINVALUE 1 MAXVALUE 99999 INCREMENT BY 1 START WITH 501 CACHE 20 NOORDER  CYCLE;  

--------------------------------------------------------
--  DDL for Sequence SEQ_ID_MANTENCION
--------------------------------------------------------

   CREATE SEQUENCE  "ATEMPORADA"."SEQ_ID_MANTENCION"  MINVALUE 1 MAXVALUE 99999 INCREMENT BY 1 START WITH 401 CACHE 20 NOORDER  CYCLE;  
--------------------------------------------------------
--  DDL for Sequence SEQ_ID_MULTA
--------------------------------------------------------

   CREATE SEQUENCE  "ATEMPORADA"."SEQ_ID_MULTA"  MINVALUE 1 MAXVALUE 99999 INCREMENT BY 1 START WITH 341 CACHE 20 NOORDER  CYCLE;  
--------------------------------------------------------
--  DDL for Sequence SEQ_ID_REGISTROINVENTARIO
--------------------------------------------------------

   CREATE SEQUENCE  "ATEMPORADA"."SEQ_ID_REGISTROINVENTARIO"  MINVALUE 1 MAXVALUE 99999 INCREMENT BY 1 START WITH 401 CACHE 20 NOORDER  CYCLE; 
--------------------------------------------------------
--  DDL for Sequence SEQ_ID_SERVICIOEXTRA
--------------------------------------------------------

   CREATE SEQUENCE  "ATEMPORADA"."SEQ_ID_SERVICIOEXTRA"  MINVALUE 1 MAXVALUE 99999 INCREMENT BY 1 START WITH 81 CACHE 20 NOORDER  CYCLE; 
--------------------------------------------------------
--  DDL for Sequence SEQ_ID_TOUR
--------------------------------------------------------

   CREATE SEQUENCE  "ATEMPORADA"."SEQ_ID_TOUR"  MINVALUE 1 MAXVALUE 99999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  CYCLE;  
--------------------------------------------------------
--  DDL for Sequence SEQ_ID_VIAJE
--------------------------------------------------------

   CREATE SEQUENCE  "ATEMPORADA"."SEQ_ID_VIAJE"  MINVALUE 1 MAXVALUE 99999 INCREMENT BY 1 START WITH 121 CACHE 20 NOORDER  CYCLE;
   
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_RESERVA
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_ARRIENDO" 
(p_id_reserva in NUMBER, 
p_dias_reserva in NUMBER,
p_valor_final in NUMBER,
p_checkin in TIMESTAMP,
p_checkout in TIMESTAMP,
p_total_multas in NUMBER,
p_fecha_contrato in TIMESTAMP,
p_metodo_pago in VARCHAR2,
p_departamento_id_departamento in NUMBER,
p_anticipo in NUMBER,
p_estadopago in VARCHAR2,
p_estado in VARCHAR2,
p_return OUT NUMBER)

is
v_valor NUMBER;
  BEGIN
    v_valor := SEQ_ID_RESERVA.NEXTVAL;
    INSERT INTO RESERVA values(v_valor,p_dias_reserva,p_valor_final, p_checkin,p_checkout,p_total_multas, p_fecha_contrato,
    p_metodo_pago,p_departamento_id_departamento,p_anticipo, p_estadopago,p_estado );
    p_return:= v_valor;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_CARACTERISTICA
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_CARACTERISTICA" 
(p_id_caracteristica in NUMBER, 
p_nombre in VARCHAR2,
p_descripcion in VARCHAR2,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO CARACTERISTICAS values(SEQ_ID_CARACTERISTICA.NEXTVAL, p_nombre, p_descripcion);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;
/

--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_CONDUCTOR
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_CONDUCTOR" 
(p_rut in VARCHAR2, 
p_nombre in VARCHAR2,
p_apellido in VARCHAR2,
p_disponible in NUMBER,
p_email in VARCHAR2,
p_nro_contacto in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO CONDUCTOR values(p_rut, p_nombre, p_apellido, p_disponible, p_email, p_nro_contacto);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_DEPARTAMENTO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_DEPARTAMENTO" 
(p_direccion in VARCHAR2,
p_metros_cuadrados in NUMBER,
p_valor_arriendo_diario in NUMBER,
p_disponible in VARCHAR2,
p_zona in VARCHAR2,
p_nro_habitaciones in NUMBER,
p_nro_banios in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
   v_valor := SEQ_ID_DEPARTAMENTO.NEXTVAL;
    INSERT INTO DEPARTAMENTO values(v_valor, p_direccion, p_metros_cuadrados, p_valor_arriendo_diario, p_disponible, p_zona,
    p_nro_habitaciones, p_nro_banios);
    p_return:=v_valor;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_DETALLEMULTA
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_DETALLEMULTA" 
(p_id_dmulta in NUMBER,
p_objervaciones in VARCHAR2,
p_reserva_id_reserva in NUMBER,
p_multa_id_multa in NUMBER,
p_estadomulta in VARCHAR2,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO DETALLEMULTA values(SEQ_ID_DMULTA.NEXTVAL,p_objervaciones,p_reserva_id_reserva,p_multa_id_multa, p_estadomulta);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_DETALLESERVICIOS
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_DETALLESERVICIOS" 
(p_id_detser in NUMBER,
p_precio in NUMBER, 
p_fecha in TIMESTAMP,
p_servicioextra_id_servicioex in NUMBER,
p_reserva_id_reserva in NUMBER,
p_id_tour in NUMBER,
p_viaje_id in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO DETALLESERVICIOS values(SEQ_ID_DETALLESERVICIO.nextval, p_precio, p_fecha, p_servicioextra_id_servicioex, p_reserva_id_reserva,p_viaje_id,p_viaje_id );
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_ENCARGADO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_ENCARGADO" 
(p_rut in VARCHAR2,
p_nro_contacto in NUMBER,
p_nombre in VARCHAR2,
p_apellido in VARCHAR2,
p_email in VARCHAR2,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO ENCARGADO values(p_rut,p_nro_contacto,p_nombre,p_apellido,p_email);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_FOTO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_FOTO" 
(p_id_foto in NUMBER, 
p_descripcion in VARCHAR2,
p_nombre in VARCHAR2,
p_departamento_id_departamento in NUMBER,
p_imagen in BLOB,

p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO FOTO values(SEQ_ID_FOTO.NEXTVAL, p_descripcion,p_nombre,p_departamento_id_departamento,p_imagen);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_ACOMPANANTE
--------------------------------------------------------
set define off;

create or replace  PROCEDURE "PROCE_AGREGAR_LISTAHUESPEDES" 
(p_acompanante_cedula in VARCHAR2, 
p_reserva_id_reserva in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO LISTAACOMP values(p_acompanante_cedula, p_reserva_id_reserva);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_INVENTARIO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_INVENTARIO" 
(p_fecha_asignacion in TIMESTAMP, 
p_ultima_modificacion in TIMESTAMP,
p_cantidad in NUMBER,
p_item_id_item in NUMBER,
p_departamento_id_departamento in NUMBER,
p_valor_total in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO INVENTARIO values(p_fecha_asignacion, p_ultima_modificacion,p_cantidad,p_item_id_item,
    p_departamento_id_departamento,p_valor_total);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_INVOLUCRADOS
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_INVOLUCRADOS" 
(p_usuario_email in VARCHAR2,
p_reserva_id_reserva in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO INVOLUCRADOS values(p_usuario_email,p_reserva_id_reserva);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_ITEM
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_ITEM" 
(p_id_item in NUMBER, 
p_nombre in VARCHAR2,
p_valor in VARCHAR2,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO ITEMS values(SEQ_ID_ITEM.NEXTVAL, p_nombre, p_valor);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_LISTACARACTERISTICA
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_LISTACARAC" 
(p_departamento_id_depto in NUMBER,
p_caracteristica_id_carac in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO LISTACARACTERISTICAS values(p_departamento_id_depto,p_caracteristica_id_carac);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_LISTAACOMPANANTE
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_LISTAHUESPEDES" 
(p_acompanante_cedula in VARCHAR2, 
p_reserva_id_reserva in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO LISTAACOMP values(p_acompanante_cedula, p_reserva_id_reserva);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_MANTENCION
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_MANTENCION" 
(p_id_mantencion in NUMBER,
p_valor_total in NUMBER,
p_descripcion in VARCHAR2,
p_fecha_inicio in TIMESTAMP,
p_fecha_termino in TIMESTAMP,
p_motivo in VARCHAR2,
p_tipo_mantencion in VARCHAR2,
p_encargado_rut in VARCHAR2,
p_departamento_id_departamento in NUMBER,
p_estado_mantencion in VARCHAR2,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO MANTENCION values(SEQ_ID_MANTENCION.NEXTVAL,p_valor_total,p_descripcion,p_fecha_inicio,p_fecha_termino,p_motivo,p_tipo_mantencion,
    p_encargado_rut,p_departamento_id_departamento, p_estado_mantencion);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_MULTA
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_MULTA" 
(p_id_multa in NUMBER,
p_nombre in VARCHAR2,
p_descripcion in VARCHAR2,
p_valor in NUMBER,
p_estado_multa in VARCHAR2,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
   v_valor := SEQ_ID_MULTA.NEXTVAL;
    INSERT INTO MULTA values(v_valor,p_nombre,p_descripcion,p_valor, p_estado_multa);
    p_return:= v_valor;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_REGISTROINVENTARIO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_REGISTROINVEN" 
(p_fecha_asignacion in TIMESTAMP, 
p_ultima_modificacion in TIMESTAMP,
p_item_id_item in NUMBER,
p_cantidad in NUMBER,
p_departamento_id_departamento in NUMBER,
p_valor_total in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO REGISTROINVENTARIO values(p_fecha_asignacion, p_ultima_modificacion,p_item_id_item,p_cantidad,
    p_departamento_id_departamento,p_valor_total);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_REVISION
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_REVISION" 
(p_estado in VARCHAR2, 
p_observaciones in VARCHAR2,
p_inventario_items_id_item in NUMBER,
p_inventario_depto_id_depto in NUMBER,
p_reserva_id_reserva in NUMBER,

p_return OUT NUMBER)

is

v_valor NUMBER;
  BEGIN
    INSERT INTO REVISION values(p_estado,p_observaciones,p_inventario_items_id_item ,p_inventario_depto_id_depto, p_reserva_id_reserva );
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_SERVICIOEXTRA
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_SERVICIOEXTRA" 
(p_id_servicio in NUMBER,
p_nombre in VARCHAR2,
p_valor in NUMBER,
p_descripcion in VARCHAR2,
p_disponible in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO SERVICIOEXTRA values(SEQ_ID_SERVICIOEXTRA.NEXTVAL,p_nombre,p_valor,p_descripcion, p_disponible );
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_TOUR
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_TOUR" 
(p_inicio in TIMESTAMP, 
p_termino in TIMESTAMP,
p_origen in VARCHAR2,
p_destino in VARCHAR2,
p_rut_conductor in VARCHAR2,
p_patente_vehiculo in VARCHAR2,
p_nroparticipantes in NUMBER,
p_valor in number,
p_disponible in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO TOUR values(SEQ_ID_TOUR.NEXTVAL,p_inicio, p_termino, p_origen, p_destino,
    p_rut_conductor, p_patente_vehiculo,p_nroparticipantes,p_valor, p_disponible);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_USUARIO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_USUARIO" 
(p_email in VARCHAR2, 
p_cedula in VARCHAR2,
p_nombre in VARCHAR2,
p_apellido in VARCHAR2,
p_telefono in NUMBER,
p_estado in VARCHAR2,
p_password in VARCHAR2,
p_tipo in VARCHAR2,

p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO USUARIO values(p_email, p_cedula, p_nombre, p_apellido, p_telefono, p_estado,p_password ,p_tipo );
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_VEHICULO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_VEHICULO" 
(p_patente in VARCHAR2, 
p_modelo in VARCHAR2,
p_a�o in NUMBER,
p_color in VARCHAR2,
p_disponible in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO VEHICULO values(p_patente, p_modelo, p_a�o, p_color, p_disponible);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_AGREGAR_VIAJE
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_AGREGAR_VIAJE" 
(p_id_viaje in NUMBER,
p_origen in VARCHAR2,
p_destino in VARCHAR2,
p_comienzo in TIMESTAMP,
p_precio in NUMBER,
p_conductor_rut in VARCHAR2,
p_vehiculo_patente in VARCHAR2,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    INSERT INTO VIAJE values(SEQ_ID_VIAJE.NEXTVAL,p_origen,p_destino,p_comienzo,p_precio,
    p_conductor_rut,p_vehiculo_patente);
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_ELIMINAR_CARACTERISTICA
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_ELIMINAR_CARACTERISTICA" 
(p_id_caracteristica in VARCHAR2,
p_return OUT NUMBER)
is
v_valor NUMBER; 
  BEGIN
    DELETE FROM CARACTERISTICAS
    WHERE ID_CARACTERISTICA = p_id_caracteristica;
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_ELIMINAR_FOTO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_ELIMINAR_FOTO" 
(p_id_foto in VARCHAR2,
p_return OUT NUMBER)
is
v_valor NUMBER; 
  BEGIN
    DELETE FROM FOTO
    WHERE ID_FOTO = p_id_foto;
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_ELIMINAR_ACOMPANANTE
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_ELIMINAR_HUESPED" 
(p_acompanante_cedula in VARCHAR2,
p_return OUT NUMBER)
is
v_valor NUMBER; 
  BEGIN
    DELETE FROM ACOMPANANTE
    WHERE CEDULA = p_acompanante_cedula;
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_ELIMINAR_INVENTARIO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_ELIMINAR_INVENTARIO" 
(p_departamento_id_departamento in NUMBER,
p_items_id_items in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER; 
  BEGIN
    DELETE FROM INVENTARIO
    WHERE p_departamento_id_departamento = DEPARTAMENTO_ID_DEPARTAMENTO
    AND p_items_id_items = ITEMS_ID_ITEM;
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_ELIMINAR_INVOLUCRADOFUNCIONARIO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_ELIMINAR_INVOLUCRADOFUN" 
(p_id_reserva in NUMBER,
p_correo in VARCHAR2,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    DELETE FROM INVOLUCRADOS
    WHERE RESERVA_ID_RESERVA = p_id_reserva AND
    USUARIO_EMAIL = p_correo;
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_ELIMINAR_ITEMS
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_ELIMINAR_ITEMS" 
(p_id_item in VARCHAR2,
p_return OUT NUMBER)
is
v_valor NUMBER; 
  BEGIN
    DELETE FROM ITEMS
    WHERE ID_ITEM = p_id_item;
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_ELIMINAR_LISTACARACTERISTICA
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_ELIMINAR_LISTACARA" 
(p_departamento_id_depart in NUMBER,
p_caracteristica_id_caract in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    DELETE FROM LISTACARACTERISTICAS
    WHERE DEPARTAMENTO_ID_DEPARTAMENTO = p_departamento_id_depart AND
    CARACTERISTICAS_ID_CARACT = p_caracteristica_id_caract;
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_ELIMINAR_LISTAACOMP
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_ELIMINAR_LISTAHUESPED" 
(p_acompanante_cedula in VARCHAR2,
p_reserva_id_reserva in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    DELETE FROM LISTAACOMP
    WHERE ACOMPANANTE_CEDULA = p_acompanante_cedula AND
    RESERVA_ID_RESERVA = p_reserva_id_reserva;
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_ELIMINAR_VIAJE
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_ELIMINAR_VIAJE" 
(p_id_viaje in NUMBER,
p_return OUT NUMBER)
is
v_valor NUMBER;
  BEGIN
    DELETE FROM VIAJE
    WHERE ID_VIAJE = p_id_viaje;
    p_return:=1;
    COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_MODIFICAR_RESERVA
--------------------------------------------------------
set define off;

create or replace  PROCEDURE "PROCE_MODIFICAR_ARRIENDO" 
(p_id_reserva in NUMBER, 
p_dias_reserva in NUMBER,
p_valor_final in NUMBER,
p_checkin in TIMESTAMP,
p_checkout in TIMESTAMP,
p_total_multas in NUMBER,
p_fecha_contrato in TIMESTAMP,
p_metodo_pago in VARCHAR2,
p_departamento_id_departamento in NUMBER,
p_anticipo in NUMBER,
p_estadopago in VARCHAR2,
p_estado in VARCHAR2,
p_return OUT NUMBER)
IS

BEGIN
        UPDATE RESERVA
        SET 
        DIAS_RESERVA = p_dias_reserva,
        VALOR_FINAL =p_valor_final,
        CHECKIN =p_checkin,
        CHECKOUT =p_checkout,
        TOTAL_MULTAS =p_total_multas,
        FECHA_CONTRATO =p_fecha_contrato,
        METODO_PAGO =p_metodo_pago,
        DEPARTAMENTO_ID_DEPARTAMENTO =p_departamento_id_departamento,
        ANTICIPO =p_anticipo,
        ESTADODEPAGO =p_estadopago,
        ESTADO =p_estado

        WHERE ID_RESERVA = p_id_reserva;

        p_return := 1;
        COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_MODIFICAR_CARACTERISTICA
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_MODIFICAR_CARACTERISTICA" 
(p_id_caracteristica in NUMBER, 
p_nombre in VARCHAR2,
p_descripcion in VARCHAR2,
p_return OUT NUMBER)  
IS

BEGIN
        UPDATE CARACTERISTICAS
        SET 
        NOMBRE = p_nombre,
        DESCRIPCION = p_descripcion
        WHERE ID_CARACTERISTICA = p_id_caracteristica;

        p_return := 1;
        COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_MODIFICAR_CONDUCTOR
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_MODIFICAR_CONDUCTOR" 
(p_rut in VARCHAR2, 
p_nombre in VARCHAR2,
p_apellido in VARCHAR2,
p_disponible in NUMBER,
p_email in VARCHAR2,
p_nro_contacto in NUMBER,
p_return OUT NUMBER)  
IS

BEGIN
        UPDATE CONDUCTOR
        SET NOMBRE = p_nombre,
        APELLIDO = p_apellido,
        DISPONIBLE = p_disponible,
        EMAIL = p_email,
        NRO_CONTACTO = p_nro_contacto
        WHERE RUT = p_rut;

        p_return := 1;
        COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_MODIFICAR_DEPARTAMENTO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_MODIFICAR_DEPARTAMENTO" 
(p_id_departamento in NUMBER, 
p_direccion in VARCHAR2,
p_metros_cuadrados in NUMBER,
p_valor_arriendo_diario in VARCHAR2,
p_disponible in NUMBER,
p_zona in VARCHAR2,
p_nro_habitaciones in VARCHAR2,
p_nro_banios in VARCHAR2,
p_return OUT NUMBER)  
IS

BEGIN
        UPDATE DEPARTAMENTO
        SET 
        DIRECCION = p_direccion,
        METROS_CUADRADOS = p_metros_cuadrados,
        VALOR_ARRIENDO_DIARIO = p_valor_arriendo_diario,
        DISPONBILE = p_disponible,
        ZONA = p_zona,
        NRO_HABITACIONES = p_nro_habitaciones,
        NRO_BANIOS = p_nro_banios
        WHERE ID_DEPARTAMENTO = p_id_departamento;

        p_return := 1;
        COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_MODIFICAR_ENCARGADO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_MODIFICAR_ENCARGADO" 
(p_rut in VARCHAR2,
p_nro_contacto in NUMBER,
p_nombre in VARCHAR2,
p_apellido in VARCHAR2,
p_email in VARCHAR2,
p_return OUT NUMBER)  
IS

BEGIN
        UPDATE ENCARGADO
        SET 
        NRO_CONTACTO = p_nro_contacto,
        NOMBRE = p_nombre,
        APELLIDO = p_apellido,
        EMAIL = p_email
        WHERE RUT = p_rut;

        p_return := 1;
        COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_MODIFICAR_ACOMPANANTE
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_MODIFICAR_HUESPED" 
(p_cedula in VARCHAR2, 
p_nombre in VARCHAR2,
p_apellido in VARCHAR2,
p_telefono in NUMBER,
p_return OUT NUMBER)  
IS

BEGIN
        UPDATE ACOMPANANTE
        SET NOMBRE = p_nombre,
        APELLIDO = p_apellido,
        TELEFONO = p_telefono
        WHERE CEDULA = p_cedula;

        p_return := 1;
        COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_MODIFICAR_INVENTARIO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_MODIFICAR_INVENTARIO" 
(p_fecha_asignacion in TIMESTAMP, 
p_fecha_ultima_moficacion in TIMESTAMP,
p_cantidad in NUMBER,
p_items_id_items in NUMBER,
p_departamento_id_departamento in NUMBER,
p_valor_total in NUMBER,
p_return OUT NUMBER)  
IS

BEGIN
        UPDATE INVENTARIO
        SET 
        FECHA_ASIGNACION = p_fecha_asignacion,
        FECHA_ULTIMA_MODIFICACION = p_fecha_ultima_moficacion,
        CANTIDAD = p_cantidad,
        ITEMS_ID_ITEM = p_items_id_items,
        DEPARTAMENTO_ID_DEPARTAMENTO = p_departamento_id_departamento,
        VALOR_TOTAL = p_valor_total
        WHERE DEPARTAMENTO_ID_DEPARTAMENTO = p_departamento_id_departamento
        and ITEMS_ID_ITEM = p_items_id_items;

        p_return := 1;
        COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_MODIFICAR_MANTENCION
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_MODIFICAR_MANTENCION" 
(p_id_mantencion in NUMBER, 
p_valor_total in NUMBER,
p_descripcion in VARCHAR2,
p_fecha_inicio in TIMESTAMP,
p_fecha_termino in TIMESTAMP,
p_motivo in VARCHAR2,
p_tipo_mantencion in VARCHAR2,
p_encargado_rut in VARCHAR2,
p_departamento_id in NUMBER,
p_estado_mantencion in VARCHAR2,
p_return OUT NUMBER)  
IS

BEGIN
        UPDATE MANTENCION
        SET 
        VALOR_TOTAL = p_valor_total,
        DESCRIPCION = p_descripcion,
        FECHA_INICIO = p_fecha_inicio,
        FECHA_TERMINO = p_fecha_termino,
        MOTIVO=p_motivo,
        TIPO_MANTENCION = p_tipo_mantencion,
        ENCARGADO_RUT = p_encargado_rut,
        DEPARTAMENTO_ID_DEPARTAMENTO = p_departamento_id,
        ESTADO = p_estado_mantencion
        WHERE ID_MANTENCION = p_id_mantencion;

        p_return := 1;
        COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_MODIFICAR_MULTA
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_MODIFICAR_MULTA" 
(p_id_multa in NUMBER, 
p_nombre in VARCHAR2,
p_descripcion in VARCHAR2,
p_valor in NUMBER,
p_estado_multa in VARCHAR2,
p_return OUT NUMBER)  
IS

BEGIN
        UPDATE MULTA
        SET 
     
        NOMBRE = p_nombre,
        DESCRIPCION = p_descripcion,
        VALOR = p_valor,
        ESTADO_MULTA=p_estado_multa
        
        WHERE ID_MULTA = p_id_multa;

        p_return := 1;
        COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_MODIFICAR_REVISION
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_MODIFICAR_REVISION" 
(p_estado in VARCHAR2, 
p_observaciones in VARCHAR2,
p_inventario_items_id_item in NUMBER,
p_inventario_depto_id_depto in NUMBER,
p_reserva_id_reserva in NUMBER,

p_return OUT NUMBER)
 
IS

BEGIN
        UPDATE REVISION
        SET ESTADO = p_estado,
        OBSERVACIONES = p_observaciones,
        INVENTARIO_ITEMS_ID_ITEM = p_inventario_items_id_item,
        INVENTARIO_DEPTO_ID_DEPTO = p_inventario_depto_id_depto,
        RESERVA_ID_RESERVA = p_reserva_id_reserva
        WHERE INVENTARIO_ITEMS_ID_ITEM = p_inventario_items_id_item
        AND INVENTARIO_DEPTO_ID_DEPTO = p_inventario_depto_id_depto
        AND RESERVA_ID_RESERVA = p_reserva_id_reserva;

        p_return := 1;
        COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_MODIFICAR_SERVICIOEXTRA
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_MODIFICAR_SERVICIOEXTRA" 
(p_id_servicio in NUMBER, 
p_nombre in VARCHAR2,
p_valor in NUMBER,
p_descripcion in VARCHAR2,
p_disponible in NUMBER,
p_return OUT NUMBER)  
IS

BEGIN
        UPDATE SERVICIOEXTRA
        SET 
        
        NOMBRE_SERVICIO = p_nombre,
        VALOR_SERVICIO = p_valor,
        DESCRIPCION = p_descripcion,
        DISPONIBLE = p_disponible
        WHERE ID_SERVICIO = p_id_servicio;

        p_return := 1;
        COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_MODIFICAR_USUARIO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_MODIFICAR_USUARIO" 
(p_email in VARCHAR2, 
p_cedula in VARCHAR2,
p_nombre in VARCHAR2,
p_apellido in VARCHAR2,
p_telefono in NUMBER,
p_estado in VARCHAR2,
p_tipo in VARCHAR2,
p_password in VARCHAR2,
p_return OUT NUMBER)  
IS

BEGIN
        UPDATE USUARIO
        SET EMAIL = p_email,
        CEDULA = p_cedula,
        NOMBRE = p_nombre,
        APELLIDO = p_apellido,
        TELEFONO = p_telefono,
        ESTADO = p_estado,
        TIPO = p_tipo,
        PASSWORD = p_password
        WHERE EMAIL = p_email;

        p_return := 1;
        COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_MODIFICAR_VEHICULO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_MODIFICAR_VEHICULO" 
(p_patente in VARCHAR2, 
p_modelo in VARCHAR2,
p_a�o in NUMBER,
p_color in VARCHAR2,
p_disponible in NUMBER,
p_return OUT NUMBER)  
IS

BEGIN
        UPDATE VEHICULO
        SET 
        MODELO = p_modelo,
        A�O = p_a�o,
        COLOR = p_color,
        DISPONIBLE = p_disponible
        WHERE PATENTE = p_patente;

        p_return := 1;
        COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure PROCE_MODIFICAR_VIAJE
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."PROCE_MODIFICAR_VIAJE" 
(p_id_viaje in NUMBER, 
p_origen in VARCHAR2,
p_destino in VARCHAR2,
p_comienzo in TIMESTAMP,
p_precio in NUMBER,
p_conductor_rut in VARCHAR2,
p_vehiculo_patente in VARCHAR2,
p_return OUT NUMBER)  
IS

BEGIN
        UPDATE VIAJE
        SET 
        ORIGEN = p_origen,
        DESTINO = p_destino,
        COMIENZO = p_comienzo,
        PRECIO =p_precio,
        CONDUCTOR_RUT = p_conductor_rut,
        VEHICULO_PATENTE = p_vehiculo_patente
        WHERE ID_VIAJE = p_id_viaje;

        p_return := 1;
        COMMIT;
EXCEPTION
    WHEN DUP_VAL_ON_INDEX THEN
    p_return := 0;
    WHEN NO_DATA_FOUND THEN
    p_return := 0;
    WHEN OTHERS THEN
    p_return := 0;
END;

/
--------------------------------------------------------
--  DDL for Procedure VALIDARUSUARIO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE  PROCEDURE "ATEMPORADA"."VALIDARUSUARIO" (p_email in VARCHAR2, p_passw in VARCHAR2, p_result out NUMBER)
as
  BEGIN
    SELECT COUNT(*) INTO p_result
    FROM USUARIO WHERE email=p_email AND (password=p_passw) AND tipo!='Cliente';
  END;
/
set define off;
CREATE OR REPLACE PROCEDURE insert_multa (nombre IN VARCHAR2, descripcion IN VARCHAR2, valor IN NUMBER,estado_multa IN VARCHAR2) IS
BEGIN
INSERT INTO multa (id_multa, nombre, descripcion, valor,estado_multa)
VALUES (SEQ_ID_MULTA.nextval,nombre, descripcion, valor,estado_multa);
END;
/
set define off;
CREATE OR REPLACE PROCEDURE insert_dmulta (observaciones IN VARCHAR2, reserva_id_reserva IN NUMBER, multa_id_multa IN NUMBER,estadomulta IN VARCHAR2) IS
BEGIN
INSERT INTO detallemulta (id_dmulta, observaciones, reserva_id_reserva, multa_id_multa,estadomulta)
VALUES (SEQ_ID_DMULTA.nextval,observaciones, reserva_id_reserva, multa_id_multa,estadomulta);
END; 
/