/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ClasesDAO;

import ClasesEntity.cliente;
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
public class ClienteDAO {
    
    private boolean validado;
    
    public boolean ingresarCliente(Connection conn, cliente cli) {
        validado = false;
        String sql = "{call insert_cliente(?,?,?,?,?,?,?,?,?,?,?)}";
        
        try {
            CallableStatement pst = conn.prepareCall(sql);
            pst.setString(1, cli.getRut_cliente());
            pst.setString(2, cli.getPasaporte());
            pst.setString(3, cli.getPasswrd());
            pst.setString(4, cli.getNombre());
            pst.setString(5, cli.getAppaterno());
            pst.setString(6, cli.getApmaterno());
            pst.setInt(7, cli.getNum_celular());
            pst.setString(8, cli.getCorreo());
            pst.setString(9, cli.getNacionalidad());
            pst.setString(10, Character.toString(cli.getCliente_frecuente()));
            pst.setString(11, cli.getEstado_cliente());
            pst.execute();
            pst.close();
            validado = true;
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
//            System.out.println(cli.getRut_cliente());
//            System.out.println(cli.getPasaporte());
//            System.out.println(cli.getRut_cliente());
//            System.out.println(cli.getPasswrd());
//            System.out.println(cli.getNombre());
//            System.out.println(cli.getAppaterno());
//            System.out.println(cli.getApmaterno());
//            System.out.println(cli.getNum_celular());
//            System.out.println(cli.getCorreo());
//            System.out.println(cli.getNacionalidad());
//            System.out.println(Character.toString(cli.getCliente_frecuente()));
//            System.out.println(cli.getEstado_cliente());
        return validado;
    }
    
//    public boolean eliminarCliente(Connection con, int id) {
//        boolean pasaEliminacion = false;
//        String sql = "{call delete_cliente (?)}";
//        
//        try {
//            CallableStatement pst = con.prepareCall(sql);
//            pst.setInt(1, id);
//            pst.execute();
//            pst.close();
//            pasaEliminacion = true;
//        } catch (SQLException e) {
//            JOptionPane.showMessageDialog(null, e);
//        }
//        return pasaEliminacion;
//    }
    
    public boolean DesabilitarCliente(Connection con, int id) {
        boolean pasoDesabilitar = false;
        String sql = "{call inhabilitar_cliente (?)}";
        
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
    
    public boolean modificarCliente(Connection con, cliente cli) {
        boolean pasoModi = false;
        String sql = "{call update_cliente(?,?,?,?,?,?,?,?,?,?,?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setInt(1, cli.getId_cliente());
            pst.setString(2, cli.getRut_cliente());
            pst.setString(3, cli.getPasaporte());
            pst.setString(4, cli.getNombre());
            pst.setString(5, cli.getAppaterno());
            pst.setString(6, cli.getApmaterno());
            pst.setInt(7, cli.getNum_celular());
            pst.setString(8, cli.getCorreo());
            pst.setString(9, cli.getNacionalidad());
            pst.setString(10, Character.toString(cli.getCliente_frecuente()));
            pst.setString(11, cli.getEstado_cliente());
            pst.execute();
            pst.close();
            pasoModi = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }
        return pasoModi;
    }
    
    public void listarClientes(Connection conn, JTable tabla) {
        DefaultTableModel model;
        String [] columnas = {"ID","RUT", "Pasaporte", "Nombre", "A.Paterno", "A.Materno", "Celular", "Correo", "Nacionalidad", "Clte.Frecuente", "Estado" };
        model = new DefaultTableModel(null, columnas);
        
        String sql = "select id_cliente, rut_cliente, pasaporte, nombre, apellido_p, apellido_m, num_celular, correo, nacionalidad,cliente_frecuente, estado_cliente  from cliente";
        String[] filas = new String[11];
        
        try {
            Statement st = conn.createStatement();
            ResultSet rs = st.executeQuery(sql);
            while (rs.next()) {                
                for (int i = 0; i < 11; i++) {
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
