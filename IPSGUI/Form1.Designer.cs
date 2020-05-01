namespace IPSGUI
{
    partial class FrmLiquidacion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.TxtNumeroLiquidacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbTipoAfiliacion = new System.Windows.Forms.ComboBox();
            this.DtpFechaLiquidacion = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtIdentificacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtSalarioDevengado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtValorHospitalizacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(320, 330);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 0;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // TxtNumeroLiquidacion
            // 
            this.TxtNumeroLiquidacion.Location = new System.Drawing.Point(257, 92);
            this.TxtNumeroLiquidacion.Name = "TxtNumeroLiquidacion";
            this.TxtNumeroLiquidacion.Size = new System.Drawing.Size(138, 20);
            this.TxtNumeroLiquidacion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Número Liquidación";
            // 
            // CmbTipoAfiliacion
            // 
            this.CmbTipoAfiliacion.FormattingEnabled = true;
            this.CmbTipoAfiliacion.Items.AddRange(new object[] {
            "Contributivo",
            "Subsidiado"});
            this.CmbTipoAfiliacion.Location = new System.Drawing.Point(257, 209);
            this.CmbTipoAfiliacion.Name = "CmbTipoAfiliacion";
            this.CmbTipoAfiliacion.Size = new System.Drawing.Size(138, 21);
            this.CmbTipoAfiliacion.TabIndex = 3;
            // 
            // DtpFechaLiquidacion
            // 
            this.DtpFechaLiquidacion.Location = new System.Drawing.Point(186, 131);
            this.DtpFechaLiquidacion.Name = "DtpFechaLiquidacion";
            this.DtpFechaLiquidacion.Size = new System.Drawing.Size(209, 20);
            this.DtpFechaLiquidacion.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Salario devengado";
            // 
            // TxtIdentificacion
            // 
            this.TxtIdentificacion.Location = new System.Drawing.Point(257, 170);
            this.TxtIdentificacion.Name = "TxtIdentificacion";
            this.TxtIdentificacion.Size = new System.Drawing.Size(138, 20);
            this.TxtIdentificacion.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo de afiliación";
            // 
            // TxtSalarioDevengado
            // 
            this.TxtSalarioDevengado.Location = new System.Drawing.Point(257, 249);
            this.TxtSalarioDevengado.Name = "TxtSalarioDevengado";
            this.TxtSalarioDevengado.Size = new System.Drawing.Size(138, 20);
            this.TxtSalarioDevengado.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Idetificación Paciente";
            // 
            // TxtValorHospitalizacion
            // 
            this.TxtValorHospitalizacion.Location = new System.Drawing.Point(257, 288);
            this.TxtValorHospitalizacion.Name = "TxtValorHospitalizacion";
            this.TxtValorHospitalizacion.Size = new System.Drawing.Size(138, 20);
            this.TxtValorHospitalizacion.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Fecha Liquidación";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Valor Servicio Hospitalización";
            // 
            // FrmLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtValorHospitalizacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtSalarioDevengado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtIdentificacion);
            this.Controls.Add(this.DtpFechaLiquidacion);
            this.Controls.Add(this.CmbTipoAfiliacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtNumeroLiquidacion);
            this.Controls.Add(this.BtnGuardar);
            this.Name = "FrmLiquidacion";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox TxtNumeroLiquidacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbTipoAfiliacion;
        private System.Windows.Forms.DateTimePicker DtpFechaLiquidacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtIdentificacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtSalarioDevengado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtValorHospitalizacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

