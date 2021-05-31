/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDAO;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;

/**
 *
 * @author Favio
 */
public class ReservaDAO {
    
    
    public void listarReserva(Connection con, JTable tabla) {
        DefaultTableModel model;
        String [] columnas = {"ID Reserva", "F.Inicio","F.Fin", "Estado","ID Cliente","RUT Cliente"};
        model = new DefaultTableModel(null, columnas);
        
        String sql = "Select r.id_reserva,r.fecha_inicio,r.fecha_fin,r.estado,r.cliente_id_cliente,c.rut_cliente from reserva r join cliente c on r.cliente_id_cliente=c.id_cliente where estado='FINALIZADO'";
        
        String[] filas = new String[6];
        
        try {
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery(sql);
            while (rs.next()) {
                for(int i = 0; i < 6; i++) {
                    filas[i] = rs.getString(i+1);
                }
                model.addRow(filas);
            }
            tabla.setModel(model);
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
    }
    
    public boolean cambiarEstadoReserva(Connection conn,int idreserva) {
        boolean pasoMod = false;
        CallableStatement pst;
        String slq  = "UPDATE reserva SET estado = 'FINALIZADO' WHERE id_reserva = ?";
        
        try {
            pst = conn.prepareCall(slq);
            pst.setInt(1, idreserva);
            pst.execute();
            pst.close();
            pasoMod = true;
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return pasoMod;
    }
}
