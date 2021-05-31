/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDTO;

import ClasesDAO.ReservaDAO;
import conexionBD.conexion;
import java.sql.Connection;
import java.sql.SQLException;
import javax.swing.JOptionPane;
import javax.swing.JTable;

/**
 *
 * @author Favio
 */
public class ReservaDTO {
    
    private ReservaDAO rDAO = new ReservaDAO();
    private boolean valida;
    
    public void listarReserva(JTable tabla) {
        Connection conn = conexion.getConnection();
        rDAO.listarReserva(conn, tabla);
        try {
            conn.close();
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
    }
    
    public boolean cambiarEstadoReserva(int idreserva) {
        valida = false;
        Connection conn = conexion.getConnection();
        try {
            valida = rDAO.cambiarEstadoReserva(conn,idreserva);
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
}
