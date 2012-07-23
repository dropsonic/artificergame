using System;

namespace System.ComponentModel
{
    internal class CustomComponentResourceManager : ComponentResourceManager
    {
        public CustomComponentResourceManager(Type type, string resourceName)
            : base(type)
        {
            this.BaseNameField = resourceName;
        }
    }

    partial class ListEditorForm<T>
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
            System.ComponentModel.ComponentResourceManager resources = new CustomComponentResourceManager(typeof(ListEditorForm<T>), "ListEditorForm");
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.membersLabel = new System.Windows.Forms.Label();
            this.propertiesLabel = new System.Windows.Forms.Label();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.okCancelPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.listControlsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.downButton = new System.Windows.Forms.Button();
            this.itemsListBox = new System.Windows.Forms.ListBox();
            this.upButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.okCancelPanel.SuspendLayout();
            this.listControlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.membersLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.propertiesLabel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.propertyGrid, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.okCancelPanel, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.listControlsPanel, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(12, 12, 8, 0);
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(539, 411);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // membersLabel
            // 
            this.membersLabel.AutoSize = true;
            this.membersLabel.Location = new System.Drawing.Point(15, 12);
            this.membersLabel.Name = "membersLabel";
            this.membersLabel.Size = new System.Drawing.Size(53, 13);
            this.membersLabel.TabIndex = 0;
            this.membersLabel.Text = "Members:";
            // 
            // propertiesLabel
            // 
            this.propertiesLabel.AutoSize = true;
            this.propertiesLabel.Location = new System.Drawing.Point(274, 12);
            this.propertiesLabel.Name = "propertiesLabel";
            this.propertiesLabel.Size = new System.Drawing.Size(57, 13);
            this.propertiesLabel.TabIndex = 1;
            this.propertiesLabel.Text = "Properties:";
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.Location = new System.Drawing.Point(274, 40);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(254, 328);
            this.propertyGrid.TabIndex = 2;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            // 
            // okCancelPanel
            // 
            this.okCancelPanel.ColumnCount = 3;
            this.okCancelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.okCancelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.okCancelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.okCancelPanel.Controls.Add(this.cancelButton, 2, 0);
            this.okCancelPanel.Controls.Add(this.okButton, 1, 0);
            this.okCancelPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okCancelPanel.Location = new System.Drawing.Point(271, 371);
            this.okCancelPanel.Margin = new System.Windows.Forms.Padding(0);
            this.okCancelPanel.Name = "okCancelPanel";
            this.okCancelPanel.RowCount = 1;
            this.okCancelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.okCancelPanel.Size = new System.Drawing.Size(260, 40);
            this.okCancelPanel.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancelButton.Location = new System.Drawing.Point(178, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(79, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.okButton.Location = new System.Drawing.Point(93, 8);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(79, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // listControlsPanel
            // 
            this.listControlsPanel.ColumnCount = 3;
            this.listControlsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.listControlsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.listControlsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.listControlsPanel.Controls.Add(this.downButton, 2, 1);
            this.listControlsPanel.Controls.Add(this.itemsListBox, 0, 0);
            this.listControlsPanel.Controls.Add(this.upButton, 2, 0);
            this.listControlsPanel.Controls.Add(this.removeButton, 1, 3);
            this.listControlsPanel.Controls.Add(this.addButton, 0, 3);
            this.listControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listControlsPanel.Location = new System.Drawing.Point(15, 40);
            this.listControlsPanel.Name = "listControlsPanel";
            this.listControlsPanel.RowCount = 4;
            this.listControlsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.listControlsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.listControlsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.listControlsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.listControlsPanel.Size = new System.Drawing.Size(253, 328);
            this.listControlsPanel.TabIndex = 4;
            // 
            // downButton
            // 
            this.downButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downButton.Image = ((System.Drawing.Image)(resources.GetObject("downButton.Image")));
            this.downButton.Location = new System.Drawing.Point(215, 43);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(35, 34);
            this.downButton.TabIndex = 9;
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // itemsListBox
            // 
            this.listControlsPanel.SetColumnSpan(this.itemsListBox, 2);
            this.itemsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsListBox.FormattingEnabled = true;
            this.itemsListBox.Location = new System.Drawing.Point(3, 3);
            this.itemsListBox.Name = "itemsListBox";
            this.listControlsPanel.SetRowSpan(this.itemsListBox, 3);
            this.itemsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.itemsListBox.Size = new System.Drawing.Size(206, 282);
            this.itemsListBox.TabIndex = 5;
            this.itemsListBox.SelectedValueChanged += new System.EventHandler(this.itemsListBox_SelectedValueChanged);
            // 
            // upButton
            // 
            this.upButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upButton.Image = ((System.Drawing.Image)(resources.GetObject("upButton.Image")));
            this.upButton.Location = new System.Drawing.Point(215, 3);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(35, 34);
            this.upButton.TabIndex = 8;
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(109, 296);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(100, 23);
            this.removeButton.TabIndex = 10;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(3, 296);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 23);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // ListEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 411);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListEditorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List Editor";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.okCancelPanel.ResumeLayout(false);
            this.listControlsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label membersLabel;
        private System.Windows.Forms.Label propertiesLabel;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.TableLayoutPanel okCancelPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TableLayoutPanel listControlsPanel;
        private System.Windows.Forms.ListBox itemsListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button removeButton;
    }
}