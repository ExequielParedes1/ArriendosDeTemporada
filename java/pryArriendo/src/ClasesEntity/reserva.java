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
public class reserva {
    private int id_reserva;
    private Date fecha_ini;
    private Date fecha_fin;
    private String estado_rese;
    private int id_cliente;

    public reserva() {
    }

    public reserva(int id_reserva, Date fecha_ini, Date fecha_fin, String estado_rese, int id_cliente) {
        this.id_reserva = id_reserva;
        this.fecha_ini = fecha_ini;
        this.fecha_fin = fecha_fin;
        this.estado_rese = estado_rese;
        this.id_cliente = id_cliente;
    }

    public int getId_reserva() {
        return id_reserva;
    }

    public void setId_reserva(int id_reserva) {
        this.id_reserva = id_reserva;
    }

    public Date getFecha_ini() {
        return fecha_ini;
    }

    public void setFecha_ini(Date fecha_ini) {
        this.fecha_ini = fecha_ini;
    }

    public Date getFecha_fin() {
        return fecha_fin;
    }

    public void setFecha_fin(Date fecha_fin) {
        this.fecha_fin = fecha_fin;
    }

    public String getEstado_rese() {
        return estado_rese;
    }

    public void setEstado_rese(String estado_rese) {
        this.estado_rese = estado_rese;
    }

    public int getId_cliente() {
        return id_cliente;
    }

    public void setId_cliente(int id_cliente) {
        this.id_cliente = id_cliente;
    }

    @Override
    public String toString() {
        return "reserva{" + "id_reserva=" + id_reserva + ", fecha_ini=" + fecha_ini + ", fecha_fin=" + fecha_fin + ", estado_rese=" + estado_rese + ", id_cliente=" + id_cliente + '}';
    }
    
    
}
