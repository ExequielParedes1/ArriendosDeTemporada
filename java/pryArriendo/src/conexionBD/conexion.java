/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package conexionBD;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
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
}
