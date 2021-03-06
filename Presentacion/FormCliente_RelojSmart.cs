﻿using Entidad;
using Negocios;
using System;
using System.Device.Location;
using System.Windows.Forms;

namespace Presentacion {
    public partial class FormCliente_RelojSmart : Form {

        public static string dni = "";

        public FormCliente_RelojSmart() {
            InitializeComponent();
            this.TTmensaje.SetToolTip(this.btnAlerta, "Alertas");
            this.TTmensaje.SetToolTip(this.btn_Configuraciones, "Configuraciones");
            this.TTmensaje.SetToolTip(this.btnNotificaciones, "Notificaciones");
        }

        private string latitud;
        private string longitud;
        private CLsNsocket mySocket;

        private void tmr1_Tick(object sender, EventArgs e) {
            try {
                lblSegundos.Text = DateTime.Now.ToString("ss");
                cbar.Value = Convert.ToInt32(DateTime.Now.ToString("ss"));
                lblHora.Text = DateTime.Now.ToString("hh:mm");
                lblFecha.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            } catch (Exception ex) {
                MessageBox.Show(("Ocurrio Error:" + ("\r\n" + ("\r\n" + ("Detalles:" + ("\r\n" + ex.Message))))), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e) {
            if (a == 0) {
                a++;
                latitud = e.Position.Location.Latitude.ToString();
                longitud = e.Position.Location.Longitude.ToString();
                CLsNsocket so = new CLsNsocket();
                so.SendEvent("userLocation", latitud.ToString().Replace('.', ',') + "/" + longitud.ToString().Replace('.', ',') + "/" + FormCliente_Menu_UsuarioCliente.cliente.DniCliente + "/" + FormCliente_Menu_UsuarioCliente.cliente.Nombres + "/" + FormCliente_Menu_UsuarioCliente.cliente.Apellidos);
                //guardar alerta en basa de datos
                ClsEalerta E = ClsEalerta.crear(FormCliente_Menu_UsuarioCliente.cliente.DniCliente, latitud.Replace('.', ','), longitud.Replace('.', ','), Convert.ToDateTime(DateTime.Now.ToShortDateString()), DateTime.Now.ToLongTimeString(), MtdObtenerTurno(), "0");
                ClsNalerta N = new ClsNalerta();
                N.agregarAlerta(E);
                MessageBox.Show("Datos enviados, JeanNET", "JeaNet - Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int MtdObtenerTurno() {
            int hora = Convert.ToInt32(DateTime.Now.ToString("HHmmss"));
            int x = 0;
            if (hora >= 000000 && hora < 080000) {
                x = 1;
            } else if (hora >= 080000 && hora < 160000) {
                x = 2;
            } else if (hora >= 160000 && hora < 240000) {
                x = 3;
            }
            return x;
        }

        int a = 0;
        public void btm_AlertaGps2_Click(object sender, EventArgs e) {
            if (band && FormCliente_Menu_UsuarioCliente.usuario.Count == 1) {
                a = 0;
                cont = 11;
                timerRegresiva.Stop();
                label2.Enabled = false;
                label1.Enabled = false;
                GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
                watcher.PositionChanged += watcher_PositionChanged;
                watcher.Start();
                band = false;
            }
        }

        bool band = false;
        private void btn_AlertaIP_Click(object sender, EventArgs e)//AlertaGps1
        {
            if (FormCliente_Menu_UsuarioCliente.usuario.Count == 1) {
                label2.Enabled = true;
                label1.Enabled = true;
                timerRegresiva.Start();
                band = true;
            }
        }
        int cont = 11;
        private void timerRegresiva_Tick(object sender, EventArgs e) {
            cont--;
            label1.Text = cont.ToString();
            if (cont == 0) {
                MessageBox.Show("Se cancelo el envio de las coordenadas");
                cont = 11;
                label2.Text = "";
                label1.Text = "";
                timerRegresiva.Stop();
            }
        }
        private void btn_Configuraciones_Click(object sender, EventArgs e) {
            FormCliente_Configuraciones frm = new FormCliente_Configuraciones();
            frm.Show();
        }
        private void btnNotificaciones_Click(object sender, EventArgs e) {
            FormCliente_Notificaciones frm = new FormCliente_Notificaciones();
            frm.Show();
        }
        private void SalirTostripMenu_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void ZonaDeAccesosTostripMenu_Click(object sender, EventArgs e) {
            this.Hide();
            frmZonaDeAcceso frm = frmZonaDeAcceso.getFormulario();
            frm.Show();
        }

        private void btnAlerta_Click(object sender, EventArgs e) {
            FormCliente_AlertasSmartWatch frm = new FormCliente_AlertasSmartWatch();
            frm.Show();
        }

        private void FormCliente_RelojSmart_Load(object sender, EventArgs e) {
            mySocket = new CLsNsocket();
            mySocket.GetSocket().On("userNotification", data => {
                if (data.ToString().Equals(dni)) {
                    MessageBox.Show("Emergencia aceptada" + data.ToString());
                }
            });
        }
    }
}