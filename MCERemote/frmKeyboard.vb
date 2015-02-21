Imports System.Xml
Imports System.Windows.Forms
Imports System.IO

Public Class frmKeyboard

    Private Sub frmKeyboard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        sectionsList.Clear()
        sectionsDataGrid.Clear()
        actionsList.Clear()

        Me.Dispose()
    End Sub


    Private Sub frmKeyboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dgvKeyboard.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold)

        txtKey.Text = shareKey

        check_shareKey()

        configPath()

        txtKeyboard.Text = xmlKeyboard

        fillDataGrid()

    End Sub


    Private Sub check_shareKey()
        Dim index As Integer = Array.FindIndex(specialKeys, Function(s) s = shareKey)

        If Not index = -1 Then
            shareKey = specialKeysKodi(index)
        End If

    End Sub


    Private Sub configPath()
        Dim xmlConfig As String = appPath & "\config.xml"

        If File.Exists(xmlConfig) Then
            readConfigXML(xmlConfig)

        Else
            selectKeyboardPath()
            writeConfigXML(xmlConfig, xmlKeyboard)

            readConfigXML(xmlConfig)
        End If
    End Sub


    Private Sub fillDataGrid()
        dgvCmbActions.DataSource = actionsList

        If IsNumeric(shareKey) Then
            shareKey = numbersString(CInt(shareKey))
        End If

        searchInxml()

        If sectionsDataGrid.Count > 0 Then
            Me.dgvKeyboard.Rows.Add(sectionsDataGrid.Count)

            For row = 0 To sectionsDataGrid.Count - 1
                Me.dgvKeyboard.Rows(row).Cells(0).Value = sectionsDataGrid(row)

                If row < contFound Then
                    Me.dgvKeyboard.Rows(row).Cells(1).Value = actionsList(row + 1)
                    Me.dgvKeyboard.Rows(row).Cells(2).Value = fillXPath(2) & actionsList(row + 1) & "</" & shareKey.ToLower & ">"
                Else
                    Me.dgvKeyboard.Rows(row).Cells(1).Value = actionsList(0)
                    Me.dgvKeyboard.Rows(row).Cells(2).Value = "none"
                End If
            Next

        End If

    End Sub


    Private Function fillXPath(numCase As Integer) As String
        'case 1 xpath for searching in xml
        'case 2 xpath for dataviewgrid
        'case 3 xpath for save keyboard.xml
        'case 4 xpath for add a new node

        Dim xpath As String = ""

        Select Case numCase
            Case 1
                xpath = "//" & shareKey.ToLower
            Case 3
                xpath = shareKey.ToLower
        End Select

        Select Case numCase
            Case 1, 3
                If shareCTRL Or shareALT Or shareShift Or shareWindows Then
                    xpath = xpath & "[@mod='"
                Else
                    xpath = xpath & "[not(@*)]"
                End If

            Case 2
                xpath = "<" & shareKey.ToLower
                If shareCTRL Or shareALT Or shareShift Or shareWindows Then
                    xpath = xpath & " mod='"
                End If
        End Select


        If shareCTRL Or shareALT Or shareShift Or shareWindows Then
            If shareCTRL Then
                xpath = xpath & "ctrl,"
            End If

            If shareALT Then
                xpath = xpath & "alt,"
            End If

            If shareShift Then
                xpath = xpath & "shift,"
            End If

            If shareWindows Then
                xpath = xpath & "win"
            Else
                xpath = xpath.Remove(xpath.Length - 1)
            End If
        End If


        Select Case numCase
            Case 1, 3
                If shareCTRL Or shareALT Or shareShift Or shareWindows Then
                    xpath = xpath & "']"
                End If

            Case 2
                If shareCTRL Or shareALT Or shareShift Or shareWindows Then
                    xpath = xpath & "'>"
                Else
                    xpath = xpath & ">"
                End If
        End Select

        Return xpath
    End Function


    Private Sub searchInxml()
        Dim xpath As String = fillXPath(1)
        Dim posSection As Integer
        Dim fillSections As Integer

        Dim xmlDoc As New XmlDocument
        Try
            xmlDoc.Load(xmlKeyboard)

            Dim rootNode As XmlNode = xmlDoc.DocumentElement
            Dim searchNodeList As XmlNodeList = rootNode.SelectNodes(xpath)

            contFound = 0

            For Each node As XmlElement In searchNodeList
                foundInXml(node, posSection)
            Next

            fillSections = contFound

            For i = 0 To sectionsList.Count - 1
                sectionsDataGrid.Insert(fillSections, sectionsList(i))
                fillSections = fillSections + 1
            Next

        Catch ex As Exception
            MsgBox("Error in file:" & vbCr & xmlKeyboard & vbCr & ex.Message.ToString, MsgBoxStyle.Critical, "Error opening Keyboard.xml")
            Me.Dispose()
        End Try

    End Sub


    Private Sub foundInXml(node As XmlElement, posSection As Integer)

        posSection = sectionsList.IndexOf(node.ParentNode.ParentNode.Name)
        If Not posSection = -1 Then
            sectionsList.RemoveAt(posSection)
        End If

        sectionsDataGrid.Insert(contFound, node.ParentNode.ParentNode.Name)

        contFound = contFound + 1

        Dim posAction As Integer = actionsList.IndexOf(node.InnerText)
        If Not posAction = -1 Then
            actionsList.RemoveAt(posAction)
        End If

        actionsList.Insert(contFound, node.InnerText)

    End Sub


    Private Sub selectKeyboardPath()
        Dim FolderBrowserDialog1 = New FolderBrowserDialog
        Dim keyboardPath As String

        keyboardPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        keyboardPath = keyboardPath & "\kodi\userdata\keymaps"

        With FolderBrowserDialog1
            .Description = "Choose Keyboard.xml Folder"
            .SelectedPath = keyboardPath
        End With

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            xmlKeyboard = FolderBrowserDialog1.SelectedPath & "\keyboard.xml"

            If Not File.Exists(xmlKeyboard) Then
                createDefaultKeyboard(xmlKeyboard)
            End If

        Else
            Me.Dispose()
        End If

    End Sub


    Private Sub createDefaultKeyboard(xmlKeyboard As String)
        Dim addInfo = File.CreateText(xmlKeyboard)

        Using addInfo
            addInfo.WriteLine("<?xml version=""1.0"" encoding=""UTF-8""?>")
            addInfo.WriteLine("")
            addInfo.WriteLine("<keymap>")
            addInfo.WriteLine("</keymap>")
        End Using

    End Sub


    Private Sub readConfigXML(xmlConfig As String)
        Dim readKeyboardPath As String = ""
        Dim xmlDoc As New XmlDocument
        Dim nodeList As XmlNodeList
        Dim childXmlNode As XmlNode

        Try
            xmlDoc.Load(xmlConfig)
        Catch ex As Exception
            MsgBox("Error in config file:" & vbCr & xmlConfig & vbCr & ex.Message.ToString, vbCritical, "Error in config file")
            Me.Dispose()
        End Try

        nodeList = xmlDoc.GetElementsByTagName("keyboardPath")

        For Each child In nodeList
            readKeyboardPath = child.InnerText
        Next child


        childXmlNode = xmlDoc.SelectSingleNode("/config/Sections")

        If Not IsNothing(childXmlNode) Then
            For i = 0 To childXmlNode.ChildNodes.Count - 1
                sectionsList.Add(childXmlNode.ChildNodes.Item(i).InnerText)
            Next i
        End If


        childXmlNode = xmlDoc.SelectSingleNode("/config/Actions")

        If Not IsNothing(childXmlNode) Then
            For i = 0 To childXmlNode.ChildNodes.Count - 1
                actionsList.Add(childXmlNode.ChildNodes.Item(i).InnerText)
            Next i
        End If

        actionsList.Sort()
        actionsList.Insert(0, "none")

        Dim directoryName As String
        Try
            directoryName = Path.GetDirectoryName(readKeyboardPath)

            If Directory.Exists(directoryName) Then
                If File.Exists(readKeyboardPath) Then
                    xmlKeyboard = readKeyboardPath
                Else
                    createDefaultKeyboard(readKeyboardPath)
                End If
            Else
                Dim path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\keyboard.xml"

                Dim searchNode As String = "//keyboardPath"

                childXmlNode = xmlDoc.SelectSingleNode(searchNode)

                If Not IsNothing(childXmlNode) Then
                    For i = 0 To childXmlNode.ChildNodes.Count - 1
                        childXmlNode.ChildNodes.Item(i).InnerText = path
                    Next i
                End If

                xmlDoc.Save(xmlConfig)
                xmlKeyboard = path
                createDefaultKeyboard(path)
            End If

        Catch ex As Exception
            Dim path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\keyboard.xml"

            childXmlNode = xmlDoc.DocumentElement

            Dim nodeElement As XmlElement = xmlDoc.CreateElement("keyboardPath")
            nodeElement.InnerText = path

            childXmlNode.InsertBefore(nodeElement, childXmlNode.FirstChild)

            xmlDoc.Save(xmlConfig)
            xmlKeyboard = path
            createDefaultKeyboard(path)
        End Try

    End Sub


    Private Sub writeConfigXML(xmlConfig As String, xmlKeyboard As String)
        Dim settings As New XmlWriterSettings()
        settings.Indent = True

        Dim XmlWrt As XmlWriter = XmlWriter.Create(xmlConfig, settings)

        With XmlWrt
            .WriteStartDocument()
            .WriteComment("delete this file to regenerate it with default values")

            .WriteStartElement("config")

            .WriteComment("keyboard.xml path")
            .WriteStartElement("keyboardPath")
            .WriteString(xmlKeyboard)
            .WriteEndElement()


            Dim num As Integer = 1
            .WriteComment("Sections")
            .WriteStartElement("Sections")
            For Each value As String In sections
                .WriteStartElement("section_" & num.ToString)
                .WriteString(value)
                .WriteEndElement()
                num = num + 1
            Next
            .WriteEndElement()


            .WriteComment("Actions")
            .WriteStartElement("Actions")
            num = 1
            For Each value As String In actions
                .WriteStartElement("action_" & num.ToString)
                .WriteString(value)
                .WriteEndElement()
                num = num + 1
            Next
            .WriteEndElement()

            .WriteEndElement()

            .WriteEndDocument()
            .Close()
        End With

    End Sub


    Private Sub saveKeyboard(xmlKeyboard As String, section As String, action As String, before As String, type As Integer)
        'type 1 = add
        'type 2 = replace
        'type 3 = delete

        Dim xmlDoc As New XmlDocument

        Try
            xmlDoc.Load(xmlKeyboard)
        Catch ex As Exception
            MsgBox("Error in keyboard file:" & vbCr & xmlKeyboard & vbCr & ex.Message.ToString, vbCritical, "Error in keyboard file")
            Me.Dispose()
        End Try

        Select Case type
            Case 1 'add
                Dim xpath As String = "/keymap/" & section
                Dim rootNode As XmlNode = xmlDoc.DocumentElement
                Dim elem As XmlElement = xmlDoc.DocumentElement

                rootNode = elem.SelectSingleNode(xpath)

                If rootNode Is Nothing Then
                    xpath = "/keymap"
                    rootNode = elem.SelectSingleNode(xpath)
                    elem = xmlDoc.CreateElement(section)
                    rootNode.AppendChild(elem)

                    xpath = xpath & "/" & section
                    rootNode = elem.SelectSingleNode(xpath)
                    elem = xmlDoc.CreateElement("keyboard")
                    rootNode.AppendChild(elem)

                    xpath = xpath & "/keyboard"
                    rootNode = elem.SelectSingleNode(xpath)
                    elem = xmlDoc.CreateElement(shareKey.ToLower)
                    elem.InnerText = action
                    rootNode.AppendChild(elem)

                Else
                    xpath = xpath & "/keyboard"
                    rootNode = elem.SelectSingleNode(xpath)

                    If rootNode Is Nothing Then
                        rootNode = elem.SelectSingleNode(xpath)
                        elem = xmlDoc.CreateElement("keyboard")
                        rootNode.AppendChild(elem)
                    End If

                    rootNode = elem.SelectSingleNode(xpath)
                    elem = xmlDoc.CreateElement(shareKey.ToLower)
                    elem.InnerText = action
                    rootNode.AppendChild(elem)

                End If

                'add attribute
                Dim attribute As String = fillXPath(4)

                xpath = xpath & "/" & shareKey.ToLower

                If Not String.IsNullOrEmpty(attribute) Then
                    elem = elem.SelectSingleNode(xpath)
                    elem.SetAttribute("mod", attribute)
                End If


            Case 2, 3 'replace, delete
                Dim searchNode As String = "/keymap/" & section & "/keyboard/" & fillXPath(3)
                Dim searchNodeList As XmlNodeList = xmlDoc.SelectNodes(searchNode)
                Dim xpath As String = ""

                For Each node As XmlElement In searchNodeList
                    xpath = fillXPath(2)
                    xpath = xpath & node.InnerText & "</" & shareKey.ToLower & ">"

                    Select Case type
                        Case 2 'replace
                            If String.Equals(before, xpath) Then
                                node.InnerText = action
                            End If

                        Case 3 'delete
                            If String.Equals(before, xpath) Then
                                node.ParentNode.RemoveChild(node)
                            End If
                    End Select
                Next
        End Select

        xmlDoc.Save(xmlKeyboard)

    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If File.Exists(xmlKeyboard) Then
            Dim section As String
            Dim action As String
            Dim before As String
            Dim after As String

            For row As Integer = 0 To dgvKeyboard.RowCount - 1
                section = dgvKeyboard.Rows(row).Cells(0).Value
                action = dgvKeyboard.Rows(row).Cells(1).Value
                before = dgvKeyboard.Rows(row).Cells(2).Value
                after = dgvKeyboard.Rows(row).Cells(3).Value

                If Not after Is Nothing Then

                    If String.Equals(before, after) = False Then
                        If String.Equals(after, "none") Then
                            'remove from xml
                            saveKeyboard(xmlKeyboard, section, action, before, 3)

                        ElseIf String.Equals(before, "none") Then
                            'add to xml
                            saveKeyboard(xmlKeyboard, section, action, before, 1)

                        Else
                            'replace in xml
                            saveKeyboard(xmlKeyboard, section, action, before, 2)
                        End If

                    End If

                End If
            Next

        Else
            MsgBox("Keyboard xml file missing:" & vbCr & xmlKeyboard, vbCritical, "Keyboard.xml not found")
        End If

        Me.Dispose()
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub


    Private Sub dgvKeyboard_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvKeyboard.EditingControlShowing

        If dgvKeyboard.CurrentCell.ColumnIndex = 1 Then
            Dim combo As ComboBox = CType(e.Control, ComboBox)
            If (combo IsNot Nothing) Then
                RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionchangeCommitted)
                AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionchangeCommitted)
            End If
        End If
    End Sub


    Private Sub ComboBox_SelectionchangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim combo As ComboBox = CType(sender, ComboBox)

        If String.Equals(combo.SelectedValue, "none") = False Then
            dgvKeyboard.Rows(dgvKeyboard.CurrentRow.Index).Cells(3).Value = fillXPath(2) & combo.SelectedValue & "</" & shareKey.ToLower & ">"
        Else
            dgvKeyboard.Rows(dgvKeyboard.CurrentRow.Index).Cells(3).Value = "none"
        End If

        dgvKeyboard.Rows(dgvKeyboard.CurrentRow.Index).Cells(3).Style.BackColor = Color.Yellow

    End Sub


    Private Sub btnConfig_Click(sender As Object, e As EventArgs) Handles btnConfig.Click
        Dim xmlConfig As String = appPath & "\config.xml"

        If System.IO.File.Exists(xmlConfig) = True Then
            Process.Start(xmlConfig)
        End If

    End Sub


End Class