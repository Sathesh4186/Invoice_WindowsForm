using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Billing
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblName, lblContact, lblEmail, lblVehicleType, lblServiceType, lblAmount, lblGst, lblTotal;
        private System.Windows.Forms.TextBox txtName, txtContact, txtEmail, txtVehicleType, txtServiceType, txtAmount, txtGst, txtTotal;
        private System.Windows.Forms.Button btnCalculate, btnSave, btnPreview, btnPrint, btnDownloadPDF;
        private System.Windows.Forms.DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.lblServiceType = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblGst = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();

            this.txtName = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtVehicleType = new System.Windows.Forms.TextBox();
            this.txtServiceType = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtGst = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();

            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDownloadPDF = new System.Windows.Forms.Button();

            this.dataGridView1 = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            int x1 = 50, x2 = 200, y = 40, gap = 40;

            this.lblName.Text = "Customer Name:";
            this.lblName.Location = new System.Drawing.Point(x1, y);
            this.txtName.Location = new System.Drawing.Point(x2, y);

            this.lblContact.Text = "Contact Number:";
            this.lblContact.Location = new System.Drawing.Point(x1, y += gap);
            this.txtContact.Location = new System.Drawing.Point(x2, y);

            this.lblEmail.Text = "Email Address:";
            this.lblEmail.Location = new System.Drawing.Point(x1, y += gap);
            this.txtEmail.Location = new System.Drawing.Point(x2, y);

            this.lblVehicleType.Text = "Vehicle Type:";
            this.lblVehicleType.Location = new System.Drawing.Point(x1, y += gap);
            this.txtVehicleType.Location = new System.Drawing.Point(x2, y);

            this.lblServiceType.Text = "Service Type:";
            this.lblServiceType.Location = new System.Drawing.Point(x1, y += gap);
            this.txtServiceType.Location = new System.Drawing.Point(x2, y);

            this.lblAmount.Text = "Amount:";
            this.lblAmount.Location = new System.Drawing.Point(x1, y += gap);
            this.txtAmount.Location = new System.Drawing.Point(x2, y);

            this.lblGst.Text = "GST (%):";
            this.lblGst.Location = new System.Drawing.Point(x1, y += gap);
            this.txtGst.Location = new System.Drawing.Point(x2, y);

            this.lblTotal.Text = "Total:";
            this.lblTotal.Location = new System.Drawing.Point(x1, y += gap);
            this.txtTotal.Location = new System.Drawing.Point(x2, y);
            this.txtTotal.ReadOnly = true;

            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.Location = new System.Drawing.Point(450, 280);
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(560, 280);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnPreview.Text = "Preview";
            this.btnPreview.Location = new System.Drawing.Point(670, 280);
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);

            this.btnPrint.Text = "Print";
            this.btnPrint.Location = new System.Drawing.Point(780, 280);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            this.btnDownloadPDF.Text = "Download PDF";
            this.btnDownloadPDF.Location = new System.Drawing.Point(890, 280);
            this.btnDownloadPDF.Click += new System.EventHandler(this.btnDownloadPDF_Click);

            this.dataGridView1.Location = new System.Drawing.Point(50, 340);
            this.dataGridView1.Size = new System.Drawing.Size(950, 250);

            this.ClientSize = new System.Drawing.Size(1080, 620);
            this.Controls.AddRange(new Control[] {
                lblName, txtName, lblContact, txtContact, lblEmail, txtEmail,
                lblVehicleType, txtVehicleType, lblServiceType, txtServiceType,
                lblAmount, txtAmount, lblGst, txtGst, lblTotal, txtTotal,
                btnCalculate, btnSave, btnPreview, btnPrint, btnDownloadPDF,
                dataGridView1
            });

            this.Text = "Billing - Sri Kumaran Electricals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
