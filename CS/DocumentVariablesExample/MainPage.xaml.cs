using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Reflection;
#region #usings
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit;
using DevExpress.Xpf.RichEdit;
using DevExpress.Services;
#endregion #usings

namespace DocumentVariablesExample
{
    public partial class MainPage : UserControl
    {
        RichEditControl richEdit;
        GeoLocationData glData;
        ConditionsData wData;

        public MainPage()
        {
            InitializeComponent();

        }

        private void richEditControl1_Loaded(object sender, RoutedEventArgs e)
        {
            richEditControl1.ApplyTemplate();
            richEditControl1.LoadDocument(GetDataStream("invitation.docx"), DocumentFormat.OpenXml);
            richEditControl1.Options.MailMerge.DataSource = new SampleData();
            richEditControl2.Document.CalculateDocumentVariable += new CalculateDocumentVariableEventHandler(eventHandler_CalculateDocumentVariable);
            this.richEdit = richEditControl1;
            glData = new GeoLocationData();
            wData = new ConditionsData();
            tabControl.SelectionChanged+=new DevExpress.Xpf.Core.TabControlSelectionChangedEventHandler(tabControl_SelectionChanged);

        }

        private void btnMailMerge_Click(object sender, RoutedEventArgs e) {
            MailMergeOptions myMergeOptions = richEditControl1.Document.CreateMailMergeOptions();
            myMergeOptions.MergeMode = MergeMode.NewSection;
            richEditControl1.Document.MailMerge(myMergeOptions, richEditControl2.Document);
            tabControl.SelectedIndex = 1;
        }

        #region #mailmergerecordstarted
        private void richEditControl1_MailMergeRecordStarted(object sender, MailMergeRecordStartedEventArgs e) {
            DocumentRange _range = e.RecordDocument.InsertText(e.RecordDocument.Range.Start,
String.Format("Created on {0:G}\n\n", DateTime.Now));
            CharacterProperties cp = e.RecordDocument.BeginUpdateCharacters(_range);
            cp.FontSize = 8;
            cp.ForeColor = Colors.Red;
            cp.Hidden = true;
            e.RecordDocument.EndUpdateCharacters(cp);
        }
        #endregion #mailmergerecordstarted

        #region #mailmergerecordfinished
        private void richEditControl1_MailMergeRecordFinished(object sender, MailMergeRecordFinishedEventArgs e) {
            e.RecordDocument.AppendDocumentContent(GetDataStream("bungalow.docx"), DocumentFormat.OpenXml);
        }
        #endregion #mailmergerecordfinished

        #region #calculatedocumentvariable
        void eventHandler_CalculateDocumentVariable(object sender, CalculateDocumentVariableEventArgs e) {
            string location = e.Arguments[0].Value.ToString();

            Console.WriteLine(e.VariableName + " " + location);

            if ((location.Trim() == String.Empty) || (location.Contains("<"))) {
                e.Value = " ";
                e.Handled = true;
                return;
            }

            switch (e.VariableName) {
                case "Weather":
                    Conditions conditions = Weather.GetCurrentConditions(location, wData);
                    e.Value = String.Format("Forecast for {0}: \nConditions: {1}\n",
                        conditions.City, conditions.Condition);
                    break;
                case "Location":
                    GeoLocation[] loc = GeoLocation.GeocodeAddress(location,glData);
                    e.Value = String.Format(" {0}\nLatitude: {1}\nLongitude: {2}\n",
                        loc[0].Address, loc[0].Latitude.ToString(), loc[0].Longitude.ToString());
                    break;
            }
            e.Handled = true;
        }
        #endregion #calculatedocumentvariable

        private void tabControl_SelectionChanged(object sender, DevExpress.Xpf.Core.TabControlSelectionChangedEventArgs e) {
            switch (tabControl.SelectedIndex) {
                case 0:
                    richEdit = richEditControl1;
                    this.btnMailMerge.IsEnabled = true;
                    break;
                case 1:
                    richEdit = richEditControl2;
                    this.btnMailMerge.IsEnabled = false;
                    break;
            }
        }

        private void chkShowCodes_Checked(object sender, RoutedEventArgs e) {
            ShowFieldCodes(true);
        }

        private void chkShowCodes_Unchecked(object sender, RoutedEventArgs e) {
            ShowFieldCodes(false);
        }

        void ShowFieldCodes(bool showCodes) {
            Document doc = richEdit.Document;
            doc.BeginUpdate();
            foreach (Field f in doc.Fields) f.ShowCodes = showCodes;
            doc.EndUpdate();
        }

        private Stream GetDataStream(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                return null;
            string path = "DocumentVariablesExample.Docs." + fileName;
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
        }


    }
}
