﻿using Entidad;
using Microsoft.Win32;
using Negocios;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections;
using System.Threading.Tasks;

namespace Presentacion {
    public partial class frmLoginAdmin : Form {

        private static frmLoginAdmin frm = null;

        private frmLoginAdmin() {
            InitializeComponent();
        }

        public static frmLoginAdmin getFormulario() {
            if (frm == null) {
                frm = new frmLoginAdmin();
            }
            return frm;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtuser_Enter(object sender, EventArgs e) {
            if (txtUsuario.Text == "Usuario") {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.DarkBlue;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e) {
            if (txtUsuario.Text == "") {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.Silver;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e) {
            if (txtClave.Text == "Contraseña") {
                txtClave.Text = "";
                txtClave.ForeColor = Color.DarkBlue;
                txtClave.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e) {
            if (txtClave.Text == "") {
                txtClave.Text = "Contraseña";
                txtClave.ForeColor = Color.Silver;
                txtClave.UseSystemPasswordChar = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form_LoginAdmi_Empleado_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel_LoginAdmiEmpleado_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void SalirTostripMenu_Click(object sender, EventArgs e) {
            MtdAuditoria(txtUsuario.Text, "Clic en cerrar aplicacion");
            Application.Exit();
        }

        public string contra = "";
        private void btn0_Click(object sender, EventArgs e) {
            contra = contra + btn0.Text;
            txtClave.Text = contra;
        }

        private void btn1_Click(object sender, EventArgs e) {
            contra = contra + btn1.Text;
            txtClave.Text = contra;
        }

        private void btn2_Click(object sender, EventArgs e) {
            contra = contra + btn2.Text;
            txtClave.Text = contra;
        }

        private void btn3_Click(object sender, EventArgs e) {
            contra = contra + btn3.Text;
            txtClave.Text = contra;
        }

        private void btn4_Click(object sender, EventArgs e) {
            contra = contra + btn4.Text;
            txtClave.Text = contra;
        }

        private void btn5_Click(object sender, EventArgs e) {
            contra = contra + btn5.Text;
            txtClave.Text = contra;
        }

        private void btn6_Click(object sender, EventArgs e) {
            contra = contra + btn6.Text;
            txtClave.Text = contra;
        }

        private void btn7_Click(object sender, EventArgs e) {
            contra = contra + btn7.Text;
            txtClave.Text = contra;
        }

        private void btn8_Click(object sender, EventArgs e) {
            contra = contra + btn8.Text;
            txtClave.Text = contra;
        }

        private void btn9_Click(object sender, EventArgs e) {
            contra = contra + btn9.Text;
            txtClave.Text = contra;
        }

        private void btnBorrar_Click(object sender, EventArgs e) {
            MtdHabilitar();
        }

        private void MtdHabilitar() {
            contra = "";
            txtClave.Clear();
            btn0.Enabled = true;
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
        }

        private void frmLoginAdmin_Load(object sender, EventArgs e) {
            ClsNlogin N = new ClsNlogin();
            int[] numeros = N.GenerarNumeros();
            btn0.Text = numeros[0].ToString();
            btn1.Text = numeros[1].ToString();
            btn2.Text = numeros[2].ToString();
            btn3.Text = numeros[3].ToString();
            btn4.Text = numeros[4].ToString();
            btn5.Text = numeros[5].ToString();
            btn6.Text = numeros[6].ToString();
            btn7.Text = numeros[7].ToString();
            btn8.Text = numeros[8].ToString();
            btn9.Text = numeros[9].ToString();
        }

        private async void btnIngresar_ClickAsync(object sender, EventArgs e) {
            if (MtdValidarCampos()) {
                ClsElogin E = ClsElogin.crear(txtUsuario.Text, txtClave.Text);
                ClsNlogin N = new ClsNlogin();
                DataTable dt = N.ValidarLogin(txtUsuario.Text);             

                if (dt.Rows.Count == 1) {
                    switch (N.MtdVerificarCuenta(dt, E, 1)) {
                        case 0:
                            MessageBox.Show("Error desconocido, comuniquese con soporte.", "JeaNET - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 1:
                            MessageBox.Show("Clave Incorrecta", "JeaNET - Informa.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MtdAuditoria(txtUsuario.Text, "Intento entrar, contraseña incorrecta");
                            break;
                        case 2:
                            MessageBox.Show("La cuenta esta inactiva, comuniquese con soporte.", "JeaNET - Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MtdAuditoria(txtUsuario.Text, "Intento entrar, cuenta inhabilitada");
                            break;
                        case 3:
                            MessageBox.Show("No cuenta con privilegios para ingresar a esta área.", "JeaNET - Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MtdAuditoria(txtUsuario.Text, "Intento entrar, no cuenta con permiso");
                            break;
                        case 4:
                            MessageBox.Show("Esta fuera de su horario de trabajo.", "JeaNET - Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MtdAuditoria(txtUsuario.Text, "Intento entrar, fuera de horario de trabajo.");
                            break;
                        case 5:
                            MessageBox.Show("Su cesion esta abierta, cierrela para poder ingresar.", "JeaNET - Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MtdAuditoria(txtUsuario.Text, "Intento entrar, sesion ya esta abierta.");
                            break;
                        case 6:
                            //sms
                            ClsEsms Es = ClsEsms.crear("+51" + dt.Rows[0][5].ToString(), "El usuario " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString() + " acaba de iniciar sesion a las " + DateTime.Now.ToLongTimeString() + ".");
                            ClsNsms Ns = new ClsNsms();
                            Ns.MtdMandarMensaje(Es);
                            //correo
                           
                           
                            
                            //agregar sesion
                            N.MtdGuardarSesion(dt.Rows[0][9].ToString());
                            //bienvenida
                            MessageBox.Show("Bienvenido " + dt.Rows[0][1] + " " + dt.Rows[0][2] + ".", "JeaNET - Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MtdAuditoria(dt.Rows[0][0].ToString(), "Ingreso al sistema");                           
                           
                            frmAdministrador f = new frmAdministrador(dt);
                            this.Hide();
                            f.Show();
                            break;
                    }
                } else {
                    MessageBox.Show("No existe el usuario", "JeaNet - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       

        public static void MtdAuditoria(string dni, string desc) {
            ClsEauditoria objEauditoria = ClsEauditoria.crear(dni, desc, Convert.ToDateTime(DateTime.Now.ToShortDateString()), DateTime.Now.ToLongTimeString());
            ClsNauditoria objNauditoria = new ClsNauditoria();
            objNauditoria.agregarAuditoria(objEauditoria);
        }

        private bool MtdValidarCampos() {
            ClsNValidacion validacion = ClsNValidacion.getValidacion();
            //validando que campos no esten vacios o null
            bool result = !existenVacios(validacion);
            if (result) {
                //validando cantidad de caracteres
                result = rangoCaracteresCorrecto(validacion) && result;
            }
            return result;
        }

        private bool rangoCaracteresCorrecto(ClsNValidacion validacion) {
            bool result = validacion.tieneRangoCaracteres(error1, txtClave, 6, 6, "La clave tiene que tener 6 numeros");
            return result;
        }

        private bool existenVacios(ClsNValidacion validacion) {
            bool result = validacion.estaVacioONull(error1, txtUsuario, "Tiene que ingresar su Usario");
            result = validacion.estaVacioONull(error1, txtClave, "Tiene que ingresar su Clave") || result;
            return result;
        }

        private void ZonaDeAccesosTostripMenu_Click(object sender, EventArgs e) {
            MtdAuditoria(txtUsuario.Text, "Clic en zona de acceso");
            frmZonaDeAcceso frm1 = frmZonaDeAcceso.getFormulario();
            this.Hide();
            frm1.Show();
        }

        private void linkpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            MtdAuditoria(txtUsuario.Text, "Clic en recuparar contraseña");
            frmRecuperarContraseña f = new frmRecuperarContraseña();
            f.ShowDialog();
        }

        private void TxtUsuario_MouseClick(object sender, MouseEventArgs e) {
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

        private void frmLoginAdmin_FormClosing(object sender, FormClosingEventArgs e) {
            frm = null;
        }
    }
}
