using Models;
using Controllers;

namespace Views
{
    public class ListCar : Form
    {
        ListView listCar;

        private void AddListView(Models.Car car)
        {
            string[]row = 
            {
                car.CarId.ToString(),
                car.Year.ToString(),
                car.Color,
                car.LicensePlate,
                car.BodyworkType,
                car.Price.ToString(),
                car.ChassisCode,
                car.RenavanCode,
                car.FuelType,
                car.TransmissionType,
                car.CarMileage.ToString(),
                car.ModelId.ToString(),
                car.BrandId.ToString()
            };

            ListViewItem item = new ListViewItem(row);
            listCar.Items.Add(item);
        }

        public void RefreshList()
        {
            listCar.Items.Clear();

            IEnumerable<Models.Car> list = Models.Car.ReadAllCars();

            foreach (Models.Car car in list)
            {
                AddListView(car);
            }
        }

        public Models.Car GetSelectedCar(Option option)
        {
            if(listCar.SelectedItems.Count > 0)
            {
                int selectedCarId = int.Parse(listCar.SelectedItems[0].Text);
                return Models.Car.ReadByIdCar(selectedCarId);
            }
            else
            {
                throw new Exception($"Seleciona um carro para {(option == Option.Update? "editar" : "deletar")}");
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var CreateCar = new Views.CreateCar();
            CreateCar.Show();
        }

        private void btUdpate_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Car car = GetSelectedCar(Option.Update);
                RefreshList();
                var CarUpdateView = new Views.UpdateCar();
                if(CarUpdateView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Carro editado com sucesso.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Car car = GetSelectedCar(Option.Delete);
                DialogResult result = MessageBox.Show("Tem certeza?", "Deletar Carro", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    RefreshList();
                }
            }catch (Exception err)
            {
                if(err.InnerException != null)
                {
                    MessageBox.Show(err.InnerException.Message);
                }
                else
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ListCar()
        {
            this.Text = "Carros";
            this.Size = new Size(1000, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            Color color = ColorTranslator.FromHtml("#F7F7F7"); 

            listCar = new ListView();
            listCar.Size = new Size(880, 350);
            listCar.Location = new Point(50, 50);
            listCar.View = View.Details;
            listCar.Columns.Add("Id");
            listCar.Columns.Add("Ano");
            listCar.Columns.Add("Cor");
            listCar.Columns.Add("Placa");
            listCar.Columns.Add("Carroceria");
            listCar.Columns.Add("Preço");
            listCar.Columns.Add("Código do chassi");
            listCar.Columns.Add("Código renavan");
            listCar.Columns.Add("Combustível");
            listCar.Columns.Add("Transmissão");
            listCar.Columns.Add("Quilometragem");
            listCar.Columns.Add("Modelo");
            listCar.Columns.Add("Marca");
            listCar.Columns[0].Width = 30;
            listCar.Columns[1].Width = 60;
            listCar.Columns[2].Width = 60;
            listCar.Columns[3].Width = 80;
            listCar.Columns[4].Width = 100;
            listCar.Columns[5].Width = 60;
            listCar.Columns[6].Width = 120;
            listCar.Columns[7].Width = 120;
            listCar.Columns[8].Width = 100;
            listCar.Columns[9].Width = 100;
            listCar.Columns[10].Width = 120;
            listCar.Columns[11].Width = 80;
            listCar.Columns[12].Width = 80;
            listCar.FullRowSelect = true;
            this.Controls.Add(listCar);

            RefreshList();

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Bottom;
            panel.AutoSize = true;
            // panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.Padding = new Padding(10, 10, 10, 10);
            panel.BackColor = ColorTranslator.FromHtml("#58ACFA");
            panel.ColumnCount = 8;
            panel.RowCount = 1;
            panel.ColumnStyles.Clear();

            for (int i = 0; i < panel.ColumnCount; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            }

            Button btCrt = new Button();
            btCrt.Text = "Adicionar";
            btCrt.Size = new Size(30, 30);
            // btCrt.Location = new Point(50, 330);
            btCrt.Font = new Font("Roboto", 8, FontStyle.Regular);
            btCrt.FlatStyle = FlatStyle.Flat;
            btCrt.FlatAppearance.BorderSize = 0;
            btCrt.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btCrt.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btCrt.Dock = DockStyle.Fill;
            btCrt.Click += new EventHandler(btCrt_Click);
            
            Button btUpdate = new Button();
            btUpdate.Text = "Editar";
            btUpdate.Size = new Size(30, 30);
            //btUpdate.Location = new Point(170, 330);
            btUpdate.Font = new Font("Roboto", 8, FontStyle.Regular);
            btUpdate.FlatStyle = FlatStyle.Flat;
            btUpdate.FlatAppearance.BorderSize = 0;
            btUpdate.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btUpdate.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btUpdate.Dock = DockStyle.Fill;
            btUpdate.Click += new EventHandler(btUdpate_Click);
            this.Controls.Add(btUpdate);

            Button btDelete = new Button();
            btDelete.Text = "Deletar";
            btDelete.Size = new Size(30, 30);
            // btDelete.Location = new Point(290, 330);
            btDelete.Font = new Font("Roboto", 8, FontStyle.Regular);
            btDelete.FlatStyle = FlatStyle.Flat;
            btDelete.FlatAppearance.BorderSize = 0;
            btDelete.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btDelete.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btDelete.Dock = DockStyle.Fill;
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btDelete);

            Button btClose = new Button();
            btClose.Text = "Voltar";
            btClose.Size = new Size(30, 30);
            // btClose.Location = new Point(410, 330);
            btClose.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btClose.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btClose.Font = new Font("Roboto", 8, FontStyle.Regular);
            btClose.FlatStyle = FlatStyle.Flat;
            btClose.FlatAppearance.BorderSize = 0;
            btClose.Dock = DockStyle.Fill;
            btClose.Click += (sender, s) =>
            {
                this.Close();
            };
            
            panel.Controls.Add(btCrt, 4, 0);
            panel.Controls.Add(btUpdate, 5, 0);
            panel.Controls.Add(btDelete, 6, 0);
            panel.Controls.Add(btClose, 7, 0); 
            this.Controls.Add(panel);
        }
    }
}