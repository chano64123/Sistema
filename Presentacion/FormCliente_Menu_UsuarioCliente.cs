﻿using Entidad;
using Microsoft.Win32;
using Negocios;
using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace Presentacion {
    public partial class FormCliente_Menu_UsuarioCliente : Form {
        public FormCliente_Menu_UsuarioCliente() {
            InitializeComponent();
        }
        readonly public static string dni;
        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Hide();
        }

        private void btnSalirLogin_Click(object sender, EventArgs e) {
            this.Hide();
            FormCliente_Configuraciones frm = new FormCliente_Configuraciones();
            frm.Show();
        }

        public static ClsEcliente cliente;
        public static ArrayList usuario = new ArrayList();
        ArrayList temp = new ArrayList();

        private void btnGuardar_Click(object sender, EventArgs e) {
            usuario = temp;
            foreach (ClsEcliente item in usuario) {
                cliente = ClsEcliente.crear(item.DniCliente, item.Nombres, item.Apellidos, item.Correo, item.Telefono, item.Estado);
            }
            MessageBox.Show("Datos Guardados correctamente", "JeaNet - Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e) {
            ClsNValidacion validacion = ClsNValidacion.getValidacion();
            validacion.soloNumero(e);
        }

        private void FormCliente_Menu_UsuarioCliente_Load(object sender, EventArgs e) {
            if (usuario.Count == 1) {
                foreach (ClsEcliente item in temp) {
                    txtDNI.Text = item.Nombres;
                    txtNombres.Text = item.DniCliente;
                    txtApellidos.Text = item.Apellidos;
                    txtTelefono.Text = item.Telefono;
                }
            }
        }

        private void txtDNI_MouseClick(object sender, MouseEventArgs e) {
            foreach (Process proceso in Process.GetProcesses()) {
                if (proceso.ProcessName == "TabTip") {
                    proceso.Kill();
                }
            }

            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\TabletTip\\1.7");

            registryKey?.SetValue("KeyboardLayoutPreference", 0, RegistryValueKind.DWord);
            registryKey?.SetValue("LastUsedModalityWasHandwriting", 1, RegistryValueKind.DWord);

            Process.Start(@"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe");
        }

        private void txtDNI_TextChanged(object sender, EventArgs e) {
            if (txtDNI.Text.Length == 8) {
                ClsNcliente N = new ClsNcliente();
                temp = N.busquedaCliente(txtDNI.Text);
                if (temp.Count == 1) {
                    foreach (ClsEcliente item in temp) {
                        txtNombres.Text = item.Nombres;
                        txtApellidos.Text = item.Apellidos;
                        txtTelefono.Text = item.Telefono;
                    }
                    FormCliente_RelojSmart.dni = txtDNI.Text;
                }
            }
        }
    }
}