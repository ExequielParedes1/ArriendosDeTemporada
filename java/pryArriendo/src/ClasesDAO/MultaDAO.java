/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDAO;

import ClasesEntity.multa;
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
public class MultaDAO {
    public boolean ingresarMulta(Connection con, multa mu) {
        boolean pasoInsert = false;
        String sql = "{call insert_multa(?,?,?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setString(1, mu.getDescripcion());
            pst.setInt(2, mu.getMonto());
            pst.setInt(3, mu.getId_reserva());
            pst.execute();
            pst.close();
            pasoInsert = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }
        return pasoInsert;
    }
    
    public void listarMulta(Connection con, JTable tabla) {
        DefaultTableModel model;
        String [] columnas = {"ID multa", "Descripcion", "monto","ID Reserva"};
        model = new DefaultTableModel(null, columnas);
        
        String sql = "Select * from multa";
        
        String[] filas = new String[4];
        
        try {
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery(sql);
            while (rs.next()) {
                for(int i = 0; i < 4; i++) {
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
