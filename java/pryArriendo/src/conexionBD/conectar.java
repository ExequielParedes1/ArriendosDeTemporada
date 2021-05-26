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
public class conectar {
    
    Connection conect = null;
    private static String user = "favio";
    private static String pass = "duoc";
    private static String url = "jdbc:oracle:thin:@localhost:1521:XE";
    public Connection conexion() {
        try {
            Class.forName("oracle.jdbc.driver.OracleDriver");
            conect = DriverManager.getConnection(url, user, pass); //DRIVER 
            conect.setAutoCommit(false);
            if (conect != null) {
                System.out.println("EXITO conexión base datos");
            } else {
                System.out.println("ERROR conexión base datos ");
            }
        } catch (ClassNotFoundException | SQLException e) {
            JOptionPane.showMessageDialog(null, "Conexión Fallida" + e.getMessage());
        }
        return conect;

    }
}
