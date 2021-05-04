/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDTO;

import ClasesDAO.ClienteDAO;
import ClasesEntity.cliente;
import conexionBD.conexion;
import java.sql.Connection;
import java.sql.SQLException;
import javax.swing.JOptionPane;
import javax.swing.JTable;

/**
 *
 * @author Favio
 */
public class ClienteDTO {
    private String mensaje = "";
    private ClienteDAO cdao = new ClienteDAO();
    private boolean validado;
    
    public boolean ingresarCliente(cliente cli) {
        validado = false;
        Connection conn = conexion.getConnection();
        try {
            validado = cdao.ingresarCliente(conn, cli);
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
        return validado;
    }
    
    public boolean modificarCliente(cliente clien) {
        validado = false;
        Connection conn = conexion.getConnection();
        try {
            validado = cdao.modificarCliente(conn, clien);
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
        return validado;
    }
    
    public boolean eliminarCliente(int id) {
        validado = false;
        Connection conn = conexion.getConnection();
        try {
            validado = cdao.eliminarCliente(conn, id);
            //conn.rollback();
        } catch (Exception e) {
            mensaje = mensaje + " " + e.getMessage();
        }finally{
            try {
                if (conn != null) {
                    conn.close();
                }
            } catch (Exception e) {
                mensaje = mensaje + " " + e.getMessage();
            }
        }
        return validado;
    }
    
    public boolean DesabilitarCliente(int id) {
        validado = false;
        Connection conn = conexion.getConnection();
        try {
            validado = cdao.DesabilitarCliente(conn, id);
            //conn.rollback();
        } catch (Exception e) {
            mensaje = mensaje + " " + e.getMessage();
        }finally{
            try {
                if (conn != null) {
                    conn.close();
                }
            } catch (Exception e) {
                mensaje = mensaje + " " + e.getMessage();
            }
        }
        return validado;
    }
    
    public void listarClientes(JTable tabla) {
        Connection conn = conexion.getConnection();
        cdao.listarClientes(conn, tabla);
        try {
            conn.close();
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
    }
}
