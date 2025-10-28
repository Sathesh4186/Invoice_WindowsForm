using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using Font = System.Drawing.Font;

namespace WindowsFormsApp1
{
    public partial class Billing : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private string pdfFilePath = "";

        public Billing()
        {
            InitializeComponent();
            InitializeTable();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        private void InitializeTable()
        {
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Contact", "Contact");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Vehicle", "Vehicle Type");
            dataGridView1.Columns.Add("Service", "Service Type");
            dataGridView1.Columns.Add("Amount", "Amount");
            dataGridView1.Columns.Add("GST", "GST");
            dataGridView1.Columns.Add("Total", "Total");
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount) && decimal.TryParse(txtGst.Text, out decimal gst))
            {
                decimal total = amount + (amount * gst / 100);
                txtTotal.Text = total.ToString("0.00");
            }
            else
            {
                MessageBox.Show("Enter valid Amount and GST values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(txtName.Text, txtContact.Text, txtEmail.Text, txtVehicleType.Text, txtServiceType.Text, txtAmount.Text, txtGst.Text, txtTotal.Text);
            MessageBox.Show("Record saved successfully!");
        }

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

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float yPos = 100;
            int leftMargin = 50;

            Font font = new Font("Arial", 12);
            e.Graphics.DrawString("Sri Kumaran Electricals - Billing", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, leftMargin, 40);

            e.Graphics.DrawString("Customer Name: " + txtName.Text, font, Brushes.Black, leftMargin, yPos);
            e.Graphics.DrawString("Contact: " + txtContact.Text, font, Brushes.Black, leftMargin, yPos + 30);
            e.Graphics.DrawString("Email: " + txtEmail.Text, font, Brushes.Black, leftMargin, yPos + 60);
            e.Graphics.DrawString("Vehicle: " + txtVehicleType.Text, font, Brushes.Black, leftMargin, yPos + 90);
            e.Graphics.DrawString("Service: " + txtServiceType.Text, font, Brushes.Black, leftMargin, yPos + 120);
            e.Graphics.DrawString("Amount: " + txtAmount.Text, font, Brushes.Black, leftMargin, yPos + 150);
            e.Graphics.DrawString("GST: " + txtGst.Text + "%", font, Brushes.Black, leftMargin, yPos + 180);
            e.Graphics.DrawString("Total: " + txtTotal.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, leftMargin, yPos + 220);
        }

        private void btnDownloadPDF_Click(object sender, EventArgs e)
        {
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

        private void GeneratePDF(string filePath)
        {
            Document doc = new Document(PageSize.A4, 36, 36, 36, 36);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            // Title (iTextSharp font)
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            Paragraph title = new Paragraph("Sri Kumaran - Billing", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            doc.Add(new Paragraph("\n"));

            // body
            Font normal = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            doc.Add(new Paragraph($"Customer Name: {txtName.Text}", normal));
            doc.Add(new Paragraph($"Contact: {txtContact.Text}", normal));
            doc.Add(new Paragraph($"Email: {txtEmail.Text}", normal));
            doc.Add(new Paragraph($"Vehicle Type: {txtVehicleType.Text}", normal));
            doc.Add(new Paragraph($"Service Type: {txtServiceType.Text}", normal));
            doc.Add(new Paragraph($"Amount: {txtAmount.Text}", normal));
            doc.Add(new Paragraph($"GST: {txtGst.Text}%", normal));
            doc.Add(new Paragraph($"Total: {txtTotal.Text}", normal));
            doc.Add(new Paragraph("\n"));

            // Table
            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
            table.WidthPercentage = 100;
            // headers
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, normal));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
            }
            // rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell dgvc in row.Cells)
                    {
                        table.AddCell(new Phrase(dgvc.Value?.ToString() ?? "", normal));
                    }
                }
            }
            doc.Add(table);

            doc.Close();
        }

    }
}
