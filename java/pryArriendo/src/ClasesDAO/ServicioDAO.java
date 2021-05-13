/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDAO;

import ClasesEntity.servicio;
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
public class ServicioDAO {
    
    public boolean ingresarServicio(Connection con, servicio serv) {
        boolean pasoInsert = false;
        String sql = "{call insert_servicio(?,?,?,?,?,?,?,?,?,?,?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setString(1, serv.getNombre());
            pst.setString(2, serv.getTipo());
            pst.setDate(3, serv.getHora_ini());
            pst.setDate(4, serv.getHora_fin());
            pst.setString(5, serv.getPunto_reunion());
            pst.setInt(6, serv.getValor());
            pst.setString(7, serv.getRecorrido());
            pst.setString(8, serv.getVehiculo());
            pst.setString(9, serv.getChofer());
            pst.setString(10,serv.getEstado_servicio());
            pst.setInt(11, serv.getCupos());
            pst.execute();
            pst.close();
            pasoInsert = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }

//            System.out.println(to.getRecorrido());
//            System.out.println(to.getPunto_reunion());
//            System.out.println(to.getHorario_salida());
//            System.out.println(to.getHorario_llegada());
//            System.out.println(to.getValor());


        return pasoInsert;
    }
    
    
    public boolean modificarServicio(Connection con, servicio serv) {
        boolean pasoModi = false;
        String sql = "{call update_servicio(?,?,?,?,?,?,?,?,?,?,?,?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setInt(1, serv.getId_servicio());
            pst.setString(2, serv.getNombre());
            pst.setString(3, serv.getTipo());
            pst.setDate(4, serv.getHora_ini());
            pst.setDate(5, serv.getHora_fin());
            pst.setString(6, serv.getPunto_reunion());
            pst.setInt(7, serv.getValor());
            pst.setString(8, serv.getRecorrido());
            pst.setString(9, serv.getVehiculo());
            pst.setString(10, serv.getChofer());
            pst.setString(11, serv.getEstado_servicio());
            pst.setInt(12, serv.getCupos());
            
            
            pst.execute();
            pst.close();
            pasoModi = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }

            
        return pasoModi;
    }
    
//    public boolean eliminarServicio(Connection con, int id) {
//        boolean pasoEliminar = false;
//        String sql = "{call delete_servicio (?)}";
//        
//        try {
//            CallableStatement pst = con.prepareCall(sql);
//            pst.setInt(1, id);
//            pst.execute();
//            pst.close();
//            pasoEliminar = true;
//        } catch (SQLException e) {
//            JOptionPane.showMessageDialog(null, e);
//        }
//        return pasoEliminar;
//    }
    
    public boolean inhabilitarServicio(Connection con, int id) {
        boolean pasoEli = false;
        String sql = "{call inhabilitar_servicio (?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setInt(1, id);
            pst.execute();
            pst.close();
            pasoEli = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }
        return pasoEli;
    }
    
    public void listarServicio(Connection con, JTable tabla) {
        DefaultTableModel model;
        String [] columnas = {"ID Serv.", "Nombre", "Tipo", "Inicio", "Fin", "Punto Reunion","Valor","Recorrido","Vehiculo","Chofer","Estado","Cupos"};
        model = new DefaultTableModel(null, columnas);
        
        String sql = "Select * from servicio";
        
        String[] filas = new String[12];
        
        try {
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery(sql);
            while (rs.next()) {
                for(int i = 0; i < 12; i++) {
                    filas[i] = rs.getString(i+1);
                }
                model.addRow(filas);
            }
            tabla.setModel(model);
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
    }
}
