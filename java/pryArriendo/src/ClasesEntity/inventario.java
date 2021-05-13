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
public class inventario {
    private int id_inventario;
    private String nombre_articulo;
    private String tipo_articulo;
    private int valor_articulo;
    private int depto;
    private String estado_inventario;

    public inventario() {
    }

    public inventario(int id_inventario, String nombre_articulo, String tipo_articulo, int valor_articulo, int depto, String estado_inventario) {
        this.id_inventario = id_inventario;
        this.nombre_articulo = nombre_articulo;
        this.tipo_articulo = tipo_articulo;
        this.valor_articulo = valor_articulo;
        this.depto = depto;
        this.estado_inventario = estado_inventario;
    }

    public int getId_inventario() {
        return id_inventario;
    }

    public void setId_inventario(int id_inventario) {
        this.id_inventario = id_inventario;
    }

    public String getNombre_articulo() {
        return nombre_articulo;
    }

    public void setNombre_articulo(String nombre_articulo) {
        this.nombre_articulo = nombre_articulo;
    }

    public String getTipo_articulo() {
        return tipo_articulo;
    }

    public void setTipo_articulo(String tipo_articulo) {
        this.tipo_articulo = tipo_articulo;
    }

    public int getValor_articulo() {
        return valor_articulo;
    }

    public void setValor_articulo(int valor_articulo) {
        this.valor_articulo = valor_articulo;
    }

    public int getDepto() {
        return depto;
    }

    public void setDepto(int depto) {
        this.depto = depto;
    }

    public String getEstado_inventario() {
        return estado_inventario;
    }

    public void setEstado_inventario(String estado_inventario) {
        this.estado_inventario = estado_inventario;
    }

    @Override
    public String toString() {
        return "inventario{" + "id_inventario=" + id_inventario + ", nombre_articulo=" + nombre_articulo + ", tipo_articulo=" + tipo_articulo + ", valor_articulo=" + valor_articulo + ", depto=" + depto + ", estado_inventario=" + estado_inventario + '}';
    }

    

    
    
    
    
}
