/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDAO;

import ClasesEntity.departamento;
import ClasesEntity.inventario;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import javax.swing.JOptionPane;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;

/**
 *
 * @author Favio
 */
public class InventarioDAO {
    
    
    private boolean paso;
    
    public boolean ingresarInventario(Connection con, inventario inv) {
        paso = false;
            String sql = "{call insert_inventario (?,?,?,?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setString(1, inv.getNombre_articulo());
            pst.setString(2, inv.getTipo_articulo());
            pst.setInt(3, inv.getValor_articulo());
            pst.setInt(4, inv.getDepto());
            pst.execute();
            pst.close();
            paso = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }
        return paso;
    }
    
    
     public void listarInventario(Connection con, JTable tabla) {
        DefaultTableModel model;
        String [] columnas = {"ID", "Articulo", "Tipo Articulo", "Valor", "ID DEPTO"};
        model = new DefaultTableModel(null, columnas);
        
        String sql = "Select * from inventario";
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
     
     public boolean eliminarInventario(Connection con, int id) {
        boolean pasoEliminar = false;
        String sql = "{call delete_inventario (?)}";
        
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
     
    
    public ArrayList<departamento> listDpto(Connection conn) {
        ArrayList<departamento> Adep = new ArrayList<>();
        
        String sql = "select id_dpto, num_depto from dpto";
        
        try {
            Statement st = conn.createStatement();
            ResultSet rs = st.executeQuery(sql);
            while (rs.next()) {                
                departamento dep = new departamento();
                dep.setId_depto(rs.getInt(1));
                dep.setNum_depto(rs.getString(2));
                Adep.add(dep);
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        
        return Adep;
    }
}
