function hideModal(element) {
    var myModalEl = document.getElementById(element.id)
    var myModal = bootstrap.Modal.getInstance(myModalEl)
    myModal.hide()
};

function checkBoxes(boxes) {
    console.log('triggered checkBoxes');

    const triggerBottom = window.innerHeight / 6 * 5;

    boxes.forEach((box) => {
        const boxTop = box.getBoundingClientRect().top;

        if (boxTop < triggerBottom) {
            box.classList.add('show');
        } else {
            box.classList.remove('show');
        }
    })
}

export { hideModal, checkBoxes };