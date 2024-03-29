﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace OLV
{
    public partial class SampleForm : Form
    {
        private List<Parameter> Parameters;
        private int SelectedIndex = -1;
        private bool PreventSwap = false;

        public SampleForm()
        {
            InitializeComponent();
        }

        private void SampleForm_Load(object sender, EventArgs e)
        {
            InitializeModel();
            InitializeObjectListView();
            propertyGrid.BrowsableAttributes = new AttributeCollection(new CategoryAttribute("User Parameters"));
        }

        private void InitializeModel()
        {
            Parameters = new List<Parameter>
            {
                new Parameter("Clean"),
                new Parameter("Simulation"),
                new Parameter("Source Align"),
                new Parameter("Pre-Print Metrology"),
                new Parameter("Target Align"),
                new Parameter("Post-Print Metrology"),
                new Parameter("Custom Start")
            };
        }

        public void InitializeObjectListView()
        {
            olvColumnParameter.AspectToStringConverter = delegate (object x) { return ""; };
            objectListView.SetObjects(Parameters);
        }

        private void ObjectListView_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Parameter parameter = (Parameter)e.Model;
                NamedDescriptionDecoration decoration = new NamedDescriptionDecoration
                {
                    ImageList = imageListLarge,
                    Title = parameter.ParameterName,
                    ImageName = parameter.ParameterIcon,
                    Description = parameter.Description
                };
                e.SubItem.Decoration = decoration;
            }
        }

        private void ObjectListView_SelectionChanged(object sender, EventArgs e)
        {
            if (PreventSwap)
            {
                PreventSwap = false;
                return;
            }
            lblActiveParameter.Text = ((Parameter)objectListView.SelectedObject).ParameterName;
            propertyGrid.SelectedObject = objectListView.SelectedObject;
            SelectedIndex = objectListView.SelectedIndex;
            SwapPanes(false);
        }

        private void PropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            objectListView.SetObjects(Parameters);
            objectListView.SelectedIndex = SelectedIndex;
            btnApply.BackColor = btnApply.FlatAppearance.MouseOverBackColor;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SwapPanes(true);
            PreventSwap = true;
            objectListView.DeselectAll();
        }

        private void SwapPanes(bool showOLV)
        {
            if (showOLV)
            {
                tableLayoutPanel.SetColumn(tableLayoutPanelGrid, 1);
                tableLayoutPanel.SetColumn(objectListView, 0);
            }
            else
            {
                tableLayoutPanel.SetColumn(objectListView, 2);
                tableLayoutPanel.SetColumn(tableLayoutPanelGrid, 0);
            }
        }
    }
}
