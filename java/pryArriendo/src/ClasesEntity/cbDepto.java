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
public class cbDepto {
    private int id_depto;
    private String num_depto;

    public cbDepto() {
    }

    public cbDepto(int id_depto, String num_depto) {
        this.id_depto = id_depto;
        this.num_depto = num_depto;
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

    @Override
    public String toString() {
        return num_depto;
    }
    
    
    
}
