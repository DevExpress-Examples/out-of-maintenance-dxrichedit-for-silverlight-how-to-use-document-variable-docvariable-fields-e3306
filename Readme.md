# DXRichEdit for Silverlight: How to use document variable (DOCVARIABLE) fields


<p>This example illustrates the use of a <strong>DOCVARIABLE </strong>field to provide additional information which is dependent on the value of a merged field. This technique is implemented so each merged document contains geocoordinates and a weather conditions for a location that corresponds to the current data record.<br />
Coordinates and weather conditions are obtained from the corresponding data lists in the application, and not from Google, because Silverlight security includes cross-domain networking restrictions.</p><p>The location is represented by a merge field. It is included as an argument within the DOCVARIABLE field. When the DOCVARIABLE field is updated, the <strong>DevExpress.XtraRichEdit.API.Native.Document.CalculateDocumentVariable</strong> event is triggered. A code within the event handler obtains the information on geocoordinates and weather. It uses <u>e.VariableName</u> to get the name of the variable within the field, <u>e.Arguments</u> to get the location and returns the calculated result in <u>e.Value</u> property.<br />
The <strong>MailMergeRecordStarted</strong> event is handled to insert a hidden text indicating when the document is created. To display hidden text and all non-printing characters, use the CTRL-SHIFT-8 key combination.</p><p><br />
</p><br />


<br/>


