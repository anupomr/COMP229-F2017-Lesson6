<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="COMP229_F2017_Lesson6.StudentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1> Student Details</h1>
                <h5> All fields are  required</h5>
                <br/>
                <div class="form-group">
                    <label class="control-label" for="LastNameTextbox"> Last Name   </label> 
                    <asp:TextBox runat="server" CssClass="form-control" ID="LastNameTextBox"
                        placeholder="Last Name" required="true">                   

                    </asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="control-label" for="FirstNameTextbox"> First Name   </label> 
                    <asp:TextBox runat="server" CssClass="form-control" ID="FirstNameTextbox"
                        placeholder="First Name" required="true">  </asp:TextBox>
                </div>

                 <div class="form-group">
                    <label class="control-label" for="EnrollmentDateTextbox"> Enrollment Date   </label> 
                    <asp:TextBox runat="server" CssClass="form-control" ID="EnrollmentDateTextbox"
                        placeholder="Enrollment Date " required="true" TextMode="Date">    </asp:TextBox>
                </div>

                <div class="text-right">
                    <asp:Button Text="cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" 
                         UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click"/>
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server"
                        onClick="SaveButton_Click" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
