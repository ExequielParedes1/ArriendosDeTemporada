/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDTO;

import ClasesDAO.DepartamentoDAO;
import ClasesEntity.departamento;
import conexionBD.conexion;
import java.sql.Connection;
import java.sql.SQLException;
import javax.swing.JOptionPane;
import javax.swing.JTable;

/**
 *
 * @author Favio
 */
public class DepartamentoDTO {
    
    private DepartamentoDAO deptoDAO = new DepartamentoDAO();
    private boolean valida;
    
    public boolean ingresarDepto(departamento ins) {
        valida = false;
        Connection conn = conexion.getConnection();
        try {
            valida = deptoDAO.ingresarDepto(conn, ins);
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
    
    public boolean modificarDepto(departamento dept) {
        valida = false;
        Connection conn = conexion.getConnection();
        try {
            valida = deptoDAO.modificarDepto(conn, dept);
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
    
     public boolean inhabilitarDepto(int id) {
        valida = false;
        Connection conn = conexion.getConnection();
        try {
            valida = deptoDAO.inhabilitarDepto(conn, id);
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
    
    public void listarDepto(JTable tabla) {
        Connection conn = conexion.getConnection();
        deptoDAO.listarDepto(conn, tabla);
        try {
            conn.close();
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
    }
}
