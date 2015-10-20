using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace House
{
    public partial class Form1 : Form
    {
        Location currentLocation;
        RoomWithDoor livingRoom;
        Room diningRoom;
        RoomWithDoor kitchen;
        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        Outside garden;
        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(livingRoom);

        }
        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("an antique carpet", "Living Room", 
            "an oak door with a brass knob");
            diningRoom = new Room( "a crystal chandelier","Dining Room");
            kitchen = new RoomWithDoor("stainless steel appliances", "Kitchen", "a screen door");
            frontYard = new OutsideWithDoor(false, "Front Yard", "an oak door with a brass knob");
            backYard = new OutsideWithDoor(true, "Back Yard", "a screen door");
            garden = new Outside(false,"Garden");
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            livingRoom.Exits = new Location[] { diningRoom };
            kitchen.Exits = new Location[] { diningRoom };
            frontYard.Exits = new Location[] { backYard, garden };
            backYard.Exits = new Location[] { frontYard, garden };
            garden.Exits = new Location[] { backYard, frontYard };
            livingRoom.location = frontYard;
            frontYard.location= livingRoom;
            kitchen.location = backYard;
            backYard.location = kitchen;
        }
        private void MoveToANewLocation(Location newLocation)
        {
            currentLocation = newLocation;
            comboBox1.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
                comboBox1.Items.Add(currentLocation.Exits[i].Name);
            comboBox1.SelectedIndex = 0;
            textBox1.Text = currentLocation.Description ;
            if (currentLocation is IHasExteriorDoor)
                button2.Visible = true;
            else
               button2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[comboBox1.SelectedIndex]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.location);
        }


    }
}
