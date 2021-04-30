using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IronMountains
{
    public partial class Form1 : Form
    {
        User User { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.Server = "localhost";
            dbCon.DatabaseName = "iron_mountain";
            dbCon.UserName = "root";
            dbCon.Password = "Qweasdzxc123Halo02";
            bool connected = false;
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT * FROM iron_mountain.users;";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read() && !connected)
                    {
                        User user = new User(reader);
                        if (user.Username == txtUsername.Text && user.Password == txtPassword.Text)
                        {
                            this.User = user;
                            MessageBox.Show("User is in as:" + user.Role.ToString());
                            connected = true;
                        }
                    }
                    if (!connected)
                    {
                        MessageBox.Show("Wrong username or password");
                        dbCon.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Couldn't connect to database");
            }


        }
    }
}
