<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128550278/14.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5121)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Sample/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Sample/Controllers/HomeController.vb))
* [Person.cs](./CS/Sample/Models/Person.cs) (VB: [Person.vb](./VB/Sample/Models/Person.vb))
* [PersonsList.cs](./CS/Sample/Models/PersonsList.cs) (VB: [PersonsList.vb](./VB/Sample/Models/PersonsList.vb))
* [GridViewEditingPartial.cshtml](./CS/Sample/Views/Home/GridViewEditingPartial.cshtml)
* [Index.cshtml](./CS/Sample/Views/Home/Index.cshtml)
<!-- default file list end -->
# GridView - How to implement data editing with hidden column
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e5121/)**
<!-- run online end -->


<p><strong>Problem:</strong></p>
<p>I need to hide some columns in the GridView because they are utilized for internal purpose (e.g., rowversion column). At the same time, it is necessary to have these column values in the update action method specified via the <a href="https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.MVCxGridViewEditingSettings.UpdateRowRouteValues"><u>MVCxGridViewEditingSettings.UpdateRowRouteValues Property</u></a>. Currently, the corresponding values are empty.</p>
<p><strong>Solution:</strong></p>
<p>This issue occurs because the generated HTML does not contain INPUT fields that correspond to hidden columns. For this reason, when data is posted to the server, the corresponding model fields are left empty (the model binding mechanism cannot find appropriate values for these fields). To solve this problem, you can use the approach from the <a href="http://documentation.devexpress.com/#AspNet/CustomDocument9941"><u>Passing Values to Controller Action Through Callbacks</u></a> help section to forcibly pass the required values to the update action method. In addition to the <a href="https://docs.devexpress.com/AspNetMvc/js-MVCxClientGridView.BeginCallback"><u>MVCxClientGridView.BeginCallback Event</u></a>, you need to handle the <a href="https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GridViewSettings.CustomJSProperties"><u>GridViewSettings.CustomJSProperties Event</u></a> to pass the currently edited row values to the client side.<br /><br /><strong>Note:</strong></p>
<p>If it is OK for you to show the caption and editor of the hidden column in the Edit Form, you can use a much simpler solution. Just set the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewGridColumnEditFormSettings_Visibletopic">GridColumnEditFormSettings.Visible</a> property to true. This approach might be useful when you are hiding columns via the <a href="https://documentation.devexpress.com/#AspNet/CustomDocument16878">Customization Window</a>.</p>

<br/>


