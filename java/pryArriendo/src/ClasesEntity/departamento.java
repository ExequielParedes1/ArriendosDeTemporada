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
public class departamento {
    
    private int id_depto;
    private String num_depto;
    private String direccion;
    private String Descripcion;
    private String region;
    private String estado;
    private int valor_diario;

    public departamento() {
    }

    public departamento(int id_depto, String num_depto, String direccion, String Descripcion, String region, String estado, int valor_diario) {
        this.id_depto = id_depto;
        this.num_depto = num_depto;
        this.direccion = direccion;
        this.Descripcion = Descripcion;
        this.region = region;
        this.estado = estado;
        this.valor_diario = valor_diario;
    }

    public int getId_depto() {
        return id_depto;
    }

    public void setId_depto(int id_depto) {
        this.id_depto = id_depto;
    }

    public String getNum_depto() {
        return num_depto;
    }

    public void setNum_depto(String num_depto) {
        this.num_depto = num_depto;
    }

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    public String getDescripcion() {
        return Descripcion;
    }

    public void setDescripcion(String Descripcion) {
        this.Descripcion = Descripcion;
    }

    public String getRegion() {
        return region;
    }

    public void setRegion(String region) {
        this.region = region;
    }

    public String getEstado() {
        return estado;
    }

    public void setEstado(String estado) {
        this.estado = estado;
    }

    public int getValor_diario() {
        return valor_diario;
    }

    public void setValor_diario(int valor_diario) {
        this.valor_diario = valor_diario;
    }

    @Override
    public String toString() {
        return "departamento{" + "id_depto=" + id_depto + ", num_depto=" + num_depto + ", direccion=" + direccion + ", Descripcion=" + Descripcion + ", region=" + region + ", estado=" + estado + ", valor_diario=" + valor_diario + '}';
    }

    
    
    
    
}
