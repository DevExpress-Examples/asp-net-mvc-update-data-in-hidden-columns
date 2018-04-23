# GridView - How to implement data editing with hidden column


<p><strong>Problem:</strong></p>
<p>I need to hide some columns in the GridView because they are utilized for internal purpose (e.g., rowversion column). At the same time, it is necessary to have these column values in the update action method specified via the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcMVCxGridViewEditingSettings_UpdateRowRouteValuestopic"><u>MVCxGridViewEditingSettings.UpdateRowRouteValues Property</u></a>. Currently, the corresponding values are empty.</p>
<p><strong>Solution:</strong></p>
<p>This issue occurs because the generated HTML does not contain INPUT fields that correspond to hidden columns. For this reason, when data is posted to the server, the corresponding model fields are left empty (the model binding mechanism cannot find appropriate values for these fields). To solve this problem, you can use the approach from the <a href="http://documentation.devexpress.com/#AspNet/CustomDocument9941"><u>Passing Values to Controller Action Through Callbacks</u></a> help section to forcibly pass the required values to the update action method. In addition to the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMVCScriptsMVCxClientGridView_BeginCallbacktopic"><u>MVCxClientGridView.BeginCallback Event</u></a>, you need to handle the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewSettings_CustomJSPropertiestopic"><u>GridViewSettings.CustomJSProperties Event</u></a> to pass the currently edited row values to the client side.<br /><br /><strong>Note:</strong></p>
<p>If it is OK for you to show the caption and editor of the hidden column in the Edit Form, you can use a much simpler solution. Just set the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewGridColumnEditFormSettings_Visibletopic">GridColumnEditFormSettings.Visible</a> property to true. This approach might be useful when you are hiding columns via the <a href="https://documentation.devexpress.com/#AspNet/CustomDocument16878">Customization Window</a>.</p>

<br/>


