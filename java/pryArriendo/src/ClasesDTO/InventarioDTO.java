/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDTO;

import ClasesDAO.InventarioDAO;
import ClasesEntity.departamento;
import ClasesEntity.inventario;
import conexionBD.conexion;
import java.sql.Connection;
import java.sql.SQLException;
import java.util.ArrayList;
import javax.swing.JOptionPane;
import javax.swing.JTable;

/**
 *
 * @author Favio
 */
public class InventarioDTO {
    
    private String mensaje = "";
    private InventarioDAO invendao = new InventarioDAO();
    private boolean paso;
    
    public boolean ingresarInventario(inventario in) {
        paso = false;
        Connection conn = conexion.getConnection();
        try {
            paso = invendao.ingresarInventario(conn, in);
        } catch (Exception e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }finally{
            try {
                if (conn != null) {
                    conn.close();
                }
            } catch (Exception e) {
                JOptionPane.showMessageDialog(null, e);
            }
        }
        return paso;
    }
    
    public boolean modificarInv(inventario in) {
        paso = false;
        Connection conn = conexion.getConnection();
        try {
            paso = invendao.modificarInv(conn, in);
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
        return paso;
    }
    
    public boolean inhabilitarInv(int id) {
        paso = false;
        Connection conn = conexion.getConnection();
        try {
            paso = invendao.inhabilitarInv(conn, id);
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
        return paso;
    }
    
    
    public void listarInventario(JTable tabla) {
        Connection conn = conexion.getConnection();
        invendao.listarInventario(conn, tabla);
        try {
            conn.close();
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
    }
    
    
    
    public ArrayList<departamento> listDepto() {
        Connection conn = conexion.getConnection();
        ArrayList<departamento> ADep = invendao.listDpto(conn);
        try {
            conn.close();
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return ADep;
    }
}
