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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DataAccessClient;
using Newtonsoft.Json;
using Opc.Ua;
using Orientation = System.Windows.Forms.Orientation;

namespace Quickstarts.DataAccessClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            this.MenuBar = new MenuStrip();
            this.fILEToolStripMenuItem = new ToolStripMenuItem();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.ServerMI = new ToolStripMenuItem();
            this.Server_DiscoverMI = new ToolStripMenuItem();
            this.Server_ConnectMI = new ToolStripMenuItem();
            this.Server_DisconnectMI = new ToolStripMenuItem();
            this.Server_SetLocaleMI = new ToolStripMenuItem();
            this.Server_SetUserMI = new ToolStripMenuItem();
            this.toolStripMenuItem2 = new ToolStripSeparator();
            this.saveAddressSpaceToolStripMenuItem = new ToolStripMenuItem();
            this.ViewMI = new ToolStripMenuItem();
            this.FileMI = new ToolStripMenuItem();
            this.File_LoadMI = new ToolStripMenuItem();
            this.File_SaveMI = new ToolStripMenuItem();
            this.HelpMI = new ToolStripMenuItem();
            this.Help_ContentsMI = new ToolStripMenuItem();
            this.StatusBar = new StatusStrip();
            this.saveProgressBar = new ToolStripProgressBar();
            this.MainPN = new SplitContainer();
            this.TopPN = new SplitContainer();
            this.BrowseNodesTV = new TreeView();
            this.BrowsingMenu = new ContextMenuStrip(this.components);
            this.Browse_MonitorMI = new ToolStripMenuItem();
            this.Browse_WriteMI = new ToolStripMenuItem();
            this.Browse_ReadHistoryMI = new ToolStripMenuItem();
            this.toolStripMenuItem1 = new ToolStripSeparator();
            this.saveAsToolStripMenuItem = new ToolStripMenuItem();
            this.imageList1 = new ImageList(this.components);
            this.panelServer = new Panel();
            this.boxBrowsePath = new TextBox();
            this.AttributesLV = new ListView();
            this.AttributeNameCH = ((ColumnHeader)(new ColumnHeader()));
            this.AttributeDataTypeCH = ((ColumnHeader)(new ColumnHeader()));
            this.AttributeValueCH = ((ColumnHeader)(new ColumnHeader()));
            this.panelObjects = new Panel();
            this.boxNodeName = new TextBox();
            this.MonitoredItemsLV = new ListView();
            this.MonitoredItemIdCH = ((ColumnHeader)(new ColumnHeader()));
            this.VariableNameCH = ((ColumnHeader)(new ColumnHeader()));
            this.MonitoringModeCH = ((ColumnHeader)(new ColumnHeader()));
            this.SamplingIntevalCH = ((ColumnHeader)(new ColumnHeader()));
            this.DeadbandCH = ((ColumnHeader)(new ColumnHeader()));
            this.ValueCH = ((ColumnHeader)(new ColumnHeader()));
            this.QualityCH = ((ColumnHeader)(new ColumnHeader()));
            this.TimestampCH = ((ColumnHeader)(new ColumnHeader()));
            this.LastOperationStatusCH = ((ColumnHeader)(new ColumnHeader()));
            this.MonitoringMenu = new ContextMenuStrip(this.components);
            this.Monitoring_DeleteMI = new ToolStripMenuItem();
            this.Monitoring_WriteMI = new ToolStripMenuItem();
            this.Monitoring_MonitoringModeMI = new ToolStripMenuItem();
            this.Monitoring_MonitoringMode_DisabledMI = new ToolStripMenuItem();
            this.Monitoring_MonitoringMode_SamplingMI = new ToolStripMenuItem();
            this.Monitoring_MonitoringMode_ReportingMI = new ToolStripMenuItem();
            this.Monitoring_SamplingIntervalMI = new ToolStripMenuItem();
            this.Monitoring_SamplingInterval_FastMI = new ToolStripMenuItem();
            this.Monitoring_SamplingInterval_1000MI = new ToolStripMenuItem();
            this.Monitoring_SamplingInterval_2500MI = new ToolStripMenuItem();
            this.Monitoring_SamplingInterval_5000MI = new ToolStripMenuItem();
            this.Monitoring_DeadbandMI = new ToolStripMenuItem();
            this.Monitoring_Deadband_NoneMI = new ToolStripMenuItem();
            this.Monitoring_Deadband_AbsoluteMI = new ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_5MI = new ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_10MI = new ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_25MI = new ToolStripMenuItem();
            this.Monitoring_Deadband_PercentageMI = new ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_1MI = new ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_5MI = new ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_10MI = new ToolStripMenuItem();
            this.ConnectServerCTRL = new Opc.Ua.Client.Controls.ConnectServerCtrl();
            this.MenuBar.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((ISupportInitialize)(this.MainPN)).BeginInit();
            this.MainPN.Panel1.SuspendLayout();
            this.MainPN.Panel2.SuspendLayout();
            this.MainPN.SuspendLayout();
            ((ISupportInitialize)(this.TopPN)).BeginInit();
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
            this.MenuBar.Items.AddRange(new ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.ServerMI,
            this.ViewMI,
            this.FileMI,
            this.HelpMI});
            this.MenuBar.Location = new Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new Size(1063, 24);
            this.MenuBar.TabIndex = 1;
            this.MenuBar.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new Size(37, 20);
            this.fILEToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new Size(93, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ServerMI
            // 
            this.ServerMI.DropDownItems.AddRange(new ToolStripItem[] {
            this.Server_DiscoverMI,
            this.Server_ConnectMI,
            this.Server_DisconnectMI,
            this.Server_SetLocaleMI,
            this.Server_SetUserMI,
            this.toolStripMenuItem2,
            this.saveAddressSpaceToolStripMenuItem});
            this.ServerMI.Name = "ServerMI";
            this.ServerMI.Size = new Size(51, 20);
            this.ServerMI.Text = "Server";
            // 
            // Server_DiscoverMI
            // 
            this.Server_DiscoverMI.Name = "Server_DiscoverMI";
            this.Server_DiscoverMI.Size = new Size(186, 22);
            this.Server_DiscoverMI.Text = "Discover...";
            this.Server_DiscoverMI.Click += new EventHandler(this.Server_DiscoverMI_Click);
            // 
            // Server_ConnectMI
            // 
            this.Server_ConnectMI.Name = "Server_ConnectMI";
            this.Server_ConnectMI.Size = new Size(186, 22);
            this.Server_ConnectMI.Text = "Connect";
            this.Server_ConnectMI.Click += new EventHandler(this.Server_ConnectMI_ClickAsync);
            // 
            // Server_DisconnectMI
            // 
            this.Server_DisconnectMI.Name = "Server_DisconnectMI";
            this.Server_DisconnectMI.Size = new Size(186, 22);
            this.Server_DisconnectMI.Text = "Disconnect";
            this.Server_DisconnectMI.Click += new EventHandler(this.Server_DisconnectMI_Click);
            // 
            // Server_SetLocaleMI
            // 
            this.Server_SetLocaleMI.Name = "Server_SetLocaleMI";
            this.Server_SetLocaleMI.Size = new Size(186, 22);
            this.Server_SetLocaleMI.Text = "Select Locale...";
            this.Server_SetLocaleMI.Click += new EventHandler(this.Server_SetLocaleMI_Click);
            // 
            // Server_SetUserMI
            // 
            this.Server_SetUserMI.Name = "Server_SetUserMI";
            this.Server_SetUserMI.Size = new Size(186, 22);
            this.Server_SetUserMI.Text = "Set User...";
            this.Server_SetUserMI.Click += new EventHandler(this.Server_SetUserMI_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new Size(183, 6);
            // 
            // saveAddressSpaceToolStripMenuItem
            // 
            this.saveAddressSpaceToolStripMenuItem.Name = "saveAddressSpaceToolStripMenuItem";
            this.saveAddressSpaceToolStripMenuItem.Size = new Size(186, 22);
            this.saveAddressSpaceToolStripMenuItem.Text = "Save Address Space...";
            this.saveAddressSpaceToolStripMenuItem.Click += new EventHandler(this.saveAddressSpaceToolStripMenuItem_Click);
            // 
            // ViewMI
            // 
            this.ViewMI.Name = "ViewMI";
            this.ViewMI.Size = new Size(44, 20);
            this.ViewMI.Text = "View";
            // 
            // FileMI
            // 
            this.FileMI.DropDownItems.AddRange(new ToolStripItem[] {
            this.File_LoadMI,
            this.File_SaveMI});
            this.FileMI.Name = "FileMI";
            this.FileMI.Size = new Size(107, 20);
            this.FileMI.Text = "Monitored Items";
            // 
            // File_LoadMI
            // 
            this.File_LoadMI.Name = "File_LoadMI";
            this.File_LoadMI.Size = new Size(109, 22);
            this.File_LoadMI.Text = "Load...";
            this.File_LoadMI.Click += new EventHandler(this.File_LoadMI_Click);
            // 
            // File_SaveMI
            // 
            this.File_SaveMI.Name = "File_SaveMI";
            this.File_SaveMI.Size = new Size(109, 22);
            this.File_SaveMI.Text = "Save...";
            this.File_SaveMI.Click += new EventHandler(this.File_SaveMI_Click);
            // 
            // HelpMI
            // 
            this.HelpMI.DropDownItems.AddRange(new ToolStripItem[] {
            this.Help_ContentsMI});
            this.HelpMI.Name = "HelpMI";
            this.HelpMI.Size = new Size(44, 20);
            this.HelpMI.Text = "Help";
            // 
            // Help_ContentsMI
            // 
            this.Help_ContentsMI.Name = "Help_ContentsMI";
            this.Help_ContentsMI.Size = new Size(122, 22);
            this.Help_ContentsMI.Text = "Contents";
            this.Help_ContentsMI.Click += new EventHandler(this.Help_ContentsMI_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new ToolStripItem[] {
            this.saveProgressBar});
            this.StatusBar.Location = new Point(0, 654);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new Size(1063, 22);
            this.StatusBar.TabIndex = 2;
            // 
            // saveProgressBar
            // 
            this.saveProgressBar.ForeColor = Color.Lime;
            this.saveProgressBar.Name = "saveProgressBar";
            this.saveProgressBar.Size = new Size(200, 16);
            this.saveProgressBar.Style = ProgressBarStyle.Marquee;
            this.saveProgressBar.Visible = false;
            // 
            // MainPN
            // 
            this.MainPN.Dock = DockStyle.Fill;
            this.MainPN.Location = new Point(0, 47);
            this.MainPN.Name = "MainPN";
            this.MainPN.Orientation = Orientation.Horizontal;
            // 
            // MainPN.Panel1
            // 
            this.MainPN.Panel1.Controls.Add(this.TopPN);
            // 
            // MainPN.Panel2
            // 
            this.MainPN.Panel2.Controls.Add(this.MonitoredItemsLV);
            this.MainPN.Size = new Size(1063, 607);
            this.MainPN.SplitterDistance = 417;
            this.MainPN.TabIndex = 1;
            // 
            // TopPN
            // 
            this.TopPN.Dock = DockStyle.Fill;
            this.TopPN.Location = new Point(0, 0);
            this.TopPN.Name = "TopPN";
            // 
            // TopPN.Panel1
            // 
            this.TopPN.Panel1.Controls.Add(this.BrowseNodesTV);
            this.TopPN.Panel1.Controls.Add(this.panelServer);
            // 
            // TopPN.Panel2
            // 
            this.TopPN.Panel2.BackColor = SystemColors.AppWorkspace;
            this.TopPN.Panel2.Controls.Add(this.AttributesLV);
            this.TopPN.Panel2.Controls.Add(this.panelObjects);
            this.TopPN.Panel2.ForeColor = SystemColors.ControlLightLight;
            this.TopPN.Size = new Size(1063, 417);
            this.TopPN.SplitterDistance = 468;
            this.TopPN.TabIndex = 0;
            // 
            // BrowseNodesTV
            // 
            this.BrowseNodesTV.ContextMenuStrip = this.BrowsingMenu;
            this.BrowseNodesTV.Dock = DockStyle.Fill;
            this.BrowseNodesTV.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.BrowseNodesTV.HideSelection = false;
            this.BrowseNodesTV.ImageIndex = 0;
            this.BrowseNodesTV.ImageList = this.imageList1;
            this.BrowseNodesTV.Indent = 20;
            this.BrowseNodesTV.Location = new Point(0, 27);
            this.BrowseNodesTV.Name = "BrowseNodesTV";
            this.BrowseNodesTV.SelectedImageIndex = 0;
            this.BrowseNodesTV.Size = new Size(468, 390);
            this.BrowseNodesTV.TabIndex = 0;
            this.BrowseNodesTV.BeforeExpand += new TreeViewCancelEventHandler(this.BrowseNodesTV_BeforeExpand);
            this.BrowseNodesTV.DrawNode += new DrawTreeNodeEventHandler(this.BrowseNodesTV_DrawNode);
            this.BrowseNodesTV.AfterSelect += new TreeViewEventHandler(this.BrowseNodesTV_AfterSelect);
            this.BrowseNodesTV.MouseDown += new MouseEventHandler(this.BrowseNodesTV_MouseDown);
            // 
            // BrowsingMenu
            // 
            this.BrowsingMenu.Items.AddRange(new ToolStripItem[] {
            this.Browse_MonitorMI,
            this.Browse_WriteMI,
            this.Browse_ReadHistoryMI,
            this.toolStripMenuItem1,
            this.saveAsToolStripMenuItem});
            this.BrowsingMenu.Name = "BrowsingMenu";
            this.BrowsingMenu.Size = new Size(151, 98);
            this.BrowsingMenu.Opening += new CancelEventHandler(this.BrowsingMenu_Opening);
            // 
            // Browse_MonitorMI
            // 
            this.Browse_MonitorMI.Name = "Browse_MonitorMI";
            this.Browse_MonitorMI.Size = new Size(150, 22);
            this.Browse_MonitorMI.Text = "Monitor";
            this.Browse_MonitorMI.Click += new EventHandler(this.Browse_MonitorMI_Click);
            // 
            // Browse_WriteMI
            // 
            this.Browse_WriteMI.Name = "Browse_WriteMI";
            this.Browse_WriteMI.Size = new Size(150, 22);
            this.Browse_WriteMI.Text = "Write...";
            this.Browse_WriteMI.Click += new EventHandler(this.Browse_WriteMI_Click);
            // 
            // Browse_ReadHistoryMI
            // 
            this.Browse_ReadHistoryMI.Name = "Browse_ReadHistoryMI";
            this.Browse_ReadHistoryMI.Size = new Size(150, 22);
            this.Browse_ReadHistoryMI.Text = "Read History...";
            this.Browse_ReadHistoryMI.Click += new EventHandler(this.Browse_ReadHistoryMI_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new Size(147, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new Size(150, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = Color.Transparent;
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
            this.panelServer.BackColor = SystemColors.AppWorkspace;
            this.panelServer.Controls.Add(this.boxBrowsePath);
            this.panelServer.Dock = DockStyle.Top;
            this.panelServer.Location = new Point(0, 0);
            this.panelServer.Name = "panelServer";
            this.panelServer.Size = new Size(468, 27);
            this.panelServer.TabIndex = 1;
            this.panelServer.MouseClick += new MouseEventHandler(this.labelServerName_MouseClick);
            // 
            // boxBrowsePath
            // 
            this.boxBrowsePath.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
                                                          | AnchorStyles.Left) 
                                                         | AnchorStyles.Right)));
            this.boxBrowsePath.BackColor = SystemColors.AppWorkspace;
            this.boxBrowsePath.BorderStyle = BorderStyle.None;
            this.boxBrowsePath.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.boxBrowsePath.ForeColor = SystemColors.Info;
            this.boxBrowsePath.Location = new Point(5, 7);
            this.boxBrowsePath.Margin = new Padding(5, 3, 3, 3);
            this.boxBrowsePath.Name = "boxBrowsePath";
            this.boxBrowsePath.ReadOnly = true;
            this.boxBrowsePath.Size = new Size(469, 19);
            this.boxBrowsePath.TabIndex = 2;
            this.boxBrowsePath.TabStop = false;
            this.boxBrowsePath.Text = "Server";
            this.boxBrowsePath.WordWrap = false;
            // 
            // AttributesLV
            // 
            this.AttributesLV.Columns.AddRange(new ColumnHeader[] {
            this.AttributeNameCH,
            this.AttributeDataTypeCH,
            this.AttributeValueCH});
            this.AttributesLV.Dock = DockStyle.Fill;
            this.AttributesLV.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.AttributesLV.FullRowSelect = true;
            this.AttributesLV.HideSelection = false;
            this.AttributesLV.Location = new Point(0, 27);
            this.AttributesLV.Name = "AttributesLV";
            this.AttributesLV.Size = new Size(591, 390);
            this.AttributesLV.TabIndex = 0;
            this.AttributesLV.UseCompatibleStateImageBehavior = false;
            this.AttributesLV.View = View.Details;
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
            this.panelObjects.Dock = DockStyle.Top;
            this.panelObjects.Location = new Point(0, 0);
            this.panelObjects.Margin = new Padding(0);
            this.panelObjects.Name = "panelObjects";
            this.panelObjects.Size = new Size(591, 27);
            this.panelObjects.TabIndex = 2;
            // 
            // boxNodeName
            // 
            this.boxNodeName.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
                                                        | AnchorStyles.Left) 
                                                       | AnchorStyles.Right)));
            this.boxNodeName.BackColor = SystemColors.AppWorkspace;
            this.boxNodeName.BorderStyle = BorderStyle.None;
            this.boxNodeName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.boxNodeName.ForeColor = SystemColors.Info;
            this.boxNodeName.Location = new Point(5, 7);
            this.boxNodeName.Margin = new Padding(5, 3, 3, 3);
            this.boxNodeName.Name = "boxNodeName";
            this.boxNodeName.ReadOnly = true;
            this.boxNodeName.Size = new Size(588, 19);
            this.boxNodeName.TabIndex = 1;
            this.boxNodeName.TabStop = false;
            this.boxNodeName.Text = "Objects";
            this.boxNodeName.WordWrap = false;
            // 
            // MonitoredItemsLV
            // 
            this.MonitoredItemsLV.Columns.AddRange(new ColumnHeader[] {
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
            this.MonitoredItemsLV.Dock = DockStyle.Fill;
            this.MonitoredItemsLV.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.MonitoredItemsLV.FullRowSelect = true;
            this.MonitoredItemsLV.HideSelection = false;
            this.MonitoredItemsLV.Location = new Point(0, 0);
            this.MonitoredItemsLV.Name = "MonitoredItemsLV";
            this.MonitoredItemsLV.Size = new Size(1063, 186);
            this.MonitoredItemsLV.TabIndex = 0;
            this.MonitoredItemsLV.UseCompatibleStateImageBehavior = false;
            this.MonitoredItemsLV.View = View.Details;
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
            this.MonitoringMenu.Items.AddRange(new ToolStripItem[] {
            this.Monitoring_DeleteMI,
            this.Monitoring_WriteMI,
            this.Monitoring_MonitoringModeMI,
            this.Monitoring_SamplingIntervalMI,
            this.Monitoring_DeadbandMI});
            this.MonitoringMenu.Name = "MonitoringMenu";
            this.MonitoringMenu.Size = new Size(169, 114);
            // 
            // Monitoring_DeleteMI
            // 
            this.Monitoring_DeleteMI.Name = "Monitoring_DeleteMI";
            this.Monitoring_DeleteMI.Size = new Size(168, 22);
            this.Monitoring_DeleteMI.Text = "Delete";
            this.Monitoring_DeleteMI.Click += new EventHandler(this.Monitoring_DeleteMI_Click);
            // 
            // Monitoring_WriteMI
            // 
            this.Monitoring_WriteMI.Name = "Monitoring_WriteMI";
            this.Monitoring_WriteMI.Size = new Size(168, 22);
            this.Monitoring_WriteMI.Text = "Write...";
            this.Monitoring_WriteMI.Click += new EventHandler(this.Monitoring_WriteMI_Click);
            // 
            // Monitoring_MonitoringModeMI
            // 
            this.Monitoring_MonitoringModeMI.DropDownItems.AddRange(new ToolStripItem[] {
            this.Monitoring_MonitoringMode_DisabledMI,
            this.Monitoring_MonitoringMode_SamplingMI,
            this.Monitoring_MonitoringMode_ReportingMI});
            this.Monitoring_MonitoringModeMI.Name = "Monitoring_MonitoringModeMI";
            this.Monitoring_MonitoringModeMI.Size = new Size(168, 22);
            this.Monitoring_MonitoringModeMI.Text = "Monitoring Mode";
            // 
            // Monitoring_MonitoringMode_DisabledMI
            // 
            this.Monitoring_MonitoringMode_DisabledMI.Name = "Monitoring_MonitoringMode_DisabledMI";
            this.Monitoring_MonitoringMode_DisabledMI.Size = new Size(126, 22);
            this.Monitoring_MonitoringMode_DisabledMI.Text = "Disabled";
            this.Monitoring_MonitoringMode_DisabledMI.Click += new EventHandler(this.Monitoring_MonitoringMode_Click);
            // 
            // Monitoring_MonitoringMode_SamplingMI
            // 
            this.Monitoring_MonitoringMode_SamplingMI.Name = "Monitoring_MonitoringMode_SamplingMI";
            this.Monitoring_MonitoringMode_SamplingMI.Size = new Size(126, 22);
            this.Monitoring_MonitoringMode_SamplingMI.Text = "Sampling";
            this.Monitoring_MonitoringMode_SamplingMI.Click += new EventHandler(this.Monitoring_MonitoringMode_Click);
            // 
            // Monitoring_MonitoringMode_ReportingMI
            // 
            this.Monitoring_MonitoringMode_ReportingMI.Name = "Monitoring_MonitoringMode_ReportingMI";
            this.Monitoring_MonitoringMode_ReportingMI.Size = new Size(126, 22);
            this.Monitoring_MonitoringMode_ReportingMI.Text = "Reporting";
            this.Monitoring_MonitoringMode_ReportingMI.Click += new EventHandler(this.Monitoring_MonitoringMode_Click);
            // 
            // Monitoring_SamplingIntervalMI
            // 
            this.Monitoring_SamplingIntervalMI.DropDownItems.AddRange(new ToolStripItem[] {
            this.Monitoring_SamplingInterval_FastMI,
            this.Monitoring_SamplingInterval_1000MI,
            this.Monitoring_SamplingInterval_2500MI,
            this.Monitoring_SamplingInterval_5000MI});
            this.Monitoring_SamplingIntervalMI.Name = "Monitoring_SamplingIntervalMI";
            this.Monitoring_SamplingIntervalMI.Size = new Size(168, 22);
            this.Monitoring_SamplingIntervalMI.Text = "Samping Interval";
            // 
            // Monitoring_SamplingInterval_FastMI
            // 
            this.Monitoring_SamplingInterval_FastMI.Name = "Monitoring_SamplingInterval_FastMI";
            this.Monitoring_SamplingInterval_FastMI.Size = new Size(155, 22);
            this.Monitoring_SamplingInterval_FastMI.Text = "Fast as Possible";
            this.Monitoring_SamplingInterval_FastMI.Click += new EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_SamplingInterval_1000MI
            // 
            this.Monitoring_SamplingInterval_1000MI.Name = "Monitoring_SamplingInterval_1000MI";
            this.Monitoring_SamplingInterval_1000MI.Size = new Size(155, 22);
            this.Monitoring_SamplingInterval_1000MI.Text = "1000ms";
            this.Monitoring_SamplingInterval_1000MI.Click += new EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_SamplingInterval_2500MI
            // 
            this.Monitoring_SamplingInterval_2500MI.Name = "Monitoring_SamplingInterval_2500MI";
            this.Monitoring_SamplingInterval_2500MI.Size = new Size(155, 22);
            this.Monitoring_SamplingInterval_2500MI.Text = "2500ms";
            this.Monitoring_SamplingInterval_2500MI.Click += new EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_SamplingInterval_5000MI
            // 
            this.Monitoring_SamplingInterval_5000MI.Name = "Monitoring_SamplingInterval_5000MI";
            this.Monitoring_SamplingInterval_5000MI.Size = new Size(155, 22);
            this.Monitoring_SamplingInterval_5000MI.Text = "5000ms";
            this.Monitoring_SamplingInterval_5000MI.Click += new EventHandler(this.Monitoring_SamplingInterval_Click);
            // 
            // Monitoring_DeadbandMI
            // 
            this.Monitoring_DeadbandMI.DropDownItems.AddRange(new ToolStripItem[] {
            this.Monitoring_Deadband_NoneMI,
            this.Monitoring_Deadband_AbsoluteMI,
            this.Monitoring_Deadband_PercentageMI});
            this.Monitoring_DeadbandMI.Name = "Monitoring_DeadbandMI";
            this.Monitoring_DeadbandMI.Size = new Size(168, 22);
            this.Monitoring_DeadbandMI.Text = "Deadband";
            // 
            // Monitoring_Deadband_NoneMI
            // 
            this.Monitoring_Deadband_NoneMI.Name = "Monitoring_Deadband_NoneMI";
            this.Monitoring_Deadband_NoneMI.Size = new Size(133, 22);
            this.Monitoring_Deadband_NoneMI.Text = "None";
            this.Monitoring_Deadband_NoneMI.Click += new EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_AbsoluteMI
            // 
            this.Monitoring_Deadband_AbsoluteMI.DropDownItems.AddRange(new ToolStripItem[] {
            this.Monitoring_Deadband_Absolute_5MI,
            this.Monitoring_Deadband_Absolute_10MI,
            this.Monitoring_Deadband_Absolute_25MI});
            this.Monitoring_Deadband_AbsoluteMI.Name = "Monitoring_Deadband_AbsoluteMI";
            this.Monitoring_Deadband_AbsoluteMI.Size = new Size(133, 22);
            this.Monitoring_Deadband_AbsoluteMI.Text = "Absolute";
            // 
            // Monitoring_Deadband_Absolute_5MI
            // 
            this.Monitoring_Deadband_Absolute_5MI.Name = "Monitoring_Deadband_Absolute_5MI";
            this.Monitoring_Deadband_Absolute_5MI.Size = new Size(86, 22);
            this.Monitoring_Deadband_Absolute_5MI.Text = "5";
            this.Monitoring_Deadband_Absolute_5MI.Click += new EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Absolute_10MI
            // 
            this.Monitoring_Deadband_Absolute_10MI.Name = "Monitoring_Deadband_Absolute_10MI";
            this.Monitoring_Deadband_Absolute_10MI.Size = new Size(86, 22);
            this.Monitoring_Deadband_Absolute_10MI.Text = "10";
            this.Monitoring_Deadband_Absolute_10MI.Click += new EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Absolute_25MI
            // 
            this.Monitoring_Deadband_Absolute_25MI.Name = "Monitoring_Deadband_Absolute_25MI";
            this.Monitoring_Deadband_Absolute_25MI.Size = new Size(86, 22);
            this.Monitoring_Deadband_Absolute_25MI.Text = "25";
            this.Monitoring_Deadband_Absolute_25MI.Click += new EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_PercentageMI
            // 
            this.Monitoring_Deadband_PercentageMI.DropDownItems.AddRange(new ToolStripItem[] {
            this.Monitoring_Deadband_Percentage_1MI,
            this.Monitoring_Deadband_Percentage_5MI,
            this.Monitoring_Deadband_Percentage_10MI});
            this.Monitoring_Deadband_PercentageMI.Name = "Monitoring_Deadband_PercentageMI";
            this.Monitoring_Deadband_PercentageMI.Size = new Size(133, 22);
            this.Monitoring_Deadband_PercentageMI.Text = "Percentage";
            // 
            // Monitoring_Deadband_Percentage_1MI
            // 
            this.Monitoring_Deadband_Percentage_1MI.Name = "Monitoring_Deadband_Percentage_1MI";
            this.Monitoring_Deadband_Percentage_1MI.Size = new Size(96, 22);
            this.Monitoring_Deadband_Percentage_1MI.Text = "1%";
            this.Monitoring_Deadband_Percentage_1MI.Click += new EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Percentage_5MI
            // 
            this.Monitoring_Deadband_Percentage_5MI.Name = "Monitoring_Deadband_Percentage_5MI";
            this.Monitoring_Deadband_Percentage_5MI.Size = new Size(96, 22);
            this.Monitoring_Deadband_Percentage_5MI.Text = "5%";
            this.Monitoring_Deadband_Percentage_5MI.Click += new EventHandler(this.Monitoring_Deadband_Click);
            // 
            // Monitoring_Deadband_Percentage_10MI
            // 
            this.Monitoring_Deadband_Percentage_10MI.Name = "Monitoring_Deadband_Percentage_10MI";
            this.Monitoring_Deadband_Percentage_10MI.Size = new Size(96, 22);
            this.Monitoring_Deadband_Percentage_10MI.Text = "10%";
            this.Monitoring_Deadband_Percentage_10MI.Click += new EventHandler(this.Monitoring_Deadband_Click);
            // 
            // ConnectServerCTRL
            // 
            this.ConnectServerCTRL.Configuration = null;
            this.ConnectServerCTRL.DisableDomainCheck = false;
            this.ConnectServerCTRL.Dock = DockStyle.Top;
            this.ConnectServerCTRL.Location = new Point(0, 24);
            this.ConnectServerCTRL.MaximumSize = new Size(2048, 23);
            this.ConnectServerCTRL.MinimumSize = new Size(500, 23);
            this.ConnectServerCTRL.Name = "ConnectServerCTRL";
            this.ConnectServerCTRL.PreferredLocales = null;
            this.ConnectServerCTRL.ServerUrl = "";
            this.ConnectServerCTRL.SessionName = null;
            this.ConnectServerCTRL.Size = new Size(1063, 23);
            this.ConnectServerCTRL.StatusStrip = this.StatusBar;
            this.ConnectServerCTRL.TabIndex = 4;
            this.ConnectServerCTRL.UserIdentity = null;
            this.ConnectServerCTRL.UseSecurity = true;
            this.ConnectServerCTRL.ReconnectStarting += new EventHandler(this.Server_ReconnectStarting);
            this.ConnectServerCTRL.ReconnectComplete += new EventHandler(this.Server_ReconnectComplete);
            this.ConnectServerCTRL.ConnectComplete += new EventHandler(this.Server_ConnectComplete);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1063, 676);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.ConnectServerCTRL);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainForm";
            this.Text = "OPC-UA Data Access Client";
            this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.MainPN.Panel1.ResumeLayout(false);
            this.MainPN.Panel2.ResumeLayout(false);
            ((ISupportInitialize)(this.MainPN)).EndInit();
            this.MainPN.ResumeLayout(false);
            this.TopPN.Panel1.ResumeLayout(false);
            this.TopPN.Panel2.ResumeLayout(false);
            ((ISupportInitialize)(this.TopPN)).EndInit();
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

        private MenuStrip MenuBar;
        private StatusStrip StatusBar;
        private ToolStripMenuItem ServerMI;
        private ToolStripMenuItem Server_DiscoverMI;
        private ToolStripMenuItem Server_ConnectMI;
        private ToolStripMenuItem Server_DisconnectMI;
        private ToolStripMenuItem ViewMI;
        private ToolStripMenuItem HelpMI;
        private ToolStripMenuItem Help_ContentsMI;
        private SplitContainer MainPN;
        private SplitContainer TopPN;
        private TreeView BrowseNodesTV;
        private ListView AttributesLV;
        private ColumnHeader AttributeNameCH;
        private ColumnHeader AttributeDataTypeCH;
        private ColumnHeader AttributeValueCH;
        private ListView MonitoredItemsLV;
        private ColumnHeader MonitoredItemIdCH;
        private ColumnHeader VariableNameCH;
        private ColumnHeader MonitoringModeCH;
        private ColumnHeader SamplingIntevalCH;
        private ColumnHeader DeadbandCH;
        private ColumnHeader ValueCH;
        private ColumnHeader QualityCH;
        private ColumnHeader TimestampCH;
        private ColumnHeader LastOperationStatusCH;
        private ContextMenuStrip BrowsingMenu;
        private ToolStripMenuItem Browse_MonitorMI;
        private ToolStripMenuItem Browse_WriteMI;
        private ContextMenuStrip MonitoringMenu;
        private ToolStripMenuItem Monitoring_DeleteMI;
        private ToolStripMenuItem Monitoring_MonitoringModeMI;
        private ToolStripMenuItem Monitoring_MonitoringMode_DisabledMI;
        private ToolStripMenuItem Monitoring_MonitoringMode_SamplingMI;
        private ToolStripMenuItem Monitoring_MonitoringMode_ReportingMI;
        private ToolStripMenuItem Monitoring_SamplingIntervalMI;
        private ToolStripMenuItem Monitoring_SamplingInterval_FastMI;
        private ToolStripMenuItem Monitoring_SamplingInterval_1000MI;
        private ToolStripMenuItem Monitoring_SamplingInterval_2500MI;
        private ToolStripMenuItem Monitoring_SamplingInterval_5000MI;
        private ToolStripMenuItem Monitoring_DeadbandMI;
        private ToolStripMenuItem Monitoring_Deadband_NoneMI;
        private ToolStripMenuItem Monitoring_Deadband_AbsoluteMI;
        private ToolStripMenuItem Monitoring_Deadband_Absolute_5MI;
        private ToolStripMenuItem Monitoring_Deadband_Absolute_10MI;
        private ToolStripMenuItem Monitoring_Deadband_Absolute_25MI;
        private ToolStripMenuItem Monitoring_Deadband_PercentageMI;
        private ToolStripMenuItem Monitoring_Deadband_Percentage_1MI;
        private ToolStripMenuItem Monitoring_Deadband_Percentage_5MI;
        private ToolStripMenuItem Monitoring_Deadband_Percentage_10MI;
        private ToolStripMenuItem Browse_ReadHistoryMI;
        private ToolStripMenuItem Monitoring_WriteMI;
        private ToolStripMenuItem FileMI;
        private ToolStripMenuItem File_LoadMI;
        private ToolStripMenuItem File_SaveMI;
        private Opc.Ua.Client.Controls.ConnectServerCtrl ConnectServerCTRL;
        private ToolStripMenuItem Server_SetLocaleMI;
        private ToolStripMenuItem Server_SetUserMI;
        private ToolStripMenuItem fILEToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem saveAddressSpaceToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private Panel panelServer;
        private Panel panelObjects;
        private ImageList imageList1;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripProgressBar saveProgressBar;
        private TextBox boxNodeName;
        private TextBox boxBrowsePath;
    }
}
