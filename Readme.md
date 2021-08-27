<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128603216/11.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3169)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsApplication54/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication54/Form1.vb))
* [Person.cs](./CS/WindowsApplication54/Person.cs) (VB: [Person.vb](./VB/WindowsApplication54/Person.vb))
<!-- default file list end -->
# How to serialize an XPO data source


<p>This example demonstrates the capability to save and load a report's definition to XML format.</p><p>To do this, override the <strong>ReportStorageExtension</strong> class, and use the <strong>XtraReport.SaveLayoutToXml()</strong> method. And, you can use an opposite <strong>SaveLayoutToXml()</strong> method, to de-serialize an XML report  from a file or stream.</p><p>In addition, it is required to register a custom ReportDesignExtension, which implements the data source serialization functionality.</p><p>To see how this feature is implemented in this example, run the End-User Designer, and create a report bound to an XPO data source. Save the report to a file, and then restore the file, to see its bindings restored.</p><p>See also: <a href="https://www.devexpress.com/Support/Center/p/E3157">How to implement custom XML serialization of a report that is bound to a dataset</a> <br />
</p>

<br/>


