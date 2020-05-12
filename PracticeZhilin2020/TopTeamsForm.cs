using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeZhilin2020
{
    public partial class TopTeamsForm : Form
    {
        private Panel[] ClubPanel;    // Массив Панелей
        int count = 0;
        int DynamicButtonCount = 0;
        int id_club;
        public TopTeamsForm()
        {
            InitializeComponent();
            ClubPanel = new Panel[100];
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `clubs` ORDER BY points DESC,winning_matches DESC, goals_scored DESC", db.getConnection());
            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                write_panel(reader);
            }
            reader.Close();
            db.closeConnection();


        }
        void write_panel(MySqlDataReader reader)
        {
            count++;
            DynamicButtonCount++;

            //panel
            ClubPanel[count] = new Panel();
            ClubPanel[count].BackColor = Color.White;
            ClubPanel[count].BorderStyle = BorderStyle.FixedSingle;
            ClubPanel[count].Size = new System.Drawing.Size(1000, 70);
            ClubPanel[count].Name = reader["Id"].ToString();


            //team_name
            Label nameLabel = new Label();
            nameLabel.Text = reader["team_name"].ToString();
            nameLabel.ForeColor = Color.Black;
            nameLabel.Font = new Font("Century Gothic", 15, FontStyle.Bold);
            nameLabel.Size = new System.Drawing.Size(220, 35);
            nameLabel.Location = new System.Drawing.Point(0, 0);

            //place
            Label infoLabel = new Label();
            infoLabel.Text = reader["club_location"].ToString();
            infoLabel.ForeColor = Color.Black;
            infoLabel.Font = new Font("Century Gothic", 12);
            infoLabel.Size = new System.Drawing.Size(220, 35);
            infoLabel.Location = new System.Drawing.Point(0, 35);

            //points
            Label points = new Label();
            points.Text = reader["points"].ToString();
            points.ForeColor = Color.Black;
            points.Font = new Font("Century Gothic", 15);
            points.Size = new System.Drawing.Size(80, 35);
            points.Location = new System.Drawing.Point(310, 15);
            points.TextAlign = ContentAlignment.MiddleLeft;


            //winning_matches
            Label wm = new Label();
            wm.Text = reader["winning_matches"].ToString();
            wm.ForeColor = Color.Black;
            wm.Font = new Font("Century Gothic", 15);
            wm.Size = new System.Drawing.Size(80, 35);
            wm.Location = new System.Drawing.Point(390, 15);
            wm.TextAlign = ContentAlignment.MiddleLeft;

            //draw_matches
            Label dm = new Label();
            dm.Text = reader["draw_matches"].ToString();
            dm.ForeColor = Color.Black;
            dm.Font = new Font("Century Gothic", 15);
            dm.Size = new System.Drawing.Size(80, 35);
            dm.Location = new System.Drawing.Point(470, 15);
            dm.TextAlign = ContentAlignment.MiddleLeft;

            //losing_matches
            Label lm = new Label();
            lm.Text = reader["losing_matches"].ToString();
            lm.ForeColor = Color.Black;
            lm.Font = new Font("Century Gothic", 15);
            lm.Size = new System.Drawing.Size(80, 35);
            lm.Location = new System.Drawing.Point(550, 15);
            lm.TextAlign = ContentAlignment.MiddleLeft;

            //goals_scored
            Label gs = new Label();
            gs.Text = reader["goals_scored"].ToString();
            gs.ForeColor = Color.Black;
            gs.Font = new Font("Century Gothic", 15);
            gs.Size = new System.Drawing.Size(80, 35);
            gs.Location = new System.Drawing.Point(630, 15);
            gs.TextAlign = ContentAlignment.MiddleLeft;

            //goals_conceded
            Label gc = new Label();
            gc.Text = reader["goals_conceded"].ToString();
            gc.ForeColor = Color.Black;
            gc.Font = new Font("Century Gothic", 15);
            gc.Size = new System.Drawing.Size(80, 35);
            gc.Location = new System.Drawing.Point(710, 15);
            gc.TextAlign = ContentAlignment.MiddleLeft;


            ClubPanel[count].Controls.Add(nameLabel);
            ClubPanel[count].Controls.Add(infoLabel);
            ClubPanel[count].Controls.Add(points);
            ClubPanel[count].Controls.Add(wm);
            ClubPanel[count].Controls.Add(dm);
            ClubPanel[count].Controls.Add(lm);
            ClubPanel[count].Controls.Add(gs);
            ClubPanel[count].Controls.Add(gc);
            clubsTopPanel.Controls.Add(ClubPanel[count]);


        }
        private void TopTeamsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
