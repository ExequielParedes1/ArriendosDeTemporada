/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDAO;

import ClasesEntity.revision;
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
public class RevisionDAO {
    
    
    public boolean ingresarRevision(Connection con, revision rev) {
        boolean pasoInsert = false;
        String sql = "{call insert_revision(?,?,?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setString(1, rev.getRut_usuario());
            pst.setDate(2, rev.getFecha_revision());
            pst.setInt(3, rev.getId_depto());
            pst.execute();
            pst.close();
            pasoInsert = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }
        return pasoInsert;
    }
    
    public void listarRevision(Connection con, JTable tabla) {
        DefaultTableModel model;
        String [] columnas = {"ID REVISION", "RUT FUNCIONARIO", "FECHA REVISION", "ID.DEPTO"};
        model = new DefaultTableModel(null, columnas);
        
        String sql = "Select id_revision,usuario_rut_usuario,fecha_revision,dpto_id_dpto from revision_inv";
        
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
