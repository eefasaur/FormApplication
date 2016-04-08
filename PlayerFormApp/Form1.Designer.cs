namespace PlayerFormApp
{
    partial class playerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._viewPlayersTable = new System.Windows.Forms.DataGridView();
            this._logoImg = new System.Windows.Forms.PictureBox();
            this._loadButton = new System.Windows.Forms.Button();
            this._updateButton = new System.Windows.Forms.Button();
            this._deleteButton = new System.Windows.Forms.Button();
            this._newButton = new System.Windows.Forms.Button();
            this._idLabel = new System.Windows.Forms.Label();
            this._speedLabel = new System.Windows.Forms.Label();
            this._distanceLabel = new System.Windows.Forms.Label();
            this._heightLabel = new System.Windows.Forms.Label();
            this._ageLabel = new System.Windows.Forms.Label();
            this._nameLabel = new System.Windows.Forms.Label();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.distanceTextBox = new System.Windows.Forms.TextBox();
            this.speedTextBox = new System.Windows.Forms.TextBox();
            this.updateAgeButton = new System.Windows.Forms.Button();
            this.updateSpeedButton = new System.Windows.Forms.Button();
            this.updateDistanceButton = new System.Windows.Forms.Button();
            this.statsDistance = new System.Windows.Forms.Button();
            this.statsSpeed = new System.Windows.Forms.Button();
            this._statsLabel = new System.Windows.Forms.Label();
            this._maxLabel = new System.Windows.Forms.Label();
            this._minLabel = new System.Windows.Forms.Label();
            this._meanLabel = new System.Windows.Forms.Label();
            this.maxTextBox = new System.Windows.Forms.TextBox();
            this.meanTextBox = new System.Windows.Forms.TextBox();
            this.minTextBox = new System.Windows.Forms.TextBox();
            this.doneButton = new System.Windows.Forms.Button();
            this._addToDatabase = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._viewPlayersTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._logoImg)).BeginInit();
            this.SuspendLayout();
            // 
            // _viewPlayersTable
            // 
            this._viewPlayersTable.AllowUserToAddRows = false;
            this._viewPlayersTable.AllowUserToDeleteRows = false;
            this._viewPlayersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._viewPlayersTable.Location = new System.Drawing.Point(28, 231);
            this._viewPlayersTable.Name = "_viewPlayersTable";
            this._viewPlayersTable.ReadOnly = true;
            this._viewPlayersTable.RowTemplate.Height = 24;
            this._viewPlayersTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._viewPlayersTable.Size = new System.Drawing.Size(449, 197);
            this._viewPlayersTable.TabIndex = 0;
            this._viewPlayersTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._viewPlayersTable_CellContentClick);
            this._viewPlayersTable.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._viewPlayersTable_MouseDoubleClick);
            // 
            // _logoImg
            // 
            this._logoImg.Image = global::PlayerFormApp.Properties.Resources.logo_symbol;
            this._logoImg.Location = new System.Drawing.Point(541, 26);
            this._logoImg.Name = "_logoImg";
            this._logoImg.Size = new System.Drawing.Size(147, 151);
            this._logoImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._logoImg.TabIndex = 1;
            this._logoImg.TabStop = false;
            // 
            // _loadButton
            // 
            this._loadButton.Location = new System.Drawing.Point(360, 434);
            this._loadButton.Name = "_loadButton";
            this._loadButton.Size = new System.Drawing.Size(117, 29);
            this._loadButton.TabIndex = 2;
            this._loadButton.Text = "Load Players";
            this._loadButton.UseVisualStyleBackColor = true;
            this._loadButton.Click += new System.EventHandler(this._loadButton_Click);
            // 
            // _updateButton
            // 
            this._updateButton.Location = new System.Drawing.Point(370, 88);
            this._updateButton.Name = "_updateButton";
            this._updateButton.Size = new System.Drawing.Size(76, 43);
            this._updateButton.TabIndex = 3;
            this._updateButton.Text = "Update Player";
            this._updateButton.UseVisualStyleBackColor = true;
            this._updateButton.Visible = false;
            this._updateButton.Click += new System.EventHandler(this._updateButton_Click);
            // 
            // _deleteButton
            // 
            this._deleteButton.Location = new System.Drawing.Point(370, 150);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(76, 43);
            this._deleteButton.TabIndex = 4;
            this._deleteButton.Text = "Delete Player";
            this._deleteButton.UseVisualStyleBackColor = true;
            this._deleteButton.Visible = false;
            this._deleteButton.Click += new System.EventHandler(this._deleteButton_Click);
            // 
            // _newButton
            // 
            this._newButton.Location = new System.Drawing.Point(370, 26);
            this._newButton.Name = "_newButton";
            this._newButton.Size = new System.Drawing.Size(76, 43);
            this._newButton.TabIndex = 5;
            this._newButton.Text = "New Player";
            this._newButton.UseVisualStyleBackColor = true;
            this._newButton.Click += new System.EventHandler(this._newButton_Click);
            // 
            // _idLabel
            // 
            this._idLabel.AutoSize = true;
            this._idLabel.Location = new System.Drawing.Point(86, 23);
            this._idLabel.Name = "_idLabel";
            this._idLabel.Size = new System.Drawing.Size(65, 17);
            this._idLabel.TabIndex = 6;
            this._idLabel.Text = "Player ID";
            // 
            // _speedLabel
            // 
            this._speedLabel.AutoSize = true;
            this._speedLabel.Location = new System.Drawing.Point(40, 170);
            this._speedLabel.Name = "_speedLabel";
            this._speedLabel.Size = new System.Drawing.Size(111, 17);
            this._speedLabel.TabIndex = 7;
            this._speedLabel.Text = "Maximum Speed";
            // 
            // _distanceLabel
            // 
            this._distanceLabel.AutoSize = true;
            this._distanceLabel.Location = new System.Drawing.Point(31, 140);
            this._distanceLabel.Name = "_distanceLabel";
            this._distanceLabel.Size = new System.Drawing.Size(120, 17);
            this._distanceLabel.TabIndex = 8;
            this._distanceLabel.Text = "Running Distance";
            // 
            // _heightLabel
            // 
            this._heightLabel.AutoSize = true;
            this._heightLabel.Location = new System.Drawing.Point(58, 109);
            this._heightLabel.Name = "_heightLabel";
            this._heightLabel.Size = new System.Drawing.Size(93, 17);
            this._heightLabel.TabIndex = 9;
            this._heightLabel.Text = "Player Height";
            // 
            // _ageLabel
            // 
            this._ageLabel.AutoSize = true;
            this._ageLabel.Location = new System.Drawing.Point(74, 79);
            this._ageLabel.Name = "_ageLabel";
            this._ageLabel.Size = new System.Drawing.Size(77, 17);
            this._ageLabel.TabIndex = 10;
            this._ageLabel.Text = "Player Age";
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(62, 52);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(89, 17);
            this._nameLabel.TabIndex = 11;
            this._nameLabel.Text = "Player Name";
            // 
            // heightTextBox
            // 
            this.heightTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.heightTextBox.Location = new System.Drawing.Point(167, 109);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.ReadOnly = true;
            this.heightTextBox.Size = new System.Drawing.Size(100, 22);
            this.heightTextBox.TabIndex = 12;
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(167, 23);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ReadOnly = true;
            this.idTextBox.Size = new System.Drawing.Size(100, 22);
            this.idTextBox.TabIndex = 13;
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nameTextBox.Location = new System.Drawing.Point(167, 52);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(100, 22);
            this.nameTextBox.TabIndex = 14;
            // 
            // ageTextBox
            // 
            this.ageTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ageTextBox.Location = new System.Drawing.Point(167, 79);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.ReadOnly = true;
            this.ageTextBox.Size = new System.Drawing.Size(100, 22);
            this.ageTextBox.TabIndex = 15;
            // 
            // distanceTextBox
            // 
            this.distanceTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.distanceTextBox.Location = new System.Drawing.Point(167, 140);
            this.distanceTextBox.Name = "distanceTextBox";
            this.distanceTextBox.ReadOnly = true;
            this.distanceTextBox.Size = new System.Drawing.Size(100, 22);
            this.distanceTextBox.TabIndex = 16;
            // 
            // speedTextBox
            // 
            this.speedTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.speedTextBox.Location = new System.Drawing.Point(167, 170);
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.ReadOnly = true;
            this.speedTextBox.Size = new System.Drawing.Size(100, 22);
            this.speedTextBox.TabIndex = 17;
            // 
            // updateAgeButton
            // 
            this.updateAgeButton.Location = new System.Drawing.Point(273, 79);
            this.updateAgeButton.Name = "updateAgeButton";
            this.updateAgeButton.Size = new System.Drawing.Size(75, 23);
            this.updateAgeButton.TabIndex = 18;
            this.updateAgeButton.Text = "Update";
            this.updateAgeButton.UseVisualStyleBackColor = true;
            this.updateAgeButton.Visible = false;
            this.updateAgeButton.Click += new System.EventHandler(this.updateAgeButton_Click);
            // 
            // updateSpeedButton
            // 
            this.updateSpeedButton.Location = new System.Drawing.Point(273, 170);
            this.updateSpeedButton.Name = "updateSpeedButton";
            this.updateSpeedButton.Size = new System.Drawing.Size(75, 23);
            this.updateSpeedButton.TabIndex = 19;
            this.updateSpeedButton.Text = "Update";
            this.updateSpeedButton.UseVisualStyleBackColor = true;
            this.updateSpeedButton.Visible = false;
            this.updateSpeedButton.Click += new System.EventHandler(this.updateSpeedButton_Click);
            // 
            // updateDistanceButton
            // 
            this.updateDistanceButton.Location = new System.Drawing.Point(273, 137);
            this.updateDistanceButton.Name = "updateDistanceButton";
            this.updateDistanceButton.Size = new System.Drawing.Size(75, 23);
            this.updateDistanceButton.TabIndex = 20;
            this.updateDistanceButton.Text = "Update";
            this.updateDistanceButton.UseVisualStyleBackColor = true;
            this.updateDistanceButton.Visible = false;
            this.updateDistanceButton.Click += new System.EventHandler(this.updateDistanceButton_Click);
            // 
            // statsDistance
            // 
            this.statsDistance.Location = new System.Drawing.Point(600, 428);
            this.statsDistance.Name = "statsDistance";
            this.statsDistance.Size = new System.Drawing.Size(88, 30);
            this.statsDistance.TabIndex = 21;
            this.statsDistance.Text = "Distance";
            this.statsDistance.UseVisualStyleBackColor = true;
            // 
            // statsSpeed
            // 
            this.statsSpeed.Location = new System.Drawing.Point(601, 388);
            this.statsSpeed.Name = "statsSpeed";
            this.statsSpeed.Size = new System.Drawing.Size(87, 34);
            this.statsSpeed.TabIndex = 22;
            this.statsSpeed.Text = "Max Speed";
            this.statsSpeed.UseVisualStyleBackColor = true;
            // 
            // _statsLabel
            // 
            this._statsLabel.AutoSize = true;
            this._statsLabel.Location = new System.Drawing.Point(544, 231);
            this._statsLabel.Name = "_statsLabel";
            this._statsLabel.Size = new System.Drawing.Size(127, 17);
            this._statsLabel.TabIndex = 23;
            this._statsLabel.Text = "Statistics Summary";
            // 
            // _maxLabel
            // 
            this._maxLabel.AutoSize = true;
            this._maxLabel.Location = new System.Drawing.Point(509, 277);
            this._maxLabel.Name = "_maxLabel";
            this._maxLabel.Size = new System.Drawing.Size(66, 17);
            this._maxLabel.TabIndex = 24;
            this._maxLabel.Text = "Maximum";
            // 
            // _minLabel
            // 
            this._minLabel.AutoSize = true;
            this._minLabel.Location = new System.Drawing.Point(509, 312);
            this._minLabel.Name = "_minLabel";
            this._minLabel.Size = new System.Drawing.Size(63, 17);
            this._minLabel.TabIndex = 25;
            this._minLabel.Text = "Minimum";
            // 
            // _meanLabel
            // 
            this._meanLabel.AutoSize = true;
            this._meanLabel.Location = new System.Drawing.Point(509, 349);
            this._meanLabel.Name = "_meanLabel";
            this._meanLabel.Size = new System.Drawing.Size(61, 17);
            this._meanLabel.TabIndex = 26;
            this._meanLabel.Text = "Average";
            // 
            // maxTextBox
            // 
            this.maxTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.maxTextBox.Location = new System.Drawing.Point(601, 276);
            this.maxTextBox.Name = "maxTextBox";
            this.maxTextBox.ReadOnly = true;
            this.maxTextBox.Size = new System.Drawing.Size(100, 22);
            this.maxTextBox.TabIndex = 27;
            // 
            // meanTextBox
            // 
            this.meanTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.meanTextBox.Location = new System.Drawing.Point(601, 349);
            this.meanTextBox.Name = "meanTextBox";
            this.meanTextBox.ReadOnly = true;
            this.meanTextBox.Size = new System.Drawing.Size(100, 22);
            this.meanTextBox.TabIndex = 28;
            // 
            // minTextBox
            // 
            this.minTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.minTextBox.Location = new System.Drawing.Point(601, 312);
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.ReadOnly = true;
            this.minTextBox.Size = new System.Drawing.Size(100, 22);
            this.minTextBox.TabIndex = 29;
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(370, 26);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(76, 43);
            this.doneButton.TabIndex = 30;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Visible = false;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // _addToDatabase
            // 
            this._addToDatabase.Location = new System.Drawing.Point(370, 26);
            this._addToDatabase.Name = "_addToDatabase";
            this._addToDatabase.Size = new System.Drawing.Size(76, 43);
            this._addToDatabase.TabIndex = 31;
            this._addToDatabase.Text = "Add Player";
            this._addToDatabase.UseVisualStyleBackColor = true;
            this._addToDatabase.Visible = false;
            this._addToDatabase.Click += new System.EventHandler(this._addToDatabase_Click);
            // 
            // playerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(746, 483);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.minTextBox);
            this.Controls.Add(this.meanTextBox);
            this.Controls.Add(this.maxTextBox);
            this.Controls.Add(this._meanLabel);
            this.Controls.Add(this._minLabel);
            this.Controls.Add(this._maxLabel);
            this.Controls.Add(this._statsLabel);
            this.Controls.Add(this.statsSpeed);
            this.Controls.Add(this.statsDistance);
            this.Controls.Add(this.updateDistanceButton);
            this.Controls.Add(this.updateSpeedButton);
            this.Controls.Add(this.updateAgeButton);
            this.Controls.Add(this.speedTextBox);
            this.Controls.Add(this.distanceTextBox);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._ageLabel);
            this.Controls.Add(this._heightLabel);
            this.Controls.Add(this._distanceLabel);
            this.Controls.Add(this._speedLabel);
            this.Controls.Add(this._idLabel);
            this.Controls.Add(this._newButton);
            this.Controls.Add(this._deleteButton);
            this.Controls.Add(this._updateButton);
            this.Controls.Add(this._loadButton);
            this.Controls.Add(this._logoImg);
            this.Controls.Add(this._viewPlayersTable);
            this.Controls.Add(this._addToDatabase);
            this.Name = "playerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player Form";
            this.Load += new System.EventHandler(this.playerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._viewPlayersTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._logoImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _viewPlayersTable;
        private System.Windows.Forms.PictureBox _logoImg;
        private System.Windows.Forms.Button _loadButton;
        private System.Windows.Forms.Button _updateButton;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.Button _newButton;
        private System.Windows.Forms.Label _idLabel;
        private System.Windows.Forms.Label _speedLabel;
        private System.Windows.Forms.Label _distanceLabel;
        private System.Windows.Forms.Label _heightLabel;
        private System.Windows.Forms.Label _ageLabel;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.TextBox distanceTextBox;
        private System.Windows.Forms.TextBox speedTextBox;
        private System.Windows.Forms.Button updateAgeButton;
        private System.Windows.Forms.Button updateSpeedButton;
        private System.Windows.Forms.Button updateDistanceButton;
        private System.Windows.Forms.Button statsDistance;
        private System.Windows.Forms.Button statsSpeed;
        private System.Windows.Forms.Label _statsLabel;
        private System.Windows.Forms.Label _maxLabel;
        private System.Windows.Forms.Label _minLabel;
        private System.Windows.Forms.Label _meanLabel;
        private System.Windows.Forms.TextBox maxTextBox;
        private System.Windows.Forms.TextBox meanTextBox;
        private System.Windows.Forms.TextBox minTextBox;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button _addToDatabase;
    }
}

