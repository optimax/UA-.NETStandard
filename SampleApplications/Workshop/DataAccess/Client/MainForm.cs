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
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DataAccessClient;
using Newtonsoft.Json;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;
using TypeInfo = Opc.Ua.TypeInfo;

namespace Quickstarts.DataAccessClient
{
    /// <summary>
    /// The main form for a simple Data Access Client application.
    /// </summary>
    public partial class MainForm : Form
    {
        private const string DEFAULT_PATH_NAME = "Server";
        private const string DEFAULT_OBJECTS_NAME = "Objects";

        #region Constructors

        /// <summary>
        /// Creates an empty form.
        /// </summary>
        private MainForm()
        {
            InitializeComponent();
            this.Icon = ClientUtils.GetAppIcon();
        }


        /// <summary>
        /// Creates a form which uses the specified client configuration.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        public MainForm(ClientApplicationConfiguration configuration)
        {
            InitializeComponent();
            this.Icon = ClientUtils.GetAppIcon();
            ConnectServerCTRL.Configuration = m_configuration = configuration;

            LoadClientConfiguration(m_configuration);

            var availableUrls = configuration.RemoteUrls;
            if (availableUrls.Any())
            {
                ConnectServerCTRL.SetAvailableUrls(availableUrls);
                if (String.IsNullOrEmpty(configuration.LastRemoteUrl))
                    configuration.LastRemoteUrl = availableUrls[0];
                ConnectServerCTRL.ServerUrl = configuration.LastRemoteUrl;
            }

            SaveClientConfiguration(m_configuration);

            this.Text = m_configuration.ApplicationName;
            boxNodeName.Text = DEFAULT_OBJECTS_NAME;

            // create the callback.
            m_MonitoredItem_Notification = new MonitoredItemNotificationEventHandler(MonitoredItem_Notification);
        }

        #endregion


        #region Private Fields

        private ClientApplicationConfiguration m_configuration;
        private Session m_session;
        private bool m_connectedOnce;
        private Subscription m_subscription;
        private MonitoredItemNotificationEventHandler m_MonitoredItem_Notification;

        #endregion


        #region Configuration

        public static void LoadClientConfiguration(ClientApplicationConfiguration config)
        {
            var fileName = ApplicationConfiguration.GetFilePathFromAppConfig("DataAccessClient");
            var folderName = Path.GetDirectoryName(fileName);

            var urlFileName = Path.Combine(folderName ?? "", "DataAccessClient.Urls.json");
            if (!File.Exists(urlFileName))
            {
                config.RemoteUrls = new List<string>();
                return;
            }

            var json = File.ReadAllText(urlFileName);
            config.RemoteUrls = JsonConvert.DeserializeObject<List<string>>(json);
        }


        public static void SaveClientConfiguration(ClientApplicationConfiguration config)
        {
            var fileName = ApplicationConfiguration.GetFilePathFromAppConfig("DataAccessClient");
            var folderName = Path.GetDirectoryName(fileName);
            var outFileName = Path.Combine(folderName ?? "", "DataAccessClient.Config.json");
            var newJson = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(outFileName, newJson);
        }


        #endregion


        #region Event Handlers

        /// <summary>
        /// Connects to a server.
        /// </summary>
        private async void Server_ConnectMI_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                await ConnectServerCTRL.Connect();
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Disconnects from the current session.
        /// </summary>
        private void Server_DisconnectMI_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectServerCTRL.Disconnect();
                m_subscription.Dispose();
                m_subscription = null;
                m_session = null;
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Prompts the user to choose a server on another host.
        /// </summary>
        private void Server_DiscoverMI_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectServerCTRL.Discover(null);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Updates the application after connecting to or disconnecting from the server.
        /// </summary>
        private void Server_ConnectComplete(object sender, EventArgs e)
        {
            try
            {
                m_session = ConnectServerCTRL.Session;

                if (m_session == null)
                {
                    MonitoredItemsLV.Items.Clear();
                    AttributesLV.Items.Clear();
                    BrowseNodesTV.Nodes.Clear();
                    BrowseNodesTV.Enabled = false;
                    MonitoredItemsLV.Enabled = false;
                    AttributesLV.Enabled = false;
                    saveAddressSpaceToolStripMenuItem.Enabled = false;

                    panelServer.BackColor = boxBrowsePath.BackColor = SystemColors.AppWorkspace;
                    panelObjects.BackColor = boxNodeName.BackColor = SystemColors.AppWorkspace;

                    boxBrowsePath.Text = DEFAULT_PATH_NAME;
                    return;
                }

                // set a suitable initial state.
                if (m_session != null && !m_connectedOnce)
                {
                    m_connectedOnce = true;
                }


                // populate the browse view.
                var info = new OpcAddressSpaceInfo(m_session);

                PopulateBranch(ObjectIds.RootFolder, BrowseNodesTV.Nodes); //ObjectIds.ObjectsFolder

                BrowseNodesTV.Enabled = true;
                MonitoredItemsLV.Enabled = true;
                AttributesLV.Enabled = true;
                saveAddressSpaceToolStripMenuItem.Enabled = true;

                panelServer.BackColor = boxBrowsePath.BackColor = Color.DarkGreen;
                panelObjects.BackColor = boxNodeName.BackColor = Color.Black;

                var serverName = m_session.ConfiguredEndpoint.EndpointUrl.ToString();
                if (serverName.StartsWith("opc-tcp://"))
                    serverName = serverName.Substring(10);
                boxBrowsePath.Text = serverName;
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Updates the application after a communicate error was detected.
        /// </summary>
        private void Server_ReconnectStarting(object sender, EventArgs e)
        {
            try
            {
                BrowseNodesTV.Enabled = false;
                MonitoredItemsLV.Enabled = false;
                AttributesLV.Items.Clear();
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Updates the application after reconnecting to the server.
        /// </summary>
        private void Server_ReconnectComplete(object sender, EventArgs e)
        {
            try
            {
                m_session = ConnectServerCTRL.Session;

                foreach (Subscription subscription in m_session.Subscriptions)
                {
                    m_subscription = subscription;
                    break;
                }

                BrowseNodesTV.Enabled = true;
                MonitoredItemsLV.Enabled = true;
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Cleans up when the main form closes.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConnectServerCTRL.Disconnect();
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Populates the branch in the tree view.
        /// </summary>
        /// <param name="sourceId">The NodeId of the Node to browse.</param>
        /// <param name="nodes">The node collect to populate.</param>
        private void PopulateBranch(NodeId sourceId, TreeNodeCollection nodes)
        {
            try
            {
                nodes.Clear();

                // find all of the components of the node.
                BrowseDescription nodeToBrowse1 = new BrowseDescription();

                nodeToBrowse1.NodeId = sourceId;
                nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.Aggregates;
                nodeToBrowse1.IncludeSubtypes = true;
                nodeToBrowse1.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
                nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

                // find all nodes organized by the node.
                BrowseDescription nodeToBrowse2 = new BrowseDescription();

                nodeToBrowse2.NodeId = sourceId;
                nodeToBrowse2.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse2.ReferenceTypeId = ReferenceTypeIds.Organizes;
                nodeToBrowse2.IncludeSubtypes = true;
                nodeToBrowse2.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
                nodeToBrowse2.ResultMask = (uint)BrowseResultMask.All;


                // find all child nodes of the node.
                BrowseDescription nodeToBrowse3 = new BrowseDescription();

                nodeToBrowse3.NodeId = sourceId;
                nodeToBrowse3.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse3.ReferenceTypeId = ReferenceTypeIds.HasChild;
                nodeToBrowse3.IncludeSubtypes = true;
                nodeToBrowse3.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable | NodeClass.Method);
                nodeToBrowse3.ResultMask = (uint)BrowseResultMask.All;



                BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
                nodesToBrowse.Add(nodeToBrowse1);
                nodesToBrowse.Add(nodeToBrowse2);
                nodesToBrowse.Add(nodeToBrowse3);

                // fetch references from the server.
                var references = FormUtils.Browse(m_session, nodesToBrowse, false);

                // process results.
                foreach (var target in references)
                    //for (int ii = 0; ii < references.Count; ii++)
                {
                    // add node.
                    TreeNode child = new TreeNode($"{target.DisplayName}");
                    child.Tag = target;
                    child.Nodes.Add(new TreeNode());

                    child.ImageIndex =
                        ClientUtils.GetImageIndex(m_session, target.NodeClass, target.TypeDefinition, false);
                    child.SelectedImageIndex = child.ImageIndex;

                    if (child.ImageIndex == ClientUtils.Method)
                    {
                        child.Text = $"{child.Text}()";
                    }

                    nodes.Add(child);
                }

                // update the attributes display.
                DisplayAttributes(sourceId);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Displays the attributes and properties in the attributes view.
        /// </summary>
        /// <param name="sourceId">The NodeId of the Node to browse.</param>
        private void DisplayAttributes(NodeId sourceId)
        {
            try
            {
                AttributesLV.Items.Clear();

                ReadValueIdCollection nodesToRead = new ReadValueIdCollection();

                // attempt to read all possible attributes.
                for (uint ii = Attributes.NodeClass; ii <= Attributes.UserExecutable; ii++)
                {
                    ReadValueId nodeToRead = new ReadValueId();
                    nodeToRead.NodeId = sourceId;
                    nodeToRead.AttributeId = ii;
                    nodesToRead.Add(nodeToRead);
                }

                int startOfProperties = nodesToRead.Count;

                // find all of the pror of the node.
                BrowseDescription nodeToBrowse1 = new BrowseDescription();

                nodeToBrowse1.NodeId = sourceId;
                nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.HasProperty;
                nodeToBrowse1.IncludeSubtypes = true;
                nodeToBrowse1.NodeClassMask = 0;
                nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

                BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
                nodesToBrowse.Add(nodeToBrowse1);

                // fetch property references from the server.
                ReferenceDescriptionCollection references = FormUtils.Browse(m_session, nodesToBrowse, false);

                if (references == null)
                {
                    return;
                }

                for (int ii = 0; ii < references.Count; ii++)
                {
                    // ignore external references.
                    if (references[ii].NodeId.IsAbsolute)
                    {
                        continue;
                    }

                    ReadValueId nodeToRead = new ReadValueId();
                    nodeToRead.NodeId = (NodeId)references[ii].NodeId;
                    nodeToRead.AttributeId = Attributes.Value;
                    nodesToRead.Add(nodeToRead);
                }

                // read all values.
                DataValueCollection results = null;
                DiagnosticInfoCollection diagnosticInfos = null;

                m_session.Read(
                    null,
                    0,
                    TimestampsToReturn.Neither,
                    nodesToRead,
                    out results,
                    out diagnosticInfos);

                ClientBase.ValidateResponse(results, nodesToRead);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

                // process results.
                for (int ii = 0; ii < results.Count; ii++)
                {
                    string name = null;
                    string datatype = null;
                    string value = null;

                    // process attribute value.
                    if (ii < startOfProperties)
                    {
                        // ignore attributes which are invalid for the node.
                        if (results[ii].StatusCode == StatusCodes.BadAttributeIdInvalid)
                        {
                            continue;
                        }

                        // get the name of the attribute.
                        name = Attributes.GetBrowseName(nodesToRead[ii].AttributeId);

                        // display any unexpected error.
                        if (StatusCode.IsBad(results[ii].StatusCode))
                        {
                            datatype = Utils.Format("{0}", Attributes.GetDataTypeId(nodesToRead[ii].AttributeId));
                            value = Utils.Format("{0}", results[ii].StatusCode);
                        }

                        // display the value.
                        else
                        {
                            TypeInfo typeInfo = TypeInfo.Construct(results[ii].Value);

                            datatype = typeInfo.BuiltInType.ToString();

                            if (typeInfo.ValueRank >= ValueRanks.OneOrMoreDimensions)
                            {
                                datatype += "[]";
                            }

                            value = Utils.Format("{0}", results[ii].Value);


                            if (name == "NodeClass")
                            {
                                value = $"{value} ({(NodeClass)results[ii].Value})";
                            }
                        }
                    }

                    // process property value.
                    else
                    {
                        // ignore properties which are invalid for the node.
                        if (results[ii].StatusCode == StatusCodes.BadNodeIdUnknown)
                        {
                            continue;
                        }

                        // get the name of the property.
                        name = Utils.Format("{0}", references[ii - startOfProperties]);

                        // display any unexpected error.
                        if (StatusCode.IsBad(results[ii].StatusCode))
                        {
                            datatype = String.Empty;
                            value = Utils.Format("{0}", results[ii].StatusCode);
                        }

                        // display the value.
                        else
                        {
                            TypeInfo typeInfo = TypeInfo.Construct(results[ii].Value);

                            datatype = typeInfo.BuiltInType.ToString();

                            if (typeInfo.ValueRank >= ValueRanks.OneOrMoreDimensions)
                            {
                                datatype += "[]";
                            }

                            value = Utils.Format("{0}", results[ii].Value);
                        }
                    }

                    // add the attribute name/value to the list view.
                    ListViewItem item = new ListViewItem(name);
                    item.SubItems.Add(datatype);
                    item.SubItems.Add(value);
                    AttributesLV.Items.Add(item);
                }

                // adjust width of all columns.
                for (int ii = 0; ii < AttributesLV.Columns.Count; ii++)
                {
                    AttributesLV.Columns[ii].Width = -2;
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Converts a monitoring filter to text for display.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The deadback formatted as a string.</returns>
        private string DeadbandFilterToText(MonitoringFilter filter)
        {
            DataChangeFilter datachangeFilter = filter as DataChangeFilter;

            if (datachangeFilter != null)
            {
                if (datachangeFilter.DeadbandType == (uint)DeadbandType.Absolute)
                {
                    return Utils.Format("{0:##.##}", datachangeFilter.DeadbandValue);
                }

                if (datachangeFilter.DeadbandType == (uint)DeadbandType.Percent)
                {
                    return Utils.Format("{0:##.##}%", datachangeFilter.DeadbandValue);
                }
            }

            return "None";
        }

        #endregion


        #region Event Handlers

        /// <summary>
        /// Handles the Click event of the Help_ContentsMI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Help_ContentsMI_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Path.GetDirectoryName(Application.ExecutablePath) +
                              "\\WebHelp\\daclientoverview.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to launch help documentation. Error: " + ex.Message);
            }
        }


        /// <summary>
        /// Fetches the children for a node the first time the node is expanded in the tree view.
        /// </summary>
        private void BrowseNodesTV_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                // check if node has already been expanded once.
                if (e.Node.Nodes.Count != 1 || e.Node.Nodes[0].Text != String.Empty)
                {
                    return;
                }

                // get the source for the node.
                ReferenceDescription reference = e.Node.Tag as ReferenceDescription;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    e.Cancel = true;
                    return;
                }

                // populate children.
                PopulateBranch((NodeId)reference.NodeId, e.Node.Nodes);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Updates the display after a node is selected.
        /// </summary>
        private void BrowseNodesTV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                // get the source for the node.
                ReferenceDescription reference = e.Node.Tag as ReferenceDescription;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    return;
                }


                var nodeId = reference.NodeId;
                boxNodeName.Text = nodeId.ToString(); // e.Node.Text;

                // populate children.
                PopulateBranch((NodeId)reference.NodeId, e.Node.Nodes);

                boxBrowsePath.Text = e.Node.FullPath;

            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Ensures the correct node is selected before displaying the context menu.
        /// </summary>
        private void BrowseNodesTV_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                BrowseNodesTV.SelectedNode = BrowseNodesTV.GetNodeAt(e.X, e.Y);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Handles the Click event of the Browse_MonitorMI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Browse_MonitorMI_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (m_session == null || BrowseNodesTV.SelectedNode == null)
                {
                    return;
                }

                // can only subscribe to local variables. 
                ReferenceDescription reference = (ReferenceDescription)BrowseNodesTV.SelectedNode.Tag;

                if (reference.NodeId.IsAbsolute || reference.NodeClass != NodeClass.Variable)
                {
                    return;
                }

                ListViewItem item = CreateMonitoredItem((NodeId)reference.NodeId, Utils.Format("{0}", reference));

                m_subscription.ApplyChanges();

                MonitoredItem monitoredItem = (MonitoredItem)item.Tag;

                if (ServiceResult.IsBad(monitoredItem.Status.Error))
                {
                    item.SubItems[8].Text = monitoredItem.Status.Error.StatusCode.ToString();
                }

                //item.SubItems.Add(monitoredItem.DisplayName);
                //item.SubItems[2].Text = monitoredItem.MonitoringMode.ToString();
                //item.SubItems[3].Text = monitoredItem.SamplingInterval.ToString();
                //item.SubItems[4].Text = DeadbandFilterToText(monitoredItem.Filter);

                
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Creates the monitored item.
        /// </summary>
        private ListViewItem CreateMonitoredItem(NodeId nodeId, string displayName)
        {
            if (m_subscription == null)
            {
                m_subscription = new Subscription(m_session.DefaultSubscription);

                m_subscription.PublishingEnabled = true;
                m_subscription.PublishingInterval = 1000;
                m_subscription.KeepAliveCount = 10;
                m_subscription.LifetimeCount = 10;
                m_subscription.MaxNotificationsPerPublish = 1000;
                m_subscription.Priority = 100;

                m_session.AddSubscription(m_subscription);

                m_subscription.Create();
            }

            // add the new monitored item.
            MonitoredItem monitoredItem = new MonitoredItem(m_subscription.DefaultItem);

            monitoredItem.StartNodeId = nodeId;
            monitoredItem.AttributeId = Attributes.Value;
            monitoredItem.DisplayName = displayName;
            monitoredItem.MonitoringMode = MonitoringMode.Reporting;
            monitoredItem.SamplingInterval = 1000;
            monitoredItem.QueueSize = 0;
            monitoredItem.DiscardOldest = true;

            monitoredItem.Notification += m_MonitoredItem_Notification;

            

            // add the attribute name/value to the list view.
            ListViewItem item = new ListViewItem(monitoredItem.ClientHandle.ToString());
            monitoredItem.Handle = item;

            item.SubItems.Add(monitoredItem.DisplayName);
            item.SubItems.Add(monitoredItem.MonitoringMode.ToString());
            item.SubItems.Add(monitoredItem.SamplingInterval.ToString());
            item.SubItems.Add(DeadbandFilterToText(monitoredItem.Filter));
            item.SubItems.Add(String.Empty);
            item.SubItems.Add(String.Empty);
            item.SubItems.Add(String.Empty);
            item.SubItems.Add(String.Empty);

            item.Tag = monitoredItem;
            MonitoredItemsLV.Items.Add(item);

            

            MonitoredItemsLV.Columns[0].Width = -2;
            MonitoredItemsLV.Columns[1].Width = -2;
            MonitoredItemsLV.Columns[8].Width = -2;

            
            m_subscription.AddItem(monitoredItem);
            if (ServiceResult.IsBad(monitoredItem.Status.Error))
            {
                item.SubItems[8].Text = monitoredItem.Status.Error.StatusCode.ToString();
            }

            return item;
        }


        /// <summary>
        /// Prompts the use to write the value of a varible.
        /// </summary>
        private void Browse_WriteMI_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (m_session == null || BrowseNodesTV.SelectedNode == null)
                {
                    return;
                }

                // can only subscribe to local variables. 
                ReferenceDescription reference = (ReferenceDescription)BrowseNodesTV.SelectedNode.Tag;

                if (reference.NodeId.IsAbsolute || reference.NodeClass != NodeClass.Variable)
                {
                    return;
                }

                new WriteValueDlg().ShowDialog(m_session, (NodeId)reference.NodeId, Attributes.Value);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Handles the Click event of the Browse_ReadHistoryMI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Browse_ReadHistoryMI_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (m_session == null || BrowseNodesTV.SelectedNode == null)
                {
                    return;
                }

                // can only subscribe to local variables. 
                ReferenceDescription reference = (ReferenceDescription)BrowseNodesTV.SelectedNode.Tag;

                if (reference.NodeId.IsAbsolute || reference.NodeClass != NodeClass.Variable)
                {
                    return;
                }

                new ReadHistoryDlg().ShowDialog(m_session, (NodeId)reference.NodeId);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Updates the display with a new value for a monitored variable. 
        /// </summary>
        private void MonitoredItem_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MonitoredItemNotificationEventHandler(MonitoredItem_Notification), monitoredItem,
                    e);
                return;
            }

            try
            {
                if (m_session == null)
                {
                    return;
                }

                MonitoredItemNotification notification = e.NotificationValue as MonitoredItemNotification;

                if (notification == null)
                {
                    return;
                }

                ListViewItem item = (ListViewItem)monitoredItem.Handle;

                item.SubItems[5].Text = Utils.Format("{0}", notification.Value.WrappedValue);
                item.SubItems[6].Text = Utils.Format("{0}", notification.Value.StatusCode);
                item.SubItems[7].Text =
                    Utils.Format("{0:HH:mm:ss.fff}", notification.Value.SourceTimestamp.ToLocalTime());
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Changes the monitoring mode for the currently selected monitored items.
        /// </summary>
        private void Monitoring_MonitoringMode_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (m_session == null || m_subscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                // determine the monitoring mode being requested.
                MonitoringMode monitoringMode = MonitoringMode.Disabled;

                if (sender == Monitoring_MonitoringMode_ReportingMI)
                {
                    monitoringMode = MonitoringMode.Reporting;
                }

                if (sender == Monitoring_MonitoringMode_SamplingMI)
                {
                    monitoringMode = MonitoringMode.Sampling;
                }

                // update the monitoring mode.
                List<MonitoredItem> itemsToChange = new List<MonitoredItem>();

                for (int ii = 0; ii < MonitoredItemsLV.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        itemsToChange.Add(monitoredItem);
                    }
                }

                // apply the changes to the server.
                m_subscription.SetMonitoringMode(monitoringMode, itemsToChange);

                // update the display.
                for (int ii = 0; ii < itemsToChange.Count; ii++)
                {
                    ListViewItem item = itemsToChange[ii].Handle as ListViewItem;

                    if (item != null)
                    {
                        item.SubItems[8].Text = String.Empty;

                        if (ServiceResult.IsBad(itemsToChange[ii].Status.Error))
                        {
                            item.SubItems[8].Text = itemsToChange[ii].Status.Error.StatusCode.ToString();
                        }

                        item.SubItems[2].Text = itemsToChange[ii].Status.MonitoringMode.ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Changes the sampling interval for the currently selected monitored items.
        /// </summary>
        private void Monitoring_SamplingInterval_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (m_session == null || m_subscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                // determine the sampling interval being requested.
                double samplingInterval = 0;

                if (sender == Monitoring_SamplingInterval_1000MI)
                {
                    samplingInterval = 1000;
                }
                else if (sender == Monitoring_SamplingInterval_2500MI)
                {
                    samplingInterval = 2500;
                }
                else if (sender == Monitoring_SamplingInterval_5000MI)
                {
                    samplingInterval = 5000;
                }

                // update the monitoring mode.
                List<MonitoredItem> itemsToChange = new List<MonitoredItem>();

                for (int ii = 0; ii < MonitoredItemsLV.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        monitoredItem.SamplingInterval = (int)samplingInterval;
                        itemsToChange.Add(monitoredItem);
                    }
                }

                // apply the changes to the server.
                m_subscription.ApplyChanges();

                // update the display.
                for (int ii = 0; ii < itemsToChange.Count; ii++)
                {
                    ListViewItem item = itemsToChange[ii].Handle as ListViewItem;

                    if (item != null)
                    {
                        item.SubItems[8].Text = String.Empty;

                        if (ServiceResult.IsBad(itemsToChange[ii].Status.Error))
                        {
                            item.SubItems[8].Text = itemsToChange[ii].Status.Error.StatusCode.ToString();
                        }

                        item.SubItems[3].Text = itemsToChange[ii].Status.SamplingInterval.ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Changes the deadband for the currently selected monitored items.
        /// </summary>
        private void Monitoring_Deadband_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (m_session == null || m_subscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                // determine the filter being requested.
                DataChangeFilter filter = new DataChangeFilter();
                filter.Trigger = DataChangeTrigger.StatusValue;

                if (sender == Monitoring_Deadband_Absolute_5MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Absolute;
                    filter.DeadbandValue = 5.0;
                }
                else if (sender == Monitoring_Deadband_Absolute_10MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Absolute;
                    filter.DeadbandValue = 10.0;
                }
                else if (sender == Monitoring_Deadband_Absolute_25MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Absolute;
                    filter.DeadbandValue = 25.0;
                }
                else if (sender == Monitoring_Deadband_Percentage_1MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Percent;
                    filter.DeadbandValue = 1.0;
                }
                else if (sender == Monitoring_Deadband_Percentage_5MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Percent;
                    filter.DeadbandValue = 5.0;
                }
                else if (sender == Monitoring_Deadband_Percentage_10MI)
                {
                    filter.DeadbandType = (uint)DeadbandType.Percent;
                    filter.DeadbandValue = 10.0;
                }
                else
                {
                    filter = null;
                }

                // update the monitoring mode.
                List<MonitoredItem> itemsToChange = new List<MonitoredItem>();

                for (int ii = 0; ii < MonitoredItemsLV.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        monitoredItem.Filter = filter;
                        itemsToChange.Add(monitoredItem);
                    }
                }

                // apply the changes to the server.
                m_subscription.ApplyChanges();

                // update the display.
                for (int ii = 0; ii < itemsToChange.Count; ii++)
                {
                    ListViewItem item = itemsToChange[ii].Handle as ListViewItem;

                    if (item != null)
                    {
                        item.SubItems[8].Text = String.Empty;

                        if (ServiceResult.IsBad(itemsToChange[ii].Status.Error))
                        {
                            itemsToChange[ii].Filter = null;
                            item.SubItems[8].Text = itemsToChange[ii].Status.Error.StatusCode.ToString();
                        }

                        item.SubItems[4].Text = DeadbandFilterToText(itemsToChange[ii].Status.Filter);
                    }
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Handles the Click event of the Monitoring_DeleteMI control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Monitoring_DeleteMI_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                // collect the items to delete.
                List<ListViewItem> itemsToDelete = new List<ListViewItem>();

                for (int ii = 0; ii < MonitoredItemsLV.SelectedItems.Count; ii++)
                {
                    MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[ii].Tag as MonitoredItem;

                    if (monitoredItem != null)
                    {
                        monitoredItem.Notification -= m_MonitoredItem_Notification;
                        itemsToDelete.Add(MonitoredItemsLV.SelectedItems[ii]);

                        if (m_subscription != null)
                        {
                            m_subscription.RemoveItem(monitoredItem);
                        }
                    }
                }

                // update the server.
                if (m_subscription != null)
                {
                    m_subscription.ApplyChanges();

                    // check the status.
                    for (int ii = 0; ii < itemsToDelete.Count; ii++)
                    {
                        MonitoredItem monitoredItem = itemsToDelete[ii].Tag as MonitoredItem;

                        if (ServiceResult.IsBad(monitoredItem.Status.Error))
                        {
                            itemsToDelete[ii].SubItems[8].Text = monitoredItem.Status.Error.StatusCode.ToString();
                            continue;
                        }
                    }
                }

                // remove the items.
                for (int ii = 0; ii < itemsToDelete.Count; ii++)
                {
                    itemsToDelete[ii].Remove();
                }

                MonitoredItemsLV.Columns[0].Width = -2;
                MonitoredItemsLV.Columns[1].Width = -2;
                MonitoredItemsLV.Columns[8].Width = -2;
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        private void BrowsingMenu_Opening(object sender, CancelEventArgs e)
        {
            Browse_MonitorMI.Enabled = true;
            Browse_ReadHistoryMI.Enabled = true;
            Browse_WriteMI.Enabled = true;

            if (m_session == null || BrowseNodesTV.SelectedNode == null)
            {
                Browse_MonitorMI.Enabled = false;
                Browse_ReadHistoryMI.Enabled = false;
                Browse_WriteMI.Enabled = false;
                return;
            }

            ReferenceDescription reference = (ReferenceDescription)BrowseNodesTV.SelectedNode.Tag;

            if (reference.NodeId.IsAbsolute || reference.NodeClass != NodeClass.Variable)
            {
                Browse_MonitorMI.Enabled = false;
                Browse_ReadHistoryMI.Enabled = false;
                Browse_WriteMI.Enabled = false;
                return;
            }
        }


        private void Monitoring_WriteMI_Click(object sender, EventArgs e)
        {
            try
            {
                // check if operation is currently allowed.
                if (m_session == null || m_subscription == null || MonitoredItemsLV.SelectedItems.Count == 0)
                {
                    return;
                }

                MonitoredItem monitoredItem = MonitoredItemsLV.SelectedItems[0].Tag as MonitoredItem;

                if (monitoredItem != null)
                {
                    new WriteValueDlg().ShowDialog(m_session, (NodeId)monitoredItem.ResolvedNodeId, Attributes.Value);
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Creates monitored items from a saved list of node ids.
        /// </summary>
        private void File_LoadMI_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Saves the current monitored items.
        /// </summary>
        private void File_SaveMI_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        /// <summary>
        /// Sets the locale to use.
        /// </summary>
        private void Server_SetLocaleMI_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_session == null)
                {
                    return;
                }

                string locale = new SelectLocaleDlg().ShowDialog(m_session);

                if (locale == null)
                {
                    return;
                }

                ConnectServerCTRL.PreferredLocales = new string[] {locale};
                m_session.ChangePreferredLocales(new StringCollection(ConnectServerCTRL.PreferredLocales));
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        private void Server_SetUserMI_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //if (MessageBox.Show("Exit the application?", "UA Sample Client", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            //{
            //}
        }


        private void labelServerName_MouseClick(object sender, MouseEventArgs e)
        {
            BrowseNodesTV.SelectedNode = null;
            boxNodeName.Text = DEFAULT_OBJECTS_NAME;
            if (m_session != null)
                PopulateBranch(ObjectIds.ObjectsFolder, BrowseNodesTV.Nodes);
        }


        

        #endregion


        #region Saving Address Space Info

        private bool alreadySaving;


        private void saveAddressSpaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var (filterIndex, fileName) = ShowSaveFileDialog();

            switch (filterIndex)
            {
                case 1:
                    SaveAddressSpaceAsJson(ObjectIds.ObjectsFolder, "", fileName);
                    break;
                case 2:
                    SaveAddressSpaceAsList(null, "", fileName);
                    break;
            }
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var treeNode = BrowseNodesTV.SelectedNode;
            var reference = treeNode.Tag as ReferenceDescription;
            if (reference == null || reference.NodeId.IsAbsolute)
            {
                return;
            }

            var nodeId = (NodeId)reference.NodeId;
            if (nodeId == null || alreadySaving)
                return;

            var (filterIndex, fileName) = ShowSaveFileDialog();
            switch (filterIndex)
            {
                case 1:
                    SaveAddressSpaceAsJson(nodeId, treeNode.FullPath, fileName);
                    break;
                case 2:
                    SaveAddressSpaceAsList(treeNode, treeNode.FullPath, fileName);
                    break;
            }
        }


        private (int, string) ShowSaveFileDialog()
        {
            var dlg = new SaveFileDialog {
                DefaultExt = ".json",
                Filter = "JSON Files (*.json)|*.json|List of Children (*.csv)|*.csv",
                AddExtension = true,
                Title = "Save Address Space Objects As",
                OverwritePrompt = true,
            };

            var serverUrl = ConnectServerCTRL.ServerUrl.Substring(10);
            dlg.FileName = serverUrl.Replace("/", "-")
                .Replace(":", "-");

            if (dlg.ShowDialog() != DialogResult.OK)
                return (-1, null);
            return (dlg.FilterIndex, dlg.FileName);
        }


        private void SaveAddressSpaceObjects(NodeId nodeId, string nodePath, string fileName)
        {
            SaveAddressSpaceAsJson(nodeId, nodePath, fileName);
        }


        private void SaveAddressSpaceAsList(TreeNode node, string nodePath, string fileName)
        {
            void ProcessTreeNodes(IList nodesList, StringBuilder sb)
            {
                if (nodesList == null || nodesList.Count == 0)
                    return;

                foreach (TreeNode treeNode in nodesList)
                {
                    var reference = treeNode.Tag as ReferenceDescription;
                    if (reference == null)
                        continue;
                    sb.AppendLine($"{reference.DisplayName},{reference.NodeId.ToString()},{treeNode.FullPath}");
                    ProcessTreeNodes(treeNode.Nodes, sb);
                }
            }

            IList treeNodes = node == null ? BrowseNodesTV.Nodes : node.Nodes;

            var oldCursor = Cursor.Current;
            saveProgressBar.Visible = true;
            alreadySaving = true;
            Application.DoEvents();
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var sb = new StringBuilder();
                sb.AppendLine($"DisplayName,OPCNodeId,NodePath");
                ProcessTreeNodes(treeNodes, sb);
                File.WriteAllText(fileName, sb.ToString());

                StatusBar.Text = $"Address space nodes saved to {fileName}";
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
            }
            finally
            {
                saveProgressBar.Visible = false;
                Cursor.Current = oldCursor;
                alreadySaving = false;
            }
        }


        private void SaveAddressSpaceAsJson(NodeId nodeId, string path, string fileName)
        {
            var oldCursor = Cursor.Current;
            saveProgressBar.Visible = true;
            alreadySaving = true;
            Application.DoEvents();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var space = new OpcAddressSpaceInfo(m_session)
                    .Populate(nodeId, path, (o) => Application.DoEvents());


                var txt = JsonConvert.SerializeObject(space, Formatting.Indented);
                File.WriteAllText(fileName, txt);

                StatusBar.Text = $"Address space nodes saved to {fileName}";
            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
            }
            finally
            {
                saveProgressBar.Visible = false;
                Cursor.Current = oldCursor;
                alreadySaving = false;
            }
        }

        #endregion

        private void BrowseNodesTV_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {

        }
    }
}
