using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            try
            {
                // 🖼️ Automatically get the relative path to the image
                string imagePath = Path.Combine(
                    Application.StartupPath,
                    "Properties", "Images", "Shop.jpg"
                );

                // ✅ Check if the file exists before setting it
                if (File.Exists(imagePath))
                {
                    this.BackgroundImage = Image.FromFile(imagePath);
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    // 🔸 Optional: Show a warning if the image is missing
                    MessageBox.Show("Background image not found:\n" + imagePath,
                                    "Image Missing",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading background image:\n" + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = textBox2.Text;

            if (username == "admin" && password == "Admin@123")
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 🚀 You can redirect to next form here if needed:
                // new Dashboard().Show();
                // this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
