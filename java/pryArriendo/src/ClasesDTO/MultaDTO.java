/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDTO;

import ClasesDAO.MultaDAO;
import ClasesEntity.multa;
import conexionBD.conexion;
import java.sql.Connection;
import java.sql.SQLException;
import javax.swing.JOptionPane;
import javax.swing.JTable;

/**
 *
 * @author Favio
 */
public class MultaDTO {
    private MultaDAO mDAO = new MultaDAO();
    private boolean valida;
    private String mensaje = "";
    
     public boolean ingresarMulta(multa m) {
        valida = false;
        Connection conn = conexion.getConnection();
        try {
            valida = mDAO.ingresarMulta(conn, m);
            //conn.rollback();
        } catch (Exception e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }finally{
            try {
                if (conn != null) {
                    conn.close();
                }
            } catch (SQLException e) {
                JOptionPane.showMessageDialog(null, e.getMessage());
            }
        }
        return valida;
    }
    
     public void listarMulta(JTable tabla) {
        Connection conn = conexion.getConnection();
        mDAO.listarMulta(conn, tabla);
        try {
            conn.close();
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
    }
}
