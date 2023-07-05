using Models;
using Controllers;

namespace Views
{
    public class UpdateBrand : Form
    {
        public Label lblTitle;
        public Label lblName;
        public ComboBox comboBoxName;
        public Button btUdpate;
        public Button btClose;
        public TableLayoutPanel panel;

        public Models.Brand brand;
        public void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                string name = comboBoxName.Text;

                Controllers.Brand.UpdateBrand(
                    brand.BrandId,
                    name
                );

                MessageBox.Show("Marca editada com sucesso!");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            ListBrand BrandList = Application.OpenForms.OfType<ListBrand>().FirstOrDefault();
            if (BrandList != null)
            {
                BrandList.RefreshList();
            }
            this.Close();
        }

        private void ClearForm()
        {
            comboBoxName.Text = "";
        }
        public UpdateBrand(Models.Brand brand)
        {
            this.brand = brand;

            this.Text = "Edição";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(300, 350);

            this.lblTitle = new Label();
            this.lblTitle.Text = "Cadastro de Marca";
            this.lblTitle.Font = new Font("Segoe UI", 13f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(60, 30);
            this.lblTitle.Size = new Size(250, 40);

            this.lblName = new Label();
            this.lblName.Text = "Nome:";
            this.lblName.Location = new Point(33, lblTitle.Bottom + 10);
            this.lblName.Size = new Size(70, 20);

            this.comboBoxName = new ComboBox();
            this.comboBoxName.Location = new Point(33, lblName.Bottom + 5);
            this.comboBoxName.Size = new Size(220, 20);
            this.comboBoxName.Items.Add("Audi");
            this.comboBoxName.Items.Add("BMW");
            this.comboBoxName.Items.Add("CAOA Chery");
            this.comboBoxName.Items.Add("Chevrolet");
            this.comboBoxName.Items.Add("Citroën");
            this.comboBoxName.Items.Add("Fiat");
            this.comboBoxName.Items.Add("Ford");
            this.comboBoxName.Items.Add("Honda");
            this.comboBoxName.Items.Add("Hyundai");
            this.comboBoxName.Items.Add("Jeep");
            this.comboBoxName.Items.Add("Land Rover");
            this.comboBoxName.Items.Add("Mercedes-Benz");
            this.comboBoxName.Items.Add("Mitsubishi");
            this.comboBoxName.Items.Add("Nissan");
            this.comboBoxName.Items.Add("Peugeot");
            this.comboBoxName.Items.Add("Porsche");
            this.comboBoxName.Items.Add("Renault");
            this.comboBoxName.Items.Add("Toyota");
            this.comboBoxName.Items.Add("Volkswagen");
            this.comboBoxName.Items.Add("Volvo");

            this.panel = new TableLayoutPanel();
            this.panel.Dock = DockStyle.Bottom;
            this.panel.AutoSize = true;
            this.panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.panel.Padding = new Padding(10, 10, 10, 10);
            this.panel.BackColor = ColorTranslator.FromHtml("#58ACFA");
            this.panel.ColumnCount = 3;
            this.panel.RowCount = 1;
            this.panel.ColumnStyles.Clear();

            for (int i = 0; i < panel.ColumnCount; i++)
            {
                this.panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            }

            this.btUdpate = new Button();
            this.btUdpate.Text = "Editar";
            //this.btUdpate.Location = new Point(90, 180);
            this.btUdpate.Size = new Size(200, 25);
            this.btUdpate.Font = new Font("Arial", 8, FontStyle.Regular);
            this.btUdpate.FlatStyle = FlatStyle.Flat;
            this.btUdpate.FlatAppearance.BorderSize = 0;
            this.btUdpate.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.btUdpate.ForeColor = ColorTranslator.FromHtml("#000000");
            this.btUdpate.Dock = DockStyle.Fill;
            this.btUdpate.Click += new EventHandler(btUdpate_Click);

            this.btClose = new Button();
            this.btClose.Text = "Fechar";
            //this.btClose.Location = new Point(80, btCrt.Bottom + 10);
            this.btClose.Size = new Size(200, 25);
            this.btClose.Font = new Font("Arial", 8, FontStyle.Regular);
            this.btClose.FlatStyle = FlatStyle.Flat;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.btClose.ForeColor = ColorTranslator.FromHtml("#000000");
            this.btClose.Dock = DockStyle.Fill;
            this.btClose.Click += (sender, s) =>
            {
                this.Close();
            };

            this.panel.Controls.Add(btUdpate, 1, 0);
            this.panel.Controls.Add(btClose, 2, 0);

            this.Controls.Add(panel);
            this.Controls.Add(lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.comboBoxName);
        }
    }
}