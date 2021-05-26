/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDTO;

import ClasesDAO.RevisionDAO;
import ClasesEntity.revision;
import conexionBD.conexion;
import java.sql.Connection;
import java.sql.SQLException;
import javax.swing.JOptionPane;
import javax.swing.JTable;

/**
 *
 * @author Favio
 */
public class RevisionDTO {
    
    private RevisionDAO rDAO = new RevisionDAO();
    private boolean valida;
    
    
     public boolean ingresarRevision(revision rev) {
        valida = false;
        Connection conn = conexion.getConnection();
        try {
            valida = rDAO.ingresarRevision(conn, rev);
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
    
    public void listarRevision(JTable tabla) {
        Connection conn = conexion.getConnection();
        rDAO.listarRevision(conn, tabla);
        try {
            conn.close();
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
    }
}
