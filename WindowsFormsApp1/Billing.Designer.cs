using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Billing
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName, lblContact, lblEmail, lblVehicleType, lblServiceType, lblAmount, lblGst, lblTotal;
        private TextBox txtName, txtContact, txtEmail, txtVehicleType, txtServiceType, txtAmount, txtGst, txtTotal;
        private Button btnCalculate, btnPreview, btnPrint, btnDownloadPDF;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 🎨 Background
            this.Paint += (s, e) =>
            {
                LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                    Color.FromArgb(240, 248, 255),
                    Color.FromArgb(200, 220, 255),
                    LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            };

            Font labelFont = new Font("Segoe UI", 11, FontStyle.Bold);
            Font textFont = new Font("Segoe UI", 11);

            int labelX = 50, textX = 220, y = 50, gap = 45;

            Label MakeLabel(string text, int yPos)
            {
                return new Label()
                {
                    Text = text,
                    Location = new Point(labelX, yPos),
                    Font = labelFont,
                    AutoSize = true,
                    ForeColor = Color.Navy
                };
            }

            TextBox MakeTextBox(int yPos)
            {
                return new TextBox()
                {
                    Location = new Point(textX, yPos),
                    Size = new Size(200, 28),
                    Font = textFont,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.WhiteSmoke
                };
            }

            lblName = MakeLabel("Customer Name:", y);
            txtName = MakeTextBox(y);

            lblContact = MakeLabel("Contact:", y += gap);
            txtContact = MakeTextBox(y);

            lblEmail = MakeLabel("Email:", y += gap);
            txtEmail = MakeTextBox(y);

            lblVehicleType = MakeLabel("Vehicle Type:", y += gap);
            txtVehicleType = MakeTextBox(y);

            lblServiceType = MakeLabel("Service Type:", y += gap);
            txtServiceType = MakeTextBox(y);

            lblAmount = MakeLabel("Amount:", y += gap);
            txtAmount = MakeTextBox(y);

            lblGst = MakeLabel("GST (%):", y += gap);
            txtGst = MakeTextBox(y);

            lblTotal = MakeLabel("Total:", y += gap);
            txtTotal = MakeTextBox(y);
            txtTotal.ReadOnly = true;
            txtTotal.BackColor = Color.LightYellow;

            // Buttons
            btnCalculate = new Button()
            {
                Text = "🧮 Calculate",
                Location = new Point(470, 80),
                Size = new Size(150, 40),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCalculate.FlatAppearance.BorderSize = 0;
            btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            btnPreview = new Button()
            {
                Text = "👁 Preview",
                Location = new Point(470, 140),
                Size = new Size(150, 40),
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnPreview.Click += new System.EventHandler(this.btnPreview_Click);

            btnPrint = new Button()
            {
                Text = "🖨 Print",
                Location = new Point(470, 200),
                Size = new Size(150, 40),
                BackColor = Color.Orange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            btnDownloadPDF = new Button()
            {
                Text = "⬇ PDF Download",
                Location = new Point(470, 260),
                Size = new Size(150, 40),
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDownloadPDF.Click += new System.EventHandler(this.btnDownloadPDF_Click);

            // Add controls
            this.Controls.AddRange(new Control[]
            {
                lblName, txtName, lblContact, txtContact, lblEmail, txtEmail,
                lblVehicleType, txtVehicleType, lblServiceType, txtServiceType,
                lblAmount, txtAmount, lblGst, txtGst, lblTotal, txtTotal,
                btnCalculate, btnPreview, btnPrint, btnDownloadPDF
            });

            // Form setup
            this.Text = "Sri Kumaran - Billing";
            this.ClientSize = new Size(670, 500);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
    }
}
