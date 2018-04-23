@ModelType List (Of Sample.Models.Person)

@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "grid"
            settings.KeyFieldName = "PersonID"
            settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewEditingPartial"}

            settings.SettingsEditing.Mode = GridViewEditingMode.EditFormAndDisplayRow
            settings.SettingsEditing.AddNewRowRouteValues = New With {Key .Controller = "Home", Key .Action = "EditingAddNew"}
            settings.SettingsEditing.UpdateRowRouteValues = New With {Key .Controller = "Home", Key .Action = "EditingUpdate"}
            settings.SettingsEditing.DeleteRowRouteValues = New With {Key .Controller = "Home", Key .Action = "EditingDelete"}

            settings.CommandColumn.Visible = True
            settings.CommandColumn.ShowNewButton = True
            settings.CommandColumn.ShowDeleteButton = True
            settings.CommandColumn.ShowEditButton = True

            settings.Columns.Add("FirstName")
            'settings.Columns.Add("MiddleName")
            settings.Columns.Add("LastName")

            settings.CustomJSProperties = _
                Sub(sender, e)
                        Dim gridView As MVCxGridView = CType(sender, MVCxGridView)
                        If gridView.EditingRowVisibleIndex > -1 Then
                            e.Properties("cpMiddleName") = gridView.GetRowValues(gridView.EditingRowVisibleIndex, "MiddleName")
                        End If
                End Sub

            settings.ClientSideEvents.BeginCallback = "function(s, e) { if(s.cpMiddleName) e.customArgs['MiddleName'] =  s.cpMiddleName; }"
    End Sub).Bind(Model).GetHtml()