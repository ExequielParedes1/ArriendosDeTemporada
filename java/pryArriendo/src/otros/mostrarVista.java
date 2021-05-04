package otros;

import javax.swing.JOptionPane;
import vistas.*;

public class mostrarVista {
    
   private final vistas.vistaAdministrador vg = new vistaAdministrador();
   private final vistas.vistaFuncionario vf = new vistaFuncionario();

    
    public void mostrarVistas(String rol) {
        if (rol.equals("ADMINISTRADOR")) {
            vg.setVisible(true);
        }else if (rol.equals("FUNCIONARIO")) {
            vf.setVisible(true);
        }else {
            JOptionPane.showMessageDialog(null, "Usuario no encontrado");
        }
        
       
    }
}
