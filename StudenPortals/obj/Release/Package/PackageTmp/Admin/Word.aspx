<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Word.aspx.cs" Inherits="StudenPortals.Admin.WebForm1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Download Word File</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet" />
    <style>
        <style >
        body {
            background-image: url('https://www.example.com/path/to/your/background-image.jpg');
            background-size: cover;
            background-position: center;
            background-attachment: fixed;
            font-family: 'Roboto', sans-serif;
        }

        .container {
            max-width: 600px;
            margin-top: 100px;
            text-align: center;
            color: black;
        }

        .btn-custom {
            background-color: #0078d4;
            color: white;
            border-radius: 5px;
            padding: 15px 25px;
            font-size: 18px;
            transition: background-color 0.3s ease;
        }

            .btn-custom:hover {
                background-color: #005a9e;
            }

            .btn-custom:focus {
                outline: none;
            }

        .logo {
            width: 130px;
            height: 130px;
            margin-bottom: 30px;
        }

        .content-box {
            /*background-color: rgba(0, 0, 0, 0.7);*/
            background-color: white;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 8px 15px rgba(0, 0, 0, 0.9);
        }

            .content-box h2 {
                font-size: 24px;
                margin-bottom: 30px;
            }

        .row {
            margin-top: 20px;
        }

        @media (max-width: 576px) {
            .container {
                margin-top: 50px;
                padding: 10px;
            }

            .btn-custom {
                width: 100%;
                font-size: 16px;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="content-box">
             <img src="../img/word.jpeg" alt="Microsoft Word Logo" class="logo" style="width: 140px; height: 140px;"" />
                <h2>Click To Download Word File</h2>
                <asp:Button ID="btnSearchby" runat="server" Text="Download" OnClick="btnSearchby_Click" CssClass="btn-custom" />
            </div>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="row mt-4">
                <div class="col-lg-12">
                    <rsweb:reportviewer id="ReportViewer1" runat="server" height="0%" width="0%"></rsweb:reportviewer>
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
