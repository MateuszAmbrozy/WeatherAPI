namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            hours_label = new Label();
            lat = new Label();
            lon = new Label();
            lat_box = new TextBox();
            lon_box = new TextBox();
            hours_list = new ListBox();
            button1 = new Button();
            button2 = new Button();
            treeView1 = new TreeView();
            info = new Label();
            deleteButton = new Button();
            SuspendLayout();
            // 
            // hours_label
            // 
            hours_label.AutoSize = true;
            hours_label.BackColor = SystemColors.ActiveCaption;
            hours_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            hours_label.Location = new Point(400, 63);
            hours_label.Name = "hours_label";
            hours_label.Size = new Size(129, 21);
            hours_label.TabIndex = 0;
            hours_label.Text = "How many hours";
            // 
            // lat
            // 
            lat.AutoSize = true;
            lat.BackColor = SystemColors.ActiveCaption;
            lat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lat.Location = new Point(709, 63);
            lat.Name = "lat";
            lat.Size = new Size(31, 21);
            lat.TabIndex = 1;
            lat.Text = "Lat";
            // 
            // lon
            // 
            lon.AutoSize = true;
            lon.BackColor = SystemColors.ActiveCaption;
            lon.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lon.Location = new Point(575, 63);
            lon.Name = "lon";
            lon.Size = new Size(36, 21);
            lon.TabIndex = 2;
            lon.Text = "Lon";
            // 
            // lat_box
            // 
            lat_box.Location = new Point(666, 100);
            lat_box.Name = "lat_box";
            lat_box.Size = new Size(129, 23);
            lat_box.TabIndex = 3;
            // 
            // lon_box
            // 
            lon_box.Location = new Point(535, 100);
            lon_box.Name = "lon_box";
            lon_box.Size = new Size(115, 23);
            lon_box.TabIndex = 4;
            // 
            // hours_list
            // 
            hours_list.FormattingEnabled = true;
            hours_list.ItemHeight = 15;
            hours_list.Location = new Point(409, 100);
            hours_list.Name = "hours_list";
            hours_list.Size = new Size(120, 34);
            hours_list.TabIndex = 5;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button1.Location = new Point(635, 338);
            button1.Name = "button1";
            button1.Size = new Size(139, 50);
            button1.TabIndex = 7;
            button1.Text = "Download API";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button2.Location = new Point(400, 338);
            button2.Name = "button2";
            button2.Size = new Size(151, 50);
            button2.TabIndex = 9;
            button2.Text = "Show";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(-3, 42);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(397, 413);
            treeView1.TabIndex = 12;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // info
            // 
            info.AutoSize = true;
            info.BackColor = SystemColors.MenuHighlight;
            info.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            info.ForeColor = SystemColors.ActiveCaptionText;
            info.Location = new Point(284, 7);
            info.Name = "info";
            info.Size = new Size(226, 30);
            info.TabIndex = 13;
            info.Text = "Weather API App";
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(510, 415);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(172, 23);
            deleteButton.TabIndex = 14;
            deleteButton.Text = "Delete selected Data";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(800, 450);
            Controls.Add(deleteButton);
            Controls.Add(info);
            Controls.Add(treeView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(hours_list);
            Controls.Add(lon_box);
            Controls.Add(lat_box);
            Controls.Add(lon);
            Controls.Add(lat);
            Controls.Add(hours_label);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label hours_label;
        private Label lat;
        private Label lon;
        private TextBox lat_box;
        private TextBox lon_box;
        private ListBox hours_list;
        private Button button1;
        private Button button2;
        private Button save_btn;
        private TreeView treeView1;
        private Label info;
        private Button deleteButton;
    }
}
