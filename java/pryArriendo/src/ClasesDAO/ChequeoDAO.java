/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDAO;

import ClasesEntity.chequeo;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import javax.swing.JOptionPane;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;

/**
 *
 * @author Favio
 */
public class ChequeoDAO {
    
    public boolean ingresarChequeo(Connection con, chequeo check) {
        boolean pasoInsert = false;
        String sql = "{call insert_chequeo(?,?,?,?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setString(1, check.getTipo_chequeo());
            pst.setDate(2, check.getFecha_chequeo());
            pst.setString(3, check.getRut_funcionario());
            pst.setInt(4, check.getId_reserva());
            pst.execute();
            pst.close();
            pasoInsert = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }
        return pasoInsert;
    }
    
    public boolean EliminarChequeo(Connection con, int id) {
        boolean pasoDesabilitar = false;
        String sql = "{call inhabilitar_chequeo (?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setInt(1, id);
            pst.execute();
            pst.close();
            pasoDesabilitar = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }
        return pasoDesabilitar;
    }
    
    public void listarChequeo(Connection con, JTable tabla) {
        DefaultTableModel model;
        String [] columnas = {"ID Chequeo", "Tipo chequeo", "Fecha", "RUT Funcionario", "ID Reserva"};
        model = new DefaultTableModel(null, columnas);
        
        String sql = "Select * from checkeo";
        
        String[] filas = new String[5];
        
        try {
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery(sql);
            while (rs.next()) {
                for(int i = 0; i < 5; i++) {
                    filas[i] = rs.getString(i+1);
                }
                model.addRow(filas);
            }
            tabla.setModel(model);
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
    }
    
    public void listarChequeo2(Connection con, JTable tabla) {
        DefaultTableModel model;
        String [] columnas = {"ID Chequeo", "Tipo chequeo", "Fecha", "RUT Funcionario", "ID Reserva"};
        model = new DefaultTableModel(null, columnas);
        
        String sql = "Select * from checkeo";
        
        String[] filas = new String[5];
        
        try {
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery(sql);
            while (rs.next()) {
                for(int i = 0; i < 5; i++) {
                    filas[i] = rs.getString(i+1);
                }
                model.addRow(filas);
            }
            tabla.setModel(model);
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
    }
    

    
    // para realizar check out
    public boolean pasarAcheckout(Connection con, chequeo check) {
        boolean pasoModi = false;
        String sql = "{call check_out(?,?,?,?,?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setInt(1, check.getId_chequeo());
            pst.setString(2, check.getTipo_chequeo());
            pst.setDate(3, check.getFecha_chequeo());
            pst.setString(4, check.getRut_funcionario());
            pst.setInt(5, check.getId_reserva());
            pst.execute();
            pst.close();
            pasoModi = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }
            
        return pasoModi;
    }
    
    public boolean cambiarEstadoaRevisado(Connection conn,int idchequeo) {
        boolean pasoMod = false;
        CallableStatement pst;
        String slq  = "UPDATE checkeo SET tipo_checkeo = 'REVISADO' WHERE id_checkeo = ?";
        
        try {
            pst = conn.prepareCall(slq);
            pst.setInt(1, idchequeo);
            pst.execute();
            pst.close();
            pasoMod = true;
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return pasoMod;
    }
    //para cambiar estado reserva luego del chequeo
    
//    public boolean modificarReserva(Connection conn, int idreserva , int depto) {
//        boolean pasoMod = false;
//        CallableStatement pst;
//        String slq  = "UPDATE reserva SET estado = 'CHECK IN' WHERE id_reserva = ?";
//        
//        try {
//            pst = conn.prepareCall(slq);
//            pst.setInt(1, idreserva);
//            pst.execute();
//            pst.close();
//            pasoMod = true;
//        } catch (SQLException e) {
//            System.out.println(e.getMessage());
//        }
//        return pasoMod;
//    }
}
