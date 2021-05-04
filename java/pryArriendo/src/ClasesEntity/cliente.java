/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesEntity;

/**
 *
 * @author Favio
 */
public class cliente {
    private int id_cliente;
    private String rut_cliente;
    private String pasaporte;
    private String passwrd;
    private String nombre;
    private String appaterno;
    private String apmaterno;
    private int num_celular;
    private String correo;
    private String nacionalidad;
    private char cliente_frecuente;
    private String estado_cliente;

    public cliente() {
    }

    public cliente(int id_cliente, String rut_cliente, String pasaporte, String passwrd, String nombre, String appaterno, String apmaterno, int num_celular, String correo, String nacionalidad, char cliente_frecuente, String estado_cliente) {
        this.id_cliente = id_cliente;
        this.rut_cliente = rut_cliente;
        this.pasaporte = pasaporte;
        this.passwrd = passwrd;
        this.nombre = nombre;
        this.appaterno = appaterno;
        this.apmaterno = apmaterno;
        this.num_celular = num_celular;
        this.correo = correo;
        this.nacionalidad = nacionalidad;
        this.cliente_frecuente = cliente_frecuente;
        this.estado_cliente = estado_cliente;
    }

    public int getId_cliente() {
        return id_cliente;
    }

    public void setId_cliente(int id_cliente) {
        this.id_cliente = id_cliente;
    }

    public String getRut_cliente() {
        return rut_cliente;
    }

    public void setRut_cliente(String rut_cliente) {
        this.rut_cliente = rut_cliente;
    }

    public String getPasaporte() {
        return pasaporte;
    }

    public void setPasaporte(String pasaporte) {
        this.pasaporte = pasaporte;
    }

    public String getPasswrd() {
        return passwrd;
    }

    public void setPasswrd(String passwrd) {
        this.passwrd = passwrd;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getAppaterno() {
        return appaterno;
    }

    public void setAppaterno(String appaterno) {
        this.appaterno = appaterno;
    }

    public String getApmaterno() {
        return apmaterno;
    }

    public void setApmaterno(String apmaterno) {
        this.apmaterno = apmaterno;
    }

    public int getNum_celular() {
        return num_celular;
    }

    public void setNum_celular(int num_celular) {
        this.num_celular = num_celular;
    }

    public String getCorreo() {
        return correo;
    }

    public void setCorreo(String correo) {
        this.correo = correo;
    }

    public String getNacionalidad() {
        return nacionalidad;
    }

    public void setNacionalidad(String nacionalidad) {
        this.nacionalidad = nacionalidad;
    }

    public char getCliente_frecuente() {
        return cliente_frecuente;
    }

    public void setCliente_frecuente(char cliente_frecuente) {
        this.cliente_frecuente = cliente_frecuente;
    }

    public String getEstado_cliente() {
        return estado_cliente;
    }

    public void setEstado_cliente(String estado_cliente) {
        this.estado_cliente = estado_cliente;
    }

    @Override
    public String toString() {
        return "cliente{" + "id_cliente=" + id_cliente + ", rut_cliente=" + rut_cliente + ", pasaporte=" + pasaporte + ", passwrd=" + passwrd + ", nombre=" + nombre + ", appaterno=" + appaterno + ", apmaterno=" + apmaterno + ", num_celular=" + num_celular + ", correo=" + correo + ", nacionalidad=" + nacionalidad + ", cliente_frecuente=" + cliente_frecuente + ", estado_cliente=" + estado_cliente + '}';
    }

    
    
    
    
    
            
    
}
