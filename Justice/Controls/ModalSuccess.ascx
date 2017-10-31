<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModalSuccess.ascx.cs" Inherits="Justice.ModalSuccess" %>

<div class="modal modal-success fade" id="modal-success">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Success Modal</h4>
            </div>
            <div class="modal-body">
                <asp:Label runat="server" ID="modalLabel" Text="YES!"></asp:Label>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-outline">Save changes</button>
            </div>
        </div>
    </div>
</div>
