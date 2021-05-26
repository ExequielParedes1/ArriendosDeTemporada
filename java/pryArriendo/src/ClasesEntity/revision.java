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
public class revision {
    private String rut_usuario;
    private int id_revision;
    private Date fecha_revision;
    private int id_depto;

    public revision() {
    }

    public revision(String rut_usuario, int id_revision, Date fecha_revision, int id_depto) {
        this.rut_usuario = rut_usuario;
        this.id_revision = id_revision;
        this.fecha_revision = fecha_revision;
        this.id_depto = id_depto;
    }

    public String getRut_usuario() {
        return rut_usuario;
    }

    public void setRut_usuario(String rut_usuario) {
        this.rut_usuario = rut_usuario;
    }

    public int getId_revision() {
        return id_revision;
    }

    public void setId_revision(int id_revision) {
        this.id_revision = id_revision;
    }

    public Date getFecha_revision() {
        return fecha_revision;
    }

    public void setFecha_revision(Date fecha_revision) {
        this.fecha_revision = fecha_revision;
    }

    public int getId_depto() {
        return id_depto;
    }

    public void setId_depto(int id_depto) {
        this.id_depto = id_depto;
    }

    @Override
    public String toString() {
        return "revision{" + "rut_usuario=" + rut_usuario + ", id_revision=" + id_revision + ", fecha_revision=" + fecha_revision + ", id_depto=" + id_depto + '}';
    }
    
    
    
    
}
