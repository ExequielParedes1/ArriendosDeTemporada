/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDTO;

import ClasesDAO.ServicioDAO;
import ClasesEntity.servicio;
import conexionBD.conexion;
import java.sql.Connection;
import java.sql.SQLException;
import javax.swing.JOptionPane;
import javax.swing.JTable;

/**
 *
 * @author Favio
 */
public class ServicioDTO {
    
    private ServicioDAO sDAO = new ServicioDAO();
    private boolean valida;
    
    public boolean ingresarServicio(servicio ins) {
        valida = false;
        Connection conn = conexion.getConnection();
        try {
            valida = sDAO.ingresarServicio(conn, ins);
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
    
     public boolean modificarServicio(servicio tou) {
        valida = false;
        Connection conn = conexion.getConnection();
        try {
            valida = sDAO.modificarServicio(conn, tou);
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
    
     public boolean inhabilitarServicio(int id) {
        valida = false;
        Connection conn = conexion.getConnection();
        try {
            valida = sDAO.inhabilitarServicio(conn, id);
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
    
    public void listarServicio(JTable tabla) {
        Connection conn = conexion.getConnection();
        sDAO.listarServicio(conn, tabla);
        try {
            conn.close();
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
    }
}
