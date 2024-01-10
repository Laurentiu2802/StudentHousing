using DataAcces;
using Logic.Entities;
using Logic.Enums;
using Logic.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace StudentHousing
{
    public partial class Menu : Form
    {
        private readonly HouseManager houseManager;
        private byte[] photo;

        List<House> houses = new List<House>();

        public Menu()
        {
            InitializeComponent();

            houseManager = new HouseManager(new HouseRepository());

            houses = houseManager.GetAllHouses();

            foreach (House house in houses)
            {
                lbHouse.Items.Add(house);
            }

        }

        public void ClearAllBoxes()
        {
            tbHouseNumber.Clear();
            tbCity.Clear();
            tbAddress.Clear();
            tbDeposit.Clear();
            cbFurnished.SelectedIndex = -1;
            tbRent.Clear();
            tbSpace.Clear();
            tbContractType.Clear();
            tbHouseType.Clear();
        }

        public void RefreshHouseList()
        {
            houses = houseManager.GetAllHouses();
            lbHouse.Items.Clear();
            foreach (House house in houses)
            {
                lbHouse.Items.Add(house);
            }
        }

        public void AddHouse()
        {
            if (cbFurnished.SelectedIndex == 1)
            {
                House house = new House(Convert.ToInt32(tbHouseNumber.Text), tbAddress.Text, tbCity.Text, tbHouseType.Text, Convert.ToInt32(tbSpace.Text), true, tbContractType.Text, Convert.ToInt32(tbRent.Text), Convert.ToInt32(tbDeposit.Text), photo);
                houseManager.AddHouse(house.HouseToHouseDTO());
                RefreshHouseList();
                ClearAllBoxes();
            }
            else if (cbFurnished.SelectedIndex == 2)
            {
                House house = new House(Convert.ToInt32(tbHouseNumber.Text), tbAddress.Text, tbCity.Text, tbHouseType.Text, Convert.ToInt32(tbSpace.Text), false, tbContractType.Text, Convert.ToInt32(tbRent.Text), Convert.ToInt32(tbDeposit.Text), photo);
                houseManager.AddHouse(house.HouseToHouseDTO());
                RefreshHouseList();
                ClearAllBoxes();
            }
        }

        public void EditHouse()
        {
            House selectedHouse = lbHouse.SelectedItem as House;
            if (cbFurnished.SelectedIndex == 1)
            {
                House house = new House(selectedHouse.HouseID,Convert.ToInt32(tbHouseNumber.Text), tbAddress.Text, tbCity.Text, tbHouseType.Text, Convert.ToInt32(tbSpace.Text), true, tbContractType.Text, Convert.ToInt32(tbRent.Text), Convert.ToInt32(tbDeposit.Text), photo);
                houseManager.UpdateHouse(house.HouseToHouseDTO());
                RefreshHouseList();
                ClearAllBoxes();
            }
            else if (cbFurnished.SelectedIndex == 2)
            {
                House house = new House(selectedHouse.HouseID,Convert.ToInt32(tbHouseNumber.Text), tbAddress.Text, tbCity.Text, tbHouseType.Text, Convert.ToInt32(tbSpace.Text), false, tbContractType.Text, Convert.ToInt32(tbRent.Text), Convert.ToInt32(tbDeposit.Text), photo);
                houseManager.UpdateHouse(house.HouseToHouseDTO());
                RefreshHouseList();
                ClearAllBoxes();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddHouse();
        }



        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetFullPath(ofd.FileName);
                using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                using MemoryStream memoryStream = new MemoryStream();
                fs.CopyTo(memoryStream);
                photo = memoryStream.ToArray();
                MemoryStream stmBLOBData = new MemoryStream(photo);
                houseImage.Image = Image.FromStream(stmBLOBData);
            }
            else { MessageBox.Show("You canceled"); }
        }

        private void btnEditHouse_Click(object sender, EventArgs e)
        {
            EditHouse();
        }

        private void lbHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            House house = lbHouse.SelectedItem as House;
            tbHouseNumber.Text = house.HouseNumber.ToString();
            tbAddress.Text = house.Address.ToString();
            tbCity.Text = house.City.ToString();
            tbHouseType.Text = house.HouseType.ToString();
            tbSpace.Text = house.Space.ToString();
            if(house.Furnished == true)
            {
                cbFurnished.SelectedIndex = 1;
            }
            else if(house.Furnished == false)
            {
                cbFurnished.SelectedIndex = 2;
            }
            //cbFurnished.Text = house.Furnished.ToString();
            tbContractType.Text = house.ContractType.ToString();
            tbRent.Text = house.Rent.ToString();
            tbDeposit.Text = house.Deposit.ToString();
            MemoryStream stmBLOBData = new MemoryStream(house.HousePhoto);
            houseImage.Image = Image.FromStream(stmBLOBData);
            photo = stmBLOBData.ToArray();
        }
    }
}
