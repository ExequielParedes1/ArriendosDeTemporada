/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package vistas;

import ClasesDTO.ChequeoDTO;
import ClasesDTO.RevisionDTO;
import ClasesEntity.revision;
import conexionBD.conectar;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Timer;
import java.util.TimerTask;
import javax.swing.JOptionPane;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableColumn;

/**
 *
 * @author Favio
 */
public class vistaReviDeptoOut extends javax.swing.JFrame {
    conectar cc = new conectar();    
    Connection cn = cc.conexion();
    private RevisionDTO reviDTO = new RevisionDTO();
    private ChequeoDTO checkDTO = new ChequeoDTO();
    /**
     * Creates new form vistaReviDeptoOut
     */
    public vistaReviDeptoOut() {
        initComponents();
        this.setResizable(false);
        this.setLocationRelativeTo(null);
        listarRevisiones();
        //String  rutfunci =txtRutFuncionarioRevisi.getText();
        tomareserva.setVisible(false);
        //checkEstado();
        Timer tiempo = new Timer();
        TimerTask tarea = new TimerTask() {
            @Override
            public void run() {
                CargarRevisionOut();
            }
        };
        tiempo.schedule(tarea, 1000);
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        tomareserva = new javax.swing.JLabel();
        jTabbedPane1 = new javax.swing.JTabbedPane();
        jPanel1 = new javax.swing.JPanel();
        jLabel1 = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        tablarevisionOUT = new javax.swing.JTable();
        btnCierraVentana = new javax.swing.JButton();
        btnIngresaProblemas = new javax.swing.JButton();
        btnRealizaRevision = new javax.swing.JButton();
        jPanel2 = new javax.swing.JPanel();
        btnCierraVentana2 = new javax.swing.JButton();
        jLabel2 = new javax.swing.JLabel();
        jLabel3 = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        txtRutFuncionarioRevisi = new javax.swing.JTextField();
        txtFechaRevision = new com.toedter.calendar.JDateChooser();
        txtiddeptoRevisi = new javax.swing.JTextField();
        btnIngresaRevi = new javax.swing.JButton();
        jScrollPane2 = new javax.swing.JScrollPane();
        tablaRevisiones = new javax.swing.JTable();
        jLabel5 = new javax.swing.JLabel();
        recuperaidcheckin = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setPreferredSize(new java.awt.Dimension(1148, 718));

        jTabbedPane1.setPreferredSize(new java.awt.Dimension(1148, 718));

        jLabel1.setFont(new java.awt.Font("Dialog", 1, 18)); // NOI18N
        jLabel1.setText("LISTA DE CHEQUEO");

        tablarevisionOUT.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {},
                {},
                {},
                {}
            },
            new String [] {

            }
        ));
        tablarevisionOUT.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                tablarevisionOUTMouseClicked(evt);
            }
        });
        jScrollPane1.setViewportView(tablarevisionOUT);

        btnCierraVentana.setText("CERRAR VENTANA");
        btnCierraVentana.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnCierraVentanaActionPerformed(evt);
            }
        });

        btnIngresaProblemas.setText("INGRESAR DAÑOS");

        btnRealizaRevision.setText("REALIZAR REVISION");
        btnRealizaRevision.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnRealizaRevisionActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGap(175, 175, 175)
                        .addComponent(btnCierraVentana)
                        .addGap(160, 160, 160)
                        .addComponent(btnIngresaProblemas)
                        .addGap(141, 141, 141)
                        .addComponent(btnRealizaRevision))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGap(56, 56, 56)
                        .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 998, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addGap(468, 468, 468)
                        .addComponent(jLabel1)))
                .addContainerGap(736, Short.MAX_VALUE))
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addContainerGap(99, Short.MAX_VALUE)
                .addComponent(jLabel1)
                .addGap(44, 44, 44)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 415, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(68, 68, 68)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btnCierraVentana)
                    .addComponent(btnIngresaProblemas)
                    .addComponent(btnRealizaRevision))
                .addGap(46, 46, 46))
        );

        jTabbedPane1.addTab("Listado de chequeo", jPanel1);

        btnCierraVentana2.setText("CERRAR VENTANA");
        btnCierraVentana2.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnCierraVentana2ActionPerformed(evt);
            }
        });

        jLabel2.setText("FECHA REVISION");

        jLabel3.setText("ID. DEPARTAMENTO");

        jLabel4.setText("RUT FUNCIONARIO");

        txtRutFuncionarioRevisi.setEditable(false);

        txtiddeptoRevisi.setEditable(false);

        btnIngresaRevi.setText("INGRESAR REVISION");
        btnIngresaRevi.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnIngresaReviActionPerformed(evt);
            }
        });

        tablaRevisiones.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            },
            new String [] {
                "Title 1", "Title 2", "Title 3", "Title 4"
            }
        ));
        jScrollPane2.setViewportView(tablaRevisiones);

        jLabel5.setFont(new java.awt.Font("Dialog", 1, 14)); // NOI18N
        jLabel5.setText("REGISTRO DE REVISION DE DEPARTAMENTO");

        javax.swing.GroupLayout jPanel2Layout = new javax.swing.GroupLayout(jPanel2);
        jPanel2.setLayout(jPanel2Layout);
        jPanel2Layout.setHorizontalGroup(
            jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel2Layout.createSequentialGroup()
                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel2Layout.createSequentialGroup()
                        .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(jPanel2Layout.createSequentialGroup()
                                .addGap(67, 67, 67)
                                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addGroup(jPanel2Layout.createSequentialGroup()
                                        .addGap(125, 125, 125)
                                        .addComponent(btnIngresaRevi))
                                    .addGroup(jPanel2Layout.createSequentialGroup()
                                        .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                            .addComponent(jLabel3)
                                            .addComponent(jLabel2)
                                            .addComponent(jLabel4))
                                        .addGap(55, 55, 55)
                                        .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                                            .addComponent(txtFechaRevision, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                            .addComponent(txtRutFuncionarioRevisi)
                                            .addComponent(txtiddeptoRevisi, javax.swing.GroupLayout.PREFERRED_SIZE, 153, javax.swing.GroupLayout.PREFERRED_SIZE)))))
                            .addGroup(jPanel2Layout.createSequentialGroup()
                                .addGap(112, 112, 112)
                                .addComponent(jLabel5)))
                        .addGap(173, 173, 173)
                        .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(jPanel2Layout.createSequentialGroup()
                        .addGap(476, 476, 476)
                        .addComponent(btnCierraVentana2))
                    .addGroup(jPanel2Layout.createSequentialGroup()
                        .addGap(101, 101, 101)
                        .addComponent(recuperaidcheckin)))
                .addContainerGap(745, Short.MAX_VALUE))
        );
        jPanel2Layout.setVerticalGroup(
            jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanel2Layout.createSequentialGroup()
                .addGap(63, 63, 63)
                .addComponent(recuperaidcheckin)
                .addGap(53, 53, 53)
                .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel2Layout.createSequentialGroup()
                        .addComponent(jLabel5)
                        .addGap(90, 90, 90)
                        .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(jLabel4)
                            .addComponent(txtRutFuncionarioRevisi, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(18, 18, 18)
                        .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel2, javax.swing.GroupLayout.PREFERRED_SIZE, 24, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(txtFechaRevision, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(28, 28, 28)
                        .addGroup(jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(jLabel3)
                            .addComponent(txtiddeptoRevisi, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(52, 52, 52)
                        .addComponent(btnIngresaRevi))
                    .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 367, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 128, Short.MAX_VALUE)
                .addComponent(btnCierraVentana2)
                .addGap(49, 49, 49))
        );

        jTabbedPane1.addTab("Ingresar Revision", jPanel2);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addComponent(jTabbedPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 1792, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(tomareserva)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(106, 106, 106)
                .addComponent(tomareserva)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
            .addGroup(layout.createSequentialGroup()
                .addComponent(jTabbedPane1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void btnCierraVentanaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnCierraVentanaActionPerformed
        this.setVisible(false);
    }//GEN-LAST:event_btnCierraVentanaActionPerformed

    private void btnCierraVentana2ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnCierraVentana2ActionPerformed
        this.setVisible(false);
    }//GEN-LAST:event_btnCierraVentana2ActionPerformed

    private void tablarevisionOUTMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_tablarevisionOUTMouseClicked
        int selecciona_de = tablarevisionOUT.rowAtPoint(evt.getPoint());
        txtiddeptoRevisi.setText(tablarevisionOUT.getValueAt(selecciona_de, 5)+"");
    }//GEN-LAST:event_tablarevisionOUTMouseClicked

    private void btnRealizaRevisionActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnRealizaRevisionActionPerformed
        jTabbedPane1.setSelectedIndex(1);
    }//GEN-LAST:event_btnRealizaRevisionActionPerformed

    private void btnIngresaReviActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnIngresaReviActionPerformed
        revision revi = new revision();
        boolean ingreRevi = false;
        java.sql.Date fecharevision = new java.sql.Date(txtFechaRevision.getDate().getTime());
        if (txtFechaRevision.getDate()==null) {
            JOptionPane.showMessageDialog(null, "Ingrese una fecha para la revision");  
        }else{
            try{
                 
                 revi.setRut_usuario(txtRutFuncionarioRevisi.getText());
                 revi.setFecha_revision(fecharevision);
                 revi.setId_depto(Integer.parseInt(txtiddeptoRevisi.getText()));
                 
                 ingreRevi = reviDTO.ingresarRevision(revi);
                 
            }catch(Exception  e){
                JOptionPane.showMessageDialog(null, "Por favor realize registro de revision de depto");
                System.out.println(e);
                
            }     
        }
        
        if (ingreRevi==true) {
            JOptionPane.showMessageDialog(null, "Revision ingresada con éxito");
            checkDTO.cambiarEstadoaRevisado(Integer.parseInt(recuperaidcheckin.getText()));
            limpiaTabla(tablaRevisiones);
            listarRevisiones();
        }
    }//GEN-LAST:event_btnIngresaReviActionPerformed

    /**
     * @param args the command line arguments
     */
        //limpia tablas
     public void limpiaTabla(JTable tabla) {
        DefaultTableModel dm = (DefaultTableModel) tabla.getModel();
        dm.setRowCount(0);
    }
     
     //listar en tablas de la vista
     public void listarRevisiones() {
        reviDTO.listarRevision(tablaRevisiones);
    }
    
    void CargarRevisionOut() {
        //tomareserva.setVisible(false);
        DefaultTableModel modelo = new DefaultTableModel();
        String[] Titulos = {"ID INVENTARIO", "ARTICULO", "TIPO ARTICULO", "VALOR","DPTO","ID.DEPTO","ESTADO","SELECCION"};
        modelo.setColumnIdentifiers(Titulos);
        this.tablarevisionOUT.setModel(modelo);

        try {
              //System.out.println(testiddepto);
              //int iddepto= (Integer.parseInt(test.getValue().toString()));
              String  reserva =tomareserva.getText();
             // System.out.println(depto);
//            String ConsultaSQL = "SELECT i.id_inv,i.nombre_arti, i.tipo_arti, i.valor_arti,d.num_depto,i.estado_inventario FROM inventario i join dpto d on i.dpto_id_dpto=d.id_dpto where i.dpto_id_dpto=" + reserva + "";
            String ConsultaSQL = "select i.id_inv,i.nombre_arti, i.tipo_arti, i.valor_arti,d.num_depto,i.dpto_id_dpto,i.estado_inventario from inventario i join dpto d on i.dpto_id_dpto=d.id_dpto join reserva_depto rd on rd.dpto_id_dpto=d.id_dpto WHERE rd.reserva_id_reserva=" + reserva +"";
           // System.out.println(ConsultaSQL);
            String[] registros = new String[7];
                
            Statement st = cn.createStatement();
            ResultSet rs = st.executeQuery(ConsultaSQL);
            while (rs.next()) {
                registros[0] = rs.getString("id_inv");
                registros[1] = rs.getString("nombre_arti");
                registros[2] = rs.getString("tipo_arti");
                registros[3] = rs.getString("valor_arti");
                registros[4] = rs.getString("num_depto");
                registros[5] = rs.getString("dpto_id_dpto");
                registros[6] = rs.getString("estado_inventario");
                modelo.addRow(registros);

            }
            tablarevisionOUT.setModel(modelo);
            addCheckBox(7, tablarevisionOUT);

        } catch (SQLException ex) {
            JOptionPane.showMessageDialog(null, ex);
            System.out.println("problema carga inventario Reserva para revision out");
        }

    }
    
    public void addCheckBox(int columna, JTable tabla) {
        TableColumn tc = tabla.getColumnModel().getColumn(columna);
        tc.setCellEditor(tabla.getDefaultEditor(Boolean.class));
        tc.setCellRenderer(tabla.getDefaultRenderer(Boolean.class));
    }
    
//     public void checkEstado() {
//        for (int i = 0; i < tablarevisionOUT.getRowCount(); i++) {
//            tablarevisionOUT.setValueAt(Boolean.FALSE, i, 6);
//        }
//    }
    
    public String isSelected(int row, int column, JTable tabla) {
        return tabla.getValueAt(row, column).toString();
    }
    
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(vistaReviDeptoOut.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(vistaReviDeptoOut.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(vistaReviDeptoOut.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(vistaReviDeptoOut.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new vistaReviDeptoOut().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnCierraVentana;
    private javax.swing.JButton btnCierraVentana2;
    private javax.swing.JButton btnIngresaProblemas;
    private javax.swing.JButton btnIngresaRevi;
    private javax.swing.JButton btnRealizaRevision;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JPanel jPanel2;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JTabbedPane jTabbedPane1;
    public static javax.swing.JLabel recuperaidcheckin;
    private javax.swing.JTable tablaRevisiones;
    private javax.swing.JTable tablarevisionOUT;
    public static javax.swing.JLabel tomareserva;
    private com.toedter.calendar.JDateChooser txtFechaRevision;
    public static javax.swing.JTextField txtRutFuncionarioRevisi;
    private javax.swing.JTextField txtiddeptoRevisi;
    // End of variables declaration//GEN-END:variables
}
