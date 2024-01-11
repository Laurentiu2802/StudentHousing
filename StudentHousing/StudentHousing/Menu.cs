using DataAcces;
using Logic.Entities;
using Logic.Enums;
using Logic.Managers;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private readonly RequestManager requestManager;
        private byte[] photo;

        List<House> houses = new List<House>();
        List<Request> requests = new List<Request>();

        public Menu()
        {
            InitializeComponent();

            houseManager = new HouseManager(new HouseRepository());
            requestManager = new RequestManager(new RequestRepository());

            houses = houseManager.GetAllHouses();
            panel1.Hide();
            foreach (House house in houses)
            {
                lbHouse.Items.Add(house);
                lbHousesR.Items.Add(house);
            }
            foreach (var item in Enum.GetValues(typeof(HouseType)))
            {
                cbHouseType.Items.Add(item);
                cbHouseTypeR.Items.Add(item);
            }
            foreach (var item1 in Enum.GetValues(typeof(ContractType)))
            {
                cbContract.Items.Add(item1);
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
            cbContract.SelectedIndex = -1;
            cbHouseType.SelectedIndex = -1;
        }

        public void RefreshHouseList()
        {
            houses = houseManager.GetAllHouses();
            lbHouse.Items.Clear();
            foreach (House house in houses)
            {
                lbHouse.Items.Add(house);
                lbHousesR.Items.Add(house);
            }
        }

        public void AddHouse()
        {

            if (cbFurnished.SelectedIndex == 1)
            {
                House house = new House(Convert.ToInt32(tbHouseNumber.Text), tbAddress.Text, tbCity.Text, (HouseType)cbHouseType.SelectedItem, Convert.ToInt32(tbSpace.Text), true, (ContractType)cbContract.SelectedItem, Convert.ToInt32(tbRent.Text), Convert.ToInt32(tbDeposit.Text), photo, true);
                houseManager.AddHouse(house.HouseToHouseDTO());
                RefreshHouseList();
                ClearAllBoxes();
            }
            else if (cbFurnished.SelectedIndex == 2)
            {
                House house = new House(Convert.ToInt32(tbHouseNumber.Text), tbAddress.Text, tbCity.Text, (HouseType)cbHouseType.SelectedItem, Convert.ToInt32(tbSpace.Text), false, (ContractType)cbContract.SelectedItem, Convert.ToInt32(tbRent.Text), Convert.ToInt32(tbDeposit.Text), photo, true);
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
                House house = new House(selectedHouse.HouseID, Convert.ToInt32(tbHouseNumber.Text), tbAddress.Text, tbCity.Text, (HouseType)cbHouseType.SelectedItem, Convert.ToInt32(tbSpace.Text), true, (ContractType)cbContract.SelectedItem, Convert.ToInt32(tbRent.Text), Convert.ToInt32(tbDeposit.Text), photo, selectedHouse.Status);
                houseManager.UpdateHouse(house.HouseToHouseDTO());
                RefreshHouseList();
                ClearAllBoxes();
            }
            else if (cbFurnished.SelectedIndex == 2)
            {
                House house = new House(selectedHouse.HouseID, Convert.ToInt32(tbHouseNumber.Text), tbAddress.Text, tbCity.Text, (HouseType)cbHouseType.SelectedItem, Convert.ToInt32(tbSpace.Text), false, (ContractType)cbContract.SelectedItem, Convert.ToInt32(tbRent.Text), Convert.ToInt32(tbDeposit.Text), photo, selectedHouse.Status);
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
            cbHouseType.SelectedItem = house.HouseType;
            tbSpace.Text = house.Space.ToString();
            if (house.Furnished == true)
            {
                cbFurnished.SelectedIndex = 1;
            }
            else if (house.Furnished == false)
            {
                cbFurnished.SelectedIndex = 2;
            }
            cbContract.SelectedItem = house.ContractType;
            tbRent.Text = house.Rent.ToString();
            tbDeposit.Text = house.Deposit.ToString();
            MemoryStream stmBLOBData = new MemoryStream(house.HousePhoto);
            houseImage.Image = Image.FromStream(stmBLOBData);
            photo = stmBLOBData.ToArray();
        }

        private void lbHousesR_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Show();
            lbRequests.Items.Clear();
            House house = lbHousesR.SelectedItem as House;
            requests = requestManager.GetRequestsByHouseID(house.HouseID);
            foreach (Request request in requests)
            {
                lbRequests.Items.Add(request);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            lbHousesR.Items.Clear();
            HouseType houseType;
            bool status = false;
            houseType = (HouseType)cbHouseTypeR.SelectedItem;
            if (cbHouseStatus.SelectedIndex == 0)
            {
                status = true;
            }
            else if (cbHouseStatus.SelectedIndex == 1)
            {
                status = false;
            }

            List<House> houses = new List<House>();
            houses = houseManager.GetAllHousesByStatusAndType(status, Convert.ToInt32(houseType));
            foreach (House house in houses)
            {
                lbHousesR.Items.Add(house);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Request request = lbRequests.SelectedItem as Request;
            if(request.Status == RequestStatus.Pending)
            {
                House house = request.House;
                request.Status = RequestStatus.Accepted;
                requestManager.UpdateRequest(request.RequestToRequestDTO());
                foreach (Request request1 in lbRequests.Items)
                {
                    if (request1.RequestID != request.RequestID && request1.House.HouseID == request.House.HouseID)
                    {
                        request1.Status = RequestStatus.Rejected;
                        requestManager.UpdateRequest(request1.RequestToRequestDTO());
                    }
                }
                house.Status = false;
                houseManager.UpdateHouse(house.HouseToHouseDTO());
                RefreshRequestList();
                lbRequests.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("You can not change the person who is assigned to the house");
            }
            
        }

        public void RefreshRequestList()
        {
            lbRequests.Items.Clear();
        }
        public void RefreshFilters()
        {
            cbHouseStatus.SelectedIndex = -1;
            cbHouseTypeR.SelectedIndex = -1;

        }

        private void lbRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            Request request = lbRequests.SelectedItem as Request;
            House house = request.House;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            Request request = lbRequests.SelectedItem as Request;
            House house = request.House;
            request.Status = RequestStatus.Rejected;
            requestManager.UpdateRequest(request.RequestToRequestDTO());
            lbRequests.SelectedIndex = -1;
        }
    }
}
