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
public class servicio {
    
    private int id_servicio;
    private String nombre;
    private String tipo;
    private Date hora_ini;
    private Date hora_fin;
    private String punto_reunion;
    private int valor;
    private String recorrido;
    private String vehiculo;
    private String chofer;
    private String estado_servicio;
    private int cupos;

    public servicio() {
    }

    public servicio(int id_servicio, String nombre, String tipo, Date hora_ini, Date hora_fin, String punto_reunion, int valor, String recorrido, String vehiculo, String chofer, String estado_servicio, int cupos) {
        this.id_servicio = id_servicio;
        this.nombre = nombre;
        this.tipo = tipo;
        this.hora_ini = hora_ini;
        this.hora_fin = hora_fin;
        this.punto_reunion = punto_reunion;
        this.valor = valor;
        this.recorrido = recorrido;
        this.vehiculo = vehiculo;
        this.chofer = chofer;
        this.estado_servicio = estado_servicio;
        this.cupos = cupos;
    }

    public int getId_servicio() {
        return id_servicio;
    }

    public void setId_servicio(int id_servicio) {
        this.id_servicio = id_servicio;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getTipo() {
        return tipo;
    }

    public void setTipo(String tipo) {
        this.tipo = tipo;
    }

    public Date getHora_ini() {
        return hora_ini;
    }

    public void setHora_ini(Date hora_ini) {
        this.hora_ini = hora_ini;
    }

    public Date getHora_fin() {
        return hora_fin;
    }

    public void setHora_fin(Date hora_fin) {
        this.hora_fin = hora_fin;
    }

    public String getPunto_reunion() {
        return punto_reunion;
    }

    public void setPunto_reunion(String punto_reunion) {
        this.punto_reunion = punto_reunion;
    }

    public int getValor() {
        return valor;
    }

    public void setValor(int valor) {
        this.valor = valor;
    }

    public String getRecorrido() {
        return recorrido;
    }

    public void setRecorrido(String recorrido) {
        this.recorrido = recorrido;
    }

    public String getVehiculo() {
        return vehiculo;
    }

    public void setVehiculo(String vehiculo) {
        this.vehiculo = vehiculo;
    }

    public String getChofer() {
        return chofer;
    }

    public void setChofer(String chofer) {
        this.chofer = chofer;
    }

    public String getEstado_servicio() {
        return estado_servicio;
    }

    public void setEstado_servicio(String estado_servicio) {
        this.estado_servicio = estado_servicio;
    }

    public int getCupos() {
        return cupos;
    }

    public void setCupos(int cupos) {
        this.cupos = cupos;
    }

    @Override
    public String toString() {
        return "servicio{" + "id_servicio=" + id_servicio + ", nombre=" + nombre + ", tipo=" + tipo + ", hora_ini=" + hora_ini + ", hora_fin=" + hora_fin + ", punto_reunion=" + punto_reunion + ", valor=" + valor + ", recorrido=" + recorrido + ", vehiculo=" + vehiculo + ", chofer=" + chofer + ", estado_servicio=" + estado_servicio + ", cupos=" + cupos + '}';
    }

    
}
