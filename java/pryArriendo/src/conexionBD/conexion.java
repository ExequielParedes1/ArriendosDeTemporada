/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package conexionBD;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import javax.swing.JOptionPane;

/**
 *
 * @author Favio
 */
public class conexion {
    
    private static Connection conn;// = null;
    private static String login = "favio";
    private static String pass = "duoc";
    private static String url = "jdbc:oracle:thin:@localhost:1521:XE";
    
  
    public static Connection getConnection() {
    try {
        Class.forName("oracle.jdbc.driver.OracleDriver");
        conn = DriverManager.getConnection(url,login,pass);
        conn.setAutoCommit(false);
        if (conn != null) {
            System.out.println("Conexion Exitosa");
        }else{
            System.out.println("Conexion Erronea");
        }
    }catch (ClassNotFoundException | SQLException ex) {
        JOptionPane.showMessageDialog(null, ex.getMessage());
    }
    return conn;
    }
    
    //para metodos nuevo
    
    public Connection conexion;
    public Statement sentencia;
    public ResultSet resultado;
    
    public void ConectarBasedeDatos() {
        try {
            final String Controlador = "oracle.jdbc.driver.OracleDriver";
            Class.forName(Controlador);
            final String url_bd = "jdbc:oracle:thin:@localhost:1521:XE";
            conexion = DriverManager.getConnection(url_bd, "favio", "duoc");
            sentencia = conexion.createStatement();
        } catch (ClassNotFoundException | SQLException ex) {
            JOptionPane.showMessageDialog(null, ex.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
        }
    }
    
    public Connection getConnection4() {
        return conexion;
    }
}
