function hideModal(element) {
    var myModalEl = document.getElementById(element.id)
    var myModal = bootstrap.Modal.getInstance(myModalEl)
    myModal.hide()
};

export { hideModal };