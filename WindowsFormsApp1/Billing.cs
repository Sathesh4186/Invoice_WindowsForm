using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WindowsFormsApp1
{
    public partial class Billing : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private string pdfFilePath = "";

        public Billing()
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        // ✅ Calculate GST (optional) + validations
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter Customer Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Please enter Amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Enter valid numeric Amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            decimal gst = 0;
            if (!string.IsNullOrWhiteSpace(txtGst.Text))
            {
                if (!decimal.TryParse(txtGst.Text, out gst))
                {
                    MessageBox.Show("Enter valid GST percentage.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGst.Focus();
                    return;
                }
            }

            decimal total = amount + (amount * gst / 100);
            txtTotal.Text = total.ToString("0.00");
        }

        // 🔹 Preview Bill
        private void btnPreview_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 800,
                Height = 600
            };
            previewDialog.ShowDialog();
        }

        // 🔹 Print Bill
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        // 🔹 Print Layout
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float yPos = 100;
            int leftMargin = 60;

            using (System.Drawing.Font font = new System.Drawing.Font("Segoe UI", 12))
            {
                e.Graphics.DrawString("Sri Kumaran - Billing",
                    new System.Drawing.Font("Segoe UI", 18, FontStyle.Bold),
                    Brushes.DarkBlue, leftMargin, 40);

                e.Graphics.DrawString("Customer Name: " + txtName.Text, font, Brushes.Black, leftMargin, yPos);
                e.Graphics.DrawString("Contact: " + txtContact.Text, font, Brushes.Black, leftMargin, yPos + 30);
                e.Graphics.DrawString("Email: " + txtEmail.Text, font, Brushes.Black, leftMargin, yPos + 60);
                e.Graphics.DrawString("Vehicle: " + txtVehicleType.Text, font, Brushes.Black, leftMargin, yPos + 90);
                e.Graphics.DrawString("Service: " + txtServiceType.Text, font, Brushes.Black, leftMargin, yPos + 120);
                e.Graphics.DrawString("Amount: ₹" + txtAmount.Text, font, Brushes.Black, leftMargin, yPos + 150);
                e.Graphics.DrawString("GST: " + (string.IsNullOrWhiteSpace(txtGst.Text) ? "0" : txtGst.Text) + "%", font, Brushes.Black, leftMargin, yPos + 180);
                e.Graphics.DrawString("Total: ₹" + txtTotal.Text,
                    new System.Drawing.Font("Segoe UI", 16, FontStyle.Bold),
                    Brushes.DarkGreen, leftMargin, yPos + 230);
            }
        }

        // 🔹 Download PDF
        private void btnDownloadPDF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtTotal.Text))
            {
                MessageBox.Show("Please fill details and calculate total before downloading PDF.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = "Billing_" + txtName.Text + ".pdf"
            };

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                pdfFilePath = saveFile.FileName;
                GeneratePDF(pdfFilePath);
                MessageBox.Show("PDF downloaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 🔹 Generate PDF using iTextSharp
        private void GeneratePDF(string filePath)
        {
            try
            {
                Document doc = new Document(PageSize.A4, 36, 36, 36, 36);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLUE);
                Paragraph title = new Paragraph("Sri Kumaran - Billing", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(title);
                doc.Add(new Paragraph("\n"));

                iTextSharp.text.Font normal = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                doc.Add(new Paragraph($"Customer Name: {txtName.Text}", normal));
                doc.Add(new Paragraph($"Contact: {txtContact.Text}", normal));
                doc.Add(new Paragraph($"Email: {txtEmail.Text}", normal));
                doc.Add(new Paragraph($"Vehicle Type: {txtVehicleType.Text}", normal));
                doc.Add(new Paragraph($"Service Type: {txtServiceType.Text}", normal));
                doc.Add(new Paragraph($"Amount: ₹{txtAmount.Text}", normal));
                doc.Add(new Paragraph($"GST: {(string.IsNullOrWhiteSpace(txtGst.Text) ? "0" : txtGst.Text)}%", normal));
                doc.Add(new Paragraph($"Total: ₹{txtTotal.Text}", normal));

                doc.Close();
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
