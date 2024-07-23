namespace Presentacion
{
    partial class FrmReporteDetalleVentasDistrito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgDistritos = new System.Windows.Forms.DataGridView();
            this.dgVentasDistrito = new System.Windows.Forms.DataGridView();
            this.txtDistrito = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDistritos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVentasDistrito)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(105, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Distrito:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(331, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Productos vendidos en:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgDistritos
            // 
            this.dgDistritos.AllowUserToAddRows = false;
            this.dgDistritos.AllowUserToDeleteRows = false;
            this.dgDistritos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDistritos.Location = new System.Drawing.Point(41, 86);
            this.dgDistritos.Name = "dgDistritos";
            this.dgDistritos.ReadOnly = true;
            this.dgDistritos.RowHeadersWidth = 51;
            this.dgDistritos.Size = new System.Drawing.Size(240, 197);
            this.dgDistritos.TabIndex = 10;
            this.dgDistritos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDistritos_CellClick);
            // 
            // dgVentasDistrito
            // 
            this.dgVentasDistrito.AllowUserToAddRows = false;
            this.dgVentasDistrito.AllowUserToDeleteRows = false;
            this.dgVentasDistrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVentasDistrito.Location = new System.Drawing.Point(334, 86);
            this.dgVentasDistrito.Name = "dgVentasDistrito";
            this.dgVentasDistrito.ReadOnly = true;
            this.dgVentasDistrito.RowHeadersWidth = 51;
            this.dgVentasDistrito.Size = new System.Drawing.Size(420, 197);
            this.dgVentasDistrito.TabIndex = 11;
            this.dgVentasDistrito.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVentasDistrito_CellClick);
            // 
            // txtDistrito
            // 
            this.txtDistrito.AutoSize = true;
            this.txtDistrito.BackColor = System.Drawing.Color.Transparent;
            this.txtDistrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDistrito.Location = new System.Drawing.Point(562, 54);
            this.txtDistrito.Name = "txtDistrito";
            this.txtDistrito.Size = new System.Drawing.Size(50, 17);
            this.txtDistrito.TabIndex = 12;
            this.txtDistrito.Text = "-------";
            // 
            // FrmReporteDetalleVentasDistrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Presentacion.Properties.Resources.Fondo2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(796, 372);
            this.Controls.Add(this.txtDistrito);
            this.Controls.Add(this.dgVentasDistrito);
            this.Controls.Add(this.dgDistritos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.DoubleBuffered = true;
            this.Name = "FrmReporteDetalleVentasDistrito";
            this.Text = "Reporte de Ventas por Distrito";
            this.Load += new System.EventHandler(this.FrmReporteVentasDistrito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDistritos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVentasDistrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgDistritos;
        private System.Windows.Forms.DataGridView dgVentasDistrito;
        private System.Windows.Forms.Label txtDistrito;
    }
}