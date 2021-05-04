/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDAO;

import ClasesEntity.departamento;
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
public class DepartamentoDAO {
 
    public boolean ingresarDepto(Connection con, departamento dep) {
        boolean pasoInsert = false;
        String sql = "{call insert_dpto(?,?,?,?,?,?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
          //pst.setInt(1, dep.getNum_depto());
            pst.setString(1, dep.getNum_depto());
            pst.setString(2, dep.getDireccion());
            pst.setString(3, dep.getDescripcion());
            pst.setString(4, dep.getRegion());
            pst.setString(5, dep.getEstado());
            pst.setInt(6, dep.getValor_diario());
            pst.execute();
            pst.close();
            pasoInsert = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }
        return pasoInsert;
    }
    
    
    public boolean modificarDepto(Connection con, departamento dep) {
        boolean pasoModi = false;
        String sql = "{call update_dpto(?,?,?,?,?,?,?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setInt(1, dep.getId_depto());
            pst.setString(2, dep.getNum_depto());
            pst.setString(3, dep.getDireccion());
            pst.setString(4, dep.getDescripcion());
            pst.setString(5, dep.getRegion());
            pst.setString(6, dep.getEstado());
            pst.setInt(7, dep.getValor_diario());
            pst.execute();
            pst.close();
            pasoModi = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }
//            System.out.println(dep.getId_depto());
//            System.out.println(dep.getNum_depto());
//            System.out.println(dep.getDireccion());
//            System.out.println(dep.getDescripcion());
//            System.out.println(dep.getRegion());
//            System.out.println(dep.getEstado());
            
        return pasoModi;
    }
    
    public boolean inhabilitarDepto(Connection con, int id) {
        boolean pasoEliminar = false;
        String sql = "{call inhabilitar_dpto (?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setInt(1, id);
            pst.execute();
            pst.close();
            pasoEliminar = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }
        return pasoEliminar;
    }
    
    public void listarDepto(Connection con, JTable tabla) {
        DefaultTableModel model;
        String [] columnas = {"ID", "N° Depto", "Direccion", "descripcion", "Region", "Estado","Valor Diario"};
        model = new DefaultTableModel(null, columnas);
        
        String sql = "Select * from dpto";
        
        String[] filas = new String[7];
        
        try {
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery(sql);
            while (rs.next()) {
                for(int i = 0; i < 7; i++) {
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
