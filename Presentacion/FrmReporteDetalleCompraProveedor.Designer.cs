
namespace Presentacion
{
    partial class FrmReporteDetalleCompraProveedor
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
            this.txtProveedor = new System.Windows.Forms.Label();
            this.dgComprasProveedor = new System.Windows.Forms.DataGridView();
            this.dgProveedor = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgComprasProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProveedor
            // 
            this.txtProveedor.AutoSize = true;
            this.txtProveedor.BackColor = System.Drawing.Color.Transparent;
            this.txtProveedor.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.txtProveedor.Location = new System.Drawing.Point(805, 95);
            this.txtProveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(59, 23);
            this.txtProveedor.TabIndex = 17;
            this.txtProveedor.Text = "-------";
            // 
            // dgComprasProveedor
            // 
            this.dgComprasProveedor.AllowUserToAddRows = false;
            this.dgComprasProveedor.AllowUserToDeleteRows = false;
            this.dgComprasProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgComprasProveedor.Location = new System.Drawing.Point(408, 132);
            this.dgComprasProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgComprasProveedor.Name = "dgComprasProveedor";
            this.dgComprasProveedor.ReadOnly = true;
            this.dgComprasProveedor.RowHeadersWidth = 51;
            this.dgComprasProveedor.Size = new System.Drawing.Size(560, 242);
            this.dgComprasProveedor.TabIndex = 16;
            // 
            // dgProveedor
            // 
            this.dgProveedor.AllowUserToAddRows = false;
            this.dgProveedor.AllowUserToDeleteRows = false;
            this.dgProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProveedor.Location = new System.Drawing.Point(39, 132);
            this.dgProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgProveedor.Name = "dgProveedor";
            this.dgProveedor.ReadOnly = true;
            this.dgProveedor.RowHeadersWidth = 51;
            this.dgProveedor.Size = new System.Drawing.Size(320, 242);
            this.dgProveedor.TabIndex = 15;
            this.dgProveedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProveedor_CellClick);
            this.dgProveedor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProveedor_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(404, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Productos comprados a:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(139, 89);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Proveedor:";
            // 
            // FrmReporteDetalleCompraProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Presentacion.Properties.Resources.Fondo2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1020, 487);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.dgComprasProveedor);
            this.Controls.Add(this.dgProveedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmReporteDetalleCompraProveedor";
            this.Text = "Reporte de Compras por Proveedor";
            this.Load += new System.EventHandler(this.FrmReporteDetalleCompraProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgComprasProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtProveedor;
        private System.Windows.Forms.DataGridView dgComprasProveedor;
        private System.Windows.Forms.DataGridView dgProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
    }
}