/* ========================================================================
 * Copyright (c) 2005-2019 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

namespace Quickstarts.DataAccessClient
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_DiscoverMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_ConnectMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_DisconnectMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_SetLocaleMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_SetUserMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAddressSpaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMI = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMI = new System.Windows.Forms.ToolStripMenuItem();
            this.File_LoadMI = new System.Windows.Forms.ToolStripMenuItem();
            this.File_SaveMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_ContentsMI = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.saveProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.MainPN = new System.Windows.Forms.SplitContainer();
            this.TopPN = new System.Windows.Forms.SplitContainer();
            this.BrowseNodesTV = new System.Windows.Forms.TreeView();
            this.BrowsingMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Browse_MonitorMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Browse_WriteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Browse_ReadHistoryMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelServer = new System.Windows.Forms.Panel();
            this.boxBrowsePath = new System.Windows.Forms.TextBox();
            this.AttributesLV = new System.Windows.Forms.ListView();
            this.AttributeNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttributeDataTypeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AttributeValueCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelObjects = new System.Windows.Forms.Panel();
            this.boxNodeName = new System.Windows.Forms.TextBox();
            this.MonitoredItemsLV = new System.Windows.Forms.ListView();
            this.MonitoredItemIdCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VariableNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MonitoringModeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SamplingIntevalCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeadbandCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValueCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QualityCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimestampCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastOperationStatusCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MonitoringMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Monitoring_DeleteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_WriteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringModeMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_DisabledMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_SamplingMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_ReportingMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingIntervalMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_FastMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_1000MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_2500MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_5000MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_DeadbandMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_NoneMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_AbsoluteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_5MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_10MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_25MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_PercentageMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_1MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_5MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_10MI = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectServerCTRL = new Opc.Ua.Client.Controls.ConnectServerCtrl();
            this.MenuBar.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPN)).BeginInit();
            this.MainPN.Panel1.SuspendLayout();
            this.MainPN.Panel2.SuspendLayout();
            this.MainPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopPN)).BeginInit();
            this.TopPN.Panel1.SuspendLayout();
            this.TopPN.Panel2.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.BrowsingMenu.SuspendLayout();
            this.panelServer.SuspendLayout();
            this.panelObjects.SuspendLayout();
            this.MonitoringMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.ServerMI,
            this.ViewMI,
            this.FileMI,
            this.HelpMI});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(1063, 24);
            this.MenuBar.TabIndex = 1;
            this.MenuBar.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fILEToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ServerMI
            // 
            this.ServerMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Server_DiscoverMI,
            this.Server_ConnectMI,
            this.Server_DisconnectMI,
            this.Server_SetLocaleMI,
            this.Server_SetUserMI,
            this.toolStripMenuItem2,
            this.saveAddressSpaceToolStripMenuItem});
            this.ServerMI.Name = "ServerMI";
            this.ServerMI.Size = new System.Drawing.Size(51, 20);
            this.ServerMI.Text = "Server";
            // 
            // Server_DiscoverMI
            // 
            this.Server_DiscoverMI.Name = "Server_DiscoverMI";
            this.Server_DiscoverMI.Size = new System.Drawing.Size(186, 22);
            this.Server_DiscoverMI.Text = "Discover...";
            this.Server_DiscoverMI.Click += new System.EventHandler(this.Server_DiscoverMI_Click);
            // 
            // Server_ConnectMI
            // 
            this.Server_ConnectMI.Name = "Server_ConnectMI";
            this.Server_ConnectMI.Size = new System.Drawing.Size(186, 22);
            this.Server_ConnectMI.Text = "Connect";
            this.Server_ConnectMI.Click += new System.EventHandler(this.Server_ConnectMI_ClickAsync);
            // 
            // Server_DisconnectMI
            // 
            this.Server_DisconnectMI.Name = "Server_DisconnectMI";
            this.Server_DisconnectMI.Size = new System.Drawing.Size(186, 22);
            this.Server_DisconnectMI.Text = "Disconnect";
            this.Server_DisconnectMI.Click += new System.EventHandler(this.Server_DisconnectMI_Click);
            // 
            // Server_SetLocaleMI
            // 
            this.Server_SetLocaleMI.Name = "Server_SetLocaleMI";
            this.Server_SetLocaleMI.Size = new System.Drawing.Size(186, 22);
            this.Server_SetLocaleMI.Text = "Select Locale...";
            this.Server_SetLocaleMI.Click += new System.EventHandler(this.Server_SetLocaleMI_Click);
            // 
            // Server_SetUserMI
            // 
            this.Server_SetUserMI.Name = "Server_SetUserMI";
            this.Server_SetUserMI.Size = new System.Drawing.Size(186, 22);
            this.Server_SetUserMI.Text = "Set User...";
            this.Server_SetUserMI.Click += new System.EventHandler(this.Server_SetUserMI_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(183, 6);
            // 
            // saveAddressSpaceToolStripMenuItem
            // 
            this.saveAddressSpaceToolStripMenuItem.Name = "saveAddressSpaceToolStripMenuItem";
            this.saveAddressSpaceToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAddressSpaceToolStripMenuItem.Text = "Save Address Space...";
            this.saveAddressSpaceToolStripMenuItem.Click += new System.EventHandler(this.saveAddressSpaceToolStripMenuItem_Click);
            // 
            // ViewMI
            // 
            this.ViewMI.Name = "ViewMI";
            this.ViewMI.Size = new System.Drawing.Size(44, 20);
            this.ViewMI.Text = "View";
            // 
            // FileMI
            // 
            this.FileMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_LoadMI,
            this.File_SaveMI});
            this.FileMI.Name = "FileMI";
            this.FileMI.Size = new System.Drawing.Size(107, 20);
            this.FileMI.Text = "Monitored Items";
            // 
            // File_LoadMI
            // 
            this.File_LoadMI.Name = "File_LoadMI";
            this.File_LoadMI.Size = new System.Drawing.Size(109, 22);
            this.File_LoadMI.Text = "Load...";
            this.File_LoadMI.Click += new System.EventHandler(this.File_LoadMI_Click);
            // 
            // File_SaveMI
            // 
            this.File_SaveMI.Name = "File_SaveMI";
            this.File_SaveMI.Size = new System.Drawing.Size(109, 22);
            this.File_SaveMI.Text = "Save...";
            this.File_SaveMI.Click += new System.EventHandler(this.File_SaveMI_Click);
            // 
            // HelpMI
            // 
            this.HelpMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help_ContentsMI});
            this.HelpMI.Name = "HelpMI";
            this.HelpMI.Size = new System.Drawing.Size(44, 20);
            this.HelpMI.Text = "Help";
            // 
            // Help_ContentsMI
            // 
            this.Help_ContentsMI.Name = "Help_ContentsMI";
            this.Help_ContentsMI.Size = new System.Drawing.Size(122, 22);
            this.Help_ContentsMI.Text = "Contents";
            this.Help_ContentsMI.Click += new System.EventHandler(this.Help_ContentsMI_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveProgressBar});
            this.StatusBar.Location = new System.Drawing.Point(0, 654);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(1063, 22);
            this.StatusBar.TabIndex = 2;
            // 
            // saveProgressBar
            // 
            this.saveProgressBar.ForeColor = System.Drawing.Color.Lime;
            this.saveProgressBar.Name = "saveProgressBar";
            this.saveProgressBar.Size = new System.Drawing.Size(200, 16);
            this.saveProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.saveProgressBar.Visible = false;
            // 
            // MainPN
            // 
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 47);
            this.MainPN.Name = "MainPN";
            this.MainPN.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainPN.Panel1
            // 
            this.MainPN.Panel1.Controls.Add(this.TopPN);
            // 
            // MainPN.Panel2
            // 
            this.MainPN.Panel2.Controls.Add(this.MonitoredItemsLV);
            this.MainPN.Size = new System.Drawing.Size(1063, 607);
            this.MainPN.SplitterDistance = 417;
            this.MainPN.TabIndex = 1;
            // 
            // TopPN
            // 
            this.TopPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPN.Location = new System.Drawing.Point(0, 0);
            this.TopPN.Name = "TopPN";
            // 
            // TopPN.Panel1
            // 
            this.TopPN.Panel1.Controls.Add(this.BrowseNodesTV);
            this.TopPN.Panel1.Controls.Add(this.panelServer);
            // 
            // TopPN.Panel2
            // 
            this.TopPN.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TopPN.Panel2.Controls.Add(this.AttributesLV);
            this.TopPN.Panel2.Controls.Add(this.panelObjects);
            this.TopPN.Panel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TopPN.Size = new System.Drawing.Size(1063, 417);
            this.TopPN.SplitterDistance = 468;
            this.TopPN.TabIndex = 0;
            // 
            // BrowseNodesTV
            // 
            this.BrowseNodesTV.ContextMenuStrip = this.BrowsingMenu;
            this.BrowseNodesTV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowseNodesTV.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseNodesTV.HideSelection = false;
            this.BrowseNodesTV.ImageIndex = 0;
            this.BrowseNodesTV.ImageList = this.imageList1;
            this.BrowseNodesTV.Indent = 20;
            this.BrowseNodesTV.Location = new System.Drawing.Point(0, 27);
            this.BrowseNodesTV.Name = "BrowseNodesTV";
            this.BrowseNodesTV.SelectedImageIndex = 0;
            this.BrowseNodesTV.Size = new System.Drawing.Size(468, 390);
            this.BrowseNodesTV.TabIndex = 0;
            this.BrowseNodesTV.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.BrowseNodesTV_BeforeExpand);
            this.BrowseNodesTV.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.BrowseNodesTV_DrawNode);
            this.BrowseNodesTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.BrowseNodesTV_AfterSelect);
            this.BrowseNodesTV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BrowseNodesTV_MouseDown);
            // 
            // BrowsingMenu
            // 
            this.BrowsingMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Browse_MonitorMI,
            this.Browse_WriteMI,
            this.Browse_ReadHistoryMI,
            this.toolStripMenuItem1,
            this.saveAsToolStripMenuItem});
            this.BrowsingMenu.Name = "BrowsingMenu";
            this.BrowsingMenu.Size = new System.Drawing.Size(151, 98);
            this.BrowsingMenu.Opening += new System.ComponentModel.CancelEventHandler(this.BrowsingMenu_Opening);
            // 
            // Browse_MonitorMI
            // 
            this.Browse_MonitorMI.Name = "Browse_MonitorMI";
            this.Browse_MonitorMI.Size = new System.Drawing.Size(150, 22);
            this.Browse_MonitorMI.Text = "Monitor";
            this.Browse_MonitorMI.Click += new System.EventHandler(this.Browse_MonitorMI_Click);
            // 
            // Browse_WriteMI
            // 
            this.Browse_WriteMI.Name = "Browse_WriteMI";
            this.Browse_WriteMI.Size = new System.Drawing.Size(150, 22);
            this.Browse_WriteMI.Text = "Write...";
            this.Browse_WriteMI.Click += new System.EventHandler(this.Browse_WriteMI_Click);
            // 
            // Browse_ReadHistoryMI
            // 
            this.Browse_ReadHistoryMI.Name = "Browse_ReadHistoryMI";
            this.Browse_ReadHistoryMI.Size = new System.Drawing.Size(150, 22);
            this.Browse_ReadHistoryMI.Text = "Read History...";
            this.Browse_ReadHistoryMI.Click += new System.EventHandler(this.Browse_ReadHistoryMI_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "attribute");
            this.imageList1.Images.SetKeyName(1, "property");
            this.imageList1.Images.SetKeyName(2, "variable");
            this.imageList1.Images.SetKeyName(3, "method");
            this.imageList1.Images.SetKeyName(4, "object");
            this.imageList1.Images.SetKeyName(5, "open_folder");
            this.imageList1.Images.SetKeyName(6, "closed-folder");
            this.imageList1.Images.SetKeyName(7, "object_type");
            this.imageList1.Images.SetKeyName(8, "view");
            this.imageList1.Images.SetKeyName(9, "reference");
            this.imageList1.Images.SetKeyName(10, "number_value");
            this.imageList1.Images.SetKeyName(11, "string_value");
            this.imageList1.Images.SetKeyName(12, "byte_string_value");
            this.imageList1.Images.SetKeyName(13, "structure_value");
            this.imageList1.Images.SetKeyName(14, "array_value");
            this.imageList1.Images.SetKeyName(15, "input_argument");
            this.imageList1.Images.SetKeyName(16, "output_argument");
            // 
            // panelServer
            // 
            this.panelServer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelServer.Controls.Add(this.boxBrowsePath);
            this.panelServer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelServer.Location = new System.Drawing.Point(0, 0);
            this.panelServer.Name = "panelServer";
            this.panelServer.Size = new System.Drawing.Size(468, 27);
            this.panelServer.TabIndex = 1;
            this.panelServer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelServerName_MouseClick);
            // 
            // boxBrowsePath
            // 
            this.boxBrowsePath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxBrowsePath.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.boxBrowsePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boxBrowsePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxBrowsePath.ForeColor = System.Drawing.SystemColors.Info;
            this.boxBrowsePath.Location = new System.Drawing.Point(5, 7);
            this.boxBrowsePath.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.boxBrowsePath.Name = "boxBrowsePath";
            this.boxBrowsePath.ReadOnly = true;
            this.boxBrowsePath.Size = new System.Drawing.Size(469, 19);
            this.boxBrowsePath.TabIndex = 2;
            this.boxBrowsePath.TabStop = false;
            this.boxBrowsePath.Text = "Server";
            this.boxBrowsePath.WordWrap = false;
            // 
            // AttributesLV
            // 
            this.AttributesLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AttributeNameCH,
            this.AttributeDataTypeCH,
            this.AttributeValueCH});
            this.AttributesLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttributesLV.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttributesLV.FullRowSelect = true;
            this.AttributesLV.HideSelection = false;
            this.AttributesLV.Location = new System.Drawing.Point(0, 27);
            this.AttributesLV.Name = "AttributesLV";
            this.AttributesLV.Size = new System.Drawing.Size(591, 390);
            this.AttributesLV.TabIndex = 0;
            this.AttributesLV.UseCompatibleStateImageBehavior = false;
            this.AttributesLV.View = System.Windows.Forms.View.Details;
            // 
            // AttributeNameCH
            // 
            this.AttributeNameCH.Text = "Name";
            // 
            // AttributeDataTypeCH
            // 
            this.AttributeDataTypeCH.DisplayIndex = 2;
            this.AttributeDataTypeCH.Text = "Data Type";
            this.AttributeDataTypeCH.Width = 102;
            // 
            // AttributeValueCH
            // 
            this.AttributeValueCH.DisplayIndex = 1;
            this.AttributeValueCH.Text = "Value";
            // 
            // panelObjects
            // 
            this.panelObjects.Controls.Add(this.boxNodeName);
            this.panelObjects.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelObjects.Location = new System.Drawing.Point(0, 0);
            this.panelObjects.Margin = new System.Windows.Forms.Padding(0);
            this.panelObjects.Name = "panelObjects";
            this.panelObjects.Size = new System.Drawing.Size(591, 27);
            this.panelObjects.TabIndex = 2;
            // 
            // boxNodeName
            // 
            this.boxNodeName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxNodeName.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.boxNodeName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boxNodeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxNodeName.ForeColor = System.Drawing.SystemColors.Info;
            this.boxNodeName.Location = new System.Drawing.Point(5, 7);
            this.boxNodeName.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.boxNodeName.Name = "boxNodeName";
            this.boxNodeName.ReadOnly = true;
            this.boxNodeName.Size = new System.Drawing.Size(588, 19);
            this.boxNodeName.TabIndex = 1;
            this.boxNodeName.TabStop = false;
            this.boxNodeName.Text = "Objects";
            this.boxNodeName.WordWrap = false;
            // 
            // MonitoredItemsLV
            // 
            this.MonitoredItemsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MonitoredItemIdCH,
            this.VariableNameCH,
            this.MonitoringModeCH,
            this.SamplingIntevalCH,
            this.DeadbandCH,
            this.ValueCH,
            this.QualityCH,
            this.TimestampCH,
            this.LastOperationStatusCH});
            this.MonitoredItemsLV.ContextMenuStrip = this.MonitoringMenu;
            this.MonitoredItemsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitoredItemsLV.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonitoredItemsLV.FullRowSelect = true;
            this.MonitoredItemsLV.HideSelection = false;
            this.MonitoredItemsLV.Location = new System.Drawing.Point(0, 0);
            this.MonitoredItemsLV.Name = "MonitoredItemsLV";
            this.MonitoredItemsLV.Size = new System.Drawing.Size(1063, 186);
            this.MonitoredItemsLV.TabIndex = 0;
            this.MonitoredItemsLV.UseCompatibleStateImageBehavior = false;
            this.MonitoredItemsLV.View = System.Windows.Forms.View.Details;
            // 
            // MonitoredItemIdCH
            // 
            this.MonitoredItemIdCH.Text = "ID";
            // 
            // VariableNameCH
            // 
            this.VariableNameCH.Text = "Variable";
            // 
            // MonitoringModeCH
            // 
            this.MonitoringModeCH.Text = "Mode";
            // 
            // SamplingIntevalCH
            // 
            this.SamplingIntevalCH.Text = "Sampling Rate";
            this.SamplingIntevalCH.Width = 98;
            // 
            // DeadbandCH
            // 
            this.DeadbandCH.Text = "Deadband";
            this.DeadbandCH.Width = 89;
            // 
            // ValueCH
            // 
            this.ValueCH.Text = "Value";
            // 
            // QualityCH
            // 
            this.QualityCH.Text = "Quality";
            // 
            // TimestampCH
            // 
            this.TimestampCH.Text = "Timestamp";
            this.TimestampCH.Width = 109;
            // 
            // LastOperationStatusCH
            // 
            this.LastOperationStatusCH.Text = "Last Error";
            // 
            // MonitoringMenu
            // 
            this.MonitoringMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_DeleteMI,
            this.Monitoring_WriteMI,
            this.Monitoring_MonitoringModeMI,
            this.Monitoring_SamplingIntervalMI,
            this.Monitoring_DeadbandMI});
            this.MonitoringMenu.Name = "MonitoringMenu";
            this.MonitoringMenu.Size = new System.Drawing.Size(169, 114);
            // 
            // Monitoring_DeleteMI
            // 
            this.Monitoring_DeleteMI.Name = "Monitoring_DeleteMI";
            this.Monitoring_DeleteMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_DeleteMI.Text = "Delete";
            this.Monitoring_DeleteMI.Click += new System.EventHandler(this.Monitoring_DeleteMI_Click);
            // 
            // Monitoring_WriteMI
            // 
            this.Monitoring_WriteMI.Name = "Monitoring_WriteMI";
            this.Monitoring_WriteMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_WriteMI.Text = "Write...";
            this.Monitoring_WriteMI.Click += new System.EventHandler(this.Monitoring_WriteMI_Click);
            // 
            // Monitoring_MonitoringModeMI
            // 
            this.Monitoring_MonitoringModeMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_MonitoringMode_DisabledMI,
            this.Monitoring_MonitoringMode_SamplingMI,
            this.Monitoring_MonitoringMode_ReportingMI});
            this.Monitoring_MonitoringModeMI.Name = "Monitoring_MonitoringModeMI";
            this.Monitoring_MonitoringModeMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_MonitoringModeMI.Text = "Monitoring Mode";
            // 
            // Monitoring_MonitoringMode_DisabledMI
            // 
            this.Monitoring_MonitoringMode_DisabledMI.Name = "Monitoring_MonitoringMode_DisabledMI";
            this.Monitoring_MonitoringMode_DisabledMI.Size = new System.Drawing.Size(126, 22);
            this.Monitoring_MonitoringMode_DisabledMI.Text = "Disabled";
            this.Monitoring_MonitoringMode_DisabledMI.Click += new System.EventHandler(this.Monitoring_MonitoringMode_Click);
            // 
            // Monitoring_MonitoringMode_SamplingMI
            // 
            this.Monitoring_MonitoringMode_SamplingMI.Name = "Monitoring_MonitoringMode_SamplingMI";
            this.Monitoring_MonitoringMode_SamplingMI.Size = new System.Drawing.Size(126, 22);
            this.Monitoring_MonitoringMode_SamplingMI.Text = "Sampling";
            this.Monitoring_MonitoringMode_SamplingMI.Click += new System.EventHandler(this.Monitoring_MonitoringMode_Click);
            // 
            // Monitoring_MonitoringMode_ReportingMI
            // 
            this.Monitoring_MonitoringMode_ReportingMI.Name = "Monitoring_MonitoringMode_ReportingMI";
            this.Monitoring_MonitoringMode_ReportingMI.Size = new System.Drawing.Size(126, 22);
            this.Monitoring_MonitoringMode_ReportingMI.Text = "Reporting";
            this.Monitoring_MonitoringMode_ReportingMI.Click += new System.EventHandler(this.Monitoring_MonitoringMode_Click);
            // 
            // Monitoring_SamplingIntervalMI
            // 
            this.Monitoring_SamplingIntervalMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_SamplingInterval_FastMI,
            this.Monitoring_SamplingInterval_1000MI,
            this.Monitoring_SamplingInterval_2500MI,
            this.Monitoring_SamplingInterval_5000MI});
            this.Monitoring_SamplingIntervalMI.Name = "Monitoring_SamplingIntervalMI";
            this.Monitoring_SamplingIntervalMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_SamplingIntervalMI.Text = "Samping Interval";
            // 
            // Monitoring_SamplingInterval_FastMI
            // 
            this.Monitoring_SamplingInterval_FastMI.Name = "Monitoring_SamplingInterval_FastMI";
            this.Monitoring_SamplingInterval_FastMI.Size = new System.Drawing.Size(155, 22);
            this.Monitoring_SamplingInterval_FastMI.Text = "Fast as Possible";
            this.Monitoring_SamplingInterval_FastMI.Click += new System.EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_SamplingInterval_1000MI
            // 
            this.Monitoring_SamplingInterval_1000MI.Name = "Monitoring_SamplingInterval_1000MI";
            this.Monitoring_SamplingInterval_1000MI.Size = new System.Drawing.Size(155, 22);
            this.Monitoring_SamplingInterval_1000MI.Text = "1000ms";
            this.Monitoring_SamplingInterval_1000MI.Click += new System.EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_SamplingInterval_2500MI
            // 
            this.Monitoring_SamplingInterval_2500MI.Name = "Monitoring_SamplingInterval_2500MI";
            this.Monitoring_SamplingInterval_2500MI.Size = new System.Drawing.Size(155, 22);
            this.Monitoring_SamplingInterval_2500MI.Text = "2500ms";
            this.Monitoring_SamplingInterval_2500MI.Click += new System.EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_SamplingInterval_5000MI
            // 
            this.Monitoring_SamplingInterval_5000MI.Name = "Monitoring_SamplingInterval_5000MI";
            this.Monitoring_SamplingInterval_5000MI.Size = new System.Drawing.Size(155, 22);
            this.Monitoring_SamplingInterval_5000MI.Text = "5000ms";
            this.Monitoring_SamplingInterval_5000MI.Click += new System.EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_DeadbandMI
            // 
            this.Monitoring_DeadbandMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_Deadband_NoneMI,
            this.Monitoring_Deadband_AbsoluteMI,
            this.Monitoring_Deadband_PercentageMI});
            this.Monitoring_DeadbandMI.Name = "Monitoring_DeadbandMI";
            this.Monitoring_DeadbandMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_DeadbandMI.Text = "Deadband";
            // 
            // Monitoring_Deadband_NoneMI
            // 
            this.Monitoring_Deadband_NoneMI.Name = "Monitoring_Deadband_NoneMI";
            this.Monitoring_Deadband_NoneMI.Size = new System.Drawing.Size(133, 22);
            this.Monitoring_Deadband_NoneMI.Text = "None";
            this.Monitoring_Deadband_NoneMI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_AbsoluteMI
            // 
            this.Monitoring_Deadband_AbsoluteMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_Deadband_Absolute_5MI,
            this.Monitoring_Deadband_Absolute_10MI,
            this.Monitoring_Deadband_Absolute_25MI});
            this.Monitoring_Deadband_AbsoluteMI.Name = "Monitoring_Deadband_AbsoluteMI";
            this.Monitoring_Deadband_AbsoluteMI.Size = new System.Drawing.Size(133, 22);
            this.Monitoring_Deadband_AbsoluteMI.Text = "Absolute";
            // 
            // Monitoring_Deadband_Absolute_5MI
            // 
            this.Monitoring_Deadband_Absolute_5MI.Name = "Monitoring_Deadband_Absolute_5MI";
            this.Monitoring_Deadband_Absolute_5MI.Size = new System.Drawing.Size(86, 22);
            this.Monitoring_Deadband_Absolute_5MI.Text = "5";
            this.Monitoring_Deadband_Absolute_5MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Absolute_10MI
            // 
            this.Monitoring_Deadband_Absolute_10MI.Name = "Monitoring_Deadband_Absolute_10MI";
            this.Monitoring_Deadband_Absolute_10MI.Size = new System.Drawing.Size(86, 22);
            this.Monitoring_Deadband_Absolute_10MI.Text = "10";
            this.Monitoring_Deadband_Absolute_10MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Absolute_25MI
            // 
            this.Monitoring_Deadband_Absolute_25MI.Name = "Monitoring_Deadband_Absolute_25MI";
            this.Monitoring_Deadband_Absolute_25MI.Size = new System.Drawing.Size(86, 22);
            this.Monitoring_Deadband_Absolute_25MI.Text = "25";
            this.Monitoring_Deadband_Absolute_25MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_PercentageMI
            // 
            this.Monitoring_Deadband_PercentageMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_Deadband_Percentage_1MI,
            this.Monitoring_Deadband_Percentage_5MI,
            this.Monitoring_Deadband_Percentage_10MI});
            this.Monitoring_Deadband_PercentageMI.Name = "Monitoring_Deadband_PercentageMI";
            this.Monitoring_Deadband_PercentageMI.Size = new System.Drawing.Size(133, 22);
            this.Monitoring_Deadband_PercentageMI.Text = "Percentage";
            // 
            // Monitoring_Deadband_Percentage_1MI
            // 
            this.Monitoring_Deadband_Percentage_1MI.Name = "Monitoring_Deadband_Percentage_1MI";
            this.Monitoring_Deadband_Percentage_1MI.Size = new System.Drawing.Size(96, 22);
            this.Monitoring_Deadband_Percentage_1MI.Text = "1%";
            this.Monitoring_Deadband_Percentage_1MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Percentage_5MI
            // 
            this.Monitoring_Deadband_Percentage_5MI.Name = "Monitoring_Deadband_Percentage_5MI";
            this.Monitoring_Deadband_Percentage_5MI.Size = new System.Drawing.Size(96, 22);
            this.Monitoring_Deadband_Percentage_5MI.Text = "5%";
            this.Monitoring_Deadband_Percentage_5MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Percentage_10MI
            // 
            this.Monitoring_Deadband_Percentage_10MI.Name = "Monitoring_Deadband_Percentage_10MI";
            this.Monitoring_Deadband_Percentage_10MI.Size = new System.Drawing.Size(96, 22);
            this.Monitoring_Deadband_Percentage_10MI.Text = "10%";
            this.Monitoring_Deadband_Percentage_10MI.Click += new System.EventHandler(this.Monitoring_Deadband_Click);
            // 
            // ConnectServerCTRL
            // 
            this.ConnectServerCTRL.Configuration = null;
            this.ConnectServerCTRL.DisableDomainCheck = false;
            this.ConnectServerCTRL.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConnectServerCTRL.Location = new System.Drawing.Point(0, 24);
            this.ConnectServerCTRL.MaximumSize = new System.Drawing.Size(2048, 23);
            this.ConnectServerCTRL.MinimumSize = new System.Drawing.Size(500, 23);
            this.ConnectServerCTRL.Name = "ConnectServerCTRL";
            this.ConnectServerCTRL.PreferredLocales = null;
            this.ConnectServerCTRL.ServerUrl = "";
            this.ConnectServerCTRL.SessionName = null;
            this.ConnectServerCTRL.Size = new System.Drawing.Size(1063, 23);
            this.ConnectServerCTRL.StatusStrip = this.StatusBar;
            this.ConnectServerCTRL.TabIndex = 4;
            this.ConnectServerCTRL.UserIdentity = null;
            this.ConnectServerCTRL.UseSecurity = true;
            this.ConnectServerCTRL.ReconnectStarting += new System.EventHandler(this.Server_ReconnectStarting);
            this.ConnectServerCTRL.ReconnectComplete += new System.EventHandler(this.Server_ReconnectComplete);
            this.ConnectServerCTRL.ConnectComplete += new System.EventHandler(this.Server_ConnectComplete);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 676);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.ConnectServerCTRL);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainForm";
            this.Text = "OPC-UA Data Access Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.MainPN.Panel1.ResumeLayout(false);
            this.MainPN.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPN)).EndInit();
            this.MainPN.ResumeLayout(false);
            this.TopPN.Panel1.ResumeLayout(false);
            this.TopPN.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopPN)).EndInit();
            this.TopPN.ResumeLayout(false);
            this.BrowsingMenu.ResumeLayout(false);
            this.panelServer.ResumeLayout(false);
            this.panelServer.PerformLayout();
            this.panelObjects.ResumeLayout(false);
            this.panelObjects.PerformLayout();
            this.MonitoringMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripMenuItem ServerMI;
        private System.Windows.Forms.ToolStripMenuItem Server_DiscoverMI;
        private System.Windows.Forms.ToolStripMenuItem Server_ConnectMI;
        private System.Windows.Forms.ToolStripMenuItem Server_DisconnectMI;
        private System.Windows.Forms.ToolStripMenuItem ViewMI;
        private System.Windows.Forms.ToolStripMenuItem HelpMI;
        private System.Windows.Forms.ToolStripMenuItem Help_ContentsMI;
        private System.Windows.Forms.SplitContainer MainPN;
        private System.Windows.Forms.SplitContainer TopPN;
        private System.Windows.Forms.TreeView BrowseNodesTV;
        private System.Windows.Forms.ListView AttributesLV;
        private System.Windows.Forms.ColumnHeader AttributeNameCH;
        private System.Windows.Forms.ColumnHeader AttributeDataTypeCH;
        private System.Windows.Forms.ColumnHeader AttributeValueCH;
        private System.Windows.Forms.ListView MonitoredItemsLV;
        private System.Windows.Forms.ColumnHeader MonitoredItemIdCH;
        private System.Windows.Forms.ColumnHeader VariableNameCH;
        private System.Windows.Forms.ColumnHeader MonitoringModeCH;
        private System.Windows.Forms.ColumnHeader SamplingIntevalCH;
        private System.Windows.Forms.ColumnHeader DeadbandCH;
        private System.Windows.Forms.ColumnHeader ValueCH;
        private System.Windows.Forms.ColumnHeader QualityCH;
        private System.Windows.Forms.ColumnHeader TimestampCH;
        private System.Windows.Forms.ColumnHeader LastOperationStatusCH;
        private System.Windows.Forms.ContextMenuStrip BrowsingMenu;
        private System.Windows.Forms.ToolStripMenuItem Browse_MonitorMI;
        private System.Windows.Forms.ToolStripMenuItem Browse_WriteMI;
        private System.Windows.Forms.ContextMenuStrip MonitoringMenu;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_DeleteMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringModeMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_DisabledMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_SamplingMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_ReportingMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingIntervalMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_FastMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_1000MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_2500MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_5000MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_DeadbandMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_NoneMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_AbsoluteMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Absolute_5MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Absolute_10MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Absolute_25MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_PercentageMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Percentage_1MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Percentage_5MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Percentage_10MI;
        private System.Windows.Forms.ToolStripMenuItem Browse_ReadHistoryMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_WriteMI;
        private System.Windows.Forms.ToolStripMenuItem FileMI;
        private System.Windows.Forms.ToolStripMenuItem File_LoadMI;
        private System.Windows.Forms.ToolStripMenuItem File_SaveMI;
        private Opc.Ua.Client.Controls.ConnectServerCtrl ConnectServerCTRL;
        private System.Windows.Forms.ToolStripMenuItem Server_SetLocaleMI;
        private System.Windows.Forms.ToolStripMenuItem Server_SetUserMI;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAddressSpaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Panel panelServer;
        private System.Windows.Forms.Panel panelObjects;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar saveProgressBar;
        private System.Windows.Forms.TextBox boxNodeName;
        private System.Windows.Forms.TextBox boxBrowsePath;
    }
}
