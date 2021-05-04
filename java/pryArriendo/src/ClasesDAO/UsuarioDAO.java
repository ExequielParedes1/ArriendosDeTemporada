package ClasesDAO;

import ClasesDTO.UsuarioDTO;
import ClasesEntity.usuario;
import conexionBD.conexion;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.PreparedStatement;
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
public class UsuarioDAO {
    PreparedStatement pst = null;
    ResultSet rst;
    conexion c = new conexion();
    Connection con ;
    
    private boolean paso;
    
    public boolean ingresarUsuario(Connection con, usuario user) {
        paso = false;
        String sql = "{call insert_usuario (?,?,?,?,?,?,?,?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setString(1, user.getRut_usuario());
            pst.setString(2, user.getContrasenia());
            pst.setString(3, user.getRol());
            pst.setString(4, user.getNombre_usuario());
            pst.setString(5, user.getApellido_p());
            pst.setString(6, user.getApellido_m());
            pst.setString(7, user.getEstado_usuario());
            pst.setString(8, user.getEmail());
            pst.execute();
            pst.close();
            paso = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
            
        }
        return paso;
    }
    
    public boolean modificarUsuario(Connection con, usuario user) {
        boolean pasoModi = false;
        String sql = "call update_usuario (?,?,?,?,?,?,?)";
        
//                    System.out.println(user.getRut_usuario());
//                   System.out.println(user.getRol());
//                   System.out.println(user.getNombre_usuario());
//                   System.out.println(user.getApellido_p());
//                   System.out.println(user.getApellido_m());
//                   System.out.println(user.getEstado_usuario());
//                   System.out.println(user.getEmail());
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setString(1, user.getRut_usuario());
            pst.setString(2, user.getRol());
            pst.setString(3, user.getNombre_usuario());
            pst.setString(4, user.getApellido_p());
            pst.setString(5, user.getApellido_m());
            pst.setString(6, user.getEstado_usuario());
            pst.setString(7, user.getEmail());
            pst.execute();
            pst.close();
            pasoModi = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }
        return pasoModi;
    }
    
    public boolean inhabilitarUsuario(Connection con, String id) {
        boolean pasoEli = false;
        String sql = "{call inhabilitar_usuario (?)}";
        
        try {
            CallableStatement pst = con.prepareCall(sql);
            pst.setString(1, id);
            pst.execute();
            pst.close();
            pasoEli = true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e);
        }
        return pasoEli;
    }
    
    
    public void listarUsuario(Connection con, JTable tabla) {
        DefaultTableModel model;
        String [] columnas = {"RUT", "Rol", "Nombre", "Apellido Paterno", "Apellido Materno", "Estado", "Email"};
        model = new DefaultTableModel(null, columnas);
        
        String sql = "Select rut_usuario, rol, nombre_usuario, apellido_p, apellido_m, estado_usuario, email from usuario";
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
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
    
     public String Login(String usr, String pass){
        ArrayList<UsuarioDTO>usuarios = new ArrayList<>();  
        String sql = "Select * from usuario";
        String validado = "";
        
        try {
            con=c.getConnection();
            pst=con.prepareStatement(sql);
            rst = pst.executeQuery();
            
            while (rst.next()) {                
                UsuarioDTO usuario= new UsuarioDTO();
                usuario.setRut(rst.getString(1));
                usuario.setPass(rst.getString(2));
                usuario.setRol(rst.getString(3));
                usuario.setNombre(rst.getString(4));
                usuario.setAppaterno(rst.getString(5));
                usuario.setApmaterno(rst.getString(6));
                usuario.setEmail(rst.getString(7));
                usuarios.add(usuario);
            }
            
            for (int i = 0 ; i < usuarios.size(); i++) {
                if(usr.equals(usuarios.get(i).getRut())&&pass.equals(usuarios.get(i).getPass())){
                    validado = usuarios.get(i).getRol();
                    
                }
            }
        } catch (Exception e) {
            System.out.println(e);
        }
        return validado;
    }
}