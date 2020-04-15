Imports System.Data.SqlClient

Public Class dataAccess

    Dim conString As String = My.Settings.conectionS

    Function GetMonthTask(dateT As Date) As List(Of Tarea)

        Dim tareaList As New List(Of Tarea)
        Dim query As String = "SELECT [Id]
                                      ,[Name]
                                      ,[FirstDay]
                                      ,[LastDay]
                                      ,[CreatedBy]
                                      ,[Done]
                                      ,[Priority]
                                       ,[Description]
                                  FROM [dbo].[Task] T
                                    where MONTH(T.FirstDay)= Month(@DateT) and YEAR(T.FirstDay)= YEAR(@DateT)"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@DateT", SqlDbType.Date).Value = dateT

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim tarea As New Tarea

                    tarea.Id = reader.GetInt32(0)
                    tarea.Name = reader.GetString(1)
                    tarea.FirstDay = reader.GetDateTime(2)
                    tarea.LastDay = reader.GetDateTime(3)
                    tarea.CreatedBy = reader.GetString(4)
                    tarea.Done = reader.GetBoolean(5)
                    tarea.Priority = reader.GetInt32(6)
                    If Not IsDBNull(reader(7)) Then
                        tarea.Description = reader.GetString(7)

                    End If


                    tareaList.Add(tarea)
                End While

                reader.Close()
                connection.Close()

            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return tareaList
    End Function

    Function GetTaskByClick(firstDay As Date, lastDay As Date, Name As String) As List(Of Tarea)

        Dim tareaList As New List(Of Tarea)
        Dim query As String = "SELECT [Id]
                                          ,[Name]
                                          ,[FirstDay]
                                          ,[LastDay]
                                          ,[CreatedBy]
                                          ,[Done]
                                          ,[Priority]
                                          ,[Description]
                                      FROM [dbo].[Task] T
                                       where t.FirstDay= @FirstDay and t.LastDay=@LastDay and T.Name=@Name"

        Using connection As New SqlConnection(conString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@FirstDay", SqlDbType.Date).Value = firstDay.Date.ToString("yyyy-MM-dd")
            command.Parameters.AddWithValue("@LastDay", SqlDbType.Date).Value = lastDay.Date.ToString("yyyy-MM-dd")
            command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = Name
          

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim tarea As New Tarea

                    tarea.Id = reader.GetInt32(0)
                    tarea.Name = reader.GetString(1)
                    tarea.FirstDay = reader.GetDateTime(2)
                    tarea.LastDay = reader.GetDateTime(3)
                    tarea.CreatedBy = reader.GetString(4)
                    tarea.Done = reader.GetBoolean(5)
                    tarea.Priority = reader.GetInt32(6)
                    If Not IsDBNull(reader(7)) Then
                        tarea.Description = reader.GetString(7)

                    End If


                    tareaList.Add(tarea)
                End While

                reader.Close()
                connection.Close()

            Catch ex As Exception
                Throw ex
            End Try
        End Using
        Return tareaList
    End Function


    Sub NewTask(ByVal name As String, ByVal firstDay As Date, ByVal lastDay As Date, ByVal createdBy As String, ByVal done As Boolean, ByVal priority As Integer, ByVal description As String)

        Dim query As String = "INSERT INTO [dbo].[Task]
                                                       ([Name]
                                                       ,[FirstDay]
                                                       ,[LastDay]
                                                       ,[CreatedBy]
                                                       ,[Done]
                                                       ,[Priority]
                                                        ,[Description])
                                                 VALUES
                                                       (@Name, @FirstDay, @LastDay, @CreatedBy, @Done, @Priority, @Description)"
        Using Connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, Connection)
                'command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = name
                command.Parameters.AddWithValue("@FirstDay", SqlDbType.Date).Value = firstDay
                command.Parameters.AddWithValue("@LastDay", SqlDbType.Date).Value = lastDay
                command.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = createdBy
                command.Parameters.AddWithValue("@Done", SqlDbType.Bit).Value = done
                command.Parameters.AddWithValue("@Priority", SqlDbType.Int).Value = priority
                command.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = description
                Try
                    Connection.Open()
                    command.ExecuteNonQuery()
                    Connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using

        End Using



    End Sub

    Sub UpdateTask(ByVal id As Integer, ByVal name As String, ByVal firstDay As Date, ByVal lastDay As Date, ByVal createdBy As String, ByVal done As Boolean, ByVal priority As Integer, ByVal description As String)

        Dim query As String = "Update  [dbo].[Task] SET
                                                      [Name]=@Name
                                                       ,[FirstDay]=@FirstDay
                                                       ,[LastDay]= @LastDay
                                                       ,[CreatedBy]= @CreatedBy
                                                       ,[Done]=@Done
                                                       ,[Priority]=@Priority
                                                        ,[Description]= @Description
                                                 WHERE [Id]=@Id"
        Using Connection As New SqlConnection(conString)
            Using command As New SqlCommand(query, Connection)
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id
                command.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = name
                command.Parameters.AddWithValue("@FirstDay", SqlDbType.Date).Value = firstDay
                command.Parameters.AddWithValue("@LastDay", SqlDbType.Date).Value = lastDay
                command.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = createdBy
                command.Parameters.AddWithValue("@Done", SqlDbType.Bit).Value = done
                command.Parameters.AddWithValue("@Priority", SqlDbType.Int).Value = priority
                command.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = description
                Try
                    Connection.Open()
                    command.ExecuteNonQuery()
                    Connection.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Using

        End Using



    End Sub

End Class


