/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesEntity;

import java.sql.Date;

/**
 *
 * @author Favio
 */
public class chequeo {
    
    private int id_chequeo;
    private String tipo_chequeo;
    private Date fecha_chequeo;
    private String rut_funcionario;
    private int id_reserva;

    public chequeo() {
    }

    public chequeo(int id_chequeo, String tipo_chequeo, Date fecha_chequeo, String rut_funcionario, int id_reserva) {
        this.id_chequeo = id_chequeo;
        this.tipo_chequeo = tipo_chequeo;
        this.fecha_chequeo = fecha_chequeo;
        this.rut_funcionario = rut_funcionario;
        this.id_reserva = id_reserva;
    }

    public int getId_chequeo() {
        return id_chequeo;
    }

    public void setId_chequeo(int id_chequeo) {
        this.id_chequeo = id_chequeo;
    }

    public String getTipo_chequeo() {
        return tipo_chequeo;
    }

    public void setTipo_chequeo(String tipo_chequeo) {
        this.tipo_chequeo = tipo_chequeo;
    }

    public Date getFecha_chequeo() {
        return fecha_chequeo;
    }

    public void setFecha_chequeo(Date fecha_chequeo) {
        this.fecha_chequeo = fecha_chequeo;
    }

    public String getRut_funcionario() {
        return rut_funcionario;
    }

    public void setRut_funcionario(String rut_funcionario) {
        this.rut_funcionario = rut_funcionario;
    }

    public int getId_reserva() {
        return id_reserva;
    }

    public void setId_reserva(int id_reserva) {
        this.id_reserva = id_reserva;
    }

    @Override
    public String toString() {
        return "chequeo{" + "id_chequeo=" + id_chequeo + ", tipo_chequeo=" + tipo_chequeo + ", fecha_chequeo=" + fecha_chequeo + ", rut_funcionario=" + rut_funcionario + ", id_reserva=" + id_reserva + '}';
    }
    
    
}
