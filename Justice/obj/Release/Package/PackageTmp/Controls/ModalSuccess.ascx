<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModalSuccess.ascx.cs" Inherits="Justice.ModalSuccess" %>

<div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">

        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Xəbərdarlıq</h4>
            </div>
            <div class="modal-body">
                <asp:Label runat="server" ID="modalLabel"></asp:Label>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-default" data-dismiss="modal" Text="Pəncərəni Bağla" CausesValidation="false"></asp:Button>
                <asp:HyperLink runat="server" ID="hlInformation" CssClass="btn btn-primary" Text="Şəxsi Məlumatlarım" CausesValidation="false" NavigateUrl="~/şəxsi-məlumatlar" Visible="false"></asp:HyperLink>
                <asp:HyperLink runat="server" ID="hlPurchase" CssClass="btn btn-primary" Text="Səbətim" CausesValidation="false" NavigateUrl="~/səbət" Visible="false"></asp:HyperLink>
                <asp:HyperLink runat="server" ID="hlLogin" CssClass="btn btn-primary" Text="Login" CausesValidation="false" NavigateUrl="~/login" Visible="false"></asp:HyperLink>
                <asp:HyperLink runat="server" ID="hlIndex" CssClass="btn btn-primary" Text="Ana Səhifəyə Get" CausesValidation="false" NavigateUrl="~/ana-səhifə" Visible="false"></asp:HyperLink>
            </div>
        </div>

    </div>
</div>
