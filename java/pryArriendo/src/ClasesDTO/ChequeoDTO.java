/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDTO;

import ClasesDAO.ChequeoDAO;
import ClasesEntity.chequeo;
import conexionBD.conexion;
import java.sql.Connection;
import java.sql.SQLException;
import javax.swing.JOptionPane;
import javax.swing.JTable;

/**
 *
 * @author Favio
 */
public class ChequeoDTO {
    private ChequeoDAO cDAO = new ChequeoDAO();
    private boolean valida;
    private String mensaje = "";
    
    public boolean ingresarChequeo(chequeo check) {
        valida = false;
        Connection conn = conexion.getConnection();
        try {
            valida = cDAO.ingresarChequeo(conn, check);
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
    
    public boolean EliminarChequeo(int id) {
        valida = false;
        Connection conn = conexion.getConnection();
        try {
            valida = cDAO.EliminarChequeo(conn, id);
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
        return valida;
    }
    
    public void listarChequeo(JTable tabla) {
        Connection conn = conexion.getConnection();
        cDAO.listarChequeo(conn, tabla);
        try {
            conn.close();
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
    }
    
    public void listarChequeo2(JTable tabla) {
        Connection conn = conexion.getConnection();
        cDAO.listarChequeo2(conn, tabla);
        try {
            conn.close();
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
    }
    
    public boolean pasarAcheckout(chequeo checkout) {
        valida = false;
        Connection conn = conexion.getConnection();
        try {
            valida = cDAO.pasarAcheckout(conn, checkout);
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
    
    public boolean cambiarEstadoaRevisado(int idcheck) {
        valida = false;
        Connection conn = conexion.getConnection();
        try {
            valida = cDAO.cambiarEstadoaRevisado(conn,idcheck);
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
//    public boolean modificarReserva(reserva re) {
//        valida = false;
//        Connection conn = conexion.getConnection();
//        try {
//            valida = cDAO.modificarReserva(conn, re);
//            //conn.rollback();
//        } catch (Exception e) {
//            JOptionPane.showMessageDialog(null, e.getMessage());
//        }finally{
//            try {
//                if (conn != null) {
//                    conn.close();
//                }
//            } catch (SQLException e) {
//                JOptionPane.showMessageDialog(null, e.getMessage());
//            }
//        }
//        return valida;
//    }
}
