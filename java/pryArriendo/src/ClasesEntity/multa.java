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
public class multa {
    private int id_multa;
    private String descripcion;
    private int monto;
    private int id_reserva;

    public multa() {
    }

    public multa(int id_multa, String descripcion, int monto, int id_reserva) {
        this.id_multa = id_multa;
        this.descripcion = descripcion;
        this.monto = monto;
        this.id_reserva = id_reserva;
    }

    public int getId_multa() {
        return id_multa;
    }

    public void setId_multa(int id_multa) {
        this.id_multa = id_multa;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public int getMonto() {
        return monto;
    }

    public void setMonto(int monto) {
        this.monto = monto;
    }

    public int getId_reserva() {
        return id_reserva;
    }

    public void setId_reserva(int id_reserva) {
        this.id_reserva = id_reserva;
    }

    @Override
    public String toString() {
        return "multa{" + "id_multa=" + id_multa + ", descripcion=" + descripcion + ", monto=" + monto + ", id_reserva=" + id_reserva + '}';
    }
    
    
}
