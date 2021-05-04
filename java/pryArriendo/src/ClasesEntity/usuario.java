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
public class usuario {
    private String rut_usuario;
    private String contrasenia;
    private String rol;
    private String nombre_usuario;
    private String apellido_p ;
    private String apellido_m;
    private String estado_usuario;
    private String email;

    public usuario() {
    }

    public usuario(String rut_usuario, String contrasenia, String rol, String nombre_usuario, String apellido_p, String apellido_m, String estado_usuario, String email) {
        this.rut_usuario = rut_usuario;
        this.contrasenia = contrasenia;
        this.rol = rol;
        this.nombre_usuario = nombre_usuario;
        this.apellido_p = apellido_p;
        this.apellido_m = apellido_m;
        this.estado_usuario = estado_usuario;
        this.email = email;
    }

    public String getRut_usuario() {
        return rut_usuario;
    }

    public void setRut_usuario(String rut_usuario) {
        this.rut_usuario = rut_usuario;
    }

    public String getContrasenia() {
        return contrasenia;
    }

    public void setContrasenia(String contrasenia) {
        this.contrasenia = contrasenia;
    }

    public String getRol() {
        return rol;
    }

    public void setRol(String rol) {
        this.rol = rol;
    }

    public String getNombre_usuario() {
        return nombre_usuario;
    }

    public void setNombre_usuario(String nombre_usuario) {
        this.nombre_usuario = nombre_usuario;
    }

    public String getApellido_p() {
        return apellido_p;
    }

    public void setApellido_p(String apellido_p) {
        this.apellido_p = apellido_p;
    }

    public String getApellido_m() {
        return apellido_m;
    }

    public void setApellido_m(String apellido_m) {
        this.apellido_m = apellido_m;
    }

    public String getEstado_usuario() {
        return estado_usuario;
    }

    public void setEstado_usuario(String estado_usuario) {
        this.estado_usuario = estado_usuario;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @Override
    public String toString() {
        return "usuario{" + "rut_usuario=" + rut_usuario + ", contrasenia=" + contrasenia + ", rol=" + rol + ", nombre_usuario=" + nombre_usuario + ", apellido_p=" + apellido_p + ", apellido_m=" + apellido_m + ", estado_usuario=" + estado_usuario + ", email=" + email + '}';
    }

    
    
    
}
