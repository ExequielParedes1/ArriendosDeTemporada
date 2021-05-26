package ClasesDTO;

import ClasesDAO.UsuarioDAO;
import ClasesEntity.usuario;
import conexionBD.conexion;
import java.sql.Connection;
import java.sql.SQLException;
import javax.swing.JOptionPane;
import javax.swing.JTable;

public class UsuarioDTO {
    
    private String mensaje = "";
    private UsuarioDAO userdao = new UsuarioDAO();
    private boolean paso;
    
    public boolean ingresarUsuario(usuario user) {
        paso = false;
        Connection conn = conexion.getConnection();
        try {
            paso = userdao.ingresarUsuario(conn, user);
        } catch (Exception e) {
            JOptionPane.showMessageDialog(null, e);
        }finally{
            try {
                if (conn != null) {
                    conn.close();
                }
            } catch (Exception e) {
                JOptionPane.showMessageDialog(null, e);
            }
        }
        return paso;
    }
    
 
    
    public boolean inhabilitarUsuario(String id) {
        paso = false;
        Connection conn = conexion.getConnection();
        try {
            paso = userdao.inhabilitarUsuario(conn, id);
            //conn.rollback();
        } catch (Exception e) {
            mensaje = mensaje + " " + e.getMessage();
        }finally{
            try {
                if (conn != null) {
                    conn.close();
                }
            } catch (Exception e) {
                mensaje = mensaje + " " + e.getMessage();
            }
        }
        return paso;
    }
    
    public boolean modificarUsuario(usuario user) {
        paso = false;
        Connection conn = conexion.getConnection();
        try {
            paso = userdao.modificarUsuario(conn, user);
            //conn.rollback();
        } catch (Exception e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }finally{
            try {
                if (conn != null) {
                    conn.close();
                }
            } catch (SQLException e) {
                JOptionPane.showMessageDialog(null, e.getMessage());
            }
        }
        return paso;
    }
    
    public void listarUsuario(JTable tabla) {
        Connection conn = conexion.getConnection();
        userdao.listarUsuario(conn, tabla);
        try {
            conn.close();
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
    }
    private String Rut;
    private String pass;
    private String rol;
    private String nombre;
    private String appaterno ;
    private String apmaterno;
    private String estado;
    private String email;

    public UsuarioDTO() {
    }

    public UsuarioDTO(boolean paso, String Rut, String pass, String rol, String nombre, String appaterno, String apmaterno, String email,String estado ) {
        this.paso = paso;
        this.Rut = Rut;
        this.pass = pass;
        this.rol = rol;
        this.nombre = nombre;
        this.appaterno = appaterno;
        this.apmaterno = apmaterno;
        this.estado=estado;
        this.email = email;
    }

    public String getMensaje() {
        return mensaje;
    }

    public void setMensaje(String mensaje) {
        this.mensaje = mensaje;
    }

    public UsuarioDAO getUserdao() {
        return userdao;
    }

    public void setUserdao(UsuarioDAO userdao) {
        this.userdao = userdao;
    }

    public boolean isPaso() {
        return paso;
    }

    public void setPaso(boolean paso) {
        this.paso = paso;
    }

    public String getRut() {
        return Rut;
    }

    public void setRut(String Rut) {
        this.Rut = Rut;
    }

    public String getPass() {
        return pass;
    }

    public void setPass(String pass) {
        this.pass = pass;
    }

    public String getRol() {
        return rol;
    }

    public void setRol(String rol) {
        this.rol = rol;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getAppaterno() {
        return appaterno;
    }

    public void setAppaterno(String appaterno) {
        this.appaterno = appaterno;
    }

    public String getApmaterno() {
        return apmaterno;
    }

    public void setApmaterno(String apmaterno) {
        this.apmaterno = apmaterno;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getEstado() {
        return estado;
    }

    public void setEstado(String estado) {
        this.estado = estado;
    }

    @Override
    public String toString() {
        return "UsuarioDTO{" + "mensaje=" + mensaje + ", userdao=" + userdao + ", paso=" + paso + ", Rut=" + Rut + ", pass=" + pass + ", rol=" + rol + ", nombre=" + nombre + ", appaterno=" + appaterno + ", apmaterno=" + apmaterno + ", estado=" + estado + ", email=" + email + '}';
    }
    
    

   

    
   

    
     
}